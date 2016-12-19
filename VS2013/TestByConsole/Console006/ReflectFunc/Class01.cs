using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console006.ReflectFunc
{
  /// <summary>
  /// 反射
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      Assembly ass = Assembly.LoadFrom(@"D:\VS2013\TestByConsole\Console002\bin\Debug\Console002.exe");
      foreach (Type t in ass.GetTypes())
      {
        Console.WriteLine(t.FullName);
        foreach (MethodInfo mi in t.GetMethods())
        {
          Console.WriteLine("----" + mi.Name);
          if (t.Name == "Program" && mi.Name == "UnitTest")
          {
            Object o = Activator.CreateInstance(t);
            mi.Invoke(o, null);
          }
        }
      }

      /*
       * 反射读写公有字段，属性与它相类似
       * CC abc = (CC)System.Reflection.Assembly.Load("Updateset").CreateInstance("Updateset.Class.CC");
       * abc.GetType().GetField("PackageVersion").SetValue(null, "aaabbb");
       * Console.WriteLine(abc.GetType().GetField("PackageVersion").GetValue(null).ToString());
       * return;
       */

      Console.ReadLine();
    }
  }
  /*
   * 反射的定义：反射（Reflection）是.NET中的重要机制，通过放射，可以在运行时获得.NET中每一个类型（包括类、结构、委托、接口和枚举等）
   * 的成员，包括方法、属性、事件，以及构造函数等。还可以获得每个成员的名称、限定符和参数等。有了反射，即可对每一个类型了如指掌。如果获
   * 得了构造函数的信息，即可直接创建对象，即使这个对象的类型在编译时还不知道。
   * 
   * 1 导入using System.Reflection;
   * 2 Assembly.Load("程序集")//Assembly.LoadFile("外部调用的动态库")加载程序集,返回类型是一个Assembly
   * 3 foreach (Type type in assembly.GetTypes())
       {
          string t = type.Name;
       }
       得到程序集中所有类的名称
   * 4 Type type = assembly.GetType("程序集.类名");获取当前类的类型
   * 5 Activator.CreateInstance(type); 创建此类型实例
   * 6 MethodInfo mInfo = type.GetMethod("方法名");获取当前方法
   * 7 mInfo.Invoke(null,方法参数);
   */
}
