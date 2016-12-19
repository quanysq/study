using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 1. 空数组的长度
  /// 2. 验证空字符串是否IsNullOrEmpty
  /// 3. string.Empty
  /// </summary>
  class C1
  {
    public static void Execute()
    {
      string[] s = { };
      Console.WriteLine(s.Length);
    }

    public static void Execute2()
    {
      string s = "";
      if (string.IsNullOrEmpty(s)) Console.WriteLine("s is NullOrEmpty");
    }

    public static void Execute3()
    {
      string s = string.Empty;
      Console.WriteLine(s);
    }

    public static void Execute4()
    {
      string[] ss = new string[3];
      Console.WriteLine(ss.Length);
    }

    public static void Execute5()
    {
      string s = @"Error : The process cannot access the file 'C:\BDNA\Data Platform\bin\bms.Common.dll' because it is being used by another process.";
      Console.WriteLine(s.IndexOf("Error"));
      Console.WriteLine(s.Substring(s.IndexOf("Error")));
    }
  }
}
