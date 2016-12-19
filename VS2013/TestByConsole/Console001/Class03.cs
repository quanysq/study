using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// GetDirectories("*.*")
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      DirectoryInfo dir = new DirectoryInfo(@"D:\4.3\Patch");
      foreach (DirectoryInfo d in dir.GetDirectories("*.*"))
      {
        Console.WriteLine(d.FullName);
      }
    }
    
  }
}
