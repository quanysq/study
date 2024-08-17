using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 返回时间格式：年-月-日 小时:分钟:秒数 毫秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToyyyyMMddHHmmssfff(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss fff");
        }
    }
}
