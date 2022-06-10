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
        /// <summary>
        /// 代码生成器主要参数
        /// </summary>
        public CodeGeneratorParameter CodeGeneratorParameter { get; set; }
        
        /// <summary>
        /// 目标生成文件列表
        /// </summary>
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
        /// 表实体类内容，用于填充ViewModel
        /// TODO
        /// </summary>
        [XmlIgnore]
        public string EntityContent { get; set; }

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
        /// MVC 控制器说明（英文）
        /// </summary>
        [XmlElement("ControllerDescEn")]
        public string ControllerDescEn { get; set; }

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

    /// <summary>
    /// 目标生成文件列表
    /// </summary>
    public class GeneratorFiles
    {
        /// <summary>
        /// 基本路径
        /// </summary>
        public string BasePath { get; set; }

        /// <summary>
        /// 实体类部分路径
        /// 与基本路径，表名等组成文件全路径
        /// </summary>
        public string EntityPath { get; set; }

        /// <summary>
        /// 目标文件列表
        /// </summary>
        [XmlElement("GeneratorFile")]
        public List<GeneratorFile> GeneratorFileList { get; set; }
    }
    /// <summary>
    /// 目标生成文件数据
    /// </summary>
    public class GeneratorFile
    {
        /// <summary>
        /// 引用的文件生成器
        /// </summary>
        public string FileBuilder { get; set; }

        /// <summary>
        /// 目标生成的文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 目标生成的文件路径
        /// 与基本路径，文件名称等组成文件全路径
        /// </summary>
        public string FilePath { get; set; }
    }
}
