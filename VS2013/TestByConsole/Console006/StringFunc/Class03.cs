using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 字符串转成二进制
  /// </summary>
  class C3
  {
    public static void Execute()
    {
      // Convert2Binary();
      StringConvert();
    }

    static void Convert2Binary()
    {
      string s = "I am jacky杨";
      byte[] b = Encoding.UTF8.GetBytes(s);
      Console.WriteLine(b.Length);
      Console.WriteLine(s.ToCharArray());
    }

    static void StringConvert()
    {
      var filepath = @"D:\Work\TestData\Conf\QuestionString.txt";
      using (StreamReader sr = new StreamReader(filepath))
      {
        string s = sr.ReadToEnd();
        Console.WriteLine("String 1: [{0}]", s);
      }

      using (StreamReader sr = new StreamReader(filepath, Encoding.UTF32))
      {
        string s = sr.ReadToEnd();
        Console.WriteLine("String 3: [{0}]", s);
        var ss = s;
        Console.WriteLine("String 3: [{0}]", ss.Replace("?", ""));
      }

      using (StreamReader sr = new StreamReader(filepath, Encoding.ASCII))
      {
        string s = sr.ReadToEnd();
        Console.WriteLine("String 2: [{0}]", s);
        //Console.WriteLine("String 3: [{0}]", s.Replace("?",""));
        ConvertString(s);
      }


    }

    static void ConvertString(string u16s)
    {
      //4种编码  
      Encoding utf8 = Encoding.UTF8;
      Encoding utf16 = Encoding.Unicode;
      Encoding gb = Encoding.GetEncoding("gbk");
      Encoding b5 = Encoding.GetEncoding("big5");

      //转换得到4种编码的字节流  
      byte[] u16bytes = utf16.GetBytes(u16s);
      byte[] u8bytes = Encoding.Convert(utf16, utf8, u16bytes);
      byte[] gbytes = Encoding.Convert(utf16, gb, u16bytes);
      byte[] bbytes = Encoding.Convert(utf16, b5, u16bytes);

      Console.Write("unicode: ");
      foreach (byte c in u16bytes)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("utf8: ");
      foreach (byte c in u8bytes)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("gbk: ");
      foreach (byte c in gbytes)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("big5: ");
      foreach (byte c in bbytes)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      //得到4种编码的string  
      string u8s = utf8.GetString(u8bytes);
      string gs = gb.GetString(gbytes);
      string bs = b5.GetString(bbytes);

      Console.WriteLine("unicode: " + u16s + " " + u16s.Length.ToString());
      Console.WriteLine("utf8: " + u8s + " " + u16s.Length.ToString());
      Console.WriteLine("gbk: " + gs + " " + gs.Length.ToString());
      Console.WriteLine("big5: " + bs + " " + bs.Length.ToString());

      Console.Write("unicode: ");
      foreach (char c in u16s)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("utf8: ");
      foreach (char c in u8s)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("gb2312: ");
      foreach (char c in gs)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      Console.Write("big5: ");
      foreach (char c in bs)
      {
        Console.Write(((int)c).ToString("x") + " ");
      }
      Console.WriteLine();

      //以下实测OK
      //u16s = "f9f3b266f0e3921597b37cfb723b8ef793ccae67__";
      Encoding srcEnc = Encoding.GetEncoding("Utf-8", new EncoderReplacementFallback(""), new DecoderReplacementFallback());
      //Encoding srcEnc = Encoding.GetEncoding("Utf-8");
      Encoding tgtEnc = Encoding.GetEncoding("ASCII", new EncoderReplacementFallback(""), new DecoderReplacementFallback());
      byte[] src = tgtEnc.GetBytes(u16s);
      byte[] tgt = Encoding.Convert(srcEnc, tgtEnc, src);
      string result = srcEnc.GetString(tgt);
      Console.WriteLine(result);
    }
  }
}
