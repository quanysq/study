using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 相对路径
  /// </summary>
  class C10
  {
    public static void Execute()
    {
      string s = "../../VS2013";
      DirectoryInfo di = new DirectoryInfo(s);
      string p = di.FullName;
      Console.WriteLine(p);
    }

    public static void Execute2()
    {
      Console.WriteLine(Path.GetFullPath("."));
    }

    public static void Execute3()
    {
      Console.WriteLine(Path.GetFullPath("./abc.txt"));
    }
  }
}
