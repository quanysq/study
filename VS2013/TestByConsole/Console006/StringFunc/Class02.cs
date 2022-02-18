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

      Test("the VDI environment will include the full development workflow.  Downloading from GIT in the VDI will be very fast because VDI is in the US network.  Of course we'll need to test that to confirm");
      Test("the VDI environment");
      Test(null);
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

    static void Test(string message)
    {
      Console.WriteLine(message);
      if (!string.IsNullOrWhiteSpace(message) && message.Length > 50) message = message.Substring(0, 50);
      Console.WriteLine(message);
    }
  }
}
