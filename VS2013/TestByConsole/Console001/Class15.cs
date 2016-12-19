using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 创建嵌套目录
  /// </summary>
  class C15
  {
    public static void Execute()
    {
      string filepath = @"d:\1\2\3\4\1.txt";
      FileInfo fi = new FileInfo(filepath);
      string path = fi.DirectoryName;
      Console.WriteLine(path);
      if (!Directory.Exists(path))
      {
        Console.WriteLine(path + "is not exists! now create directory!");
        Directory.CreateDirectory(@path);
        Console.WriteLine("now has create directory!");
      }
    }
  }
}
