using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 验证null+""
  /// </summary>
  class Class10
  {
    public static void Execute()
    {
      string s = null;
      Console.WriteLine(s + "");
    }
  }
}
