using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapsterSample
{
    public class CommonUtil
    {
        /// <summary>
        /// 根据出生日期计算年龄
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static int CalculateAge(DateTime dateOfBirth)
        {
            return (DateTime.Today.Year - dateOfBirth.Year) - ((DateTime.Today.Month < dateOfBirth.Month) ? 1 : 0);
        }
    }
}
