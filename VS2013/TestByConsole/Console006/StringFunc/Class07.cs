using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 验证数组是否按顺序输出
  /// </summary>
  class C7
  {
    public static void Execute()
    {
      string[] l = { "Catalog", "DLLS", "For_UserConsole", "PatchSetReadme_DataPlatform", "PatchSetVersion_UserConsole", "PatchSetReadme_DataPlatform", "PatchSetVersion_DataPlatform" };
      foreach (string s in l) Console.WriteLine(s);
    }
  }
}
