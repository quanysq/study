using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 动态编程[dynamic]
  /// </summary>
  class C7
  {
    public static void Execute()
    {
      DynamickWork dw = new DynamickWork();

      Console.WriteLine(dw.Work(100, 1));
      Console.WriteLine(dw.Work("100", "1"));

      Console.WriteLine("===");

      dynamic d = new TestObj();
      d.TestMethod("Hi, I am dynamic");
    }
  }

  class DynamickWork
  {
    dynamic Name { get; set; }

    private dynamic value = 100;

    public dynamic Work(dynamic x, dynamic y)
    {
      dynamic result = x + y;
      return result;
    }
  }

  class TestObj
  {
    public void TestMethod(string s)
    {
      Console.WriteLine(s);
    }
  }
}
