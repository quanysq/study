using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  class C3
  {
    public static void Execute()
    {
      System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"(?<=[(（])[^（）()]*(?=[)）])");
      System.Text.RegularExpressions.Match m = reg.Match("NVARCHAR(500)");
      int len = 1024;
      if (m.Success)
      {
        Int32.TryParse(m.Value, out len);
        Console.WriteLine(m.Value);
        Console.WriteLine(len);
      }
    }
  }
}
