using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormSample05
{
  public static class XmlUtil
  {
    public static T Deserialize<T>(string configfilepath)
    {
      if (!File.Exists(configfilepath))
      {
        throw new FileNotFoundException(string.Format("[{0}] does not exists!", configfilepath));
      }

      using (Stream fStream = new FileStream(configfilepath, FileMode.Open, FileAccess.Read))
      {
        fStream.Position = 0;
        XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
        return (T)xmlFormat.Deserialize(fStream);
      }
    }
  }
}
