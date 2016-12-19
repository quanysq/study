using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 删除数组中的元素
  /// </summary>
  class C15
  {
    public static void Execute()
    {
      string[] ss = { "1", "2", "3", "1", "2" };
      foreach (string s in ss)
      {
        ss = ss.Where(x => x != "5").ToArray<string>();
      }
      Console.WriteLine("ss.Count: " + ss.Length.ToString());
      foreach (string s in ss)
      {
        Console.WriteLine(s);
      }
    }
  }
}
