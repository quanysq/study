using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// 读取线上的xml
  /// </summary>
  class C10
  {
    public static void Execute()
    {
      string xmlfilepath = "http://192.168.8.96:8083/UpdateFiles/UpdaterSchedule.xml";
      var doc = new XmlDocument();
      doc.Load(xmlfilepath);
      Console.WriteLine(doc.InnerXml);
    }
  }
}
