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
  /// 建造者模式(Builder) 
  /// </summary>
  public class C3
  {
    public static void Execute()
    {
      Director director = new Director();

      Builder instance;

      Console.WriteLine("Please Enter House No:");

      string No = Console.ReadLine();

      string houseType = ConfigurationManager.AppSettings["No" + No];

      instance = (Builder)Assembly.Load("Console024").CreateInstance("Console024.C3+" + houseType);   //利用反射执行用户选择的方法

      director.Construct(instance);

      House house = instance.GetHouse();
      house.Show();

      Console.ReadLine();
    }

    public abstract class Builder
    {
      public abstract void BuildDoor();
      public abstract void BuildWall();
      public abstract void BuildWindows();
      public abstract void BuildFloor();
      public abstract void BuildHouseCeiling();

      public abstract House GetHouse();   //结果
    }

    /// <summary>
    /// Director类：这一部分是 组合到一起的算法（相对稳定）。 
    /// </summary>
    public class Director
    {
      public void Construct(Builder builder)
      {
        builder.BuildWall();
        builder.BuildHouseCeiling();
        builder.BuildDoor();
        builder.BuildWindows();
        builder.BuildFloor();
      }
    }

    /// <summary>
    /// ChineseBuilder和RomanBuilder这两个类：这个复杂对象的两个部分经常面临着剧烈的变化。
    /// </summary>
    public class ChineseBuilder : Builder
    {
      private House ChineseHouse = new House();
      public override void BuildDoor()
      {
        ChineseHouse.Add("this Door 's style of Chinese");
      }
      public override void BuildWall()
      {
        ChineseHouse.Add("this Wall 's style of Chinese");
      }
      public override void BuildWindows()
      {
        ChineseHouse.Add("this Windows 's style of Chinese");
      }
      public override void BuildFloor()
      {
        ChineseHouse.Add("this Floor 's style of Chinese");
      }
      public override void BuildHouseCeiling()
      {
        ChineseHouse.Add("this Ceiling 's style of Chinese");
      }
      public override House GetHouse()
      {
        return ChineseHouse;
      }
    }

    class RomanBuilder : Builder
    {
      private House RomanHouse = new House();
      public override void BuildDoor()
      {
        RomanHouse.Add("this Door 's style of Roman");
      }
      public override void BuildWall()
      {
        RomanHouse.Add("this Wall 's style of Roman");
      }
      public override void BuildWindows()
      {
        RomanHouse.Add("this Windows 's style of Roman");
      }
      public override void BuildFloor()
      {
        RomanHouse.Add("this Floor 's style of Roman");
      }
      public override void BuildHouseCeiling()
      {
        RomanHouse.Add("this Ceiling 's style of Roman");
      }
      public override House GetHouse()
      {
        return RomanHouse;
      }
    }

    public class House
    {
      List<string> house = new List<string>();

      public void Add(string BuildMsg)
      {
        house.Add(BuildMsg);
      }

      public void Show()
      {
        foreach (string s in house)
        {
          Console.WriteLine(s);
        }
      }
    }
  }

  /*
   * 适用性：
      1.当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。
      2.当构造过程必须允许被构造的对象有不同的表示时。
   */
}
