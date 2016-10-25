using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp;
using PostSharp.Aspects;

namespace Console018
{
  /// <summary>
  /// AOP之PostSharp初见-OnExceptionAspect
  /// </summary>
  public class C1
  {
    [ExceptionAspectDemo]
    public static void ExceptionAspectDemoAttribute1()
    {
      string s = null;
      s.GetType();
    }
    [ExceptionAspectDemo]
    public static void ExceptionAspectDemoAttribute2()
    {
      throw new Exception("exception");
    } 
  }

  [Serializable]
  public class ExceptionAspectDemoAttribute : OnExceptionAspect
  {
    public override void OnException(MethodExecutionArgs args)
    {
      var msg = string.Format("时间[{0:yyyy年MM月dd日 HH时mm分}]方法{1}发生异常: {2}\n{3}", DateTime.Now, args.Method.Name, args.Exception.Message, args.Exception.StackTrace);
      Console.WriteLine(msg);
      args.FlowBehavior = FlowBehavior.Continue;    //继续
    }

    public override Type GetExceptionType(System.Reflection.MethodBase targetMethod)
    {
      return typeof(NullReferenceException);    //只捕捉NullReferenceException错误
      //return typeof(Exception);
    }
  }

  /*注意Postsharp的Aspect都需要标记为可序列化的，因为在编译时会为我们二进制序列化为资源，减少在运行是的开销，这个将在后面专门讲。
   * 
   * 上面的code继承至OnExceptionAspect，并且override OnException和GetExceptionType，GetExceptionType为我们需要处理的特定异常。
   * OnException为异常处理决策方法。我们的异常处理决策是当NullReferenceException时候我们会记录日志，
   * 并且方法指定继续（args.FlowBehavior = FlowBehavior.Continue）。
   * 
   * ExceptionAspectDemoAttribute1抛出了null异常
   * ExceptionAspectDemoAttribute2抛出了自定义异常，
   * 预期是NullReferenceException会被扑捉，而自定义异常会中断
   */
}
