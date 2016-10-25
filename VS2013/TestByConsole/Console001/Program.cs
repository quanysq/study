using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console001
{
  /// <summary>
  /// StreamWriter
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      C1.Execute();

      //***********************************************************************************************
      //string filepathr = @"D:\临时\RestoreReport\analyzer_report_upgrade_test.good.xanalyzer";
      //string filenote = "";
      
      //==============================================
      //using (FileStream sr = new FileStream(filepathr, FileMode.Open, FileAccess.Read))
      //{
      //  byte[] filedata = new byte[sr.Length];
      //  sr.Seek(0, SeekOrigin.Begin);
      //  for (int i = 0; i < sr.Length; i++)
      //  {
      //    filedata[i] = (byte)sr.ReadByte();
      //  }
      //  filenote = Convert.ToBase64String(filedata);
      //}

      //byte[] bdata = Convert.FromBase64String(filenote);
      //Stream stream = new MemoryStream(bdata);
      //using (StreamReader sr = new StreamReader(stream))
      //{
      //  filenote = sr.ReadToEnd();
      //  Console.WriteLine(filenote);
      //}
      //stream.Close();

      //==============================================
      //string filepathw = @"D:\临时\RestoreReport\analyzer_report_upgrade_test_good_test1.xanalyzer";
      //using (FileStream fs = new FileStream(filepathw, FileMode.Create, FileAccess.ReadWrite))
      //{
      //  byte[] bdata = Convert.FromBase64String(filenote);
      //  fs.Write(bdata, 0, bdata.Length);
      //}

      //==============================================
      //using (StreamReader sr = new StreamReader(filepathr, Encoding.UTF8))
      //{
      //  filenote = sr.ReadToEnd();
      //}

      //==============================================
      //string filepathw = @"D:\临时\RestoreReport\analyzer_report_upgrade_test_test2.xanalyzer";
      //using (StreamWriter sw = new StreamWriter(filepathw, false, Encoding.UTF8))
      //{
      //  sw.Write(filenote);
      //}
      Console.WriteLine("OK");
    }

    //StreamWriter (string path)                                以默认的形式进行，字符的编码依旧是UTF-8
    //StreamWriter (string path,bool append)                    参数append为false，则是覆盖，如果为true,则是追加
    //StreamWriter (string path,bool append,Encoding encoding)  参数encoding具体的字符编码Encoding,默认的情况是UTF-8
    //如果文件不存在会创建文件，但目录不存在会出错
  }
}
