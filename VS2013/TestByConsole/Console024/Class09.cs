using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 组合模式(Composite Pattern) 
  /// </summary>
  public class C9
  {
    public static void Execute()
    {
      Picture root = new Picture("Root");

      root.Add(new Line("Line"));
      root.Add(new Circle("Circle"));

      Rectangle r = new Rectangle("Rectangle");
      root.Add(r);

      root.Draw();

    }
  }

  /// <summary>
  /// 树根
  /// </summary>
  public abstract class Graphics
  {
    protected string _name;

    public Graphics(string name)
    {
      this._name = name;
    }
    public abstract void Draw();
    public abstract void Add(Graphics g);
    public abstract void Remove(Graphics g);
  }

  /// <summary>
  /// 树枝
  /// </summary>
  public class Picture : Graphics
  {
    protected List<Graphics> picList = new List<Graphics>();

    public Picture(string name)
      : base(name)
    { }
    public override void Draw()
    {
      Console.WriteLine("Draw a " + _name.ToString());

      foreach (Graphics g in picList)
      {
        g.Draw();
      }
    }

    public override void Add(Graphics g)
    {
      picList.Add(g);
    }
    public override void Remove(Graphics g)
    {
      picList.Remove(g);
    }
  }

  /// <summary>
  /// 树叶
  /// </summary>
  public class Line : Graphics
  {
    public Line(string name)
      : base(name)
    { }

    public override void Draw()
    {
      Console.WriteLine("Draw a " + _name.ToString());
    }
    public override void Add(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
    public override void Remove(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
  }

  public class Circle : Graphics
  {
    public Circle(string name)
      : base(name)
    { }

    public override void Draw()
    {
      Console.WriteLine("Draw a " + _name.ToString());
    }
    public override void Add(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
    public override void Remove(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
  }

  public class Rectangle : Graphics
  {
    public Rectangle(string name)
      : base(name)
    { }

    public override void Draw()
    {
      Console.WriteLine("Draw a " + _name.ToString());
    }
    public override void Add(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
    public override void Remove(Graphics g)
    {
      throw new Exception("this is a invalid method.");
    }
  }


  /*
   * 适用性：   
      1．你想表示对象的部分-整体层次结构
      2．你希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。
   * 
   * Composite模式实现要点：    
   * 1．Composite模式采用树形结构来实现普遍存在的对象容器，从而将“一对多”的关系转化“一对一”的关系，使得客户代码可以
   * 一致地处理对象和对象容器，无需关心处理的是单个的对象，还是组合的对象容器。
   * 2．将“客户代码与复杂的对象容器结构”解耦是Composite模式的核心思想，解耦之后，客户代码将与纯粹的抽象接口——而非对象容器的
   * 复杂内部实现结构——发生依赖关系，从而更能“应对变化”。
   * 3．Composite模式中，是将“Add和Remove等和对象容器相关的方法”定义在“表示抽象对象的Component类”中，还是将其定义在“表示
   * 对象容器的Composite类”中，是一个关乎“透明性”和“安全性”的两难问题，需要仔细权衡。这里有可能违背面向对象的“单一职责原则”，
   * 但是对于这种特殊结构，这又是必须付出的代价。ASP.NET控件的实现在这方面为我们提供了一个很好的示范。
   * 4．Composite模式在具体实现中，可以让父对象中的子对象反向追溯；如果父对象有频繁的遍历需求，可使用缓存技巧来改善效率。
   */
}
