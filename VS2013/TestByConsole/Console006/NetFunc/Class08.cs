using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console006.NetFunc
{
  /// <summary>
  /// Client call webservice mothod with soapheader or integration authentication  
  /// </summary>
  class C8
  {
    public static void Execute()
    {
      //CallWebServiceWithSOAPAuth();
      //CallWebServiceWithBasicAuth();
      //CallWebServiceWithFromsAuth();
      //CallWebServiceWithWindowsAuth();
      CheckAuthType();
    }

    // test successful
    private static void CallWebServiceWithSOAPAuth()
    {
      HttpClient httpclient = null;
      Stream ResponseStream = null;
      StreamReader sr = null;
      HttpResponseMessage response = null;
      try
      {
        string url = "http://127.0.0.1:8081/Services/SoapAuthService.asmx?WSDL";
        httpclient = new HttpClient();
        httpclient.DefaultRequestHeaders.Accept.Clear();
        httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));
        //httpclient.DefaultRequestHeaders.Add("Content-Type", "text/xml");
        
        string retString = string.Empty;
        //写参数，也可以读取外部文件更方便点
        StringBuilder parambody = new StringBuilder(1024);
        parambody.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        parambody.AppendLine("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">");
        parambody.AppendLine("<soap:Header>");
        parambody.AppendLine("<SoapHeaderHelper xmlns=\"http://tempuri.org/\">");
        parambody.AppendLine("<UserName>Admin</UserName>");
        parambody.AppendLine("<PassWord>1234567</PassWord>");
        parambody.AppendLine("</SoapHeaderHelper>");
        parambody.AppendLine("</soap:Header>");
        parambody.AppendLine("<soap:Body>");
        parambody.AppendLine("<HelloWorld xmlns=\"http://tempuri.org/\" />");
        parambody.AppendLine("</soap:Body>");
        parambody.AppendLine("</soap:Envelope>");
        StringContent content = new StringContent(parambody.ToString(), Encoding.UTF8, "text/xml");

        response = httpclient.PostAsync(new Uri(url), content).Result;

        response.EnsureSuccessStatusCode();

        ResponseStream = response.Content.ReadAsStreamAsync().Result;
        sr = new StreamReader(ResponseStream, Encoding.GetEncoding("utf-8"));
        retString = sr.ReadToEnd();

        Console.WriteLine(retString);
      }
      catch
      {
        throw;
      }
      finally
      {
        if (response != null) response.Dispose();
        if (sr != null) sr.Close();
        if (ResponseStream != null) ResponseStream.Close();
        if (httpclient != null) httpclient.Dispose();
      }
    }

    //  test successful
    private static void CallWebServiceWithBasicAuth()
    {
      HttpClient httpclient = null;
      Stream ResponseStream = null;
      StreamReader sr = null;
      HttpResponseMessage response = null;
      try
      {
        string retString = string.Empty;
        string url = "http://127.0.0.1:8081/services/NoneAuthService.asmx/HelloWorld";
        httpclient = new HttpClient();
        var byteArray = Encoding.ASCII.GetBytes("Admin:123654");
        httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        response = httpclient.PostAsync(new Uri(url), null).Result;
        response.EnsureSuccessStatusCode();
        ResponseStream = response.Content.ReadAsStreamAsync().Result;
        sr = new StreamReader(ResponseStream, Encoding.GetEncoding("utf-8"));
        retString = sr.ReadToEnd();
        Console.WriteLine(retString);
      }
      catch
      {
        throw;
      }
      finally
      {
        if (response != null) response.Dispose();
        if (sr != null) sr.Close();
        if (ResponseStream != null) ResponseStream.Close();
        if (httpclient != null) httpclient.Dispose();
      }
    }

    // test successful
    private static void CallWebServiceWithFromsAuth()
    {
      HttpClient httpClient = null;
      String result = "";
      try
      {
        string loginUrl = "http://192.168.8.93:8081/Login.aspx";
        string apiUrl = "http://192.168.8.93:8081/services/FromsAuthService.asmx/HelloWorld";
        httpClient = new HttpClient();
        httpClient.MaxResponseContentBufferSize = 1024 * 1024 * 10;
        List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
        paramList.Add(new KeyValuePair<string, string>("UserName", "admin"));
        paramList.Add(new KeyValuePair<string, string>("Password", "123456"));
        HttpResponseMessage response = httpClient.PostAsync(new Uri(loginUrl), new FormUrlEncodedContent(paramList)).Result;
        string nextRequestUri = response.RequestMessage.RequestUri.ToString();
        bool LoginStatus = nextRequestUri.IndexOf("Index.aspx", StringComparison.OrdinalIgnoreCase) > -1;
        if (response.StatusCode == HttpStatusCode.OK && LoginStatus)
        {
          HttpResponseMessage getresponse = httpClient.GetAsync(new Uri(apiUrl)).Result;
          if (getresponse.StatusCode == HttpStatusCode.OK)
          {
            result = getresponse.Content.ReadAsStringAsync().Result;
          }
        }
        else
        {
          result = "Login failed!";
        }
        Console.WriteLine(result);
      }
      catch
      {
        throw;
      }
      finally
      {
        if (httpClient != null) httpClient.Dispose();
      }
    }

    // test successful
    private static void CallWebServiceWithWindowsAuth()
    {
      HttpClient httpclient = null;
      Stream ResponseStream = null;
      StreamReader sr = null;
      HttpResponseMessage response = null;
      try
      {
        var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };
        //handler.Credentials = new NetworkCredential("bdnacn", "quanysq123");
        handler.Credentials = new NetworkCredential("administrator", "Simple.0");
        string retString = string.Empty;
        //string url = "http://192.168.8.93:8081/services/WindowsAuthService.asmx/HelloWorld";
        string url = "http://192.168.11.24/bdna-admin/Services/UserRightService.asmx/GetLicenseInfo";
        httpclient = new HttpClient(handler);
        response = httpclient.PostAsync(new Uri(url), null).Result;
        response.EnsureSuccessStatusCode();
        ResponseStream = response.Content.ReadAsStreamAsync().Result;
        sr = new StreamReader(ResponseStream, Encoding.GetEncoding("utf-8"));
        retString = sr.ReadToEnd();
        Console.WriteLine(retString);
      }
      catch
      {
        throw;
      }
      finally
      {
        if (response != null) response.Dispose();
        if (sr != null) sr.Close();
        if (ResponseStream != null) ResponseStream.Close();
        if (httpclient != null) httpclient.Dispose();
      }
    }

    private static void CheckAuthType()
    {
      HttpClient httpClient = null;
      HttpResponseMessage response = null;
      String result = "";
      try
      {

        //string indexUrl = "http://192.168.8.93:8081/index.aspx";
        //string indexUrl = "http://192.168.11.24/bdna-admin/admin.aspx"; //Windows Auth
        string indexUrl = "https://192.168.11.25/bdna-admin/admin.aspx"; //Forms Auth
        SetCertPass(indexUrl);
        httpClient = new HttpClient();
        response = httpClient.GetAsync(new Uri(indexUrl)).Result;
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
          result = "Windows Authentication";
        }
        else
        {
          string nextRequestUri = response.RequestMessage.RequestUri.ToString();
          bool LoginStatus = nextRequestUri.IndexOf("Login.aspx", StringComparison.OrdinalIgnoreCase) > -1;
          if (response.StatusCode == HttpStatusCode.OK && LoginStatus)
          {
            result = "Forms Authentication";
          }
          else
          {
            result = "Unknow Authentication";
          }
        }
        Console.WriteLine(result);
      }
      catch
      {
        throw;
      }
      finally
      {
        if (response != null) response.Dispose();
        if (httpClient != null) httpClient.Dispose();
      }
    }
    #region Cert verfiy
    private static void SetCertPass(string url)
    {
      if (url.StartsWith("https"))
      {
        //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((obj, certificate, chain, sslPolicyErrors) => { return true; });
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
      }
    }
    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
      return true;// Always accept
    }
    #endregion
  }
}
