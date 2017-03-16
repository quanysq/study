using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.ClassFunc
{
  /// <summary>
  /// 测试子类能否重写父类的protected方法
  /// </summary>
  public class C1
  {
    public static void Execute()
    {
      AbsClass AC = new MyClass();
      AC.Test();
    }
  }

  public abstract class AbsClass
  {
    protected void SayHello()
    {
      Console.WriteLine("I am AbsClass!");
    }

    private void TestPrivateMethod()
    {
      Console.WriteLine("Test the private method! I am AbsClass!");
    }

    public abstract void Test();
  }

  public class MyClass : AbsClass
  {
    //使用new来覆盖父类的同名内部方法
    //如果要重写父类的同名内部方法，需要该方法有virtual关键字
    private new void SayHello()
    {
      Console.WriteLine("I am MyClass!");
    }

    //子类的私有方法可以直接跟父类的私有方法同名，互不影响
    private void TestPrivateMethod()
    {
      Console.WriteLine("Test the private method! I am MyClass!");
    }

    public override void Test()
    {
      SayHello();
      TestPrivateMethod();
    }
  }
}
