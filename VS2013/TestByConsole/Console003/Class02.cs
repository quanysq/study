using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// 二进制 2
  /// </summary>
  class C2
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
