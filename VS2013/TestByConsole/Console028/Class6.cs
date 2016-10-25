using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console028
{
  /// <summary>
  /// only delete xmlnode name
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      string xmlpath = @"D:\VS2013\Updateset\Patch\UpdaterConfig\test.config";

      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlNodeList xlist = xml.SelectNodes("//Actions");
      string innerxml = xlist[0].InnerXml;
      innerxml = innerxml.Replace("<ExecTemp>", "")
                         .Replace("</ExecTemp>", "");

      xlist[0].InnerXml = innerxml;

      xml.Save(xmlpath);

      Console.WriteLine("ok");
    }
  }
}
