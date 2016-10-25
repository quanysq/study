using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestToolsExample;

namespace UnitTestToolsExample.Test
{
  public class ClsBLL_Test
  {
    public bool Hellow_Test()
    {
      //1. Set the data needed to run the method

      //2. Run actual method
      ClsBLL c = new ClsBLL();
      string s = c.Hellow();

      //3. Compare with expected value, and return
      string expect = "Hello";
      return string.Equals(s, expect);
    }

    public bool Add_Test()
    {
      //1
      int x = 1;
      int y = 2;

      //2
      ClsBLL c = new ClsBLL();
      int z = c.Add(x, y);

      //3
      int expect = 3;
      return expect == z;
    }

    public bool Div_Test()
    {
      //1
      int x = 10;
      int y = 0;

      //2
      ClsBLL c = new ClsBLL();
      int z = c.Div(x, y);

      //3
      int expect = 0;
      return expect == z;
    }

    public bool NoReturnMethod_Test()
    {
      //1

      //2
      ClsBLL c = new ClsBLL();
      c.NoReturnMethod();

      //3
      return true;
    }

    public bool TestDB_Test()
    {
      //1

      //2
      ClsBLL c = new ClsBLL();
      DataTable dt = c.TestDB();

      //3
      int expect = 179;
      return expect == dt.Rows.Count;
    }
  }
}
