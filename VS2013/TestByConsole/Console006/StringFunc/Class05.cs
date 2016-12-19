using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 对字符串补充空格
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      string s = "a";
      Console.WriteLine(s.PadLeft(4, ' '));
      string ss = new string(' ', 2);
      ss = ss + s;
      Console.WriteLine(ss);
    }
  }
}
