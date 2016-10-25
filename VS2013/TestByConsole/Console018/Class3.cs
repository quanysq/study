using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp;
using PostSharp.Aspects;

namespace Console018
{
  public class C3
  {
    public void Execute()
    {
      CreateEvent ce = new CreateEvent();
      ce.SmlEvent += new CreateEvent.SmlEventHandle(KeyPressed);
      ce.OnSmlEvent('A');
    }

    [UnMutipleTrigger]
    public void KeyPressed(object sender, SmlEventArgs e)
    {
      System.Threading.Thread.Sleep(2000);
      Console.WriteLine("发送者：{0}，所按得健为：{1}", sender, e.KeyToRaiseEvent);
    }
  }

  public class CreateEvent
  {
    public delegate void SmlEventHandle(object sender, SmlEventArgs e);

    public event SmlEventHandle SmlEvent;

    public void OnSmlEvent(char c)
    {
      if (SmlEvent != null)
      {
        SmlEventArgs e = new SmlEventArgs(c);
        SmlEvent(this, e);
      }
    }

  }

  public class SmlEventArgs : EventArgs
  {
    public readonly char KeyToRaiseEvent;

    public SmlEventArgs(char keyToRaiseEvent)
    {
      KeyToRaiseEvent = keyToRaiseEvent;
    }

  }

  [Serializable]
  public class UnMutipleTriggerAttribute : MethodInterceptionAspect
  {
    public override bool CompileTimeValidate(System.Reflection.MethodBase method)
    {
      var ps = method.GetParameters();
      if (ps != null && ps.Count() > 0 && ps[0].Name == "sender")
        return true;
      return false;
    }

    public override void OnInvoke(MethodInterceptionArgs args)
    {
      if (args.Arguments.Count > 0)
      {
        var controls = args.Arguments[0];
        if (controls != null)
        {
          Console.WriteLine("方法未执行完，先禁用");
          args.Proceed(); ;
          Console.WriteLine("方法执行完了，现启用");
        }
      }

    }
  }
}
