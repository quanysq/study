using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Console006.NetFunc
{
  class C9
  {
    public static void Execute()
    {
      string uri = "https://tus50.bdna.com:443/GetUpToDateFile.aspx";
      Dictionary<string, string> paraItem = new Dictionary<string,string>();
      paraItem.Add("requestinfo", "eJxVkF1v2jAUhv/KlFuqYjt2HFfaRZzYoSUdJSGEZqom8gGkJd+kEKb995lKu5ilI+scPX51/PzW1nnXF3WlPWjkntwD7U4L/x8h+I0PxTFDADJgIv2XDhhRmFekedXnioqCIX2PPg2vDM5HuOj9dJnHWzwpgbG9Rtk6fWkwtHJ/ddiMxGtip49kIuL+fKzaIT8tPur8Kbw2zWZGTpeMrS488MWazEMDXDtEUIRn5gRsIhm3xzaUST7dpnZywWH/KcpQpmOy/GySpJo+LV0dvXfisPPs+Unf1sU7CpNTNH9NIDWzdnPIW5GIYNiB8nWDwXqTOsFsvhyStbVgYD/yos2bLKgifZy81GvojY/dKtSjOK3aZpw+n0NrNy0nJvbc6IPSfYeg++hGLsjKDm0m9uIHf459/zor4/Yq1p6x6/fMDcWgo/x88JPn70qcXZfNthofHaUuoFh5NQFDN6WyOOa99vDzTdnd9qdb+0URZiLIFMCPdfoRFFdlHQKEgTp3mp+3Q9HlmdvVQ7Mam68IcAdVirgU/amo9v+CNYdbpsUZpZzqRBicY4fqwgTCpgLqJuNMqkzbvi2DOCVSl7YUEBLMTMeQBsIWkBjYmNuSOUCqVwpFgjEBgWlLm1BLGARb1NB1y0DUkZZDEYQG5sbti+riQgBhEkwxcaROOBemyaVUBYS0uVrFwUJ7+/MXB83EsA==");
      string result1 = RequestUri(uri, true, paraItem, "UTF-8", null, null);
      Console.WriteLine(result1);

      //string result2 = RequestUri(uri, false, paraItem, "UTF-8", null, null);
      //Console.WriteLine(result2);
    }

    private class CustomWebClient : WebClient
    {
      public static int timeout = 10 * 60 * 1000;
      public CustomWebClient()
      {

      }

      protected override WebRequest GetWebRequest(Uri uri)
      {
        ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;
        WebRequest w = base.GetWebRequest(uri);
        w.Timeout = timeout;
        return w;
      }
      private bool ValidateServerCertificate(
        object sender,
        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
        System.Security.Cryptography.X509Certificates.X509Chain chain,
        System.Net.Security.SslPolicyErrors sslPolicyErrors)
      {
        return true;
      }
    }

    private static string RequestUri(string uri, bool isPost, Dictionary<string, string> paraItem, string encoding, IWebProxy webProxy, ICredentials webCredentials)
    {
      webCredentials = webCredentials ?? CredentialCache.DefaultCredentials;
      using (CustomWebClient webClientObj = new CustomWebClient())
      {
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        webClientObj.Credentials = webCredentials;

        NameValueCollection postVars = new NameValueCollection();

        string postType = isPost ? "POST" : "GET";

        if (isPost)
        {
          foreach (KeyValuePair<string, string> para in paraItem)
          {
            postVars.Add(para.Key, para.Value);
          }
        }
        else
        {
          uri = CreateGetUri(uri, paraItem, encoding);
        }

        //Clear Default Proxy
        WebRequest.DefaultWebProxy = null;

        if (webProxy != null)
        {
          webClientObj.Proxy = webProxy;
        }

        string sRemoteInfo = "";
        byte[] byRemoteInfo;
        if (isPost)
        {
          byRemoteInfo = webClientObj.UploadValues(uri, postType, postVars);
        }
        else
        {
          byRemoteInfo = webClientObj.DownloadData(uri);
        }
        sRemoteInfo = System.Text.Encoding.GetEncoding(encoding).GetString(byRemoteInfo);
        return sRemoteInfo;
      }
    }

    private static string CreateGetUri(string uri, Dictionary<string, string> paraItem, string encoding)
    {
      StringBuilder conditionMess = new StringBuilder(uri); 
      if (uri.IndexOf("?") == -1)
      {
        conditionMess.Append("?");
      }
      if (paraItem != null)
      {
        int i = 0;
        foreach (KeyValuePair<string, string> para in paraItem)
        {
          if (i > 0)
          {
            conditionMess.Append("&");
          }
          conditionMess.AppendFormat("{0}={1}", para.Key, para.Value);
          i++;
        }
      }
      return conditionMess.ToString();
    }
  }
}
