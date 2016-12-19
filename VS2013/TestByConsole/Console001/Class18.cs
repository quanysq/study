using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 去除目录最后的\
  /// </summary>
  class C18
  {
    public static void Execute()
    {
      string s = @"C:\Program Files\BDNA\Normalize\";
      string a = @"C:\Program Files\BDNA\Analyze";
      Console.WriteLine(s);
      if (s.EndsWith("\\")) s = s.Substring(0, s.Length - 1);
      Console.WriteLine(s);
      Console.WriteLine(a);
    }
  }
}
