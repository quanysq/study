using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// Except
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      List<string> file1 = new List<string>();
      file1.Add("1");
      file1.Add("2");
      file1.Add("3");
      Console.WriteLine(file1.Contains("1"));
      List<string> file2 = new List<string>();
      file2.Add("1");
      file2.Add("2");
      file2.Add("3");
      Console.WriteLine(file1[0]);
      file1 = file1.Except(file2).ToList();
      if (file1.Count == 0) Console.WriteLine("no data");
      foreach (string s in file1) Console.WriteLine(s);
    }
  }
}
