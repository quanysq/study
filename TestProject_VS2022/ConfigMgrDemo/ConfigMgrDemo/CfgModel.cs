using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConfigMgrDemo
{
    /// <summary>
    /// 配置文档根节点相应的实体
    /// 使用 XmlRoot 将实体与配置文档根节点关联
    /// </summary>
    [XmlRoot("configuration")]
    public class CfgModel
    {
        /// <summary>
        /// Host 信息
        /// 如果属性名称跟配置文档节点名称不一致，使用 XmlElement 映射属性到文档节点名称
        /// </summary>
        [XmlElement("Host")]
        public HostSetting Host { get; set; }

        /// <summary>
        /// 管理员
        /// 如果属性名称跟配置文档节点名称一致，可不使用 XmlElement
        /// </summary>
        public string AdminUser { get; set; }
    }

    /// <summary>
    /// 配置文档中的 Host 节点元素实体类
    /// </summary>
    public class HostSetting
    {
        /// <summary>
        /// 服务器 URL
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
    }
}
