using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WinFormSample02
{
  #region CornerRadius

  /// <summary>
  /// 矩形的圆角半径
  /// </summary>
  /// User:Ryan  CreateTime:2011-07-19 10:17.
  public struct CornerRadius
  {
    #region Initializes

    /// <summary>
    /// (构造函数).Initializes a new instance of the <see cref="CornerRadius"/> struct.
    /// 设置四个角为相同的圆角半径
    /// </summary>
    /// <param name="radius">The radius.</param>
    /// User:Ryan  CreateTime:2011-07-19 11:32.
    public CornerRadius(int radius)
      : this(radius, radius, radius, radius)
    {
    }

    /// <summary>
    /// (构造函数).Initializes a new instance of the <see cref="CornerRadius"/> struct.
    /// 初始化四个角的圆角半径
    /// </summary>
    /// <param name="topLeft">The top left.</param>
    /// <param name="topRight">The top right.</param>
    /// <param name="bottomLeft">The bottom left.</param>
    /// <param name="bottomRight">The bottom right.</param>
    /// User:Ryan  CreateTime:2011-07-19 11:35.
    public CornerRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
    {
      this.TopLeft = topLeft;
      this.TopRight = topRight;
      this.BottomLeft = bottomLeft;
      this.BottomRigth = bottomRight;
    }
    #endregion

    #region Fields

    /// <summary>
    /// 左上角圆角半径
    /// </summary>
    public int TopLeft;

    /// <summary>
    /// 右上角圆角半径
    /// </summary>
    public int TopRight;

    /// <summary>
    /// 左下角圆角半径
    /// </summary>
    public int BottomLeft;

    /// <summary>
    /// 右下角圆角半径
    /// </summary>
    public int BottomRigth;

    #endregion
  }
  #endregion

  #region RECT

  /// <summary>
  /// Win32中的矩形结构，及与.net中的Rectangle的处理
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  internal struct RECT
  {
    public int left;
    public int top;
    public int right;
    public int bottom;

    public RECT(int left, int top, int right, int bottom)
    {
      this.left = left;
      this.top = top;
      this.right = right;
      this.bottom = bottom;
    }

    public RECT(Rectangle rect)
    {
      this.left = rect.Left;
      this.right = rect.Right;
      this.top = rect.Top;
      this.bottom = rect.Bottom;
    }

    public Rectangle Rect
    {
      get
      {
        return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top);
      }
    }

    public static RECT FromXYWH(int x, int y, int width, int height)
    {
      return new RECT(x, y, x + width, y + height);
    }

    public static RECT FromRectangle(Rectangle rect)
    {
      return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
    }
  }

  #endregion

  #region ComboBoxInfo

  /// <summary>
  /// ComboBox的Windows信息结构
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  internal struct ComboBoxInfo
  {
    public int cbSize;
    public RECT rcItem;
    public RECT rcButton;
    public ComboBoxButtonState stateButton;
    public IntPtr hwndCombo;
    public IntPtr hwndEdit;
    public IntPtr hwndList;
  }

  #endregion

  #region PAINTSTRUCT

  [StructLayout(LayoutKind.Sequential)]
  internal struct PAINTSTRUCT
  {
    public IntPtr hdc;
    public int fErase;
    public RECT rcPaint;
    public int fRestore;
    public int fIncUpdate;
    public int Reserved1;
    public int Reserved2;
    public int Reserved3;
    public int Reserved4;
    public int Reserved5;
    public int Reserved6;
    public int Reserved7;
    public int Reserved8;
  }

  #endregion

  #region HDITEM

  [StructLayout(LayoutKind.Sequential)]
  internal struct HDITEM
  {
    internal int mask;
    internal int cxy;
    internal IntPtr pszText;
    internal IntPtr hbm;
    internal int cchTextMax;
    internal int fmt;
    internal IntPtr lParam;
    internal int iImage;
    internal int iOrder;
    internal uint type;
    internal IntPtr pvFilter;
  }
  #endregion
}
