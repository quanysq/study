using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Console028
{
  /// <summary>
  /// 处理XML里的中文
  /// </summary>
  class C11
  {
    public static void Execute()
    {
      string xmlFilePath = @"D:\vliveshow\nsis\manifest.xml";
      var doc = new XmlDocument();
      doc.Load(xmlFilePath);
      string s = doc.InnerXml;
      Console.WriteLine(s);
    }

    /*
     * XML文件必须是UTF-8编码 
     */
  }
}
