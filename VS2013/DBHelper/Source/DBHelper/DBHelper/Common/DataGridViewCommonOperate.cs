using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Util;

namespace DBHelper.Common
{
  public static class DataGridViewCommonOperate
  {
    public static void SetGridViewHeadStyle(DataGridView gv)
    {
      foreach (DataGridViewColumn col in gv.Columns)
      {
        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
      }
    }

    public static T GetIdentilyVal<T>(DataGridView gv, int RowIndex)
    {
      object o = gv.Rows[RowIndex].Cells[0].Value;
      return CommonUtil.TranNull<T>(o);
    }

    public static T GetIdentilyVal<T>(DataGridView gv)
    {
      int RowIndex = gv.CurrentCell.RowIndex;
      return GetIdentilyVal<T>(gv, RowIndex);
    }

    public static T GetIdentilyVal<T>(DataGridView gv, int RowIndex, string ColumnName)
    {
      object o = gv.Rows[RowIndex].Cells[ColumnName].Value;
      return CommonUtil.TranNull<T>(o);
    }

    public static T GetIdentilyVal<T>(DataGridView gv, string ColumnName)
    {
      int RowIndex = gv.CurrentCell.RowIndex;
      return GetIdentilyVal<T>(gv, RowIndex, ColumnName);
    }

    public static T GetIdentilyValForEnum<T>(DataGridView gv, int RowIndex, string ColumnName)
    {
      object o = gv.Rows[RowIndex].Cells[ColumnName].Value;
      return EnumManager<T>.EnumName2Enum(o);
    }

    public static T GetIdentilyValForEnum<T>(DataGridView gv, string ColumnName)
    {
      int RowIndex = gv.CurrentCell.RowIndex;
      return GetIdentilyValForEnum<T>(gv, RowIndex, ColumnName);
    }

    public static void SelectRow(DataGridView gv, int RowIndex)
    {
      gv.Rows[RowIndex].Selected = true;
    }

    public static void DeleteRow(DataGridView gv, int RowIndex)
    {
      gv.Rows.Remove(gv.Rows[RowIndex]);
    }

    public static void DeleteRow(DataGridView gv)
    {
      int RowIndex = gv.CurrentCell.RowIndex;
      DeleteRow(gv, RowIndex);
    }

    public static void SetCellFocus(DataGridView gv, int RowIndex, int CellIndex)
    {
      DataGridViewCell TargetCell = gv.Rows[RowIndex].Cells[CellIndex];
      TargetCell.ReadOnly         = false;
      gv.CurrentCell              = TargetCell;
      gv.BeginEdit(true);
    }

    public static void ShowContextMenu(DataGridView gv, ContextMenuStrip CM, DataGridViewCellMouseEventArgs e)
    {
      if (e.Button == MouseButtons.Right)
      {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
          if (gv.Rows[e.RowIndex].IsNewRow) return;

          //若行已是选中状态就不再进行设置
          if (gv.Rows[e.RowIndex].Selected == false)
          {
            gv.ClearSelection();
            gv.Rows[e.RowIndex].Selected = true;
          }
          //只选中一行时设置活动单元格
          if (gv.SelectedRows.Count == 1)
          {
            gv.CurrentCell = gv.Rows[e.RowIndex].Cells[e.ColumnIndex];
          }
          //弹出操作菜单
          CM.Show(Control.MousePosition.X, Control.MousePosition.Y);
        }
      }
    }
  }
}