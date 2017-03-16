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
      string t = TestThrow(0);
      Console.WriteLine(t);
    }

    static string TestThrow(int i)
    {
      if (i == 0)
      {
        throw new Exception("数字不能是0");
      }
      Console.WriteLine("i is [{0}]", i);
      return "Y";
    }
  }
}
