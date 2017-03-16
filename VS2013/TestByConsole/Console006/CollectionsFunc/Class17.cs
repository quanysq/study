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
  }
}
