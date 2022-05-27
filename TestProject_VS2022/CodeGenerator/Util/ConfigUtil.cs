using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeGenerator.Util
{
    public static class ConfigUtil
    {
        public static T Deserialize<T>(string configfilePath)
        {
            if (!File.Exists(configfilePath))
            {
                throw new FileNotFoundException(string.Format("[{0}] does not exists!", configfilePath));
            }

            using (Stream fStream = new FileStream(configfilePath, FileMode.Open, FileAccess.Read))
            {
                fStream.Position = 0;
                XmlSerializer xmlFormat = new(typeof(T));
                return (T)xmlFormat.Deserialize(fStream);
            }
        }
    }
}
