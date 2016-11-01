using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Model;
using DBHelper.Enums;
using DBHelper.Common;
using DBHelper.BLL;
using DBHelper.Util;

namespace DBHelper
{
  public partial class InternalMethodList : Form
  {
    public int ClassifyID { get; set; }

    public InternalMethodList()
    {
      InitializeComponent();
      ucMethodClassifyList.OnListBoxSelectedIndexChanged += OnListBoxSelectedIndexChanged;
      gvInternalMethod.AutoGenerateColumns = false;
    }

    private void InternalMethodList_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvInternalMethod);
      (this.ParentForm as MainForm).EnableInternalMethodMenu();
    }

    private void OnListBoxSelectedIndexChanged(object sender, MethodClassifyListEventArgs e)
    {
      ClassifyID = e.Value;
      InternalMethodListLoad();
    }

    public void InternalMethodListLoad()
    {
      string Keyword                      = txtKeyword.Text.Trim();
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable result                    = internalmethodbll.InternalMethodList(Common.Common.OperateDbID.ToString(), ClassifyID.ToString(), Keyword);
      gvInternalMethod.DataSource         = result;
    }

    private void InternalMethodList_FormClosed(object sender, FormClosedEventArgs e)
    {
      MethodClassifyListEventArgs.OldKey   = string.Empty;
      MethodClassifyListEventArgs.OldValue = 0;
      (this.ParentForm as MainForm).DisableInternalMethodMenu();
    }

    private void gvInternalMethod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) return;
      int MethodID              = DataGridViewCommonOperate.GetIdentilyVal<int>(gvInternalMethod, e.RowIndex, "MethodID");
      MethodType MethodType     = DataGridViewCommonOperate.GetIdentilyValForEnum<MethodType>(gvInternalMethod, e.RowIndex, "MethodType");
      FunctionType FunctionType = DataGridViewCommonOperate.GetIdentilyValForEnum<FunctionType>(gvInternalMethod, e.RowIndex, "FunctionType");
      if (MethodType == Enums.MethodType.SQLStatement)
      {
        if (FunctionType == Enums.FunctionType.Insert)
        {
          OpenInternalMethodSubForm.OpenInsertForm((MainForm)this.ParentForm, MethodID);
        }
        else if (FunctionType == Enums.FunctionType.Update)
        {
          OpenInternalMethodSubForm.OpenUpdateForm((MainForm)this.ParentForm, MethodID);
        }
        else if (FunctionType == Enums.FunctionType.Delete)
        {
          OpenInternalMethodSubForm.OpenDeleteForm((MainForm)this.ParentForm, MethodID);
        }
        else
        {
          OpenInternalMethodSubForm.OpenQueryForm((MainForm)this.ParentForm, MethodID);
        }
      }
      else if (MethodType == Enums.MethodType.StoredProcedure)
      {
        OpenInternalMethodSubForm.OpenProcedureForm((MainForm)this.ParentForm, MethodID);
      }
      
    }

    private void btnQuery_Click(object sender, EventArgs e)
    {
      InternalMethodListLoad();
    }

    private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)13)
      {
        btnQuery_Click(null, null);
      }
    }

    private void btnMove_Click(object sender, EventArgs e)
    {
      List<int> MethodIDByCheckedList = DataGridViewCommonOperate.FindByChecked<int>(gvInternalMethod, "MethodID");
      if (MethodIDByCheckedList.Count == 0)
      {
        DBHelperMessage.Alert("请先选择元素方法！");
        return;
      }
      MethodClassifyMove MethodClassifyMoveFrm = new MethodClassifyMove();
      MethodClassifyMoveFrm.ClassifyType       = 1;
      MethodClassifyMoveFrm.MethodListJoin     = string.Join(",", MethodIDByCheckedList);
      MethodClassifyMoveFrm.ShowDialog();
      if (MethodClassifyMoveFrm.DialogResult == DialogResult.OK)
      {
        InternalMethodListLoad();
        DBHelperMessage.Info("选择的元素方法已经被移动指定的分类中！");
      }
    }

    private void btnGenerateXml_Click(object sender, EventArgs e)
    {
      try
      {
        List<int> MethodIDByCheckedList = DataGridViewCommonOperate.FindByChecked<int>(gvInternalMethod, "MethodID");
        if (MethodIDByCheckedList.Count == 0)
        {
          DBHelperMessage.Alert("请先选择元素方法！");
          return;
        }

        GenerateXml generatexml = new GenerateXml();
        foreach (int MethodID in MethodIDByCheckedList)
        {
          generatexml.GenerateInternalMothod(MethodID);
        }
        DBHelperMessage.Info("选择的元素方法已经生成了XML文件！");
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }
  }
}
