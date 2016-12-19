using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// TrimEnd
  /// </summary>
  class C15
  {
    public static void Execute()
    {
      string cellValue = "SWSW_+DM8458+SP10179384+VG42940073";
      Console.WriteLine(cellValue.TrimEnd());
      Console.WriteLine(cellValue.Length);
      Console.WriteLine(Convert.ToString(cellValue));
    }
  }
}
