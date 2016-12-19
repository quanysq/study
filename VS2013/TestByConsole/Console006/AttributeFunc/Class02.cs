using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.AttributeFunc
{
  /// <summary>
  /// 测试获取特性数据2
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      GetAttributeInfo(typeof(OldClass));
      Console.WriteLine("==============");
      GetAttributeInfo(typeof(NewClass));
      Console.ReadKey();
    }

    public static void GetAttributeInfo(Type t)
    {
      OldAttribute myattribute = (OldAttribute)Attribute.GetCustomAttribute(t, typeof(OldAttribute));
      if (myattribute == null)
      {
        Console.WriteLine(t.ToString() + "类中自定义特性不存在！");
      }
      else
      {
        Console.WriteLine("特性描述:{0}\n加入事件{1}", myattribute.Discretion, myattribute.date);
        myattribute.hello();
      }
    }
  }

  [AttributeUsage(AttributeTargets.Class, Inherited = false)]//设置了定位参数和命名参数

  //该特性适用于所有的类，而且是非继承的。
  class OldAttribute : Attribute//继承自Attribute
  {
    private string discretion;

    public string Discretion
    {
      get { return discretion; }
      set { discretion = value; }
    }
    public DateTime date;
    public OldAttribute(string discretion)
    {
      this.discretion = discretion;
      date = DateTime.Now;
    }

    public void hello()
    {
      Console.WriteLine("Hello, my world!");
    }
  }
  //现在我们定义两类
  [Old("这个类将过期")]//使用定义的新特性
  class OldClass
  {
    public void OldTest()
    {
      Console.WriteLine("测试特性");
    }
  }
  class NewClass : OldClass
  {
    public void NewTest()
    {
      Console.WriteLine("测试特性的继承");
    }
  }
}
