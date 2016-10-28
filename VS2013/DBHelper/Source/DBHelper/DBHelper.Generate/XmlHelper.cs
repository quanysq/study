using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;
using System.Xml.Serialization;
using System.IO;

namespace DBHelper.Generate
{
  public static class XmlHelper
  {
    public static void Serialize<T>(T t, string XmlFilePath)
    {
      XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
      using (Stream fStream = new FileStream(XmlFilePath, FileMode.Create, FileAccess.ReadWrite))
      {
        xmlFormat.Serialize(fStream, t);
      }
    }

    public static T DeSerialize<T>(string XmlFilePath)
    {
      if (!File.Exists(XmlFilePath))
      {
        return default(T);
      }

      XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
      using (Stream fStream = new FileStream(XmlFilePath, FileMode.Open, FileAccess.Read))
      {
        return (T)xmlFormat.Deserialize(fStream);
      }
    }
  }
}
