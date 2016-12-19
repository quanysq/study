using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console002
{
  /// <summary>
  /// 判断文件文件的编码
  /// </summary>
  class C2
  {
    public static void Execute()
    {
      Encoding en1 = GetFileEncodeType(@"D:\临时\RestoreReport\analyzer_report_upgrade_test.good.xanalyzer");
      Console.WriteLine("analyzer_report_upgrade_test.good.xanalyzer Encoding: " + en1.ToString());

      Encoding en2 = GetFileEncodeType(@"D:\临时\RestoreReport\analyzer_report_upgrade_test.xanalyzer");
      Console.WriteLine("analyzer_report_upgrade_test.xanalyzer Encoding: " + en2.ToString());

    }

    static Encoding GetFileEncodeType(string filename)
    {
      FileStream fs = null;
      BinaryReader br = null;
      try
      {
        fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
        br = new BinaryReader(fs);
        Byte[] buffer = br.ReadBytes(2);
        if (buffer[0] == 0xEF && buffer[1] == 0xBB)
        {
          return Encoding.UTF8;   //with BOM
        }
        else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
        {
          return Encoding.BigEndianUnicode;
        }
        else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
        {
          return Encoding.Unicode;
        }
        else
        {
          int i;
          int.TryParse(fs.Length.ToString(), out i);
          buffer = br.ReadBytes(i);

          if (IsTextUTF8(ref buffer)) return Encoding.UTF8;   //without BOM
          //int p = utf8_probability(buffer);
          //if (p > 80) return Encoding.UTF8;

          return System.Text.Encoding.Default;
        }
      }
      catch (Exception ex)
      {
        throw;
      }
      finally
      {
        if (fs != null) fs.Close();
        if (br != null) br.Close();
      }
    }

    static bool IsTextUTF8(ref byte[] inputStream)
    {
      int encodingBytesCount = 0;
      bool allTextsAreASCIIChars = true;

      for (int i = 0; i < inputStream.Length; i++)
      {
        byte current = inputStream[i];

        if ((current & 0x80) == 0x80)
        {
          allTextsAreASCIIChars = false;
        }
        // First byte
        if (encodingBytesCount == 0)
        {
          if ((current & 0x80) == 0)
          {
            // ASCII chars, from 0x00-0x7F
            continue;
          }

          if ((current & 0xC0) == 0xC0)
          {
            encodingBytesCount = 1;
            current <<= 2;

            // More than two bytes used to encoding a unicode char.
            // Calculate the real length.
            while ((current & 0x80) == 0x80)
            {
              current <<= 1;
              encodingBytesCount++;
            }
          }
          else
          {
            // Invalid bits structure for UTF8 encoding rule.
            return false;
          }
        }
        else
        {
          // Following bytes, must start with 10.
          if ((current & 0xC0) == 0x80)
          {
            encodingBytesCount--;
          }
          else
          {
            // Invalid bits structure for UTF8 encoding rule.
            return false;
          }
        }
      }

      if (encodingBytesCount != 0)
      {
        // Invalid bits structure for UTF8 encoding rule.
        // Wrong following bytes count.
        return false;
      }

      // Although UTF8 supports encoding for ASCII chars, we regard as a input stream, whose contents are all ASCII as default encoding.
      return !allTextsAreASCIIChars;
    }

    static int utf8_probability(byte[] rawtext)
    {
      int score = 0;
      int i, rawtextlen = 0;
      int goodbytes = 0, asciibytes = 0;

      // Maybe also use UTF8 Byte Order Mark:  EF BB BF

      // Check to see if characters fit into acceptable ranges
      rawtextlen = rawtext.Length;
      for (i = 0; i < rawtextlen; i++)
      {
        if ((rawtext[i] & (byte)0x7F) == rawtext[i])
        {  // One byte
          asciibytes++;
          // Ignore ASCII, can throw off count
        }
        else
        {
          int m_rawInt0 = Convert.ToInt16(rawtext[i]);
          int m_rawInt1 = Convert.ToInt16(rawtext[i + 1]);
          int m_rawInt2 = Convert.ToInt16(rawtext[i + 2]);

          if (256 - 64 <= m_rawInt0 && m_rawInt0 <= 256 - 33 && // Two bytes
           i + 1 < rawtextlen &&
           256 - 128 <= m_rawInt1 && m_rawInt1 <= 256 - 65)
          {
            goodbytes += 2;
            i++;
          }
          else if (256 - 32 <= m_rawInt0 && m_rawInt0 <= 256 - 17 && // Three bytes
           i + 2 < rawtextlen &&
           256 - 128 <= m_rawInt1 && m_rawInt1 <= 256 - 65 &&
           256 - 128 <= m_rawInt2 && m_rawInt2 <= 256 - 65)
          {
            goodbytes += 3;
            i += 2;
          }
        }
      }

      if (asciibytes == rawtextlen) { return 0; }

      score = (int)(100 * ((float)goodbytes / (float)(rawtextlen - asciibytes)));

      // If not above 98, reduce to zero to prevent coincidental matches
      // Allows for some (few) bad formed sequences
      if (score > 98)
      {
        return score;
      }
      else if (score > 95 && goodbytes > 30)
      {
        return score;
      }
      else
      {
        return 0;
      }
    }
  }
}
