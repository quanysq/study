using Swashbuckle.Swagger;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace SwaggerTest
{
    /// <summary>
    /// 支持方法注释
    /// </summary>
    public class SwaggerCacheProvider : ISwaggerProvider
    {
        private readonly ISwaggerProvider _swaggerProvider;
        private static ConcurrentDictionary<string, SwaggerDocument> _cache = new ConcurrentDictionary<string, SwaggerDocument>();
        private readonly string _xmlPath;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerProvider"></param>
        /// <param name="xmlpath"></param>
        public SwaggerCacheProvider(ISwaggerProvider swaggerProvider, string xmlpath)
        {
            _swaggerProvider = swaggerProvider;
            _xmlPath = xmlpath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootUrl"></param>
        /// <param name="apiVersion"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SwaggerDocument GetSwagger(string rootUrl, string apiVersion)
        {
            var cacheKey = string.Format("{0}_{1}", rootUrl, apiVersion);
            //只读取一次
            if (!_cache.TryGetValue(cacheKey, out SwaggerDocument srcDoc))
            {
                srcDoc = _swaggerProvider.GetSwagger(rootUrl, apiVersion);

                srcDoc.vendorExtensions = new Dictionary<string, object>
            {
                { "ControllerDesc", GetControllerDesc() }
            };
                _cache.TryAdd(cacheKey, srcDoc);
            }
            return srcDoc;
        }

        /// <summary>
        /// 从API文档中读取控制器描述
        /// </summary>
        /// <returns></returns>
        private ConcurrentDictionary<string, string> GetControllerDesc()
        {
            ConcurrentDictionary<string, string> controllerDescDict = new ConcurrentDictionary<string, string>();
            if (File.Exists(_xmlPath))
            {
                // 1. 加载生成 xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(_xmlPath);

                // 2. 读取控制器方法注释内容
                string[] arrPath;
                int cCount = "Controller".Length;
                foreach (XmlNode node in xmldoc.SelectNodes("//member"))
                {
                    string type = node.Attributes["name"].Value;
                    if (type.StartsWith("T:"))
                    {
                        arrPath = type.Split('.');
                        string controllerName = arrPath[arrPath.Length - 1];
                        if (controllerName.EndsWith("Controller"))  //控制器
                        {
                            //获取控制器注释
                            XmlNode summaryNode = node.SelectSingleNode("summary");
                            string key = controllerName.Remove(controllerName.Length - cCount, cCount);
                            if (summaryNode != null && !string.IsNullOrEmpty(summaryNode.InnerText) && !controllerDescDict.ContainsKey(key))
                            {
                                controllerDescDict.TryAdd(key, summaryNode.InnerText.Trim());
                            }
                        }
                    }
                }
            }
            return controllerDescDict;
        }
    }
}