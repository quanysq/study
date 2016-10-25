using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 抽象工厂（Abstract Factory）
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      // Abstractfactory1
      AbstractFactory factory1 = new ConcreteFactory1();
      Client c1 = new Client(factory1);
      c1.Run();
      // Abstractfactory2
      AbstractFactory factory2 = new ConcreteFactory2();
      Client c2 = new Client(factory2);
      c2.Run();
    }

    abstract class AbstractFactory
    {
      public abstract AbstractProductA CreateProductA();
      public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA
    {
      public abstract void Interact(AbstractProductB b);
    }

    abstract class AbstractProductB
    {
      public abstract void Interact(AbstractProductA a);
    }


    class Client
    {
      private AbstractProductA AbstractProductA;
      private AbstractProductB AbstractProductB;
      public Client(AbstractFactory factory)
      {
        AbstractProductA = factory.CreateProductA();
        AbstractProductB = factory.CreateProductB();
      }
      public void Run()
      {
        AbstractProductB.Interact(AbstractProductA);
        AbstractProductA.Interact(AbstractProductB);
      }
    }
    class ConcreteFactory1 : AbstractFactory
    {
      public override AbstractProductA CreateProductA()
      {
        return new ProductA1();
      }
      public override AbstractProductB CreateProductB()
      {
        return new ProductB1();
      }
    }
    class ConcreteFactory2 : AbstractFactory
    {
      public override AbstractProductA CreateProductA()
      {
        return new ProdcutA2();
      }
      public override AbstractProductB CreateProductB()
      {
        return new ProductB2();
      }
    }
    class ProductA1 : AbstractProductA
    {
      public override void Interact(AbstractProductB b)
      {
        Console.WriteLine(this.GetType().Name + "interact with " + b.GetType().Name);
      }
    }
    class ProductB1 : AbstractProductB
    {
      public override void Interact(AbstractProductA a)
      {
        Console.WriteLine(this.GetType().Name + "interact with " + a.GetType().Name);
      }
    }
    class ProdcutA2 : AbstractProductA
    {
      public override void Interact(AbstractProductB b)
      {
        Console.WriteLine(this.GetType().Name + "interact with " + b.GetType().Name);
      }
    }
    class ProductB2 : AbstractProductB
    {
      public override void Interact(AbstractProductA a)
      {
        Console.WriteLine(this.GetType().Name + "interact with " + a.GetType().Name);
      }
    }
  }

  /*
   * 适用性：
      1.一个系统要独立于它的产品的创建、组合和表示时。
      2.一个系统要由多个产品系统中的一个来配置时。
      3.当你要强调一系列相关的产品对象的设计以便进行联合使用时。
      4.当你提供一个产品类库，而只想显示它们的接口不是实现时。
   */
}
