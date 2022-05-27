using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CodeGenerator.Model
{
    [XmlRoot("Configuration")]
    public class CodeGeneratorModel
    {
        public CodeGeneratorParameter CodeGeneratorParameter { get; set; }
        public GeneratorFiles GeneratorFiles { get; set; }
    }

    /// <summary>
    /// 代码生成器主要参数
    /// </summary>
    public class CodeGeneratorParameter
    {
        /// <summary>
        /// 表名
        /// </summary>
        [XmlElement("TableName")]
        public string TableName { get; set; }

        /// <summary>
        /// 表说明
        /// </summary>
        [XmlElement("TableDesc")]
        public string TableDesc { get; set; }

        /// <summary>
        /// 表名，作为参数，首字母小写
        /// </summary>
        [XmlIgnore]
        public string TablePara
        {
            get
            {
                var firstChar = TableName.Substring(0, 1);
                var others = TableName.Substring(1);
                var newFirstChar = firstChar.ToLower();
                var newString = $"{newFirstChar}{others}";
                return newString;
            }
        }

        /// <summary>
        /// MVC 控制器名称
        /// </summary>
        [XmlElement("ControllerName")]
        public string ControllerName { get; set; }

        /// <summary>
        /// MVC 控制器说明
        /// </summary>
        [XmlElement("ControllerDesc")]
        public string ControllerDesc { get; set; }

        /// <summary>
        /// MVC 控制器名称小写
        /// </summary>
        [XmlIgnore]
        public string ControllerNameLower
        {
            get
            {
                return ControllerName.ToLower();
            }
        }

    }

    public class GeneratorFiles
    {
        public string BasePath { get; set; }

        [XmlElement("GeneratorFile")]
        public List<GeneratorFile> GeneratorFileList { get; set; }
    }
    /// <summary>
    /// 目标生成文件数据
    /// </summary>
    public class GeneratorFile
    {
        public string FileBuilder { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
