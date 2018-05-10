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
	
	  /* 行转列，并取各细项
    [TestMethod]
    public void ArrangeTechnopediaTableSqlListWithDuplicationData()
    {
      var filePath2 = Path.Combine(Upgrader.Server.Common.FileUtil.GetGeneratorInstallPath(), "SerializerFiles", "TechnopediaTableSqlListWithDuplicationData.json");
      var tablesqlList = SerializerUtil.Deserialize<List<ExtractorConfigTableSql>>(filePath2);
      BDNALogger.DEFAULT.InfoFormat("tablesqlList count: [{0}]", tablesqlList.Count);

      BDNALogger.DEFAULT.InfoFormat("Start to arrange tablesql list...");
      var list = (from x in tablesqlList
                  group x by new { x.SubscriptionHash, x.Vertical } into g
                  select new
                  {
                    xKey1 = g.Key.SubscriptionHash,
                    xKey2 = g.Key.Vertical,
                    cMy = g.ToList(),
                    cLong = g.LongCount(),
                    cName = string.Join("#", g.Select(n => n.CsvFileName))
                  }).ToList();
      BDNALogger.DEFAULT.InfoFormat("list.Count: [{0}]", list.Count);

      foreach (var item in list)
      {
        BDNALogger.DEFAULT.InfoFormat("[{0}], [{1}]", item.cName, item.cLong);
        foreach (var item1 in item.cMy)
        {
          BDNALogger.DEFAULT.InfoFormat(item1.CsvFileName);
        } 
      }
      Assert.IsTrue(true);
    }
	  */

    /* 高效率去重复
    public List<ExtractorConfigTableSql> TableSqlList
    {
      get
      {
        if (_tablesqlListWithDuplicationData.Count > 0)
        {
          _tablesqlList = _tablesqlListWithDuplicationData.GroupBy(x => x.Key).Select(x => x.First()).ToList();
        }
        return _tablesqlList;
      }
    }
    */
  }
}
