using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// 1. FileStream
  /// 2. 二进制数据转成Base64字符串
  /// 3. Base64字符串转成二进制
  /// </summary>
  class C14
  {
    public static void Execute()
    {
      string filepathr = @"D:\临时\RestoreReport\analyzer_report_upgrade_test.good.xanalyzer";
      string filenote = "";
      
      using (FileStream sr = new FileStream(filepathr, FileMode.Open, FileAccess.Read))
      {
        byte[] filedata = new byte[sr.Length];
        sr.Seek(0, SeekOrigin.Begin);
        for (int i = 0; i < sr.Length; i++)
        {
          filedata[i] = (byte)sr.ReadByte();
        }
        filenote = Convert.ToBase64String(filedata);
      }

      byte[] bdata = Convert.FromBase64String(filenote);
      Stream stream = new MemoryStream(bdata);
      using (StreamReader sr = new StreamReader(stream))
      {
        filenote = sr.ReadToEnd();
        Console.WriteLine(filenote);
      }
      stream.Close();
    }

    public static void Execute2()
    {
      string filepathw = @"D:\临时\RestoreReport\analyzer_report_upgrade_test_good_test1.xanalyzer";
      string filenote = "";
      using (FileStream fs = new FileStream(filepathw, FileMode.Create, FileAccess.ReadWrite))
      {
        byte[] bdata = Convert.FromBase64String(filenote);
        fs.Write(bdata, 0, bdata.Length);
      }
    }
  }
}
