using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Console038
{
  public class C1
  {
    /// <summary>
    /// Executes the wcf method.
    /// NetTcpBinding方式
    /// </summary>
    /// <typeparam name="T">服务接口</typeparam>
    /// <param name="pUrl">WCF地址</param>
    /// <param name="pMethodName">方法名</param>
    /// <param name="pParams">参数列表</param>
    /// <returns></returns>
    public static object ExecuteMethod<T>(string pUrl, string pMethodName, params object[] pParams)
    {
      EndpointAddress address = new EndpointAddress(pUrl);
      Binding bindinginstance = null;
      NetTcpBinding ws = new NetTcpBinding();
      ws.MaxReceivedMessageSize = 20971520;
      ws.Security.Mode = SecurityMode.None;
      bindinginstance = ws;
      using (ChannelFactory<T> channel = new ChannelFactory<T>(bindinginstance, address))
      {
        T instance = channel.CreateChannel();
        using (instance as IDisposable)
        {
          try
          {
            Type type = typeof(T);
            MethodInfo mi = type.GetMethod(pMethodName);

            return mi.Invoke(instance, pParams);
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

  }
}
