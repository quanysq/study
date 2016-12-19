using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 1. 排除指定的目录
  /// 2. 比较两个对象是否相等
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      Console.WriteLine("start: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff"));
      DirectoryInfo dir = new DirectoryInfo(@"D:\4.3\Patch");
      List<DirectoryInfo> dirlist = dir.GetDirectories("*").ToList();
      Console.WriteLine(dirlist.Count());
      IEnumerable<DirectoryInfo> derlist = dir.GetDirectories("cvs");
      dirlist = dirlist.Except(derlist, new DirectoryInfoEquality()).ToList();
      Console.WriteLine(dirlist.Count());
      Console.WriteLine("end: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff"));
      foreach (DirectoryInfo d in dirlist)
      {
        Console.WriteLine(d.Name);
      }
    }

    public static void Execute2()
    {
      Console.WriteLine("============");
      Console.WriteLine("start: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff"));
      DirectoryInfo dir = new DirectoryInfo(@"D:\4.3\Patch");
      List<EnDirectory> dirlist = (from dirs in dir.GetDirectories() select new EnDirectory { FullName = dirs.FullName, Name = dirs.Name }).ToList();
      Console.WriteLine(dirlist.Count);
      List<EnDirectory> derlist = (from dirs in dir.GetDirectories("cvs") select new EnDirectory { FullName = dirs.FullName, Name = dirs.Name }).ToList();
      dirlist = dirlist.Except(derlist, new EnDirectoryEquality()).ToList();
      Console.WriteLine(dirlist.Count);
      Console.WriteLine("end: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ffffff"));
      foreach (EnDirectory d in dirlist)
      {
        Console.WriteLine(d.FullName);
      }
    }
  }
}
