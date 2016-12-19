using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Console006.NetFunc
{
  /// <summary>
  /// 使用代理服务器连接网络
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      HttpClient httpClient = null;
      HttpResponseMessage response = null;
      try
      {
        bool UserProxySetting = Convert.ToBoolean(ConfigurationManager.AppSettings["UserProxySetting"]);
        Console.WriteLine("UserProxySetting: {0}", UserProxySetting);
        Console.WriteLine("");
        HttpClientHandler handler = new HttpClientHandler();
        if (UserProxySetting) 
        {
          IWebProxy wp      = new WebProxy("http://192.168.10.37:808");
          handler.Proxy    = wp;
          handler.UseProxy = true;
        }
        httpClient = new HttpClient(handler);
        //string url = "https://www.google.com";
        string url = "http://passport.cnblogs.com/login.aspx";
        response = httpClient.GetAsync(new Uri(url)).Result;
        String result = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(result);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (httpClient != null) httpClient.Dispose();
        if (response != null) response.Dispose();
      }
    }
  }
}
