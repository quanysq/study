using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// Random产生随机数
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      Random r = new Random();
      for (int i = 0; i < 21; i++)
      {
        int rnum = r.Next(1, 21);
        Console.WriteLine(rnum);
      }
    }
  }
}
