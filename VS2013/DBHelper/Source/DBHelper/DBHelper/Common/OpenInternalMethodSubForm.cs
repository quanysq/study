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
  static class OpenInternalMethodSubForm
  {
    public static void OpenQueryForm(MainForm MainFrm, int MethodID)
    {
      var Frm          = OpenForm(MainFrm, MethodID, "InternalMethodQuery");
      Frm.MethodType   = MethodType.SQLStatement;
      Frm.FunctionType = FunctionType.Select_Paging;
      Frm.Text         = "编辑查询语句方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        OpenInternalMethodStatementForm.OpenStatementForm(Frm.MethodID);
      }
    }

    public static void OpenInsertForm(MainForm MainFrm, int MethodID)
    {
      var Frm          = OpenForm(MainFrm, MethodID, "InternalMethodDDL");
      Frm.MethodType   = MethodType.SQLStatement;
      Frm.FunctionType = FunctionType.Insert;
      Frm.Text         = "编辑插入语句方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        OpenInternalMethodStatementForm.OpenStatementForm(Frm.MethodID);
      }
    }

    public static void OpenUpdateForm(MainForm MainFrm, int MethodID)
    {
      var Frm          = OpenForm(MainFrm, MethodID, "InternalMethodDDL");
      Frm.MethodType   = MethodType.SQLStatement;
      Frm.FunctionType = FunctionType.Update;
      Frm.Text         = "编辑更新语句方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        OpenInternalMethodStatementForm.OpenStatementForm(Frm.MethodID);
      }
    }

    public static void OpenDeleteForm(MainForm MainFrm, int MethodID)
    {
      var Frm          = OpenForm(MainFrm, MethodID, "InternalMethodDDL");
      Frm.MethodType   = MethodType.SQLStatement;
      Frm.FunctionType = FunctionType.Delete;
      Frm.Text         = "编辑删除语句方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        OpenInternalMethodStatementForm.OpenStatementForm(Frm.MethodID);
      }
    }

    public static void OpenProcedureForm(MainForm MainFrm, int MethodID)
    {
      var Frm          = OpenForm(MainFrm, MethodID, "InternalMethodSP");
      Frm.MethodType   = MethodType.StoredProcedure;
      Frm.FunctionType = FunctionType.Insert;
      Frm.Text         = "编辑存储过程方法";
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        OpenInternalMethodStatementForm.OpenParameterForm(Frm.MethodID);
      }
    }

    private static InternalMethodTemplete OpenForm(MainForm MainFrm, int MethodID, string FormName)
    {
      Type type                  = Type.GetType(string.Format("DBHelper.{0}", FormName));
      InternalMethodTemplete Frm = Activator.CreateInstance(type) as InternalMethodTemplete;
      Frm.Owner                  = MainFrm.FindFormByName("InternalMethodList");
      Frm.MethodID               = MethodID;
      Frm.ClassifyID             = 0;
      return Frm;
    }
  }

  static class OpenInternalMethodStatementForm
  {
    public static void OpenStatementForm(int MethodID)
    {
      var Frm  = OpenForm(MethodID, "InternalMethodSQL");
      Frm.Text = "编辑SQL语句";
      Frm.ShowDialog();
    }

    public static void OpenParameterForm(int MethodID)
    {
      var Frm  = OpenForm(MethodID, "InternalMethodParameter");
      Frm.Text = "管理参数";
      Frm.ShowDialog();
    }

    private static InternalMethodStatementTemplate OpenForm(int MethodID, string FormName)
    {
      Type type                           = Type.GetType(string.Format("DBHelper.{0}", FormName));
      InternalMethodStatementTemplate Frm = Activator.CreateInstance(type) as InternalMethodStatementTemplate;
      Frm.MethodID                        = MethodID;
      Frm.StartPosition                   = FormStartPosition.CenterScreen;
      return Frm;
    }
  }
}
