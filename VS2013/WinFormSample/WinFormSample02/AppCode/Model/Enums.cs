﻿using System;
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

  #region WindowMessages

  /// <summary>
  /// Windows常量消息参数
  /// </summary>
  internal enum WindowMessages : int
  {
    WM_NULL = 0x0000,

    WM_CREATE = 0x0001,

    WM_DESTROY = 0x0002,

    WM_MOVE = 0x0003,

    WM_SIZE = 0x0005,

    WM_ACTIVATE = 0x0006,

    WM_SETFOCUS = 0x0007,

    WM_KILLFOCUS = 0x0008,

    WM_ENABLE = 0x000A,

    WM_SETREDRAW = 0x000B,

    WM_SETTEXT = 0x000C,

    WM_GETTEXT = 0x000D,

    WM_GETTEXTLENGTH = 0x000E,

    WM_PAINT = 0x000F,

    WM_CLOSE = 0x0010,

    WM_QUIT = 0x0012,

    WM_ERASEBKGND = 0x0014,

    WM_SYSCOLORCHANGE = 0x0015,

    WM_SHOWWINDOW = 0x0018,

    WM_ACTIVATEAPP = 0x001C,

    WM_SETCURSOR = 0x0020,

    WM_MOUSEACTIVATE = 0x0021,

    WM_GETMINMAXINFO = 0x24,

    WM_WINDOWPOSCHANGING = 0x0046,

    WM_WINDOWPOSCHANGED = 0x0047,

    WM_CONTEXTMENU = 0x007B,

    WM_STYLECHANGING = 0x007C,

    WM_STYLECHANGED = 0x007D,

    WM_DISPLAYCHANGE = 0x007E,

    WM_GETICON = 0x007F,

    WM_SETICON = 0x0080,

    // non client area
    /// <summary>
    /// 在WM_CREATE前的一个消息
    /// </summary>
    WM_NCCREATE = 0x0081,

    WM_NCDESTROY = 0x0082,

    /// <summary>
    /// 计算窗体客户区域大小和位置的消息
    /// </summary>
    WM_NCCALCSIZE = 0x0083,

    WM_NCHITTEST = 0x84,

    WM_NCPAINT = 0x0085,

    WM_NCACTIVATE = 0x0086,

    WM_GETDLGCODE = 0x0087,

    WM_SYNCPAINT = 0x0088,

    // non client mouse
    WM_NCMOUSEMOVE = 0x00A0,

    WM_NCLBUTTONDOWN = 0x00A1,

    WM_NCLBUTTONUP = 0x00A2,

    WM_NCLBUTTONDBLCLK = 0x00A3,
    WM_NCRBUTTONDOWN = 0x00A4,
    WM_NCRBUTTONUP = 0x00A5,
    WM_NCRBUTTONDBLCLK = 0x00A6,
    WM_NCMBUTTONDOWN = 0x00A7,
    WM_NCMBUTTONUP = 0x00A8,
    WM_NCMBUTTONDBLCLK = 0x00A9,

    // keyboard
    WM_KEYDOWN = 0x0100,
    WM_KEYUP = 0x0101,
    WM_CHAR = 0x0102,

    WM_SYSCOMMAND = 0x0112,

    // menu
    WM_INITMENU = 0x0116,
    WM_INITMENUPOPUP = 0x0117,
    WM_MENUSELECT = 0x011F,
    WM_MENUCHAR = 0x0120,
    WM_ENTERIDLE = 0x0121,
    WM_MENURBUTTONUP = 0x0122,
    WM_MENUDRAG = 0x0123,
    WM_MENUGETOBJECT = 0x0124,
    WM_UNINITMENUPOPUP = 0x0125,
    WM_MENUCOMMAND = 0x0126,

    WM_CHANGEUISTATE = 0x0127,
    WM_UPDATEUISTATE = 0x0128,
    WM_QUERYUISTATE = 0x0129,

    // mouse
    WM_MOUSEFIRST = 0x0200,
    WM_MOUSEMOVE = 0x0200,
    WM_LBUTTONDOWN = 0x0201,
    WM_LBUTTONUP = 0x0202,
    WM_LBUTTONDBLCLK = 0x0203,
    WM_RBUTTONDOWN = 0x0204,
    WM_RBUTTONUP = 0x0205,
    WM_RBUTTONDBLCLK = 0x0206,
    WM_MBUTTONDOWN = 0x0207,
    WM_MBUTTONUP = 0x0208,
    WM_MBUTTONDBLCLK = 0x0209,
    WM_MOUSEWHEEL = 0x020A,
    WM_MOUSELAST = 0x020D,

    WM_PARENTNOTIFY = 0x0210,
    WM_ENTERMENULOOP = 0x0211,
    WM_EXITMENULOOP = 0x0212,

    WM_NEXTMENU = 0x0213,
    WM_SIZING = 0x0214,
    WM_CAPTURECHANGED = 0x0215,
    WM_MOVING = 0x0216,

    WM_ENTERSIZEMOVE = 0x0231,
    WM_EXITSIZEMOVE = 0x0232,

    WM_MOUSELEAVE = 0x02A3,
    WM_MOUSEHOVER = 0x02A1,
    WM_NCMOUSEHOVER = 0x02A0,
    WM_NCMOUSELEAVE = 0x02A2,

    WM_MDIACTIVATE = 0x0222,
    WM_HSCROLL = 0x0114,
    WM_VSCROLL = 0x0115,

    WM_PRINT = 0x0317,
    WM_PRINTCLIENT = 0x0318,
    WM_PASTE = 0X302,

    APP = 32768,
    ACTIVATE = 6,
    ACTIVATEAPP = 28,
    AFXFIRST = 864,
    AFXLAST = 895,
    ASKCBFORMATNAME = 780,
    CANCELJOURNAL = 75,
    CANCELMODE = 31,
    CAPTURECHANGED = 533,
    CHANGECBCHAIN = 781,
    CHAR = 258,
    CHARTOITEM = 47,
    CHILDACTIVATE = 34,
    CLEAR = 771,
    CLOSE = 16,
    COMMAND = 273,
    COMMNOTIFY = 68,
    COMPACTING = 65,
    COMPAREITEM = 57,
    CONTEXTMENU = 123,
    COPY = 769,
    COPYDATA = 74,
    CREATE = 1,
    CTLCOLOR = 0x0019,
    CTLCOLORBTN = 309,
    CTLCOLORDLG = 310,
    CTLCOLOREDIT = 307,
    CTLCOLORLISTBOX = 308,
    CTLCOLORMSGBOX = 306,
    CTLCOLORSCROLLBAR = 311,
    CTLCOLORSTATIC = 312,
    CUT = 768,
    DEADCHAR = 259,
    DELETEITEM = 45,
    DESTROY = 2,
    DESTROYCLIPBOARD = 775,
    DEVICECHANGE = 537,
    DEVMODECHANGE = 27,
    DISPLAYCHANGE = 126,
    DRAWCLIPBOARD = 776,
    DRAWITEM = 43,
    DROPFILES = 563,
    ENABLE = 10,
    ENDSESSION = 22,
    ENTERIDLE = 289,
    ENTERMENULOOP = 529,
    ENTERSIZEMOVE = 561,
    ERASEBKGND = 20,
    EXITMENULOOP = 530,
    EXITSIZEMOVE = 562,
    FONTCHANGE = 29,
    GETDLGCODE = 135,
    GETFONT = 49,
    GETHOTKEY = 51,
    GETICON = 127,
    GETMINMAXINFO = 36,
    GETTEXT = 13,
    GETTEXTLENGTH = 14,
    HANDHELDFIRST = 856,
    HANDHELDLAST = 863,
    HELP = 83,
    HOTKEY = 786,
    HSCROLL = 276,
    HSCROLLCLIPBOARD = 782,
    ICONERASEBKGND = 39,
    INITDIALOG = 272,
    INITMENU = 278,
    INITMENUPOPUP = 279,
    UNINITMENUPOPUP = 293,
    INPUTLANGCHANGE = 81,
    INPUTLANGCHANGEREQUEST = 80,
    KEYDOWN = 256,
    KEYUP = 257,
    KILLFOCUS = 8,
    MDIACTIVATE = 546,
    MDICASCADE = 551,
    MDICREATE = 544,
    MDIDESTROY = 545,
    MDIGETACTIVE = 553,
    MDIICONARRANGE = 552,
    MDIMAXIMIZE = 549,
    MDINEXT = 548,
    MDIREFRESHMENU = 564,
    MDIRESTORE = 547,
    MDISETMENU = 560,
    MDITILE = 550,
    MEASUREITEM = 44,
    MENUCHAR = 288,
    MENUSELECT = 287,
    MENUCOMMAND = 294,
    NEXTMENU = 531,
    MOVE = 3,
    MOVING = 534,
    NCACTIVATE = 134,
    NCCALCSIZE = 131,
    NCCREATE = 129,
    NCDESTROY = 130,
    NCHITTEST = 132,
    NCLBUTTONDBLCLK = 163,
    NCLBUTTONDOWN = 161,
    NCLBUTTONUP = 162,
    NCMBUTTONDBLCLK = 169,
    NCMBUTTONDOWN = 167,
    NCMBUTTONUP = 168,
    NCMOUSEMOVE = 160,
    NCPAINT = 133,
    NCRBUTTONDBLCLK = 166,
    NCRBUTTONDOWN = 164,
    NCRBUTTONUP = 165,
    NEXTDLGCTL = 40,
    NOTIFY = 78,
    NOTIFYFORMAT = 85,
    NULL = 0,
    PAINT = 15,
    PAINTCLIPBOARD = 777,
    PAINTICON = 38,
    PALETTECHANGED = 785,
    PALETTEISCHANGING = 784,
    PARENTNOTIFY = 528,
    PASTE = 770,
    PENWINFIRST = 896,
    PENWINLAST = 911,
    POWER = 72,
    POWERBROADCAST = 536,
    PRINT = 791,
    PRINTCLIENT = 792,
    QUERYDRAGICON = 55,
    QUERYENDSESSION = 17,
    QUERYNEWPALETTE = 783,
    QUERYOPEN = 19,
    QUEUESYNC = 35,
    QUIT = 18,
    RENDERALLFORMATS = 774,
    RENDERFORMAT = 773,
    SETCURSOR = 32,
    SETFOCUS = 7,
    SETFONT = 48,
    SETHOTKEY = 50,
    SETICON = 128,
    SETREDRAW = 11,
    SETTEXT = 12,
    SETTINGCHANGE = 26,
    SHOWWINDOW = 24,
    SIZE = 5,
    SIZECLIPBOARD = 779,
    SIZING = 532,
    SPOOLERSTATUS = 42,
    STYLECHANGED = 125,
    STYLECHANGING = 124,
    SYSCHAR = 262,
    SYSCOLORCHANGE = 21,
    SYSCOMMAND = 274,
    SYSDEADCHAR = 263,
    SYSKEYDOWN = 260,
    SYSKEYUP = 261,
    TCARD = 82,
    TIMECHANGE = 30,
    TIMER = 275,
    UNDO = 772,
    USER = 1024,
    USERCHANGED = 84,
    VKEYTOITEM = 46,
    VSCROLL = 277,
    VSCROLLCLIPBOARD = 778,
    WINDOWPOSCHANGED = 71,
    WINDOWPOSCHANGING = 70,
    WININICHANGE = 26,
    KEYFIRST = 256,
    KEYLAST = 264,
    SYNCPAINT = 136,
    MOUSEACTIVATE = 33,
    MOUSEMOVE = 512,
    LBUTTONDOWN = 513,
    LBUTTONUP = 514,
    LBUTTONDBLCLK = 515,
    RBUTTONDOWN = 516,
    RBUTTONUP = 517,
    RBUTTONDBLCLK = 518,
    MBUTTONDOWN = 519,
    MBUTTONUP = 520,
    MBUTTONDBLCLK = 521,
    MOUSEWHEEL = 522,
    MOUSEFIRST = 512,
    MOUSELAST = 522,
    MOUSEHOVER = 0x2A1,
    MOUSELEAVE = 0x2A3,
    SHNOTIFY = 0x0401,
    UNICHAR = 0x0109,
    THEMECHANGED = 0x031A

  }
  #endregion

  #region ComboBoxButtonState

  /// <summary>
  /// ComboBoxButton状态
  /// </summary>
  internal enum ComboBoxButtonState
  {
    STATE_SYSTEM_NONE = 0,

    STATE_SYSTEM_INVISIBLE = 0x00008000,

    STATE_SYSTEM_PRESSED = 0x00000008
  }

  #endregion

  #region ListViewMessages / LVM

  /// <summary>
  /// ListView Messages / LVM
  /// </summary>
  internal enum ListViewMessages : int
  {
    FIRST = 0x1000,
    SCROLL = FIRST + 20,
    GETITEM = FIRST + 75,
    SETITEM = FIRST + 76,
    GETITEMTEXTW = FIRST + 115,
    SETCOLUMNWIDTH = FIRST + 30,
    LVSCW_AUTOSIZE = -1,
    LVSCW_AUTOSIZE_USEHEADER = -2,
    SETITEMSTATE = FIRST + 43,
    INSERTITEMA = FIRST + 77,
    DELETEITEM = FIRST + 8,
    GETITEMCOUNT = FIRST + 4,
    GETCOUNTPERPAGE = FIRST + 40,
    GETSUBITEMRECT = FIRST + 56,
    SUBITEMHITTEST = FIRST + 57,
    GETCOLUMN = FIRST + 25,
    SETCOLUMN = FIRST + 26,
    GETCOLUMNORDERARRAY = FIRST + 59,
    SETCOLUMNORDERARRAY = FIRST + 58,
    SETEXTENDEDLISTVIEWSTYLE = FIRST + 54,
    GETEXTENDEDLISTVIEWSTYLE = FIRST + 55,
    EDITLABELW = FIRST + 118,
    GETITEMRECT = FIRST + 14,
    HITTEST = FIRST + 18,
    GETEDITCONTROL = FIRST + 24,
    CANCELEDITLABEL = FIRST + 179,
    GETHEADER = FIRST + 31,
    REDRAWITEMS = FIRST + 21,
    GETSELECTIONMARK = FIRST + 66,
    SETSELECTIONMARK = FIRST + 67,
    ENSUREVISIBLE = (FIRST + 19),
  }
  #endregion

  #region HeaderItem flags / HDI
  /// <summary>
  /// HeaderItem flags / HDI
  /// </summary>
  internal enum HeaderItemFlags
  {
    WIDTH = 0x0001,
    HEIGHT = WIDTH,
    TEXT = 0x0002,
    FORMAT = 0x0004,
    LPARAM = 0x0008,
    BITMAP = 0x0010,
    IMAGE = 0x0020,
    DI_SETITEM = 0x0040,
    ORDER = 0x0080
  }
  #endregion

  #region Header Control Messages / HDM
  /// <summary>
  /// Header Control Messages / HDM
  /// </summary>
  internal enum HeaderControlMessages : int
  {
    FIRST = 0x1200,
    GETITEMRECT = (FIRST + 7),
    HITTEST = (FIRST + 6),
    SETIMAGELIST = (FIRST + 8),
    GETITEMW = (FIRST + 11),
    ORDERTOINDEX = (FIRST + 15),
    SETITEM = (FIRST + 12),
    SETORDERARRAY = (FIRST + 18),
    GETITEMCOUNT = (FIRST + 0),
    GETITEMA = (FIRST + 3),

  }
  #endregion
}
