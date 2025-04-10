using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkSample
{
    // [MemoryDiagnoser] 特性用于查看内存分配情况，不加也可以，但结果没有 Allocated 指标
    [MemoryDiagnoser]
    public class BenchmarkTest
    {
        // [Benchmark] 特性标识需要进行性能测试的方法
        [Benchmark]
        public string TestMethod1()
        {
            // 循环 1000 次，使用 String 的原始方式来拼接字符串
            string result = "";
            for (int i = 0; i < 1000; i++)
            {
                result += "Hello ";
            }
            return result;
        }

        [Benchmark] 
        public string TestMethod2()
        {
            // 循环 1000 次，使用 StringBuilder 来拼接字符串
            StringBuilder sb = new StringBuilder(1024);
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("Hello ");
            }
            return sb.ToString();
        }
    }
}
