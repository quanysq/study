using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;
using System.Diagnostics;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 1. 测试List增加10000000要多久
  /// 2. Stopwatch
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      List<int> testlist = new List<int>();
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; i < 10000000; i++)
      {
        testlist.Add(i);
      }
      sw.Stop();
      Console.WriteLine(sw.ElapsedMilliseconds);
    }
  }
}
