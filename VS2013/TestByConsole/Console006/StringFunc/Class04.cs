using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// ? 和 ?? 操作符
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      string[] s = { "a" };
      Console.WriteLine(s[0]);
      string value = s.Length >= 2 ? s[1].Trim() : "ABC";
      Console.WriteLine(value);
      Console.WriteLine(s[1] ?? "b");
    }
  }
}
