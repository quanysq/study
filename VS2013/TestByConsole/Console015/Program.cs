using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console015
{
  /// <summary>
  /// HttpClient与NetworkCredential
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //C1.LoginNormalize();    //HttpClient
      //C2.LoginNormalize();    //NetworkCredential
      //C2.LoginNormalize2();    //NetworkCredential

      //Console.WriteLine(EncryptUtil.SafeEncode("Simple.0"));
      //Console.WriteLine("AQougntJw9z/NWy/RZ0B2w==");
      //Console.WriteLine("================");
      //string username = "nbiadministrator";
      //string password = "AQougntJw9z/NWy/RZ0B2w==";
      //string s1 = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));
      //Console.WriteLine(s1);
      //Console.WriteLine("================");
      //username = "nbiadministrator";
      //password = "Simple.0";
      //string s2 = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password)));
      //Console.WriteLine(s2);

      //Class3.ReadLocalCert();
      //Class4.AccessHttps();

      //string s = "E0JJRErAmEw=";
      //Console.WriteLine(EncryptUtil.SafeDecode(s));

      Class5.Execute();

      //Console.WriteLine("[{0}] Downloading...", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
      //Task.Run(async () =>
      //{
      //  await Class5.HttpGetForLargeFileInRightWay();

      //  Console.WriteLine("[{0}] Downloaded.", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
      //});

      Console.ReadKey();
    }

    
  }
}
