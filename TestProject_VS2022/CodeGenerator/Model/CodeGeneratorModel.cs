using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Model
{
    public class CodeGeneratorModel
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表说明
        /// </summary>
        public string TableDesc { get; set; }

        /// <summary>
        /// 表名，作为参数，首字母小写
        /// </summary>
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
    }
}
