using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// 任务并行化
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      Stopwatch sw = new Stopwatch();
      sw.Start();
      Console.WriteLine("===生成测试数据===");
      int[] d = BuildTestData();
      Console.WriteLine("Test Data Number: " + d.Length.ToString());
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
      Console.WriteLine("");
      Console.WriteLine("===传统方式===");
      sw.Reset();
      sw.Start();
      QuickSort_Sequential<int>(d);
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
      Console.WriteLine("");
      Console.WriteLine("===并行===");
      sw.Reset();
      sw.Start();
      QuickSort_Parallel<int>(d);
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
      Console.WriteLine("");
      Console.WriteLine("===并行(优化)===");
      sw.Reset();
      sw.Start();
      QuickSort_Parallel_Threshold<int>(d);
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
    }

    #region 传统
    public static void QuickSort_Sequential<T>(T[] items) where T : IComparable<T>
    {
      QuickSort_Sequential(items, 0, items.Length);
    }

    private static void QuickSort_Sequential<T>(T[] items, int left, int right) where T : IComparable<T>
    {
      if (left == right) return;
      int pivot = Partition(items, left, right);
      QuickSort_Sequential(items, left, pivot);
      QuickSort_Sequential(items, pivot + 1, right);
    }
    #endregion

    #region 并行
    private static void QuickSort_Parallel<T>(T[] items) where T : IComparable<T>
    {
      QuickSort_Parallel(items, 0, items.Length);
    }

    private static void QuickSort_Parallel<T>(T[] items, int left, int right) where T : IComparable<T>
    {
      if (left == right) return;
      int pivot = Partition(items, left, right);
      Task leftTask = Task.Run(() => QuickSort_Parallel(items, left, pivot));
      Task rightTask = Task.Run(() => QuickSort_Parallel(items, pivot + 1, right));
      Task.WaitAll(leftTask, rightTask);


    }
    #endregion

    #region 并行优化
    private static void QuickSort_Parallel_Threshold<T>(T[] items) where T : IComparable<T>
    {
      QuickSort_Parallel_Threshold(items, 0, items.Length);
    }

    private static void QuickSort_Parallel_Threshold<T>(T[] items, int left, int right) where T : IComparable<T>
    {
      if (left == right) return;
      int pivot = Partition(items, left, right);
      if (right - left > 500)
      {
        Parallel.Invoke(() => QuickSort_Parallel_Threshold(items, left, pivot),
                        () => QuickSort_Parallel_Threshold(items, pivot + 1, right));
      }
      else
      {
        QuickSort_Sequential(items, left, pivot);
        QuickSort_Sequential(items, pivot + 1, right);
      }
    }
    #endregion

    private static int Partition<T>(T[] items, int left, int right) where T : IComparable<T>
    {
      int pivotPosition = (right - left) / 2;
      T pivotValue = items[pivotPosition];
      Swap(ref items[right - 1], ref items[pivotPosition]);
      int store = left;
      for (int i = left; i < right - 1; ++i)
      {
        if (items[i].CompareTo(pivotValue) < 0)
        {
          Swap(ref items[i], ref items[store]);
          ++store;
        }
      }
      Swap(ref items[right - 1], ref items[store]);
      return store;
    }

    private static void Swap<T>(ref T a, ref T b)
    {
      T temp = a;
      a = b;
      b = temp;
    }

    private static int[] BuildTestData()
    {
      int iSeek = 100000;
      int[] td = new int[iSeek];
      for (int i = 0; i < iSeek; i++)
      {
        Random r = new Random();
        td[i] = r.Next(0, iSeek);
      }
      return td;
    }
  }
}
