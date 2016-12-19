using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// write date to xmlnode
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      string xmlpath = @"D:\VS2013\Updateset\Patch\UpdaterConfig\test.config";

      XmlDocument xml = new XmlDocument();
      xml.Load(xmlpath);

      XmlNodeList xlist = xml.SelectNodes("//Actions/ExecTemp");

      for (int i = 0; i < 5; i++)
      {
        string strxml = "<Exec program=\"${Normalize_Updater_FilePath}\" commandline=\"${File2_name}\" IgnoreError=\"false\" OnErrGoTo=\"Failed\" />";
        xlist[0].InnerXml = xlist[0].InnerXml + strxml;
      }

      xml.Save(xmlpath);

      Console.WriteLine(xlist[0].InnerXml);
    }
  }
}
