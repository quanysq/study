using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 正则表达式提取指定的数据
  /// </summary>
  public class Class23
  {
    public static void Execute()
    {
      //string text = @"data source=zothos.argonath.com;initial catalog=BDNA_PUBLISH;persist security info=True;uid=fv5\DBATest;pwd=Simple.0;MultipleActiveResultSets=True;App=EntityFramework;Integrated Security=True";
      /*string text = @"data source=localhost\mssql2016;initial catalog=BDNA_PUBLISH;persist security info=True;uid='JACKYDS\SRVC-MON-BDNA-PRD';pwd='ybDc6m%8`MCG;&ps6';MultipleActiveResultSets=True;App=EntityFramework;Integrated Security=True";
      string pattern1 = @"uid='(?<uid>.+?)(?<!\\)';pwd=";
      ExtractUsingRegex(text, pattern1);
      Console.WriteLine("############################");
      string pattern2 = @"pwd='(?<uid>.+?)(?<!\\)';MultipleActiveResultSets=";
      ExtractUsingRegex(text, pattern2);*/

      string str1 = "aaaabb";
      ISMD5(str1);
      string str2 = "f9f3b266f0e3921597b37cfb723b8ef793ccae67";
      ISMD5(str2);
    }

    private static void ExtractUsingRegex(string text, string pattern)
    {
      //Regex re = new Regex(cnPattern);
      //Match m = re.Match(dn);
      var m = Regex.Match(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      if (m.Success)
      {
        // Item with index 1 returns the first group match.
        string val = m.Groups[1].Value;
        Console.WriteLine(val);
        Console.WriteLine("==============");
        foreach (Group group in m.Groups)
        {
          Console.WriteLine(group.Value);
        }
      }
      else
      {
        Console.WriteLine("No value!");
      }
    }

    private static void ISMD5(string str)
    {
      var isMD5 = System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9a-fA-F]{32,512}$", System.Text.RegularExpressions.RegexOptions.Compiled);
      Console.WriteLine("[{0}] is MD5? [{1}]", str, isMD5);
    }
  }
}
