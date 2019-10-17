using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Console025.MSSQL
{
  
  /// <summary>
  /// 使用 AD account 连接 MSSQL
  /// </summary>
  class C5
  {
    const int LOGON32_LOGON_INTERACTIVE = 2;
    const int LOGON32_LOGON_NETWORK = 3;
    const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

    const int LOGON32_PROVIDER_DEFAULT = 0;
    const int LOGON32_PROVIDER_WINNT50 = 3;

    public static void Execute()
    {
      // UseConnectString();
      // UseImpersonation();
      // UseSmo();
      UseSmoWithImpersonate();
      // LogonStatus();
    }

    // Will Success
    private static void UseImpersonation()
    {
      ImpersonateLogon((domain, username, password) => 
      {
        //string conn = @"Data Source=zothos.argonath.com;Initial Catalog=MASTER;Integrated Security=SSPI; User ID=ARGONATH\DB-MASTER;Password=Simple.0;";
        //string conn = @"Data Source=localhost\sql2016;Initial Catalog=MASTER;Integrated Security=True;";
        //string conn = @"Data Source=FV5DP.FV5.COM;Initial Catalog=MASTER;Integrated Security=True;";
        //string conn = @"Data Source=localhost;Initial Catalog=BDNA;user id=${USER};password=${PASSWORD};connect timeout=60;Integrated Security=True";
        string conn = GetConnection();
        using (SqlConnection cn = new SqlConnection(conn))
        {
          cn.Open();
          Console.WriteLine("OK for connect to MSSQL");
        }
      });
    }

    // Will Fault
    private static void UseConnectString()
    {
      //string conn = @"Data Source=zothos.argonath.com;Initial Catalog=MASTER;Integrated Security=SSPI; User ID=ARGONATH\DB-MASTER;Password=Simple.0;";
      string conn = GetConnection();
      using (SqlConnection cn = new SqlConnection(conn))
      {
        cn.Open();
        Console.WriteLine("OK for connect to MSSQL");
      }
    }

    // Do for interactive login
    private static void UseSmo()
    {
      ServerConnection sconn = new ServerConnection();
      sconn.LoginSecure = true;
      sconn.ConnectAsUser = false;
      sconn.ConnectAsUserName = "ARGONATH@DB-MASTER";
      sconn.ConnectAsUserPassword = "Simple.0";
      sconn.Login = @"ARGONATH\DB-MASTER";
      sconn.Password = "Simple.0";
      sconn.DatabaseName = "MASTER";
      sconn.ServerInstance = "zothos.argonath.com";
      sconn.Connect();

      Server server = new Server(sconn);
      Console.WriteLine(server.Information.Version);
    }

    // Do for non-interactive user
    private static void UseSmoWithImpersonate()
    {
      ImpersonateLogon((domain, username, password) => 
      {
        //string conn = @"Data Source=zothos.argonath.com; Initial Catalog=MASTER; Integrated Security=True;";
        string conn = GetConnection();
        SqlConnection cn = new SqlConnection(conn);
        {
          // cn.Open();
          // Console.WriteLine("OK for connect to MSSQL");
          ServerConnection sconn = new ServerConnection(cn);
          sconn.Connect();
          Console.WriteLine("OK for connect to MSSQL using ServerConnection. IsOpen: [{0}]", sconn.IsOpen);
          Server server = new Server(sconn);
          Console.WriteLine(server.Information.Version);
          /*string script = "";
          string ScriptFullName = @"C:\Jacky\Script-DP\mssql_CreateDatabase.sql";
          using (var sr = new StreamReader(ScriptFullName))
          {
            script = sr.ReadToEnd();
          }
          server.ConnectionContext.ExecuteNonQuery(script);
          Console.WriteLine("OK for executing script. [{0}]", ScriptFullName);*/
        }
      });
    }

    private static void LogonStatus()
    {
      Console.WriteLine("Before impersonation: [{0}]", WindowsIdentity.GetCurrent().Name);
      ImpersonateLogon((domain, username, password) => 
      {
        Console.WriteLine("After impersonation: [{0}]", WindowsIdentity.GetCurrent().Name);
        Console.WriteLine("=========Get SID using PrincipalContext==========");
        GetSid(domain, username);
      });
    }
    private static void GetSid(string domain, string username)
    {
      bool isLocalMachine = false;

      Console.WriteLine("domain = [{0}]", domain);
      isLocalMachine = IsLocalhost(domain);

      Console.WriteLine("isLocalMachine = [{0}]", isLocalMachine);
      PrincipalContext context = null;
      if (isLocalMachine)
      {
        context = new PrincipalContext(ContextType.Machine);
      }
      else
      {
        context = new PrincipalContext(ContextType.Domain, domain);
      }
        
      UserPrincipal user = UserPrincipal.FindByIdentity(context, username);
      string usid2 = string.Format("0x{0}", StringToHex(user.Sid.ToString()));
      Console.WriteLine("SID: [{0}], [{1}]", user.SamAccountName, usid2);
    }

    public static bool IsLocalhost(string host)
    {
      // init vars
      string localHostName = null;
      IPAddress[] localHostAddress = null;
      try
      {
        localHostName = Dns.GetHostName();
        localHostAddress = Dns.GetHostAddresses(localHostName);
      }
      catch (Exception)
      {
        localHostName = Environment.MachineName;
      }

      if ("localhost".Equals(host, StringComparison.CurrentCultureIgnoreCase) || host == "127.0.0.1" || host == ".")
      {
        return true;
      }
      if (string.Equals(localHostName, host, StringComparison.OrdinalIgnoreCase))
      {
        return true;
      }
      if (localHostAddress != null)
      {
        foreach (IPAddress ipAddress in localHostAddress)
        {
          if (ipAddress.ToString() == host)
          {
            return true;
          }
        }
      }

      return false;
    }

    private static string StringToHex(string str)
    {
      SecurityIdentifier securityIdentifier = new SecurityIdentifier(str);
      byte[] sidByte = new byte[securityIdentifier.BinaryLength];
      securityIdentifier.GetBinaryForm(sidByte, 0);
      string ss = BuildOctString(sidByte);
      return ss;
    }
    private static string BuildOctString(byte[] bytes)
    {
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < bytes.Length; i++)
      {
        sb.Append(bytes[i].ToString("X2"));
      }
      return sb.ToString();
    }

    private static void ImpersonateLogon(Action<string, string, string> action)
    {
      using (StreamReader sr = new StreamReader("WindowNTUser.txt"))
      {
        // format: domain,username,password. e.g: FV5,DPTest,Simple.0
        string user = sr.ReadToEnd();
        string[] userInfo = user.Split(',');
        string domain = userInfo[0];
        string username = userInfo[1];
        string password = userInfo[2];

        IntPtr admin_token = default(IntPtr);
        WindowsIdentity wid_admin = null;
        WindowsImpersonationContext wic = null;

        LogonByInteractive(username, domain, password);
        LogonByNetwork(username, domain, password);
        LogonByNewCredentialsWithWinnt50(username, domain, password);
        
        //在程序中模拟域帐户登录
        if (WinLogonHelper.LogonUser(username, domain, password, LOGON32_LOGON_NEW_CREDENTIALS, 0, ref admin_token) != 0)
        {
          Console.WriteLine("Logon successful with LOGON32_LOGON_NEW_CREDENTIALS + LOGON32_PROVIDER_DEFAULT. [{0}]", username);
          using (wid_admin = new WindowsIdentity(admin_token))
          {
            using (wic = wid_admin.Impersonate())
            {
              action(domain, username, password);
            }
          }
        }
      }
    }

    private static void LogonByInteractive(string username, string domain, string password)
    {
      IntPtr test_token = default(IntPtr);
      int logonWithINTERACTIVE = WinLogonHelper.LogonUser(username, domain, password, LOGON32_LOGON_INTERACTIVE, 0, ref test_token);
      if (logonWithINTERACTIVE == 0)
      {
        int errCode = Marshal.GetLastWin32Error();
        Console.WriteLine("Logon failed with LOGON32_LOGON_INTERACTIVE, ErrorCode: [{1}]. [{0}]", username, errCode);
        var exception = new System.ComponentModel.Win32Exception(errCode);
        Console.WriteLine("Exception Message: [{0}]", exception.Message);
      }
      else
      {
        Console.WriteLine("Logon successful with LOGON32_LOGON_INTERACTIVE. [{0}]", username);
      }
    }

    private static void LogonByNetwork(string username, string domain, string password)
    {
      IntPtr test_token = default(IntPtr);
      int logonWithNETWORK = WinLogonHelper.LogonUser(username, domain, password, LOGON32_LOGON_NETWORK, 0, ref test_token);
      if (logonWithNETWORK == 0)
      {
        int errCode = Marshal.GetLastWin32Error();
        Console.WriteLine("Logon failed with LOGON32_LOGON_NETWORK, ErrorCode: [{1}]. [{0}]", username, errCode);
        var exception = new System.ComponentModel.Win32Exception(errCode);
        Console.WriteLine("Exception Message: [{0}]", exception.Message);
      }
      else
      {
        Console.WriteLine("Logon successful with LOGON32_LOGON_NETWORK. [{0}]", username);
      }
    }

    private static void LogonByNewCredentialsWithWinnt50(string username, string domain, string password)
    {
      IntPtr test_token = default(IntPtr);
      int logonWithNETWORK = WinLogonHelper.LogonUser(username, domain, password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_WINNT50, ref test_token);
      if (logonWithNETWORK == 0)
      {
        Console.WriteLine("Logon failed with LOGON32_LOGON_NEW_CREDENTIALS + LOGON32_PROVIDER_WINNT50. [{0}]", username);
      }
      else
      {
        Console.WriteLine("Logon successful with LOGON32_LOGON_NEW_CREDENTIALS + LOGON32_PROVIDER_WINNT50. [{0}]", username);
      }
    }

    private static string GetConnection()
    {
      using (StreamReader sr = new StreamReader("DBConnection.txt"))
      {
        string strConn = sr.ReadToEnd();
        Console.WriteLine("The connection is [{0}]", strConn);
        return strConn;
      }
    }
  }

  

  internal static class WinLogonHelper
  {
    /// <summary>
    /// 模拟windows登录域
    /// http://www.cnblogs.com/yukaizhao/
    /// </summary>
    [DllImport("advapi32.DLL", SetLastError = true)]
    public static extern int LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
  }

}
