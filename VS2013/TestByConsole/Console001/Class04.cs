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
      // ExcludeSpecificDirectoryUsingDirectoryInfoEquality();
      // ExcludeSpecificDirectoryUsingEnDirectoryEquality();
      ExcludeSpecificDirectoryUsingWhere();
    }

    private static void ExcludeSpecificDirectoryUsingDirectoryInfoEquality()
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

    private static void ExcludeSpecificDirectoryUsingEnDirectoryEquality()
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

    private static void ExcludeSpecificDirectoryUsingWhere()
    {
      string currentTempOutputPath = @"D:\Temp\CurrentTempTest";
      string folderPrefix = DateTime.Now.ToString("yyyyMMdd");
      DirectoryInfo dirCurrentTempOutput = new DirectoryInfo(currentTempOutputPath);
      if (!dirCurrentTempOutput.Exists) return;
      var subDirectories = dirCurrentTempOutput.GetDirectories().Where(x => !x.Name.StartsWith(folderPrefix));
      foreach (DirectoryInfo dir in subDirectories)
      {
        Console.WriteLine("Delete temp folder: [{1}, {0}]", dir.FullName, dir.Name);
        dir.Delete(true);
      }
    }
  }
}
