using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// 更新UpdaterSchedule.config指定节点的值
  /// 应用正则表达式替换
  /// </summary>
  class C8
  {
    public static void Execute()
    {
      string xmlpath = @"D:\VS2013\TestByConsole\Console028\XML\UpdaterSchedule.config";

      StringBuilder updatecontent = new StringBuilder(1024);
      updatecontent.AppendLine("<string>5.0.0.8012</string>");
      updatecontent.AppendLine("<string>US50_201602 Build20160310_8134</string>");
      UpdateSpecifiedNode(xmlpath, "AnalyzeETL", "RequiredVersions", updatecontent.ToString());

      
    }

    private static void UpdateSpecifiedNode(string xmlpath, string filterkey, string needupdatenode, string updatecontent)
    {
      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlNodeList xlist = xml.SelectNodes("//Dictionary/SerializableDictionary");

      foreach (XmlNode node in xlist)
      {
        if (node.NodeType == XmlNodeType.Element)
        {
          XmlElement element = (XmlElement)node;
          string Innerxml = element.InnerXml;
          if (Innerxml.IndexOf(filterkey) > -1)
          {
            Console.WriteLine("before update: ");
            Console.WriteLine("============================");
            Console.WriteLine(Innerxml);
            Console.WriteLine("");
              
            Console.WriteLine("after update: ");
            Console.WriteLine("============================");
            string nodeRegex = string.Format("<{0}>{1}</{0}>", needupdatenode, @"[\s\S]*");
            Regex r = new Regex(nodeRegex);
            if (r.IsMatch(Innerxml))
            {
              string updatenote = string.Format("<{0}>{1}</{0}>", needupdatenode, updatecontent);
              Innerxml = r.Replace(Innerxml, updatenote);
            }
              
            Console.WriteLine(Innerxml);
            Console.WriteLine("****************************");

            element.InnerXml = Innerxml;
          }
        }
      }

      xml.Save(xmlpath);
    }

  }


}
