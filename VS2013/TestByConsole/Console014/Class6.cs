using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console014
{
  /// <summary>
  /// XML
  /// </summary>
  public class C6
  {
    /*
     *  处理以下结构的数据
        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
          <Connection Type="MySQL">
            <Property Name="ABC" Value="BCD">1</Property>
            <Property Name="ABC" Value="BCD">2</Property>
            <Property Name="ABC" Value="BCD">3</Property>
            <Property Name="ABC" Value="BCD">4</Property>
          </Connection>
        </configuration>
     */
    public static void Execute()
    {
      //ExConfig ec = new ExConfig();
      //Connection list = new Connection();
      //list.ConnectionType = "MySQL";
      //list.PropertyList = new List<PropertyDic>();
      //PropertyDic pd = new PropertyDic();
      //pd.PropertyName = "ABC";
      //pd.PropertyValue = "BCD";
      //list.PropertyList.Add(pd);
      //list.PropertyList.Add(pd);
      //list.PropertyList.Add(pd);
      //list.PropertyList.Add(pd);
      //ec.Connection = list;

      string fileName = @"D:\Connection.xml";//文件名称与路径
      Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
      //Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
      XmlSerializer xmlFormat = new XmlSerializer(typeof(ExConfig));

      //序列化为文件
      //xmlFormat.Serialize(fStream, ec);

      //使用XML反序列化对象
      fStream.Position = 0;//重置流位置
      ExConfig list = (ExConfig)xmlFormat.Deserialize(fStream);
      
      fStream.Close();
      Console.Read();
    }
  }

  [XmlRoot("configuration")]
  public class ExConfig
  {
    //public ExConfig() { }

    [XmlElement("Connection")]
    public Connection Connection { get; set; }
  }

  public class Connection
  {
    [XmlAttribute("Type")]
    public string ConnectionType { get; set; }

    [XmlElement("Property")]
    public List<PropertyDic> PropertyList { get; set; }
  }

  public class PropertyDic
  {
    [XmlAttribute("Name")]
    public string PropertyName { get; set; }
    [XmlAttribute("Value")]
    public string PropertyValue { get; set; }

    [XmlText]
    public string PropertyVal { get; set; }
  }

}
