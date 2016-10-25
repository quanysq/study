#define AB

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console000
{
  /// <summary>
  /// Conditional
  /// </summary>
  class Class1
  {
    public static void Execute(string[] args)
    {
      TestConditional();
    }

    [Conditional("AB")]
    private static void TestConditional()
    {
      Console.WriteLine("TestConditional");
    }
  }
}
