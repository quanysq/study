using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// Path.Combine
  /// </summary>
  class C17
  {
    public static void Execute()
    {
      string p = Path.Combine(@"c:\a", "tmp", "upgradereport");
      Console.WriteLine(p);
    }
  }
}
