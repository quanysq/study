using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.ThrowFunc
{
  /// <summary>
  /// Throw
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      string t = TestThrow(1);
      Console.WriteLine(t);
    }

    static string TestThrow(int i)
    {
      if (i == 0)
      {
        throw new Exception("数字不能是0");
      }
      return "Y";
    }
  }
}
