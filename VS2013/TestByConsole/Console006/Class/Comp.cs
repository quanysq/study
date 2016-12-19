using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.Class
{
  class Comp : Comparer<string>
  {
    public override int Compare(string x, string y)
    {
      Console.WriteLine("x: {0}", x);
      Console.WriteLine("y: {0}", y);

      if (x == "NBIDLL")
        return -1;
      else
        return 1;
    }
  }
}
