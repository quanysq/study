using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace Console014
{
  /// <summary>
  /// SOAP
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      //实例化对象

      Programmer p = new Programmer("李志伟", true, "C、C#、C++、Java");

      //使用SOAP序列化对象

      string fileName = @"D:\Programmers.xml";//文件名称与路径

      Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);

      SoapFormatter soapFormat = new SoapFormatter();//创建SOAP序列化器

      soapFormat.Serialize(fStream, p);//SOAP不能序列化泛型对象

      //使用SOAP反序列化对象

      fStream.Position = 0;//重置流位置

      p = null;

      p = (Programmer)soapFormat.Deserialize(fStream);

      Console.WriteLine(p);

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
   * 需要引用System.Runtime.Serialization.Formatters.Soap.dll
   * 
   * 微软官方说这个类已经过时，推荐使用BinaryFormatter
   * 
   * SOAP序列化与二进制序列化的区别是：SOAP序列化不能序列化泛型类型。
   * 与二进制序列化一样在序列化时不需要向序列化器指定序列化对象的类型。
   * 而XML序列化需要向XML序列化器指定序列化对象的类型。
   */
}
