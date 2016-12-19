using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// default关键字
  /// ToString转换日期
  /// </summary>
  class C8
  {
    public static void Execute()
    {
      DateTime returnFullDate = default(DateTime);
      Console.WriteLine(returnFullDate.ToString("yyyy-MM-dd HH:mm:ss fff"));
    }
  }
}
