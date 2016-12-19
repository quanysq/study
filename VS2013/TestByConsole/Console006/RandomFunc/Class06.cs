using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 扩展方法
  /// </summary>
  class C6
  {
    public static void Execute()
    {
      string s = "123abc";
      s.TellType();
    }
  }

  static class MyExtensions
  {
    public static void TellType(this string str)
    {
      Console.WriteLine("我是字符串：{0}", str);
    }
  }
}
