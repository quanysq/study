using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// List排序
  /// </summary>
  class C16
  {
    public static void Execute()
    {
      List<string> l = new List<string>();
      l.Add("Z_DLLS");
      l.Add("Y_dlls");
      l.Add("BCD");
      l.Add("ABC");
      Console.WriteLine("before sort:");
      foreach (string s in l)
      {
        Console.WriteLine(s);
      }

      l.Sort();
      Console.WriteLine("\nafter sort:");
      foreach (string s in l)
      {
        Console.WriteLine(s);
      }

      l = (from ml in l orderby (ml.EndsWith("_DLLS", StringComparison.OrdinalIgnoreCase) ? 0:1), ml select ml).ToList();
      Console.WriteLine("\nafter custom sort:");
      foreach (string s in l)
      {
        Console.WriteLine(s);
      }
    }
  }
}
