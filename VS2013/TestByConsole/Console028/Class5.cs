using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console028
{
  /// <summary>
  /// delete xmlnode
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      string xmlpath = @"D:\VS2013\Updateset\Patch\UpdaterConfig\test.config";

      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlNodeList xlist = xml.SelectNodes("//Actions/ExecTemp");
      XmlNode xn = xlist[0];
      xn.ParentNode.RemoveChild(xn);

      xml.Save(xmlpath);

      Console.WriteLine("ok");
    }
  }
}
