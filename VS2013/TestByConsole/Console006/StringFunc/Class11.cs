using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// is 和 类型转换
  /// </summary>
  class C11
  {
    public static void Execute()
    {
      object o = true;
      if (o is string) Console.WriteLine("is bool");

      bool b = (bool)Convert.ChangeType(0, typeof(bool));
      Console.WriteLine(b.ToString());

      string s = (string)Convert.ChangeType("ABC", typeof(string));
      Console.WriteLine(s);

      int i = (int)Convert.ChangeType("", typeof(int));   //会出错
      Console.WriteLine(i);

      string ss = "";
      if (ss is string) Console.WriteLine("is string");

      bool b1 = false;
      object obj1 = true;
      if (obj1 is bool) b1 = (bool)obj1;
      Console.WriteLine(b1.ToString());
    }
  }
}
