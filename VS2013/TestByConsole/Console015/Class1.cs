using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;

namespace Console015
{
  /// <summary>
  /// HttpClient
  /// </summary>
  public class C1
  {
    private static String dir = @"d:\httpclient_test\";

    /// <summary>
    /// 写文件到本地
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="html"></param>
    public static void Write(string fileName, string html)
    {
      try
      {
        FileStream fs = new FileStream(dir + fileName, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs, Encoding.Default);
        sw.Write(html);
        sw.Close();
        fs.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

    }

    /// <summary>
    /// 写文件到本地
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="html"></param>
    public static void Write(string fileName, byte[] html)
    {
      try
      {
        File.WriteAllBytes(dir + fileName, html);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
      }

    }

    /// <summary>
    /// 登录博客园
    /// </summary>
    public static void LoginCnblogs()
    {
      HttpClient httpClient = new HttpClient();
      httpClient.MaxResponseContentBufferSize = 256000;
      httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
      String url = "http://passport.cnblogs.com/login.aspx";
      HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
      String result = response.Content.ReadAsStringAsync().Result;

      String username = "hi_amos";
      String password = "密码";

      do
      {
        String __EVENTVALIDATION = new Regex("id=\"__EVENTVALIDATION\" value=\"(.*?)\"").Match(result).Groups[1].Value;
        String __VIEWSTATE = new Regex("id=\"__VIEWSTATE\" value=\"(.*?)\"").Match(result).Groups[1].Value;
        String LBD_VCID_c_login_logincaptcha = new Regex("id=\"LBD_VCID_c_login_logincaptcha\" value=\"(.*?)\"").Match(result).Groups[1].Value;

        //图片验证码
        url = "http://passport.cnblogs.com" + new Regex("id=\"c_login_logincaptcha_CaptchaImage\" src=\"(.*?)\"").Match(result).Groups[1].Value;
        response = httpClient.GetAsync(new Uri(url)).Result;
        Write("amosli.png", response.Content.ReadAsByteArrayAsync().Result);

        Console.WriteLine("输入图片验证码：");
        String imgCode = "wupve";//验证码写到本地了，需要手动填写
        imgCode = Console.ReadLine();

        //开始登录
        url = "http://passport.cnblogs.com/login.aspx";
        List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
        paramList.Add(new KeyValuePair<string, string>("__EVENTTARGET", ""));
        paramList.Add(new KeyValuePair<string, string>("__EVENTARGUMENT", ""));
        paramList.Add(new KeyValuePair<string, string>("__VIEWSTATE", __VIEWSTATE));
        paramList.Add(new KeyValuePair<string, string>("__EVENTVALIDATION", __EVENTVALIDATION));
        paramList.Add(new KeyValuePair<string, string>("tbUserName", username));
        paramList.Add(new KeyValuePair<string, string>("tbPassword", password));
        paramList.Add(new KeyValuePair<string, string>("LBD_VCID_c_login_logincaptcha", LBD_VCID_c_login_logincaptcha));
        paramList.Add(new KeyValuePair<string, string>("LBD_BackWorkaround_c_login_logincaptcha", "1"));
        paramList.Add(new KeyValuePair<string, string>("CaptchaCodeTextBox", imgCode));
        paramList.Add(new KeyValuePair<string, string>("btnLogin", "登  录"));
        paramList.Add(new KeyValuePair<string, string>("txtReturnUrl", "http://home.cnblogs.com/"));
        response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;
        result = response.Content.ReadAsStringAsync().Result;
        Write("myCnblogs.html", result);
      } while (result.Contains("验证码错误，麻烦您重新输入"));

      Console.WriteLine("登录成功！");

      //用完要记得释放
      httpClient.Dispose();
    }

    public static void LoginNormalize()
    {
      HttpClient httpClient = null;
      try
      {
        httpClient = new HttpClient();
        httpClient.MaxResponseContentBufferSize = 1024 * 1024 * 10;
        httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
        String url = "http://192.168.11.25:80/bdna-admin/login.aspx";
        HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
        String result = response.Content.ReadAsStringAsync().Result;

        String username = "nbiadministrator";
        String password = EncryptUtil.SafeEncode("Simple.0");


        //开始登录
        //url = "http://192.168.10.50:8080/bdna-admin/login.aspx";
        List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
        paramList.Add(new KeyValuePair<string, string>("username", username));
        paramList.Add(new KeyValuePair<string, string>("password", password));
        response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(paramList)).Result;
        result = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine("登录成功！");
        Console.WriteLine("================");
        Console.WriteLine(response.RequestMessage.RequestUri.ToString());
        Console.WriteLine("================");
        Console.WriteLine(result);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + (ex.InnerException.Message ?? ex.Message));
      }
      finally
      {
        //用完要记得释放
        if (httpClient != null) httpClient.Dispose();
      }
    }

    public static async void HttpclientGet()
    {
      var uri = "http://124.172.174.187:8888/vliveshow-api-app/v1/tencent/signature?token=dfa10aba7a789dc3ad381113f69f2129";
      var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.None };

      using (var httpclient = new HttpClient(handler))
      {
        httpclient.BaseAddress = new Uri(uri);
        httpclient.DefaultRequestHeaders.Accept.Clear();
        httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpclient.GetAsync(new Uri(uri));

        if (response.IsSuccessStatusCode)
        {
          Stream myResponseStream = await response.Content.ReadAsStreamAsync();
          StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
          string retString = myStreamReader.ReadToEnd();
          myStreamReader.Close();
          myResponseStream.Close();

          Console.WriteLine(retString);
        }
      }  
    }

    //MultipartFormDataContent
    public static void HttpclientPost()
    {
      using (HttpClient httpclient = new HttpClient())
      {
        string url = "http://124.172.174.187:8888/vliveshow-api-app/v1/liveshow/create";
        var multipart = new MultipartFormDataContent();
        List<KeyValuePair<String, String>> parameters = new List<KeyValuePair<String, String>>();
        parameters.Add(new KeyValuePair<string, string>("token", "e00fa8595eef19d497955427690ea955"));
        parameters.Add(new KeyValuePair<string, string>("title", "Jacky的直播间4"));
        parameters.Add(new KeyValuePair<string, string>("topics", "education"));
        parameters.Add(new KeyValuePair<string, string>("geoLocaltion", "0,0,0"));
        parameters.Add(new KeyValuePair<string, string>("OPENRECORDINGKEY", "YES"));
        parameters.Add(new KeyValuePair<string, string>("folder", ""));
        //parameters.Add(new KeyValuePair<string, string>("cover", ""));
        parameters.Add(new KeyValuePair<string, string>("location", ""));
        foreach (var keyValuePair in parameters)
        {
            multipart.Add(new StringContent(keyValuePair.Value), keyValuePair.Key);
        }
        string cover = @"D:\Chrysanthemum.jpg";
        multipart.Add(new ByteArrayContent(File.ReadAllBytes(cover)), "cover", "Chrysanthemum.jpg");

        HttpResponseMessage response = httpclient.PostAsync(new Uri(url), multipart).Result;
        if (response.IsSuccessStatusCode)
        {
          Stream myResponseStream = response.Content.ReadAsStreamAsync().Result;
          StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
          string retString = myStreamReader.ReadToEnd();
          myStreamReader.Close();
          myResponseStream.Close();

          Console.WriteLine(retString);
        }
      }
    }
  }
}
