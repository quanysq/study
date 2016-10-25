using DBHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace DBHelper.Common
{
  static class OpenBusinessMethodSubForm
  {
    public static void OpenEditForm(MainForm MainFrm, string BMCode, bool CanNext)
    {
      var Frm          = OpenForm(MainFrm, BMCode, CanNext, "BusinessMethodEdit");
      Frm.Text         = "添加/编辑业务方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK && CanNext)
      {
        OpenBindIMForm(MainFrm, Frm.BMCode, Frm.CanNext);
      }
    }

    public static void OpenBindIMForm(MainForm MainFrm, string BMCode, bool CanNext)
    {
      var Frm          = OpenForm(MainFrm, BMCode, CanNext, "BusinessMethodBindIM");
      Frm.Text         = "绑定元素方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK && CanNext)
      {
        OpenParameterRelationsForm(MainFrm, Frm.BMCode, Frm.CanNext);
      }
    }

    public static void OpenParameterForm(MainForm MainFrm, string BMCode, bool CanNext)
    {
      var Frm          = OpenForm(MainFrm, BMCode, CanNext, "BusinessMethodParameter");
      Frm.Text         = "管理参数";
      Frm.ShowDialog();
    }

    public static void OpenParameterRelationsForm(MainForm MainFrm, string BMCode, bool CanNext)
    {
      var Frm          = OpenForm(MainFrm, BMCode, CanNext, "BusinessMethodParameterRelations");
      Frm.Text         = "设置业务方法参数";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK && CanNext)
      {
        OpenParameterForm(MainFrm, Frm.BMCode, Frm.CanNext);
      }
    }

    private static BusinessMethodSubFormTemplate OpenForm(MainForm MainFrm, string BMCode, bool CanNext, string FormName)
    {
      Type type                         = Type.GetType(string.Format("DBHelper.{0}", FormName));
      BusinessMethodSubFormTemplate Frm = Activator.CreateInstance(type) as BusinessMethodSubFormTemplate;
      Frm.Owner                         = MainFrm.FindFormByName("BusinessMethodList");
      Frm.BMCode                        = BMCode;
      Frm.CanNext                       = CanNext;
      Frm.StartPosition                 = FormStartPosition.CenterScreen;
      return Frm;
    }
  }
}
