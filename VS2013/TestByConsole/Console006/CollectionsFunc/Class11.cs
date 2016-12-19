using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// PLINQ
  /// </summary>
  class C11
  {
    public static void Execute()
    {
      var list = new List<int> { 1, 3, 4, 5, 6 };
      var ls = list.AsParallel().Select(x => x + 10);
      foreach (int i in ls)
      {
        Console.WriteLine(i);
      }
    }
  }
}
