using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Console015
{
  class Class6
  {
    public static void Execute()
    {
      HttpClient httpClient = null;
      HttpResponseMessage response = null;
      try
      {
        HttpClientHandler handler = new HttpClientHandler()
        {
            Proxy = new WebProxy("http://192.168.10.37:808"),
            UseProxy = true,
        };
        httpClient = new HttpClient(handler);
        string url = "https://www.google.com";
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
