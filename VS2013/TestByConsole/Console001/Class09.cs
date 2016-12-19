using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 1. RuntimeEnvironment.GetRuntimeDirectory
  /// 2. EnvironmentVariableTarget.Machine
  /// 3. Environment.CurrentDirectory
  /// 4. Environment.ExpandEnvironmentVariables
  /// </summary>
  class C9
  {
    public static void Execute()
    {
      Console.WriteLine("Runtime directory: {0}",  System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory());
      Console.WriteLine("EnvironmentVariableTarget.Machine: {0}", EnvironmentVariableTarget.Machine);
      Console.WriteLine("System.Environment.CurrentDirectory: {0}", System.Environment.CurrentDirectory);

      string p1 = System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(@"%BMS_HOME%\Abc\abc.txt"));
      string p2 = System.IO.Path.GetFullPath(Environment.ExpandEnvironmentVariables(@"d:\a\b\c.txt"));
      Console.WriteLine(p1);
      Console.WriteLine(p2);
    }
  }
}
