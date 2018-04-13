using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMSViewer
{
  public class Common
  {
    public static MethodInfo[] GetLMSMethodInfoArray()
    {
      List<string> LMSMethodList = new List<string>();
      Type type = typeof(ILMSService);
      MethodInfo[] mi = type.GetMethods();
      return mi;
    }

    public static List<string> GetLMSMethodList(MethodInfo[] mis)
    {
      List<string> LMSMethodList = new List<string>();
      LMSMethodList = (from l in mis orderby l.Name select l.Name).ToList();
      return LMSMethodList;
    }

    public static MethodInfo GetLMSMethodByName(MethodInfo[] mis, string MethodName)
    {
      MethodInfo LMSMethodInfo = mis.FirstOrDefault(x => x.Name.Equals(MethodName, StringComparison.OrdinalIgnoreCase));
      return LMSMethodInfo;
    }

    public static ParameterInfo[] GetMethodParameters(MethodInfo mi)
    {
      ParameterInfo[] paramsInfo = mi.GetParameters();
      return paramsInfo;
    }

    public static object ExecuteMethod<T>(string uri, string methodName, params object[] args)
    {
      BasicHttpBinding binding = new BasicHttpBinding();
      EndpointAddress endpoint = new EndpointAddress(uri);
      binding.MaxReceivedMessageSize = 20971520;  //20M

      using (ChannelFactory<T> channelFactory = new ChannelFactory<T>(binding, endpoint))
      {
        T instance = channelFactory.CreateChannel();
        using (instance as IDisposable)
        {
          try
          {
            Type type = typeof(T);
            MethodInfo mi = type.GetMethod(methodName);
            return mi.Invoke(instance, args);
          }
          catch (TimeoutException)
          {
            (instance as ICommunicationObject).Abort();
            throw;
          }
          catch (CommunicationException)
          {
            (instance as ICommunicationObject).Abort();
            throw;
          }
          catch (Exception vErr)
          {
            (instance as ICommunicationObject).Abort();
            throw;
          }
        }
      }
    }

    public static T JsonDeserialize<T>(string jsonString)
    {
      if (string.IsNullOrEmpty(jsonString))
        return GetObjTranNull<T>(null);
      else
      {
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
          NullValueHandling = NullValueHandling.Ignore,
          DefaultValueHandling = DefaultValueHandling.Ignore
        };
        return JsonConvert.DeserializeObject<T>(jsonString, jsonSerializerSettings);
      }
    }

    public static T GetObjTranNull<T>(Object obj)
    {
      try
      {
        if ((obj == null || obj == DBNull.Value) && (typeof(T) == typeof(string)))
        {
          return (T)Convert.ChangeType("", typeof(T));
        }
        if (obj is T)
        {
          return (T)obj;
        }
        if (typeof(T).IsGenericType)
        {
          Type genericTypeDefinition = typeof(T).GetGenericTypeDefinition();
          if (genericTypeDefinition == typeof(Nullable<>))
          {
            return (T)Convert.ChangeType(obj, Nullable.GetUnderlyingType(typeof(T)));
          }
        }
        return (T)Convert.ChangeType(obj, typeof(T));
      }
      catch (InvalidCastException se)
      {
        try
        {
          if (obj != null)
          {
            return (T)obj;
          }
        }
        catch (Exception xe)
        {
        }
      }
      catch (Exception se)
      {

      }

      return default(T);
    }

    public static string CalculateSHA1Hash(string input, Encoding encoding)
    {
      //Create SHA1 object
      SHA1 sha = new SHA1CryptoServiceProvider();

      //convent mystr to byte[]
      byte[] dataToHash = encoding.GetBytes(input);

      //Hash
      byte[] dataHashed = sha.ComputeHash(dataToHash);

      // step 2, convert byte array to hex string
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < dataHashed.Length; i++)
      {
        sb.Append(dataHashed[i].ToString("X2"));
      }

      return sb.ToString();
    }

    public void SelectAllByKey(object sender, KeyEventArgs e)
    {
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
      {
        ((TextBox)sender).SelectAll();
      }
    }
  }
}
