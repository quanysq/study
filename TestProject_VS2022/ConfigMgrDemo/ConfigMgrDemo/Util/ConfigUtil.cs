using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigMgrDemo.Util
{
    /// <summary>
    /// 配置文件序列化/反序列化工具类
    /// </summary>
    public static class ConfigUtil
    {
        /// <summary>
        /// 反序化化 XML 为指定类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configfilePath">配置文件路径</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static T Deserialize<T>(string configfilePath)
        {
            // 记录配置文件的路径，有问题帮助定位
            // Logger.DEFAULT.InfoFormat("The config file path is [{0}]", configfilePath);

            // 1. 判断配置文件是否存在
            if (!File.Exists(configfilePath))
            {
                throw new FileNotFoundException(string.Format("[{0}] does not exists!", configfilePath));
            }

            // 2. 读取配置文件内容并反序列化
            using (Stream fStream = new FileStream(configfilePath, FileMode.Open, FileAccess.Read))
            {
                // 定位文件流在起始点
                fStream.Position = 0;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(fStream);
            }
        }
    }
}
