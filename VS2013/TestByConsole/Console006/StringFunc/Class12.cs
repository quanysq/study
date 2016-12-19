using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// params参数
  /// </summary>
  class C12
  {
    public static void Execute()
    {
      string[] ss = { "A", "B", "C" };
      string s = string.Format("{0} says: {1} and {0} are good friend.", ss);
      Console.WriteLine(s);
    }
  }
}
