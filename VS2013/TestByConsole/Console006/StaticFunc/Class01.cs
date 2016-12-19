using Console006.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StaticFunc
{
  class C1
  {
    public static void Execute()
    {
      TestStatic.TestStr = "a";
      Console.WriteLine(TestStatic.TestStr);
      TestStatic.TestStr = "b";
      Console.WriteLine(TestStatic.TestStr);
    }
  }
}
