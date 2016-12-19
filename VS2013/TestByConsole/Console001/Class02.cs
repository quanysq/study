using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// StreamWriter
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      string filepath = @"d:\abc.txt";
      string filenote = "aaaaaaa";

      using (StreamWriter sw = new StreamWriter(filepath, false, Encoding.UTF8))
      {
        sw.Write(filenote);
      }
    }

    public static void Execute2()
    {
      string filepath = @"d:\abc.txt";
      string filenote = "aaaaaaa";
      using (StreamReader sr = new StreamReader(filepath, Encoding.UTF8))
      {
        filenote = sr.ReadToEnd();
      }
    }

    //StreamWriter (string path)                                以默认的形式进行，字符的编码依旧是UTF-8
    //StreamWriter (string path,bool append)                    参数append为false，则是覆盖，如果为true,则是追加
    //StreamWriter (string path,bool append,Encoding encoding)  参数encoding具体的字符编码Encoding,默认的情况是UTF-8
    //如果文件不存在会创建文件，但目录不存在会出错
  }
}
