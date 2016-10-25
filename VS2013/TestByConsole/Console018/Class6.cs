using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Console018
{
  public class C6
  {
    public static void Execute()
    {
      TestAsyncAspect pro = new TestAsyncAspect();
      for (int i = 0; i < 10; i++)
      {
        pro.SomeEvent += new EventHandler(pro_SomeEvent);
      }
      pro.OnSomeEvent();
      //      pro.SomeEvent -= new EventHandler(pro_SomeEvent); 
      Console.WriteLine("主线程完了！");
      Console.Read();
    }

    static void pro_SomeEvent(object sender, EventArgs e)
    {
      Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
    }

  }

  [Serializable]
  public class AsynEventAspectAttribute : EventInterceptionAspect
  {

    public override void OnInvokeHandler(EventInterceptionArgs args)
    {
      var th = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(new Action<object>((obj) =>
      {
        System.Threading.Thread.Sleep(new Random().Next(1000));
        try
        {
          args.ProceedInvokeHandler();
        }
        catch (Exception ex)
        {

          args.ProceedRemoveHandler();
        }
      })));
      th.Start();
    }
  }

  public class TestAsyncAspect
  {
    [AsynEventAspectAttribute]
    public event EventHandler SomeEvent = null;

    public void OnSomeEvent()
    {
      if (SomeEvent != null)
      {

        SomeEvent(this, EventArgs.Empty);
      }
    }
  }
}
