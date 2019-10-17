using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// 判断 IP 地址是否正确；
  /// 通过 域 获取 IP
  /// 获取本机IP
  /// </summary>
  public class C8
  {
    public static void Execute()
    {
      IsValidIP();
      Console.WriteLine("================");
      GetIPByDomain("www.baidu.com");
      Console.WriteLine("================");
      GetIPByDomain("tus50.bdna.com");
      Console.WriteLine("================");
      GetIPByDomain("saber.avenger.com");
      Console.WriteLine("================");
      GetIPByDomain("sabers.avenger.com");
      Console.WriteLine("================");
      GetIPByDomain("192.168.10.63");
      Console.WriteLine("================");
      GetLocalIP();
    }

    private static void IsValidIP()
    {
      string[] ipList = { "192.168.222.333", "10.10.0.1", "abc.com", "www.baidu.com", "11", "aa", "0.0.0.1", "::1", "127.0.0.1", "0.0.0.0" };
      IPAddress ip;
      for (int i = 0; i < ipList.Length; i++)
      {
        string ipStr = ipList[i];
        if (IPAddress.TryParse(ipStr, out ip))
        {
          Console.WriteLine("[{0}] is a valid IP. [{1}]", ipStr, ip);
        }
        else
        {
          Console.WriteLine("[{0}] is a invalid IP", ipStr); ;
        }
      }
    }

    private static void GetIPByDomain(string domain)
    {
      try
      {
        Console.WriteLine("The ip info of [{0}]", domain);
        IPHostEntry host = Dns.GetHostEntry(domain);
        foreach (var ipInfo in host.AddressList)
        {
          Console.WriteLine(ipInfo.ToString());
        }
      }
      catch (System.Net.Sockets.SocketException ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    private static void GetLocalIP()
    {
      Console.WriteLine("Way 1 Using ::1 :");
      GetIPByDomain("::1");
      Console.WriteLine("Way 2 Using 127.0.0.1 :");
      GetIPByDomain("127.0.0.1");
      Console.WriteLine("Way 2 Using localhost :");
      GetIPByDomain("localhost");
      Console.WriteLine("Way 4 Using hostname :");
      string hostname = Dns.GetHostName();
      GetIPByDomain(hostname);
    }
  }
}
