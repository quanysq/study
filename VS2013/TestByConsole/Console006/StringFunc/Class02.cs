using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 1. Substring
  /// 2. LastIndexOf
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      string s = "TMP_tcat_windows7_compatibility";
      Console.WriteLine(s.Length);
      s = s.Substring(0, 27) + "_" + DateTime.Now.ToString("ff");
      Console.WriteLine(s);
      Console.WriteLine(s.Length);
    }

    public static void Execute2()
    {
      string sss = @"C:\Program Files\BDNA\Analyze\NBI\NBICustom\aaabb\a.xml";
      int i = sss.LastIndexOf("\\");
      string aaa = sss.Substring(i + 1);
      Console.WriteLine(aaa);
    }

    public static void Execute3()
    {
      string s = "5.0.0.1050";
      Console.WriteLine(s.Substring(6, 4));
    }
  }
}
