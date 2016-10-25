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
  /// AOP之PostSharp2-OnMethodBoundaryAspect
  /// </summary>
  public class C2
  {
    [OnMethodBoundaryAspectDemoAttribute(Enabled = true)]
    public static void OnMethodBoundaryAspectDemoAttributeTest()
    {
      System.Threading.Thread.Sleep(2000);
    }
  }

  [Serializable]
  public class OnMethodBoundaryAspectDemoAttribute : OnMethodBoundaryAspect
  {
    public bool Enabled
    {
      get;
      set;
    }

    public override void OnEntry(MethodExecutionArgs args)
    {
      if (this.Enabled)
      {
        args.MethodExecutionTag = System.Diagnostics.Stopwatch.StartNew();
      }
    }
    public override void OnExit(MethodExecutionArgs args)
    {
      if (this.Enabled)
      {
        var sw = args.MethodExecutionTag as System.Diagnostics.Stopwatch;
        if (sw != null)
        {
          sw.Stop();
          Console.WriteLine(String.Format("方法{0}执行时间为:{1}s", args.Method.Name, sw.ElapsedMilliseconds / 1000));
          sw = null;
        }
      }
    }

    //OnMethodBoundaryAspect顾名思义其为对方法边界的切入
  }
}
