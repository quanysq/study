using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 适配器模式（Adapter Pattern) 
  /// </summary>
  public class C6
  {
    public static void Execute()
    {
      Adapter ap = new Adapter();
      ap.Push("this is the adapter pattern");
      Console.Write(ap.Peek().ToString());
    }
  }

  interface IStack
  {
    void Push(object item);
    void Pop();
    object Peek();
  }

  //对象适配器(Adapter与Adaptee组合的关系) 
  public class Adapter : IStack //适配对象
  {
    ArrayList adaptee;//被适配的对象
    public Adapter()
    {
      adaptee = new ArrayList();
    }
    public void Push(object item)
    {
      adaptee.Add(item);
    }
    public void Pop()
    {
      adaptee.RemoveAt(adaptee.Count - 1);
    }
    public object Peek()
    {
      return adaptee[adaptee.Count - 1];
    }
  }
  //类适配器
  /*
  public class Adapter : ArrayList, IStack
  {
    public void Push(object item)
    {
      this.Add(item);
    }
    public void Pop()
    {
      this.RemoveAt(this.Count - 1);
    }
    public object Peek()
    {
      return this[this.Count - 1];
    }
  }
  */

  /*
   * 适用性：
      1．系统需要使用现有的类，而此类的接口不符合系统的需要。
      2．想要建立一个可以重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。这些源类不一定有很复杂的接口。
      3．（对对象适配器而言）在设计里，需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。
   */
}
