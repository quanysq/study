using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 原型模式(Prototype) 
  /// </summary>
  public class C5
  {
    public static void Execute()
    {
      GameSystem gameSystem = new GameSystem();
      gameSystem.Run(new NormalActorA());
    }
  }

  public  abstract class NormalActor
     {
         public abstract NormalActor clone();
     }

    public class NormalActorA:NormalActor
     {
        public override NormalActor clone()
        {
            Console.WriteLine("NormalActorA is call");
            return (NormalActor)this.MemberwiseClone();
            
        }
     }

   public class NormalActorB :NormalActor
     {
        public override NormalActor clone()
        {
            Console.WriteLine("NormalActorB  was called");
            return (NormalActor)this.MemberwiseClone();
            
        }
     }

   public class GameSystem
    {
       public void Run(NormalActor normalActor)
       {
           NormalActor normalActor1 = normalActor.clone();
           NormalActor normalActor2 = normalActor.clone();
           NormalActor normalActor3 = normalActor.clone();
           NormalActor normalActor4 = normalActor.clone();
           NormalActor normalActor5 = normalActor.clone();
          
       }
    }


   /*
    * 适用性：
       1．当一个系统应该独立于它的产品创建，构成和表示时；
       2．当要实例化的类是在运行时刻指定时，例如，通过动态装载；
       3．为了避免创建一个与产品类层次平行的工厂类层次时；
       4．当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。 
    * 
    * Prototype模式同样用于隔离类对象的使用者和具体类型（易变类）之间的耦合关系，它同样要求这些“易变类”拥有“稳定的接口”。
    * 
    * Prototype模式对于“如何创建易变类的实体对象“采用“原型克隆”的方法来做，它使得我们可以非常灵活地动态创建“拥有某些稳定
    * 接口中”的新对象----所需工作仅仅是注册的地方不断地Clone.
    * 
    * Prototype模式中的Clone方法可以利用.net中的object类的memberwiseClone()方法或者序列化来实现深拷贝。
    */
 }
