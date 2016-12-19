using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console006.LoopFunc
{
  /// <summary>
  /// do...while
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      // 打印1 2 3……10 
      int i = 0;
      bool b = false;
      do        //先执行一次，再判断。  
      {
        i++;
        b = i != 3;
        Console.WriteLine(b.ToString());
        Console.WriteLine(i);
        Thread.Sleep(2000);
        //if (i > 3) break; else Thread.Sleep(2000);
      }
      while (b);
      //b = true时执行循环体, b = false时停止循环
      Console.WriteLine("aaaa");
    }
  }
}
