using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 获取文件名
  /// </summary>
  class C19
  {
    public static void Execute()
    {
      string filepath = @"\bin\hpudpuzzleconfig_spectuning.xml";
      string filename = Path.GetFileName(filepath);
      Console.WriteLine(filename);
    }

    public static void Execute2()
    {
      string filepath = @"\bin\hpudpuzzleconfig_spectuning.xml";
      int kyesindex = @filepath.LastIndexOf("\\");
      string filename = @filepath.Substring(kyesindex + 1);
      Console.WriteLine(filename);
    }
  }
}
