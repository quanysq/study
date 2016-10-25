using DBHelper.Model;
using DBHelper.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Common
{
  public class ListControlOperater
  {
    public static void Bind2ListCtr(DataTable dt, dynamic ListCtr)
    {
      ListCtr.BeginUpdate();
      foreach (DataRow row in dt.Rows)
      {
        ComboBoxItemModel cbbitem = new ComboBoxItemModel();
        cbbitem.Key               = CommonUtil.TranNull<string>(row[0]);
        cbbitem.Value             = row[1];
        ListCtr.Items.Add(cbbitem);
      }
      ListCtr.EndUpdate();
      ListCtr.SelectedIndex = 0;
    }

    public static void Bind2ListCtr(List<string> list, dynamic ListCtr)
    {
      ListCtr.BeginUpdate();
      foreach (string item in list)
      {
        ComboBoxItemModel cbbitem = new ComboBoxItemModel();
        cbbitem.Key               = item;
        cbbitem.Value             = item;
        ListCtr.Items.Add(cbbitem);
      }
      ListCtr.EndUpdate();
      ListCtr.SelectedIndex = 0;
    }

    public static void BindEmpty2ListCtr(dynamic ListCtr)
    {
      ComboBoxItemModel cbbitem = new ComboBoxItemModel();
      cbbitem.Key = "";
      cbbitem.Value = "";
      ListCtr.Items.Add(cbbitem);
    }

    public static string GetComboBoxKey(dynamic ListCtr)
    {
      ComboBoxItemModel CurrentItem = ListCtr.SelectedItem as ComboBoxItemModel;
      if (CurrentItem == null) return "";
      return CurrentItem.Key;
    }

    public static T GetComboBoxValue<T>(dynamic ListCtr)
    {
      ComboBoxItemModel CurrentItem = ListCtr.SelectedItem as ComboBoxItemModel;
      if (CurrentItem == null) return default(T);
      return CommonUtil.TranNull<T>(CurrentItem.Value);
    }

    public static void SetListCtrSelectedItem(dynamic ListCtr, string Key)
    {
      foreach (ComboBoxItemModel item in ListCtr.Items)
      {
        if (item.Key.Equals(Key, StringComparison.OrdinalIgnoreCase))
        {
          ListCtr.SelectedItem = item;
          return;
        }
      }
    }

    public static void SetListCtrDaultSelectItem(dynamic ListCtr)
    {
      ListCtr.SelectedIndex  = ListCtr.Items.Count == 0 ? -1 : 0;
    }
  }
}
