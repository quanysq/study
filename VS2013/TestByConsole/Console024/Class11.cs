using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 享元模式(Flyweight Pattern) 
  /// </summary>
  public class C11
  {
    public static void Execute()
    {
      CharactorFactory factory = CharactorFactory.Instance;

      // Charactor "A"
      CharactorA ca = (CharactorA)factory.GetCharactor("A");
      ca.SetPointSize(12);
      ca.Display();

      // Charactor "B"
      CharactorB cb = (CharactorB)factory.GetCharactor("B");
      ca.SetPointSize(10);
      ca.Display();

      // Charactor "C"
      CharactorC cc = (CharactorC)factory.GetCharactor("C");
      ca.SetPointSize(14);
      ca.Display();
    }
  }

  // "Charactor"
  public abstract class Charactor
  {
    //Fields
    protected char _symbol;

    protected int _width;

    protected int _height;

    protected int _ascent;

    protected int _descent;

    protected int _pointSize;

    //Method
    public abstract void SetPointSize(int size);
    public abstract void Display();
  }

  // "CharactorA"
  public class CharactorA : Charactor
  {
    // Constructor 
    public CharactorA()
    {
      this._symbol = 'A';
      this._height = 100;
      this._width = 120;
      this._ascent = 70;
      this._descent = 0;
    }

    //Method
    public override void SetPointSize(int size)
    {
      this._pointSize = size;
    }

    public override void Display()
    {
      Console.WriteLine(this._symbol +
        "pointsize:" + this._pointSize);
    }
  }

  // "CharactorB"
  public class CharactorB : Charactor
  {
    // Constructor 
    public CharactorB()
    {
      this._symbol = 'B';
      this._height = 100;
      this._width = 140;
      this._ascent = 72;
      this._descent = 0;
    }

    //Method
    public override void SetPointSize(int size)
    {
      this._pointSize = size;
    }

    public override void Display()
    {
      Console.WriteLine(this._symbol +
        "pointsize:" + this._pointSize);
    }
  }

  // "CharactorC"
  public class CharactorC : Charactor
  {
    // Constructor 
    public CharactorC()
    {
      this._symbol = 'C';
      this._height = 100;
      this._width = 160;
      this._ascent = 74;
      this._descent = 0;
    }

    //Method
    public override void SetPointSize(int size)
    {
      this._pointSize = size;
    }

    public override void Display()
    {
      Console.WriteLine(this._symbol +
        "pointsize:" + this._pointSize);
    }
  }

 // "CharactorFactory"
 public class CharactorFactory
 {
     // Fields
     private Hashtable charactors = new Hashtable();
 
     private static CharactorFactory instance;
     // Constructor 
     private CharactorFactory()
     {
         charactors.Add("A", new CharactorA());
         charactors.Add("B", new CharactorB());
         charactors.Add("C", new CharactorC());
     }
     
     // Property
     public static CharactorFactory Instance
     {
         get 
         {
             if (instance == null)
             {
                 instance = new CharactorFactory();
             }
             return instance;
         }
     }
 
     // Method
     public Charactor GetCharactor(string key)
     {
         Charactor charactor = charactors[key] as Charactor;
 
         if (charactor == null)
         {
             switch (key)
             {
                 case "A": charactor = new CharactorA(); break;
                 case "B": charactor = new CharactorB(); break; 
                 case "C": charactor = new CharactorC(); break;
                 //
             }
             charactors.Add(key, charactor);
         }
         return charactor;
     }
 }


  /*
   * 适用性：   
      当以下所有的条件都满足时，可以考虑使用享元模式：
      1、一个系统有大量的对象。
      2、这些对象耗费大量的内存。
      3、这些对象的状态中的大部分都可以外部化。
      4、这些对象可以按照内蕴状态分成很多的组，当把外蕴对象从对象中剔除时，每一个组都可以仅用一个对象代替。
      5、软件系统不依赖于这些对象的身份，换言之，这些对象可以是不可分辨的。
      满足以上的这些条件的系统可以使用享元对象。最后，使用享元模式需要维护一个记录了系统已有的所有享元的表，而这需要耗费资源。
      因此，应当在有足够多的享元实例可供共享时才值得使用享元模式。
   * 
   * 上面的代码通过Flyweight模式实现了优化资源的这样一个目的。在这个过程中，还有如下几点需要说明： 
      1．引入CharactorFactory是个关键，在这里创建对象已经不是new一个Charactor对象那么简单，而必须用工厂方法封装起来。
      2．在这个例子中把Charactor对象作为Flyweight对象是否准确值的考虑，这里只是为了说明Flyweight模式，至于在实际应用中，
          哪些对象需要作为Flyweight对象是要经过很好的计算得知，而绝不是凭空臆想。
      3．区分内外部状态很重要，这是享元对象能做到享元的关键所在。

   * 享元对象（Charactor）在这个系统中相对于每一个内部状态而言它是唯一的，这跟单件模式有什么区别呢？这个问题已经很好回答了，
   * 那就是单件类是不能直接被实例化的，而享元类是可以被实例化的。
   */
}
