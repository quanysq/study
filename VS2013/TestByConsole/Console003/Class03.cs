using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace Console003
{
  /// <summary>
  /// SOAP
  /// </summary>
  class C3
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
