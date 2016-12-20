using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Console001
{
  /// <summary>
  /// MD5加密
  /// </summary>
  class C21
  {
    public static void Execute()
    {
      string md5_1 = GetMd5Str16(@"123456");
      string md5_2 = GetMd5Str32(@"123456");

      Console.WriteLine("md5_1 is [{0}]", md5_1);
      Console.WriteLine("md5_2 is [{0}]", md5_2);

      string md5_3 = GetFileMD5(@"D:\document\MorganProject\SRTMS\Export\Device_1.csv");
      string md5_4 = GetMD5WithFilePath(@"D:\document\MorganProject\SRTMS\Export\Device_1.csv");
      Console.WriteLine("md5_3 is [{0}]", md5_3);
      Console.WriteLine("md5_4 is [{0}]", md5_4);
    }

    #region md5加密
    /// <summary>
    /// MD5 16位加密 加密后密码为小写
    /// </summary>
    /// <param name="ConvertString"></param>
    /// <returns></returns>
    static string GetMd5Str16(string ConvertString)
    {
      try
      {
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
          string t2 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
          return t2.Replace("-", "").ToLower();
        }
      }
      catch { return null; }
    }

    /// <summary>
    /// MD5 32位加密 加密后密码为小写
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    static string GetMd5Str32(string text)
    {
      try
      {
        using (MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider())
        {
          byte[] data = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(text));
          StringBuilder sBuilder = new StringBuilder();
          for (int i = 0; i < data.Length; i++)
          {
            sBuilder.Append(data[i].ToString("x2"));
          }
          return sBuilder.ToString().ToLower();
        }
      }
      catch { return null; }
    }

    static string GetMD5(string msg)
    {
      StringBuilder sb = new StringBuilder();

      using (MD5 md5 = MD5.Create())
      {
        byte[] buffer = Encoding.UTF8.GetBytes(msg);
        byte[] newB = md5.ComputeHash(buffer);

        foreach (byte item in newB)
        {
          sb.Append(item.ToString("x2"));
        }
      }

      return sb.ToString();
    }

    static string GetMD5WithFilePath(string filePath)
    {
      FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
      MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
      byte[] hash_byte = md5.ComputeHash(file);
      string str = System.BitConverter.ToString(hash_byte);
      str = str.Replace("-", "");
      return str;
    }

    static string GetFileMD5(string filepath)
    {
      StringBuilder sb = new StringBuilder();
      using (MD5 md5 = MD5.Create())
      {
        using (FileStream fs = File.OpenRead(filepath))
        {
          byte[] newB = md5.ComputeHash(fs);
          foreach (byte item in newB)
          {
            sb.Append(item.ToString("x2"));
          }
        }
      }

      return sb.ToString();
    }
    #endregion
  }
}
