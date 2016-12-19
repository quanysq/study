using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console006.Class
{
  class LockObj1
  {
    private bool deadlocked = true;
    //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
    public void LockMe(object o)
    {
      lock (this)
      {
        while (deadlocked)
        {
          deadlocked = (bool)o;
          Console.WriteLine("Foo: I am locked :(");
          Thread.Sleep(500);
        }
      }
    }
    //所有线程都可以同时访问的方法
    public void DoNotLockMe()
    {
      Console.WriteLine("I am not locked :)");
    }
  }

  class LockObj2
  {
    private bool deadlocked = true;
    private object locker = new object();
    //这个方法用到了lock，我们希望lock的代码在同一时刻只能由一个线程访问
    public void LockMe(object o)
    {
      lock (locker)
      {
        while (deadlocked)
        {
          deadlocked = (bool)o;
          Console.WriteLine("Foo: I am locked :(");
          Thread.Sleep(500);
        }
      }
    }
    //所有线程都可以同时访问的方法
    public void DoNotLockMe()
    {
      Console.WriteLine("I am not locked :)");
    }
  }
}
