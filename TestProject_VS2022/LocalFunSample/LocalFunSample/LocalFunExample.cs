using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFunSample
{
    public class LocalFunExample
    {
        /// <summary>
        /// 计算一个数组中的所有正数的平方和
        /// </summary>
        /// <param name="numbers">数值数组</param>
        /// <returns></returns>
        public static int CalcSumOfSquares(int[] numbers)
        {
            // 本地函数：计算单个数的平方
            int Square(int x) => x * x;

            int sum = 0;
            foreach (var number in numbers)
            {
                if (number > 0)
                {
                    sum += Square(number); // 调用本地函数
                }
            }

            return sum;
        }
    }
}
