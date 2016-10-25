using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console012
{
  /// <summary>
  /// 删除数组中的元素
  /// </summary>
  class Program
  {
    static void Main(string[] args)
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
