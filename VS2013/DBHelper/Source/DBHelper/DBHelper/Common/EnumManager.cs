using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Model;
using DBHelper.Util;

namespace DBHelper.Common
{
  public static class EnumManager<TEnum>
  {
    private static DataTable GetDataTable()
    {
      Type enumType          = typeof(TEnum);           // 获取类型对象
      FieldInfo[] enumFields = enumType.GetFields();    //获取字段信息对象集合

      DataTable table = new DataTable();
      table.Columns.Add("Name", Type.GetType("System.String"));
      table.Columns.Add("Value", Type.GetType("System.Int32"));
      //遍历集合
      foreach (FieldInfo field in enumFields)
      {
        if (!field.IsSpecialName)
        {
          DataRow row = table.NewRow();
          row[0]      = field.Name;                                           // 获取字段文本值
          row[1]      = Convert.ToInt32(field.GetRawConstantValue());         // 获取int数值
          //row[1]    = (int)Enum.Parse(enumType, field.Name);                // 也可以这样

          table.Rows.Add(row);
        }
      }
      return table;
    }

    public static void Bind2ComboBox(System.Windows.Forms.ComboBox ComboBoxCtr)
    {
      DataTable dt = GetDataTable(); 
      ListControlOperater.Bind2ListCtr(dt, ComboBoxCtr);
    }

    public static void Bind2DataGridViewComboBoxColumn(System.Windows.Forms.DataGridViewComboBoxColumn ComboBoxCtr)
    {
      DataTable dt              = GetDataTable();
      ComboBoxCtr.DataSource    = dt;
      ComboBoxCtr.DisplayMember = "Name";
      ComboBoxCtr.ValueMember   = "Name";
    }

    public static string Enum2EnumName(object Value)
    {
      string EnumName = Enum.GetName(typeof(TEnum), Value);
      return EnumName;      
    }

    public static TEnum EnumName2Enum(string EnumName)
    {
      return (TEnum)Enum.Parse(typeof(TEnum), EnumName);
    }

    public static TEnum EnumName2Enum(object objEnumName)
    {
      string EnumName = CommonUtil.TranNull<string>(objEnumName);
      return EnumName2Enum(EnumName);
    }
  }
}
