using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// bool转成int
  /// </summary>
  class C9
  {
    public static void Execute()
    {
      Console.WriteLine(Convert.ToInt16(true));
      Console.WriteLine(Convert.ToInt16(false));
    }
  }
}
