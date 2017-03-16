using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 获取文件名
  /// </summary>
  class C19
  {
    public static void Execute()
    {
      string filepath = @"\bin\hpudpuzzleconfig_spectuning.xml";
      string filename = Path.GetFileName(filepath);
      Console.WriteLine(filename);
    }

    public static void Execute2()
    {
      string filepath = @"\bin\hpudpuzzleconfig_spectuning.xml";
      int kyesindex = @filepath.LastIndexOf("\\");
      string filename = @filepath.Substring(kyesindex + 1);
      Console.WriteLine(filename);
    }

    public static void Execute3()
    {
      string filepath  = "/UserReports/test1.xanalyzer";
      string filename1 = Path.GetFileName(filepath);
      string filename2 = Path.GetFileNameWithoutExtension(filepath);
      Console.WriteLine(filename1);
      Console.WriteLine(filename2);

      /*
       * Result:
       * test1.xanalyzer
       * test1
       */ 
    }

    public static void Execute4()
    {
      string filepath  = @"/UserReports/"; //same as \UserReports
      //Console.WriteLine(filepath.Substring(0, filepath.Length - 1));
      string filename1 = Path.GetFileName(filepath);
      string filename2 = Path.GetFileNameWithoutExtension(filepath);
      Console.WriteLine(filename1);
      Console.WriteLine(filename2);

      /*
       * Result:
       * UserReports
       * UserReports
       */ 
    }
  }
}
