using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Console002
{
  /// <summary>
  /// 文件路径
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //string filepath = @"d:\1\2\3\4\1.txt";
      //FileInfo fi = new FileInfo(filepath);
      //string path = fi.DirectoryName;
      //Console.WriteLine(path);
      //if (!Directory.Exists(path))
      //{
      //  Console.WriteLine(path + "is not exists! now create directory!");
      //  Directory.CreateDirectory(@path);
      //  Console.WriteLine("now has create directory!");
      //}

      string filepath = @"d:\1\2\3\4\1.TXT";
      string ext      = Path.GetExtension(filepath);
      Console.WriteLine(ext);

      //string p = Path.Combine(@"c:\a", "tmp", "upgradereport");
      //Console.WriteLine(p);

      //string sss = @"/NBI/NBICustom/yang/a.xml";
      //string ccc = @"NBI/NBICustom";
      //int i = sss.IndexOf(ccc);
      //string aaa = sss.Substring(i + ccc.Length);
      //Console.WriteLine(aaa);
      //string bbb = @"d:\aa" + aaa.Replace("/","\\");
      //Console.WriteLine(bbb);

      //string sss = @"C:\Program Files\BDNA\Analyze\NBI\NBICustom\aaabb\a.xml";
      //Console.WriteLine(sss.Replace("\\", "/"));

      //string s = "";
      //if (string.IsNullOrEmpty(s)) Console.WriteLine("s is NullOrEmpty");

      //string sss = @"C:\Program Files\BDNA\Analyze\NBI\NBICustom\aaabb\a.xml";
      //int i = sss.LastIndexOf("\\");
      //string aaa = sss.Substring(i+1);
      //Console.WriteLine(aaa);

      //string s = "I am jacky杨";
      //byte[] b = Encoding.UTF8.GetBytes(s);
      //Console.WriteLine(b.Length);
      //Console.WriteLine(s.ToCharArray());

      //string s = "MYCOL";
      //string a = "\"" + s + "\"";
      //Console.WriteLine(s);
      //Console.WriteLine(a);

      //string s = @"C:\Program Files\BDNA\Normalize\";
      //string a = @"C:\Program Files\BDNA\Analyze";
      //Console.WriteLine(s);
      //if (s.EndsWith("\\")) s = s.Substring(0, s.Length - 1);
      //Console.WriteLine(s);
      //Console.WriteLine(a);

      //string filepath = @"\bin\hpudpuzzleconfig_spectuning.xml";
      //int kyesindex = @filepath.LastIndexOf("\\");
      //string filename = @filepath.Substring(kyesindex + 1);
      //Console.WriteLine(filename);

      //string[] ss = new string[3];
      //Console.WriteLine(ss.Length);
    }

    public void UnitTest()
    {
      string s = Console.ReadLine();
      Console.WriteLine(s.ToUpper());
    }
  }
}
