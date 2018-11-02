using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace Console005.LDAP
{
  /// <summary>
  /// Using System.DirectoryServices.Protocols.LdapConnection
  /// </summary>
  public class C3
  {
    static LdapConnection ldapConnectionAsync = null;

    public static void Execute()
    {
      //ConnectNormalLDAP();            

      //ConnectNormalLDAPWithSSL();     

      //ConnectTLSOnlyAD();             

      //ConnectTLSOnlyADWithSSL();      

      //ConnectNormalAD(); 

      //ConnectADWithBigData(); 

      //ConnectADWithBigDataAsync(); 

      SplitDN();
    }

    // test successed
    private static void ConnectNormalLDAP()
    {
      string ldapPath = "192.168.11.98:1389";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com", "Simple.0");
        ldapConnection.SessionOptions.SecureSocketLayer = false;
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        // 如果 SearchPath 不存在，会报 DirectoryOperationException 的异常: the object is not exist. 并且 Entries.Count = 0
        string distinguishedName = "ou=People,dc=dsee7-ldap,dc=com";
        // 如果根据过滤条件搜索不到数据，Entries.Count = 0
        string filter = "(&(objectClass=Person))";  
        Search(ldapConnection, 2, distinguishedName, filter, "uid", "sn", "dn");
        //Search(ldapConnection, 0, distinguishedName, filter, new string[] { "uid", "sn" });
      }
    }

    // test successed
    private static void ConnectNormalLDAPWithSSL()
    {
      string ldapPath = "192.168.11.98:1636";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com", "Simple.0");
        ldapConnection.SessionOptions.SecureSocketLayer = true;
        ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback((ldapcon, cer) => { return true; }); //这样写可以对证书进行验证
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        string distinguishedName = "ou=People,dc=dsee7-ldap,dc=com";
        string filter = "(&(objectClass=Person))";
        Search(ldapConnection, 0, distinguishedName, filter);
      }
    }

    // test successed
    private static void ConnectTLSOnlyAD()
    {
      string ldapPath = "192.168.10.58:389";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("Bee", "Simple.0");
        ldapConnection.SessionOptions.SecureSocketLayer = false;
        ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
        ldapConnection.SessionOptions.StartTransportLayerSecurity(null); // 必须放在 VerifyServerCertificate 事件之后
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        string distinguishedName = "OU=Engineering,DC=User,DC=com";
        string filter = @"(member=CN=Ait service account 2\, QZ1081394,OU=Engineering,DC=User,DC=com)";
        Search(ldapConnection, 0, distinguishedName, filter);

        ldapConnection.SessionOptions.StopTransportLayerSecurity();
      }
    }

    // test successed
    private static void ConnectTLSOnlyADWithSSL()
    {
      string ldapPath = "192.168.10.58:636";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("CN=Bee,OU=Engineering,DC=User,DC=com", "Simple.0");
        ldapConnection.SessionOptions.SecureSocketLayer = true;
        ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
        //ldapConnection.SessionOptions.StartTransportLayerSecurity(null); // 必须放在 VerifyServerCertificate 事件之后
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        string distinguishedName = "OU=Engineering,DC=User,DC=com";
        string filter = "(&(objectClass=Person))";
        Search(ldapConnection, 0, distinguishedName, filter);

        //ldapConnection.SessionOptions.StopTransportLayerSecurity();
      }
    }

    // test successed
    private static void ConnectNormalAD()
    {
      string ldapPath = "192.168.8.18:389";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("cn=DemoAdmin,ou=nbi,ou=bdna_engineerteam,dc=bdnacn,dc=com", "bdna");
        ldapConnection.SessionOptions.SecureSocketLayer = false;
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        string distinguishedName = "ou=nbi,ou=bdna_engineerteam,dc=bdnacn,dc=com";
        string filter = "(&(objectClass=Person)(cn=Demo*))";
        Search(ldapConnection, 0, distinguishedName, filter);
      }
    }

    // test successed
    private static void ConnectADWithBigData()
    {
      string ldapPath = "192.168.11.84:389";
      using (LdapConnection ldapConnection = new LdapConnection(ldapPath))
      {
        //connect
        var networkCredential = new NetworkCredential("CN=T1,CN=Users,DC=adssl,DC=com", "Simple.0");
        ldapConnection.SessionOptions.SecureSocketLayer = false;
        //ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
        //ldapConnection.SessionOptions.StartTransportLayerSecurity(new DirectoryControlCollection()); // 必须放在 VerifyServerCertificate 事件之后
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Credential = networkCredential;
        ldapConnection.Bind();

        //search
        string distinguishedName = "ou=QA,ou=Non-Users,ou=Users,ou=UserAccount,dc=adssl,dc=com";
        string filter = "(&(objectClass=Person))";
        Search(ldapConnection, 0, distinguishedName, filter);

        //ldapConnection.SessionOptions.StopTransportLayerSecurity();
      }
    }

    // test successed
    private static void ConnectADWithBigDataAsync()
    {
      try
      {
        string ldapPath = "192.168.11.84:389";
        ldapConnectionAsync = new LdapConnection(ldapPath);
        var networkCredential = new NetworkCredential("CN=T1,CN=Users,DC=adssl,DC=com", "Simple.0");
        ldapConnectionAsync.SessionOptions.SecureSocketLayer = false;
        ldapConnectionAsync.SessionOptions.ProtocolVersion = 3;
        ldapConnectionAsync.AuthType = AuthType.Basic;
        ldapConnectionAsync.Credential = networkCredential;
        ldapConnectionAsync.Bind();
        //search
        string distinguishedName = "ou=QA,ou=Non-Users,ou=Users,ou=UserAccount,dc=adssl,dc=com";
        string filter = "(&(objectClass=Person))";
        SearchAsync(ldapConnectionAsync, distinguishedName, filter);
      }
      catch
      {
        throw;
      }
    }

    private static void Search(LdapConnection ldapConnection, int sizeLimit, string distinguishedName, string filter, params string[] showAttributes)
    {
      try
      {
        SearchRequest request = new SearchRequest(distinguishedName, filter, SearchScope.Subtree, showAttributes);
        if (sizeLimit > 0) request.SizeLimit = sizeLimit; // 如果没有限制，可能最多可以搜索 10000 条数据，测试搜索 6000 多条没有问题
        SearchResponse response = (SearchResponse)ldapConnection.SendRequest(request);

        Console.WriteLine("Entries Count: [{0}]", response.Entries.Count);
        Console.WriteLine("==============");
        foreach (SearchResultEntry entry in response.Entries)
        {
          //var t1 = entry.Attributes["abcd"]; // 如果不存在的属性返回 null
          //var test = t1.GetValues(typeof(string)); 

          Console.WriteLine("[{0}]: {1}", response.Entries.IndexOf(entry), entry.DistinguishedName);
          var attributes = entry.Attributes;
          foreach (var attributeNameItem in attributes.AttributeNames)
          {
            string attributeName = attributeNameItem.ToString();
            Console.WriteLine("    Attribute Name: [{0}]", attributeName);
            var attributeValues = attributes[attributeName].GetValues(typeof(string));
            foreach (var attributeValue in attributeValues)
            {
              Console.WriteLine("        Attribute Value: [{0}]", attributeValue);
            }
          }
        }
      }
      catch (DirectoryOperationException e)
      {
        // 在这里处理受大小限制返回的数据，最多只能返回 1000 条限制
        SearchResponse response = (SearchResponse)e.Response;
        foreach (SearchResultEntry entry in response.Entries)
        {
          Console.WriteLine("[{0}]: {1}", response.Entries.IndexOf(entry), entry.DistinguishedName);
        }
      }
      catch
      {
        throw;
      }
    }

    private static void SearchAsync(LdapConnection ldapConnection, string distinguishedName, string filter, params string[] showAttributes)
    {
      ldapConnectionAsync.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
      SearchRequest request = new SearchRequest(distinguishedName, filter, SearchScope.Subtree, showAttributes);
      request.SizeLimit = 2000;

      IAsyncResult result = ldapConnectionAsync.BeginSendRequest(
          request,
          PartialResultProcessing.NoPartialResultSupport,
          new AsyncCallback(InternalCallback),
          null
          );
    }

    private static void InternalCallback(IAsyncResult asyncResult)
    {
      Console.WriteLine("Asynchronous search operation called.");
      Console.WriteLine("The search operation has been completed.");
      try
      {
        // end the send request search operation
        SearchResponse response = (SearchResponse)ldapConnectionAsync.EndSendRequest(asyncResult);

        foreach (SearchResultEntry entry in response.Entries)
        {
          Console.WriteLine("{0}:{1}", response.Entries.IndexOf(entry), entry.DistinguishedName);
        }
      }
      // in case of some directory operation exception
      // return whatever data has been processed
      catch (DirectoryOperationException e)
      {
        Console.WriteLine(e.Message);
        SearchResponse response = (SearchResponse)e.Response;
        foreach (SearchResultEntry entry in response.Entries)
        {
          Console.WriteLine("{0}:{1}", response.Entries.IndexOf(entry), entry.DistinguishedName);
        }
      }
      catch (LdapException e)
      {
        Console.WriteLine(e.Message);
      }
      finally
      {
        if (ldapConnectionAsync != null) ldapConnectionAsync.Dispose();
      }
    }

    private static void SplitDN()
    {
      string dn = @"CN=Ait service account 2\, QZ1081394\, ACD\, BDC,OU=Engineering,DC=User,DC=com";
      //string dn = @"uid=NBIAdministrator,ou=People,dc=dsee7-ldap,dc=com";
      //string dn = @"CN=QZ1081394,OU=Engineering,DC=User,DC=com";
      string cnPattern = @"^(?<cn>.+?)(?<!\\),";

      //Regex re = new Regex(cnPattern);
      //Match m = re.Match(dn);
      var m = Regex.Match(dn, cnPattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      if (m.Success)
      {
        // Item with index 1 returns the first group match.
        string cn = m.Groups[1].Value;
        cn = cn.Replace(@"\", "");
        Console.WriteLine(cn);
      }
    }
  }
}
