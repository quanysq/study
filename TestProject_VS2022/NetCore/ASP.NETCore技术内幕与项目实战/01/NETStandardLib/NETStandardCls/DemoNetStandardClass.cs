using System;
using System.IO;

namespace NETStandardCls
{
    public class DemoNetStandardClass
    {
        public static void Test()
        {
            Console.WriteLine(typeof(FileStream).Assembly.Location);
        }
    }
}
