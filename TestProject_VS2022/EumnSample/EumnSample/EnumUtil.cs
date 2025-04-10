using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EumnSample
{
    public enum HttpMethodType
    {
        [Description("查询数据")]
        GET = 1,
        [Description("保存数据")]
        POST = 2,
        [Description("更新数据")]
        PUT = 3,
        [Description("删除数据")]
        DELETE = 4
    }

    public static class EnumUtil
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            if (value == null) return "";

            System.Reflection.FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
            {
                return value.ToString();
            }
            else
            {
                return (attribArray[0] as DescriptionAttribute).Description;
            }
        }

        /// <summary>
        /// 根据描述获取枚举值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <returns></returns>
        public static T GetEnumByDescription<T>(this string description) where T : Enum
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                System.Reflection.FieldInfo[] fields = typeof(T).GetFields();
                foreach (System.Reflection.FieldInfo field in fields)
                {
                    //获取描述属性
                    object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);    
                    if (objs.Length > 0 && (objs[0] as DescriptionAttribute).Description == description)
                    {
                        return (T)field.GetValue(null);
                    }
                }
            }

            throw new ArgumentException(string.Format("{0} 未能找到对应的枚举.", description), "Description");
        }

        /// <summary>
        /// 数字转枚举
        /// </summary>
        /// <returns></returns>
        public static T ToEnum<T>(this int intValue) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), intValue);
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumString"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string enumString) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), enumString);
        }
    }
}
