using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006
{
  /// <summary>
  /// Throw
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //string t = TestThrow(1);
      //Console.WriteLine(t);

      if (string.Equals("EDIT", "edit", StringComparison.OrdinalIgnoreCase))
      {
        Console.WriteLine("Yes");
      }
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
