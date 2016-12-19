using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 获取扩展名
  /// </summary>
  class C16
  {
    public static void Execute()
    {
      string filepath = @"d:\1\2\3\4\1.TXT";
      string ext      = Path.GetExtension(filepath);
      Console.WriteLine(ext);
    }
  }
}
