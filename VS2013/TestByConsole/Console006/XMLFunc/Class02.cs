using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// SelectNodes
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      string XmlPath = System.Environment.CurrentDirectory.ToLower();
      XmlPath = XmlPath.Replace(@"bin\debug", "xml") + "\\" + "XmlForSelectNodes.xml";

      XmlDocument xml = new XmlDocument();
      xml.Load(XmlPath);                                                      //加载Xml文件  
      XmlElement root    = xml.DocumentElement;                               //获取根节点 
      XmlNodeList xlist1 = root.GetElementsByTagName("Table");                //获取Table子节点集合  
      XmlNodeList xlist2 = ((XmlElement)xlist1[0]).SelectNodes("Field");
      foreach (XmlNode xnode in xlist2)
      {
        Console.WriteLine(((XmlElement)xnode).GetAttribute("Name"));
      }
    }
  }
}
