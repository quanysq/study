using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console008
{
  /// <summary>
  /// 自定义事件和委托
  /// 事件是类和对象向外界发出的消息，事件的执行是通过事件委托的方式，调用我们所准备好的处理方法，而是先消息的响应的。要响应某些事件并针对某些事件执行我们意定的方法，需要做到以下几步：
  /// 1、声明事件委托。
  /// 2、声明事件。
  /// 3、添加事件的触发方法。
  /// 4、添加事件的处理程序（响应事件的方法）。
  /// 5、将指定的事件处理程序邦定到要处理的事件上（订阅事件）。
  /// 6、用户信息操作，并触发事件（调用事件的触发方法）。
  /// 7、通过事件委托的回调，执行我们需要的事件处理程序。
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //创建事件源对象
      TestEventSource es = new TestEventSource();

      //创建监听对象
      TestEventListener el = new TestEventListener();

      //订阅事件
      Console.WriteLine("订阅事件\n");
      el.Subscribe(es);

      //引发事件
      Console.WriteLine("输入一个字符，再按enter键");
      string s = Console.ReadLine();
      es.RaiseEvent(s.ToCharArray()[0]);

      //取消订阅事件
      Console.WriteLine("\n取消订阅事件\n");
      el.UnSubscribe(es);

      //引发事件
      Console.WriteLine("输入一个字符，再按enter健");
      s = Console.ReadLine();
      es.RaiseEvent(s.ToCharArray()[0]);
    }
  }

  /// <summary>
  /// 发布事件的类
  /// </summary>
  public class TestEventSource
  {
    //定义delegate
    public delegate void TestEventHandler(object sender, TestEventArgs e);

    //用event 关键字声明事件对象
    public event TestEventHandler TestEvent;

    //事件触发方法
    protected virtual void OnTestEvent(TestEventArgs e)
    {
      if (TestEvent != null)
        TestEvent(this, e);
    }

    //引发事件
    public void RaiseEvent(char keyToRaiseEvent)
    {
      TestEventArgs e = new TestEventArgs(keyToRaiseEvent);
      OnTestEvent(e);
    }
  }

  /// <summary>
  /// 定义事件参数类
  /// </summary>
  public class TestEventArgs : EventArgs
  {
    public readonly char KeyToRaiseEvent;
    public TestEventArgs(char keyToRaiseEvent)
    {
      KeyToRaiseEvent = keyToRaiseEvent;
    }
  }

  /// <summary>
  /// 监听事件的类
  /// </summary>
  public class TestEventListener
  {
    //定义处理事件的方法，他与声明事件的delegate具有相同的参数和返回值类型
    public void KeyPressed(object sender, TestEventArgs e)
    {
      Console.WriteLine("发送者：{0}，所按得健为：{1}", sender, e.KeyToRaiseEvent);
    }

    //订阅事件
    public void Subscribe(TestEventSource evenSource)
    {
      evenSource.TestEvent += new TestEventSource.TestEventHandler(KeyPressed);
    }
    //取消订阅事件
    public void UnSubscribe(TestEventSource evenSource)
    {
      evenSource.TestEvent -= new TestEventSource.TestEventHandler(KeyPressed);
    }
  }
}
