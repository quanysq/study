using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 验证List是否按顺序输出
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      List<string> l = new List<string>();
      l.Add("02");
      l.Add("01");
      l.Add("05");
      l.Add("06");
      foreach (string s in l) Console.WriteLine(s);
    }
  }
}
