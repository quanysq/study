using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 装饰模式(Decorator Pattern)
  /// </summary>
  public class C8
  {
    public static void Execute()
    {
      Tank tank = new T50();
      DecoratorA da = new DecoratorA(tank); //且有红外功能
      DecoratorB db = new DecoratorB(da);   //且有红外和水陆两栖功能
      DecoratorC dc = new DecoratorC(db);   //且有红外、水陆两栖、卫星定们三种功能
      dc.Shot();
      dc.Run();
    }
  }

  /// <summary>
  /// Component类
  /// </summary>
  public abstract class Tank
  {
    public abstract void Shot();
    public abstract void Run();
  }

  public class T50 : Tank
  {
    public override void Shot()
    {
      Console.WriteLine("T50坦克平均每秒射击5发子弹");
    }
    public override void Run()
    {
      Console.WriteLine("T50坦克平均每时运行30公里");
    }
  }

  public class T75 : Tank
  {
    public override void Shot()
    {
      Console.WriteLine("T75坦克平均每秒射击10发子弹");
    }
    public override void Run()
    {
      Console.WriteLine("T75坦克平均每时运行35公里");
    }
  }

  public class T90 : Tank
  {
    public override void Shot()
    {
      Console.WriteLine("T90坦克平均每秒射击10发子弹");
    }
    public override void Run()
    {
      Console.WriteLine("T90坦克平均每时运行40公里");
    }
  }

  public abstract class Decorator : Tank //Do As 接口继承 非实现继承
  {
    private Tank tank; //Has a  对象组合
    public Decorator(Tank tank)
    {
      this.tank = tank;
    }
    public override void Shot()
    {
      tank.Shot();
    }
    public override void Run()
    {
      tank.Run();
    }
  }

  public class DecoratorA : Decorator
  {
    public DecoratorA(Tank tank)
      : base(tank)
    {
    }
    public override void Shot()
    {
      //Do some extension //功能扩展 且有红外功能
      base.Shot();
    }
    public override void Run()
    {

      base.Run();
    }
  }

  public class DecoratorB : Decorator
  {
    public DecoratorB(Tank tank)
      : base(tank)
    {
    }
    public override void Shot()
    {
      //Do some extension //功能扩展 且有水陆两栖功能
      base.Shot();
    }
    public override void Run()
    {

      base.Run();
    }
  }

  public class DecoratorC : Decorator
  {
    public DecoratorC(Tank tank)
      : base(tank)
    {
    }
    public override void Shot()
    {
      //Do some extension //功能扩展 且有卫星定位功能
      base.Shot();
    }
    public override void Run()
    {

      base.Run();
    }

  }


  /*
   * 适用性：
      需要扩展一个类的功能，或给一个类增加附加责任。
      需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
      需要增加由一些基本功能的排列组合而产生的非常大量的功能，从而使继承关系变得不现实。
   * 
   * 通过采用组合、而非继承的手法，Decorator模式实现了在运行时动态地扩展对象功能的能力，而且可以根据需要扩展多个功能。
   * 避免了单独使用继承带来的“灵活性差"和"多子类衍生问题"。
   * 
   * Component类在Decorator模式中充当抽象接口的角色，不应该去实现具体的行为。而且Decorator类对于Component类应该透明
   * ---换言之Component类无需知道Decorator类，Decorator类是从外部来扩展Component类的功能。
   * 
   * Decorator类在接口上表现为is-a Component的继承关系，即Decorator类继承了Component类所且有的接口。但在实现上又
   * 表现has a Component的组合关系，即Decorator类又使用了另外一个Component类。我们可以使用一个或者多个Decorator对象来“装饰”
   * 一个Component对象，且装饰后的对象仍然是一个Component对象。
   * 
   * Decorator模式并非解决”多子类衍生的多继承“问题，Decorator模式应用的要点在于解决“主体类在多个方向上的扩展功能”------是为“装饰”的含义。
   */

}
