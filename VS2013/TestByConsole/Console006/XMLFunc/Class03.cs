using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// read xmlnode date
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      string xmlpath = @"C:\Users\yangsq\Documents\My RTX Files\jacky\bms.BmsService.exe.config";

      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlNodeList xlist = xml.SelectNodes("//configuration/runtime");
      Console.WriteLine(xlist[0].InnerXml);
    }
  }
}
