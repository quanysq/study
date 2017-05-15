using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 按位或，按位与
  /// </summary>
  public class C20
  {
    public static void Execute()
    {
      int i1 = 0;
      int i2 = 1;
      int i3 = 2;
      int i4 = 3;

      var r1 = i1 | i2 | i3 | i4;
      Console.WriteLine("| 运算符(r1)： {0}", r1);

      var r2 = i1 | i2;
      Console.WriteLine("| 运算符(r2)： {0}", r2);

      Console.WriteLine((r1 & i2) > 0);
    }
  }
}
