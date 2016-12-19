using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 字符串转成二进制
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      string s = "I am jacky杨";
      byte[] b = Encoding.UTF8.GetBytes(s);
      Console.WriteLine(b.Length);
      Console.WriteLine(s.ToCharArray());
    }
  }
}
