using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 寻找非空的目录
  /// </summary>
  class Class07
  {
    public static void Execute()
    {
      DirectoryInfo dir3 = new DirectoryInfo(@"D:\VS2013\Updateset\Pageages");
      List<DirectoryInfo> dirlist3 = dir3.GetDirectories("*").ToList();
      dirlist3 = dirlist3.FindAll(x => x.GetFileSystemInfos().Length > 0);
      foreach (DirectoryInfo d in dirlist3)
      {
        Console.WriteLine(d.Name);
      }
    }

    public static void Execute2()
    {
      DirectoryInfo di = new DirectoryInfo(@"D:\VS2013\Updateset\Pageages");
      Console.WriteLine(di.GetFileSystemInfos().Length);
    }
  }
}
