using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console003
{
  /// <summary>
  /// XML
  /// </summary>
  class Class04
  {
    public static void Execute()
    {
      //创建Programmer列表，并添加对象

      List<ProgrammerXmlObj> list = new List<ProgrammerXmlObj>();

      list.Add(new ProgrammerXmlObj("李志伟", true, "C#"));

      list.Add(new ProgrammerXmlObj("Coder2", false, "C++"));

      list.Add(new ProgrammerXmlObj("Coder3", true, "Java"));

      //使用XML序列化对象
      string fileName = @"D:\Programmers.xml";//文件名称与路径
      Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
      XmlSerializer xmlFormat = new XmlSerializer(
        typeof(List<ProgrammerXmlObj>),
        new Type[] { typeof(ProgrammerXmlObj), typeof(PersonXmlObj) }
      );//创建XML序列化器，需要指定对象的类型

      //序列化为文件
      xmlFormat.Serialize(fStream, list);
      
      //序列化为字符串
      using (StringWriter sw = new StringWriter())
      {
        XmlSerializer xf = new XmlSerializer(typeof(List<ProgrammerXmlObj>));
        xf.Serialize(sw, list);
        Console.WriteLine(sw.ToString());
      }

      //==========================
      //使用XML反序列化对象
      fStream.Position = 0;//重置流位置
      list.Clear();
      list = (List<ProgrammerXmlObj>)xmlFormat.Deserialize(fStream);
      foreach (ProgrammerXmlObj p in list)
      {
        Console.WriteLine(p);
      }
    }
  }
  
  /*
   * 使用XML序列化或反序列化时，需要对XML序列化器指定需要序列化对象的类型和其关联的类型。
   * 
   * XML序列化只能序列化对象的公有属性，并且要求对象有一个无参的构造方法，否者无法反序列化。
   * 
   * [Serializable]和[NonSerialized]特性对XML序列化无效！所以使用XML序列化时不需要对对象增加[Serializable]特性。
   * 
   * XML的使用建议：
      在服务端，C#代码中：
      1. 建议不用使用低级别的XML API来使用XML，除非你是在设计框架或者通用类库。
      2. 建议使用序列化、反序列化的方法来生成或者读取XML
      3. 当需要考虑使用XML时，先不要想着XML结构，先应该定义好数据类型。
      4. 列表节点不要使用[XmlElement]，它会让所有子节点【升级】，显得结构混乱。
      5. 如果希望序列化的XML长度小一点，可以采用[XmlAttribute]，或者指定一个更短小的别名。
      6. 不要在一个列表中输出不同的数据类型，这样的XML结构的可读性不好。
      7. 尽量使用UTF-8编码，不要使用GB2312编码。
      在客户端，JavaScript代码中，我不建议使用XML，而是建议使用JSON来代替XML，因为：
      1. XML文本的长度比JSON要长，会占用更多的网络传输时间(毕竟数据保存在服务端，所以传输是免不了的)。
      2. 在JavaScritp中使用XML比较麻烦(还有浏览器的兼容问题),反而各种浏览器对JSON有非常好的支持。
   * 
   * 反序列化的使用总结
      如果XML是由类型序列化得到那的，那么反序列化的调用代码是很简单的，反之，如果要面对一个没有类型的XML，
      就需要我们先设计一个(或者一些)类型出来，这是一个逆向推导的过程，请参考以下步骤：
      1. 首先要分析整个XML结构，定义与之匹配的类型，
      2. 如果XML结构有嵌套层次，则需要定义多个类型与之匹配，
      3. 定义具体类型（一个层级下的XML结构）时，请参考以下表格。
      XML形式                         处理方法                            补充说明
      －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
      XmlElement                      定义一个属性                        属性名与节点名字匹配
      －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
      XmlAttribute                    [XmlAttribute] 加到属性上           
      －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
      InnerText                       [XmlText] 加到属性上               一个类型只能使用一次
      －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
      节点重命名                       根节点：[XmlType("testClass")] 
                                      元素节点：[XmlElement("name")] 
                                      属性节点：[XmlAttribute("id")] 
                                      列表子元素节点：[XmlArrayItem("Detail")] 
                                      列表元素自身：[XmlArray("Items")]
      －－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－
   */
}
