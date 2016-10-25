using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console023
{
  /// <summary>
  /// 多线程
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //C1.Execute();     //单线程
      
      C2.Execute();     //多线程

      Console.ReadKey();
    }
  }

  
}
