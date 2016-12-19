using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// GetDirectories返回值
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      string[] gg = System.IO.Directory.GetDirectories(@"D:\VS2013\Updateset\Pageages");
      Console.WriteLine(gg[0]);
    }
  }
}
