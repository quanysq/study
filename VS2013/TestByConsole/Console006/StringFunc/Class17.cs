using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 不区分大小写比较
  /// </summary>
  class C17
  {
    public static void Execute()
    {
      if (string.Equals("EDIT", "edit", StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine("Yes");
      }
    }
  }
}
