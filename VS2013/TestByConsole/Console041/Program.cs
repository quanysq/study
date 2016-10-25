using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console041
{
  class Program
  {
    static void Main(string[] args)
    {
      DynamickWork dw = new DynamickWork();

      Console.WriteLine(dw.Work(100, 1));
      Console.WriteLine(dw.Work("100", "1"));

      Console.WriteLine("===");

      dynamic d = new TestObj();
      d.TestMethod("Hi, I am dynamic");
    }
  }

  public class DynamickWork
  {
    dynamic Name { get; set; }

    private dynamic value = 100;

    public dynamic Work(dynamic x, dynamic y)
    {
      dynamic result = x + y;
      return result;
    }
  }

  public class TestObj
  {
    public void TestMethod(string s)
    {
      Console.WriteLine(s);
    }
  }
}
