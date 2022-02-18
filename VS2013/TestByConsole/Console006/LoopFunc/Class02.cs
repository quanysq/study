using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.LoopFunc
{
  public class C2
  {
    public static void Execute()
    {
      //产生测试资料
      List<int> testData = new List<int>();
      Random Rand = new Random();
      //产生乱数列表
      for (int i = 0; i < 1000000; i++)
      {
        testData.Add(Rand.Next(1000));
      }
      //打印正确结果
      Console.WriteLine(testData.Sum());

      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine();
        TestFor(testData);
        TestParallelFor(testData);
        TestParallelForeach(testData);
      }

      List<int> testData2 = new List<int>();
      for (int i = 0; i < 10000; i++)
      {
        testData2.Add(Rand.Next(100));
      }
      for (int i = 0; i < 5; i++)
      {
        Console.WriteLine();
        TestFor(testData2);
        TestParallelFor(testData2);
        TestParallelForeach(testData2);
      }
    }

    static void TestFor(List<int> testData)
    {
      DateTime time1 = DateTime.Now;
      foreach (var item in testData)
      {
        item.ToString();
      }
      Console.WriteLine(string.Format("ForEach:     t{0} in {1}", testData.Sum(), (DateTime.Now - time1).TotalMilliseconds));
    }

    static void TestParallelFor(List<int> testData)
    {
      ParallelOptions options = new ParallelOptions();
      options.MaxDegreeOfParallelism = 4;

      DateTime time1 = DateTime.Now;
      Parallel.For(0, testData.Count, options, (i, loopState) =>
      {
        testData[i].ToString();
      });
      Console.WriteLine(string.Format("Parallel.For:   t{0} in {1}", testData.Sum(), (DateTime.Now - time1).TotalMilliseconds));
    }

    static void TestParallelForeach(List<int> testData)
    {
      ParallelOptions options = new ParallelOptions();
      options.MaxDegreeOfParallelism = 4;

      DateTime time1 = DateTime.Now;
      Parallel.ForEach(testData, options, (item, loopState) =>
      {
        item.ToString();
        //throw new Exception("Throw an error");
      });
      Console.WriteLine(string.Format("Parallel.ForEach:t{0} in {1}", testData.Sum(), (DateTime.Now - time1).TotalMilliseconds));
    }
  }
}
