using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  /// <summary>
  /// 发布事件的类
  /// </summary>
  class TestEventSource
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
  class TestEventArgs : EventArgs
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
  class TestEventListener
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
