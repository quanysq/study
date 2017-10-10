using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 左右补位
  /// </summary>
  public class C22
  {
    public static void Execute()
    {
      Console.WriteLine("1".PadLeft(2, '0'));
      int totalNum = "Wait".Length + 2;
      Console.WriteLine("Wait".PadRight(totalNum, '.'));
    }
  }
}
