using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// List转字符串
  /// </summary>
  class C5
  {
    public static void Execute()
    {
      List<int> l = new List<int>();
      l.Add(1);
      l.Add(3);
      l.Add(2);
      string s = string.Join(",", l);
      Console.WriteLine(s);

      
    }

    public static void Execute2()
    {
      List<string> l = new List<string>();
      l.Add("1");
      l.Add("3");
      l.Add("2");
      l.Add("5");
      string s = string.Join(",", l);
      if (s == "") Console.WriteLine(s + "b");

      string ss = "'" + string.Join("','", l) + "'";
      Console.WriteLine(ss);
    }
  }
}
