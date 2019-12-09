using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;

namespace Console002
{
  /// <summary>
  /// 判断机器是否加入 domain, 并获取 domain name
  /// </summary>
  class C7
  {
    public static void Execute()
    {
      GetByIPGlobalProperties();
      Console.WriteLine("");
      GetByWin32();
    }


    private static void GetByIPGlobalProperties()
    {
      try
      {
        Console.WriteLine("Getting the computer domain by IPGlobalProperties class");
        var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
        var domainName = ipGlobalProperties.DomainName;
        var hostName = ipGlobalProperties.HostName;
        Console.WriteLine("Result: [Domain Name: {0}] [Host Name: {1}]", domainName, hostName);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: [{0}]", ex.Message);
      }
    }

    public static void GetByWin32()
    {
      Console.WriteLine("Getting the computer domain by Win32");
      Win32.NetJoinStatus status = Win32.NetJoinStatus.NetSetupUnknownStatus;
      IntPtr pDomain = IntPtr.Zero;
      int result = Win32.NetGetJoinInformation(null, out pDomain, out status);
      Console.WriteLine("Result: [{0}], Status: [{1}]", result, status);
      if (pDomain != IntPtr.Zero)
      {
        Win32.NetApiBufferFree(pDomain);
      }
      if (result == Win32.ErrorSuccess)
      {
        var isInDomain = status == Win32.NetJoinStatus.NetSetupDomainName;
        Console.WriteLine("Is in domain? [{0}]", isInDomain);
      }
      else
      {
        Console.WriteLine("Domain Info Get Failed");
      }
    }

    internal class Win32
    {
      public const int ErrorSuccess = 0;

      [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
      public static extern int NetGetJoinInformation(string server, out IntPtr domain, out NetJoinStatus status);

      [DllImport("Netapi32.dll")]
      public static extern int NetApiBufferFree(IntPtr Buffer);

      public enum NetJoinStatus
      {
        NetSetupUnknownStatus = 0,
        NetSetupUnjoined,
        NetSetupWorkgroupName,
        NetSetupDomainName
      }

    }
  }
}
