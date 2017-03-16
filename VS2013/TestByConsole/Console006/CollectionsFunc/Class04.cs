using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 判断两个相同类型的List是否相等
  /// </summary>
  class C4
  {
    public static void Execute()
    {
      List<string> l1 = new List<string>();
      l1.Add("1");
      l1.Add("2");
      List<string> l2 = new List<string>();
      l2.Add("1");
      l2.Add("2");
      Console.WriteLine(l1.All(l2.Contains) && l1.Count == l2.Count);
    }
  }
}
