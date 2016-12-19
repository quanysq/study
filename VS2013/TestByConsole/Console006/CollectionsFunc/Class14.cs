using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// Linq to sql: 行转列， 去重复
  /// </summary>
  class C14
  {
    public static void Execute()
    {
      List<TabCol> l = new List<TabCol>();
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZZ" });
      l.Add(new TabCol { TableName = "BB", ColumnName = "YY" });
      l.Add(new TabCol { TableName = "AB", ColumnName = "ZA" });
      l.Add(new TabCol { TableName = "AD", ColumnName = "ZB" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZA" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZB" });
      l.Add(new TabCol { TableName = "AA", ColumnName = "ZB" });
      l = l.OrderBy(x => x.TableName).ThenBy(x => x.ColumnName).ToList();
      var ll = (from t in l group t by t.TableName into m select new { Tname = m.Key, Cname = string.Join(",", m.Select(n => n.ColumnName).Distinct()) }).ToList();
      foreach (var sll in ll)
      {
        Console.WriteLine(sll.Tname + "|" + sll.Cname);
      }
    }
  }
}
