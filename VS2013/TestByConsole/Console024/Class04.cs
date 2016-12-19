using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 工厂方法模式（Factory Method) 
  /// </summary>
  public class C4
  {
    public static void Execute()
    {
      Console.WriteLine("Please Enter Factory Method No:");
      Console.WriteLine("******************************");
      Console.WriteLine("no         Factory Method");
      Console.WriteLine("3          HongQiCarFactory");
      Console.WriteLine("4          BMWCarFactory");
      Console.WriteLine("******************************");
      int no = Int32.Parse(Console.ReadLine().ToString());
      string factoryType = ConfigurationManager.AppSettings["No" + no];
      //CarFactory factory = new HongQiCarFactory();
      CarFactory factory = (CarFactory)Assembly.Load("Console024").CreateInstance("Console024.C4+" + factoryType); 
      Car car = factory.CarCreate();
      car.StartUp();
      car.Run();
      car.Stop();
    }

    /// <summary>
    /// 工厂
    /// </summary>
    public abstract class CarFactory
    {
      public abstract Car CarCreate();
    }

    /// <summary>
    /// 产品
    /// </summary>
    public abstract class Car
    {
      public abstract void StartUp();
      public abstract void Run();
      public abstract void Stop();
    }

    public class HongQiCarFactory : CarFactory
    {
      public override Car CarCreate()
      {
        return new HongQiCar();
      }
    }

    public class BMWCarFactory : CarFactory
    {
      public override Car CarCreate()
      {
        return new BMWCar();
      }
    }

    public class HongQiCar : Car
    {
      public override void StartUp()
      {
        Console.WriteLine("Test HongQiCar start-up speed!");
      }
      public override void Run()
      {
        Console.WriteLine("The HongQiCar run is very quickly!");
      }
      public override void Stop()
      {
        Console.WriteLine("The slow stop time is 3 second ");
      }
    }

    public class BMWCar : Car
    {
      public override void StartUp()
      {
        Console.WriteLine("The BMWCar start-up speed is very quickly");
      }
      public override void Run()
      {
        Console.WriteLine("The BMWCar run is quitely fast and safe!!!");
      }
      public override void Stop()
      {
        Console.WriteLine("The slow stop time is 2 second");
      }
    }
  }

  /*
   * 适用性：
      1.当一个类不知道它所必须创建的对象类的时候。
      2.当一个类希望由它子类来指定它所创建对象的时候。
      3.当类将创建对象的职责委托给多个帮助子类中的某个，并且你希望将哪一个帮助子类是代理者这一信息局部化的时候。
   */
}
