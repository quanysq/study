using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 自定义排序: 
  /// 1. 自定义比较类Comp
  /// 2. OrderBy
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      List<string> l = new List<string>();
      l.Add("ABC");
      l.Add("BCD");
      l.Add("NBIDLL");
      l.Add("CDE");
      l.Sort(new Comp());
      foreach (string s in l) Console.WriteLine(s);
    }

    public static void Execute2()
    {
      List<TabCol> l = new List<TabCol>();
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZZ" });
      l.Add(new TabCol { TableName = "BB", ColumnName = "YY" });
      l.Add(new TabCol { TableName = "AB", ColumnName = "ZA" });
      l.Add(new TabCol { TableName = "AD", ColumnName = "ZB" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZA" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZB" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZB" });
      foreach (TabCol tc in l) Console.WriteLine(tc.TableName + ", " + tc.ColumnName);
      l = l.OrderBy(x => x.TableName).ThenBy(x => x.ColumnName).ToList();
      Console.WriteLine("===========after sort==========");
      foreach (TabCol tc in l) Console.WriteLine(tc.TableName + ", " + tc.ColumnName);
    }
  }
}
