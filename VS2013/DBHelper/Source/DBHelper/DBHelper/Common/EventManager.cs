using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
  /// <summary>
  /// 用于MethodClassifyList.cs中的OnListBoxSelectedIndexChanged事件
  /// </summary>
  public class MethodClassifyListEventArgs : EventArgs
  {
    public static string OldKey { get; set; }
    public static int OldValue { get; set; }
    public string Key { get; set; }
    public int Value { get; set; }
  }
}
