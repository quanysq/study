using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// HashSet
  /// </summary>
  public class C17
  {
    public static void Execute()
    {
      // CreateHashSet()
      IntersectHashSet();
    }

    private static void CreateHashSet()
    {
      HashSet<string> hashSet = new HashSet<string>();
      hashSet.Add("AA");
      hashSet.Add("aa");
      hashSet.Add("BB");
      hashSet.Add("AA");
      foreach (var i in hashSet)
      {
        Console.WriteLine(i);
      }

      /*
       * 结论：
       * HashSet<T>能够自动排除掉重复项，如上例，集合中只有2项
       */ 
    }

    private static void IntersectHashSet()
    {
      HashSet<string> hashSet1 = new HashSet<string>();
      hashSet1.Add("AA");
      hashSet1.Add("aa");
      hashSet1.Add("BB");
      hashSet1.Add("AA");

      HashSet<string> hashSet2 = new HashSet<string>();
      hashSet2.Add("AA");
      hashSet2.Add("CC");
      hashSet2.Add("aa");

      var hashSet3 = hashSet1.Intersect(hashSet2);
      var count = hashSet3.Count();
      Console.WriteLine("Count: [{0}]", count);
      Console.WriteLine("===============");
      if (count == 0)
      {
        Console.WriteLine("No data!");
        return;
      }
      foreach (var i in hashSet3)
      {
        Console.WriteLine(i);
      }
    }
  }
}
