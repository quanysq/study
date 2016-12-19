using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console004
{
  /// <summary>
  /// 并发
  /// </summary>
  public class C1
  {
    public static void Execute()
    {
      IEnumerable<int> l = null;

      Stopwatch sw = new Stopwatch();
      Console.WriteLine("===传统方式===");
      sw.Start();
      l = PrimesInRange_Sequential(0, 100000);
      Console.WriteLine("Number: " + l.Count().ToString());
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
      Console.WriteLine("");
      Console.WriteLine("===并发（多线程）===");
      sw.Reset();
      sw.Start();
      l = PrimesInRange_Thread(0, 100000);
      Console.WriteLine("Number: " + l.Count().ToString());
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
      Console.WriteLine("");
      Console.WriteLine("===并发（线程池）===");
      sw.Reset();
      sw.Start();
      l = PrimesInRange_ThreadPool(0, 100000);
      Console.WriteLine("Number: " + l.Count().ToString());
      sw.Stop();
      Console.WriteLine("Time(ms): " + sw.ElapsedMilliseconds.ToString());
    }

    /// <summary>
    /// 传统方式
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    static IEnumerable<int> PrimesInRange_Sequential(int start, int end)
    {
      List<int> primes = new List<int>();
      for (int i = start; i < end; i++)
      {
        if (IsPrime(i)) primes.Add(i);
      }
      return primes;
    }

    /// <summary>
    /// 多线程
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    static IEnumerable<int> PrimesInRange_Thread(int start, int end)
    {
      List<int> primes = new List<int>();
      int range = end - start;
      int threadNum = (int)Environment.ProcessorCount;
      int chunk = range / threadNum;
      Thread[] threads = new Thread[threadNum];
      for (int i = 0; i < threadNum; i++)
      {
        int chunkStart = start + i * chunk;
        int chunkEnd = chunkStart + chunk;
        threads[i] = new Thread(() =>
        {
          for (int number = chunkStart; number < chunkEnd; ++number)
          {
            if (IsPrime(number))
            {
              lock (primes)
              {
                primes.Add(number);
              }
            }
          }

        });

        threads[i].Start();
      }

      foreach (Thread thread in threads)
      {
        thread.Join();
      }
      return primes;
    }

    /// <summary>
    /// 多线程（线程池）
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <returns></returns>
    static IEnumerable<int> PrimesInRange_ThreadPool(int start, int end)
    {
      List<int> primes = new List<int>();
      const int chunkSize = 100;
      int completed = 0;
      ManualResetEvent allDone = new ManualResetEvent(false);
      int chunks = (end - start) / chunkSize;

      for (int i = 0; i < chunks; i++)
      {
        int chunkStart = start + i * chunkSize;
        int chunkEnd = chunkStart + chunkSize;
        ThreadPool.QueueUserWorkItem(_ =>
        {
          for (int number = chunkStart; number < chunkEnd; number++)
          {
            if (IsPrime(number))
            {
              lock (primes)
              {
                primes.Add(number);
              }
            }
          }

          if (Interlocked.Increment(ref completed) == chunks)
          {
            allDone.Set();
          }

        });
      }

      allDone.WaitOne();
      return primes;
    }

    static bool IsPrime(int number)
    {
      if (number == 2)
        return true;
      for (int divisor = 2; divisor < number; divisor += 1)
      {
        if (number % divisor == 0) return false;
      }
      return true;
    }
  }
}
