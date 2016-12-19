using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 比较Random和DateTime毫秒产生的随机数
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      for (var i = 0; i < 10; i++)
      {
        Console.WriteLine((new Random()).Next(10, 99).ToString());
      }
      Console.WriteLine("**********************************************");
      for (var i = 0; i < 10; i++)
      {
        Console.WriteLine(DateTime.Now.ToString("ff"));
      }
    }
  }
}
