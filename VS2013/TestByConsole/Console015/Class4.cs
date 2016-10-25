using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console015
{
  /// <summary>
  /// 使用特定的证书去访问HTTPS（https://192.168.11.50/bdna/Home） 
  /// </summary>
  class Class4
  {
    public static void AccessHttps()
    {
      HttpWebResponse webRes = null;
      StreamReader sr        = null;
      try
      {
        //string Url = "https://192.168.11.50/bdna-admin/Login.aspx";
        //string Url = "https://192.168.11.50/bdna/Home";
        //string Url = "https://192.168.11.50/bdna/ux/index";
        //string Url = "https://192.168.11.50/bdna/api/mantle/isAdministrator";
        string Url = "https://192.168.11.50/bdna/api/repo/files/tree";
        SetCertPass(Url);
        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(Url);
        webReq.Method = WebRequestMethods.Http.Get;
        webReq.Timeout = 120000;
        //var cert0 = new X509Certificate2(@"D:\document\Cert\adssl-root-ca.cer");
        var cert1 = new X509Certificate2(@"D:\document\Cert\adssl-sun-client-cert.pfx", "Simple.0");
        //var cert2 = new X509Certificate2(@"D:\document\Cert\adssl-earth-client-cert.cer");
        //var cert3 = new X509Certificate2(@"D:\document\Cert\adssl-earth-client-cert.pfx", "Simple.0");
        //webReq.ClientCertificates.Add(cert0);
        webReq.ClientCertificates.Add(cert1);
        //webReq.ClientCertificates.Add(cert2);
        //webReq.ClientCertificates.Add(cert3);
        webReq.KeepAlive = true;
        webRes = (HttpWebResponse)webReq.GetResponse();
        sr = new StreamReader(webRes.GetResponseStream(), System.Text.Encoding.Default);
        string result = sr.ReadToEnd();
        Console.WriteLine(result);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
      finally
      {
        if (webRes != null) webRes.Close();
        if (sr != null) sr.Close();
      }
    }

    private static void SetCertPass(string url){
      if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
      {
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
      }
    }
    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
      return true;// Always accept
    }
  }
}
