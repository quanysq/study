using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DapperSample
{
    public class OutInExample
    {
        public void Main()
        {
            int a = 2;
            int b;
            int c = OutTest(a, out b);
            Console.WriteLine($"c 值 = {c}");
            Console.WriteLine($"b 值 = {b}");
        }

        //public void Main()
        //{
        //    int n = 5;
        //    InTest(in n); // 使用'in'关键字来传递参数
        //    InTest(5); // 直接传递字面量也是允许的
        //}

        private int OutTest(int a, out int b)
        {
            b = a;  // 必须赋值
            a -= 100;
            return a;
        }

        private void InTest(in int number)
        {
            // number = 10;    // 这行代码会导致编译错误，因为number是只读的
            Console.WriteLine(number);
        }

        private void InTest2(in Point point)
        {
            Point point2 = new Point();
            // point = point2; // 这行代码会导致编译错误
            point.x = 10;
        }
    }

    public class Point
    {
        public int x;
        public int y;
    }
}
