using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Console006.ReflectFunc
{
  /// <summary>
  /// BasicHttpBinding/WSHttpBinding方式
  /// </summary>
  public class C3
  {
    /// <summary>
    /// Executes the wcf metod.
    /// BasicHttpBinding/WSHttpBinding方式
    /// </summary>
    /// <typeparam name="T">服务接口</typeparam>
    /// <param name="uri">WCF地址</param>
    /// <param name="methodName">方法名</param>
    /// <param name="args">参数列表</param>
    /// <returns></returns>
    public static object ExecuteMethod<T>(string uri, string methodName, params object[] args)
    {
      BasicHttpBinding binding = new BasicHttpBinding();
      //WSHttpBinding binding = new WSHttpBinding();
      EndpointAddress endpoint = new EndpointAddress(uri);
      binding.MaxReceivedMessageSize = 20971520;

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
  }

  /*
   * BasicHttpBinding和WSHttpBinding两者之间最大的不同你一定已经注意到了，那就是安全。
   * 默认情况下，BasicHttpBinding发送的是明文数据，而 WsHttpBinding发送的是加密和更加安全的数据。
   * 说明：默认情况下，使用basicHttpBinding的时候，安全是没有启用的。换句话说，它很像以前的webservice，也就是.asmx。
   * 但是不意味着我们不能启用安全。
   * 稍后，我会写一篇关于basicHttpBinding启用安全的文章(http://www.codeproject.com/Articles/36289/8-steps-to-enable-windows-authentication-on-WCF-Ba)。
   * 
   * 什么时候使用BasicHttpBinding，什么时候使用WsHttpBinding?
   * 如果你希望有向后兼容的能力，并且支持更多的客户端，你可以选择basicHttpBinding，如果你确定你的客户端使用的是.NET 3.0甚至更高的话，
   * 你可以选择wsHttpBinding。
   */

  //BasicHttpBinding/WSHttpBinding
  //C2.ExecuteMethod<ILMSService>("http://192.168.8.96:9876/LMSService.svc/Basic", "GetTechnopediaAuthorizationDetails", new object[] { "MkbekdUXwlkezKXCqXnMD/HbW+PHtby1CTDiNsQpy/tHFxwNou127UOeTYonLMuFU0EfskXClFISYUDLldt1Up1aP/Nws8G75N3qkYcH7x6t7fZGEBEoJVkqjOJCQsoETlMIHMsBGqUx+PUKtnkt8Ju43S6bnGuGB8vvxIKn2rjyv3C8B64L5+qt52mpRzo2dZOBcL4H0C4l3aH9ab40BUUL3xKbtq/0iHTvk/oq4H/LHEtcGOwCi+STdwJKWHmp+SNUjnm5dU/vCZlWgBRDaLUSHOaXfn4C92Yy+V1CxLXg0lG+/S+sp703f+pt8DrOwJEyNFozrOaxwQbZBEv1vMc5+lBbaZCZ064MVKhgwQ38LfK1XyQLDrrdyTbYEaDx9S8Pit8JxkqjlH0Y1ZMcD3s8wd2E+LfRj6kUzAq5iPtQ4gtlrrfWP2+cF83VBdUAyo14u9n4CFaqRu68YOcTDsY8AlzIjT46ZrJBRxxhL5ZGckBphIcyjHpiVpeMZz3Gl7RH2PJEIjC6n+2SUXDd5hec43VdE7lLYZnSy5viTdmN1Bs418kt2O4ZPnieEUfuXtKxJ+pp+EaH40K8PlNScuo2Sui76YzrVchDQn9JCZw=", "eng_superkey" });
}
