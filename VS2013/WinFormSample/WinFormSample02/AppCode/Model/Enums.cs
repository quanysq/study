using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormSample02
{
  #region EnumControlState
  /// <summary>
  /// 控件的基本状态
  /// </summary>
  internal enum EnumControlState
  {
    None,

    /// <summary>
    /// 默认状态
    /// </summary>
    Default,

    /// <summary>
    /// 高亮状态（鼠标悬浮）
    /// </summary>
    HeightLight,

    /// <summary>
    /// 焦点（鼠标按下、已选择、输入状态等）
    /// </summary>
    Focused,
  }

  #endregion
}
