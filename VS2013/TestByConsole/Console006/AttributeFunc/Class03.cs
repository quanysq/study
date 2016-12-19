#define AB

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.AttributeFunc
{
  /// <summary>
  /// Conditional
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      TestConditional();
    }

    [Conditional("AB")]
    static void TestConditional()
    {
      Console.WriteLine("TestConditional");
    }
  }
}
