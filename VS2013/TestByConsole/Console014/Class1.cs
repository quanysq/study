using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Console014
{
  /// <summary>
  /// 二进制
  /// </summary>
  public class C1
  {
    public static void Execute()
    {
      //创建Programmer列表，并添加对象

      List<Programmer> list = new List<Programmer>();

      list.Add(new Programmer("李志伟", true, "C#"));
      list.Add(new Programmer("Coder2", false, "C++"));
      list.Add(new Programmer("Coder3", true, "Java"));

      //使用二进制序列化对象

      string fileName = @"D:\Programmers.dat";//文件名称与路径

      Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);

      BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器

      binFormat.Serialize(fStream, list);

      //使用二进制反序列化对象

      list.Clear();//清空列表

      fStream.Position = 0;//重置流位置

      list = (List<Programmer>)binFormat.Deserialize(fStream);//反序列化对象

      foreach (Programmer p in list)
      {

        Console.WriteLine(p);

      }

      Console.Read();
    }

    [Serializable]  //必须添加序列化特性
    public class Person
    {

      private string Name;//姓名

      private bool Sex;//性别，是否是男

      public Person(string name, bool sex)
      {

        this.Name = name;

        this.Sex = sex;

      }

      public override string ToString()
      {

        return "姓名：" + this.Name + "\t性别：" + (this.Sex ? "男" : "女");

      }

    }

    [Serializable]  //必须添加序列化特性
    public class Programmer : Person
    {

      private string Language;//编程语言

      public Programmer(string name, bool sex, string language)
        : base(name, sex)
      {

        this.Language = language;

      }

      public override string ToString()
      {

        return base.ToString() + "\t编程语言：" + this.Language;

      }
    }
  }
  

  /*
   * 使用二进制序列化，必须为每一个要序列化的的类和其关联的类加上[Serializable]特性，对类中不需要序列化的成员可以使用[NonSerialized]特性。
    
   * 二进制序列化对象时，能序列化类的所有成员(包括私有的)，且不需要类有无参数的构造方法。
   
   * 使用二进制格式序列化时，它不仅是将对象的字段数据进行持久化，
   * 也持久化每个类型的完全限定名称和定义程序集的完整名称（包括包称、版本、公钥标记、区域性），
   * 这些数据使得在进行二进制格式反序列化时亦会进行类型检查。
   * 所以反序列化时的运行环境要与序列化时的运行环境要相同，否者可能会无法反序列化成功。
   */
}
