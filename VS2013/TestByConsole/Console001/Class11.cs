using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 1. 获取父目录
  /// 2. GetDirectoryName
  /// 3. 截取目录
  /// </summary>
  class C11
  {
    public static void Execute()
    {
      string parent = Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName;
      Console.WriteLine(parent);
    }

    public static void Execute2()
    {
      Console.WriteLine(Path.GetDirectoryName(@"c:\a\c\b.txt"));
      /*
       * Result:
       * c:\a\c
       */ 
    }

    public static void Execute3()
    {
      string sss = @"/NBI/NBICustom/yang/a.xml";
      string ccc = @"NBI/NBICustom";
      int i = sss.IndexOf(ccc);
      string aaa = sss.Substring(i + ccc.Length);
      Console.WriteLine(aaa);
      string bbb = @"d:\aa" + aaa.Replace("/","\\");
      Console.WriteLine(bbb);
    }

    public static void Execute4()
    {
      Console.WriteLine(Path.GetDirectoryName(@"/UserReports"));

      /*
       * Result:
       * \
       */ 
    }
  }
}
