using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 1. SearchOption
  /// 2. AddRange
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      DirectoryInfo Dir = new DirectoryInfo(@"D:\VS2013\Updateset\Patch");
      List<string> file1 = new List<string>();
      List<string> files = (from f in Dir.GetFiles("*.*", SearchOption.TopDirectoryOnly) select f.FullName).ToList();
      Console.WriteLine(files.Count);
      Console.WriteLine(file1.Count);
      file1.AddRange(files);
      List<string> file2 = new List<string>();
      file1.AddRange(file2);
      Console.WriteLine(file1.Count);
    }

    public static void Execute2()
    {
      DirectoryInfo Dir = new DirectoryInfo(@"D:\VS2013\Updateset\Patch\US50_201510_BUG04767_ForTest");
      FileInfo[] file1 = Dir.GetFiles("*.*", SearchOption.AllDirectories);
      foreach (FileInfo fi in file1)
      {
        Console.WriteLine(fi.FullName);
      }
      Console.WriteLine("=============================");
      FileInfo[] file2 = Dir.GetFiles("AnalyzePatchSet\\*.*", SearchOption.AllDirectories);
      foreach (FileInfo fi in file2)
      {
        Console.WriteLine(fi.FullName);
      }
    }

    public static void Execute3()
    {
      string dir = @"D:\VS2013\Updateset\Patch";
      List<string> filelist = Directory.GetFiles(dir, "*.*").ToList();    //返回文件的全路径
      foreach (string filename in filelist)
      {
        Console.WriteLine(filename);
      }
    }
  }
}
