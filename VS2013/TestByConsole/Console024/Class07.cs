using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 桥接模式（Bridge Pattern) 
  /// </summary>
  public class C7
  {
    public static void Execute()
    {
      Brush b = new BigBrush();
      b.SetColor(new Red());
      b.Paint();
      b.SetColor(new Blue());
      b.Paint();
      b.SetColor(new Green());
      b.Paint();

      b = new SmallBrush();
      b.SetColor(new Red());
      b.Paint();
      b.SetColor(new Blue());
      b.Paint();
      b.SetColor(new Green());
      b.Paint();
    }
  }

  /// <summary>
  /// 抽象者
  /// </summary>
  abstract class Brush
  {
    protected Color c;
    public abstract void Paint();

    public void SetColor(Color c)
    { this.c = c; }
  }

  class BigBrush : Brush
  {
    public override void Paint()
    { Console.WriteLine("Using big brush and color {0} painting", c.color); }
  }

  class SmallBrush : Brush
  {
    public override void Paint()
    { Console.WriteLine("Using small brush and color {0} painting", c.color); }
  }

  /// <summary>
  /// 实现者
  /// </summary>
  class Color
  {
    public string color;
  }

  class Red : Color
  {
    public Red()
    { this.color = "red"; }
  }

  class Green : Color
  {
    public Green()
    { this.color = "green"; }
  }

  class Blue : Color
  {
    public Blue()
    { this.color = "blue"; }
  }




  /*
   * 适用性：   
      1．如果一个系统需要在构件的抽象化角色和具体化角色之间增加更多的灵活性，避免在两个层次之间建立静态的联系。 
      2．设计要求实现化角色的任何改变不应当影响客户端，或者说实现化角色的改变对客户端是完全透明的。 
      3 ．一个构件有多于一个的抽象化角色和实现化角色，系统需要它们之间进行动态耦合。 
      4 ．虽然在系统中使用继承是没有问题的，但是由于抽象化角色和具体化角色需要独立变化，设计要求需要独立管理这两者。
   * 
   * Bridge要点：   
      1．Bridge模式使用“对象间的组合关系”解耦了抽象和实现之间固有的绑定关系，使得抽象和实现可以沿着各自的维度来变化。 
      2．所谓抽象和实现沿着各自维度的变化，即“子类化”它们，得到各个子类之后，便可以任意它们，从而获得不同平台上的不同型号。
      3．Bridge模式有时候类似于多继承方案，但是多继承方案往往违背了类的单一职责原则（即一个类只有一个变化的原因），
          复用性比较差。Bridge模式是比多继承方案更好的解决方法。
      4．Bridge模式的应用一般在“两个非常强的变化维度”，有时候即使有两个变化的维度，但是某个方向的变化维度并不剧烈——换言之
   *      两个变化不会导致纵横交错的结果，并不一定要使用Bridge模式。 
   */
}
