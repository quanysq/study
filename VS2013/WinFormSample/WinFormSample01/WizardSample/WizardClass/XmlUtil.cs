using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormSample01.WizardSample.WizardClass
{
  public sealed class XmlUtil
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
        throw new FileNotFoundException(string.Format("{0} does not found!", XmlFilePath));
      }

      XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
      using (Stream fStream = new FileStream(XmlFilePath, FileMode.Open, FileAccess.Read))
      {
        return (T)xmlFormat.Deserialize(fStream);
      }
    }
  }
}
