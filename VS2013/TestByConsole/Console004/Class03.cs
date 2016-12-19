using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// 并行编程
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      ExecuteWithParallel();

      Console.WriteLine(new string('=', 30));

      ExecuteWithOutParallel();
    }

    private static void ExecuteWithParallel()
    {
      List<int> list = new List<int>();
      
      for (int i = 0; i < 100; i++)
      {
        list.Add(i);
      }

      DateTime dt = DateTime.Now;

      Parallel.ForEach(list, x =>
      {
        System.Threading.Thread.Sleep(100);
        Console.WriteLine(x);
      });

      double time = (DateTime.Now - dt).TotalMilliseconds;

      Console.WriteLine(time);
    }

    private static void ExecuteWithOutParallel()
    {
      List<int> list = new List<int>();
      
      for (int i = 0; i < 100; i++)
      {
        list.Add(i);
      }

      DateTime dt = DateTime.Now;

      foreach (int x in list)
      {
        System.Threading.Thread.Sleep(100);
        Console.WriteLine(x);
      }

      double time = (DateTime.Now - dt).TotalMilliseconds;

      Console.WriteLine(time);
    }
  }
}
