using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CommonLib;

namespace Console006.NetFunc
{
  /// <summary>
  /// HttpWebResponse and NetworkCredential
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      LoginNormalize();
    }

    static void LoginNormalize()
    {
      HttpWebResponse webRes = null;
      StreamReader sr        = null;
      try
      {
        ServicePointManager.DefaultConnectionLimit = 100;

        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create("http://192.168.11.31/bdna-admin/admin.aspx");
        webReq.Method = WebRequestMethods.Http.Get;
        webReq.Timeout = 120000;
        //webReq.Credentials = new NetworkCredential("administrator", "Simple.0", Environment.UserDomainName);
        webReq.Credentials = new NetworkCredential("Administrator", "Simple.0");
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

    static void LoginNormalize2()
    {
      Dictionary<string, string> requestData = new Dictionary<string, string>();
      requestData.Add("username", "nbiadministrator");
      requestData.Add("password", EncryptUtil.SafeEncode("Simple.0"));
      string url = "http://192.168.11.25:80/bdna-admin/login.aspx";

      HttpWebResponse response = null;
      string responseHTML = string.Empty;
      string post = string.Join("&", requestData.Select(item => item.Key + "=" + item.Value));

      try
      {
        byte[] data = Encoding.ASCII.GetBytes(post);
        ServicePointManager.DefaultConnectionLimit = 100;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Timeout = 1000 * 300;
        request.Credentials = CredentialCache.DefaultCredentials;
        request.Method = "POST"; 
        //request.Accept = "*/*";
        //request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36";
        //request.Headers["X-Requested-With"] = "XMLHttpRequest";
        //request.Headers.Add("Accept-Language", "en-US");
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        Stream requestStream = request.GetRequestStream();
        requestStream.Write(data, 0, data.Length);
        requestStream.Close();
        response = (HttpWebResponse)request.GetResponse();
        System.IO.Stream responseStream = response.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.Default);
        responseHTML = reader.ReadToEnd();
        reader.Close();
        responseStream.Close();
      }
      catch (Exception ex)
      {
        throw ex;
      }
      if (response.StatusCode == HttpStatusCode.OK)
      {
        response.Close();
        Console.WriteLine(responseHTML);
      }
      else
      {
        Console.WriteLine("Execute InvokeWebService faild.");
      }
    }
  }
}
