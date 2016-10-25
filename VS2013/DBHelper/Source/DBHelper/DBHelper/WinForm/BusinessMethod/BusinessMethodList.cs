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
  public partial class BusinessMethodList : Form
  {
    public int ClassifyID { get; set; }

    public BusinessMethodList()
    {
      InitializeComponent();
      ucMethodClassifyList.OnListBoxSelectedIndexChanged += OnListBoxSelectedIndexChanged;
      gvBusinessMethod.AutoGenerateColumns = false;
    }

    private void BusinessMethodList_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvBusinessMethod);
      (this.ParentForm as MainForm).EnableBusinessMethodMenu();
    }

    private void OnListBoxSelectedIndexChanged(object sender, MethodClassifyListEventArgs e)
    {
      ClassifyID = e.Value;
      BusinessMethodListLoad();
    }

    public void BusinessMethodListLoad()
    {
      string Keyword                      = txtKeyword.Text.Trim();
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      DataTable dt                        = businessmethodbll.BusinessMethodList(Common.Common.OperateDbID.ToString(), ClassifyID.ToString(), Keyword);
      gvBusinessMethod.DataSource         = dt;
    }

    private void btnQuery_Click(object sender, EventArgs e)
    {
      BusinessMethodListLoad();
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
      //TODO
    }

    private void btnGenerateXml_Click(object sender, EventArgs e)
    {
      //TODO
    }

    private void BusinessMethodList_FormClosed(object sender, FormClosedEventArgs e)
    {
      MethodClassifyListEventArgs.OldKey   = string.Empty;
      MethodClassifyListEventArgs.OldValue = 0;
      (this.ParentForm as MainForm).DisableBusinessMethodMenu();
    }

    private void gvBusinessMethod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1) return;
      string BMCode = DataGridViewCommonOperate.GetIdentilyVal<string>(gvBusinessMethod, e.RowIndex, "BMCode");
      OpenBusinessMethodSubForm.OpenEditForm((MainForm)this.ParentForm, BMCode, CanNext: false);
    }

    private void miEdit_Click(object sender, EventArgs e)
    {
      string BMCode = GetBMCode();
      OpenBusinessMethodSubForm.OpenEditForm((MainForm)this.ParentForm, BMCode, CanNext: false);
    }

    private void miBindIM_Click(object sender, EventArgs e)
    {
      string BMCode = GetBMCode();
      OpenBusinessMethodSubForm.OpenBindIMForm((MainForm)this.ParentForm, BMCode, CanNext: false);
    }

    private void miSetParameterRelations_Click(object sender, EventArgs e)
    {
      string BMCode = GetBMCode();
      OpenBusinessMethodSubForm.OpenParameterRelationsForm((MainForm)this.ParentForm, BMCode, CanNext: false);
    }

    private void miParameter_Click(object sender, EventArgs e)
    {
      string BMCode = GetBMCode();
      OpenBusinessMethodSubForm.OpenParameterForm((MainForm)this.ParentForm, BMCode, CanNext: false);
    }

    private void miDelete_Click(object sender, EventArgs e)
    {
      string BMCode                       = GetBMCode();
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      bool result                         = businessmethodbll.BusinessMethodDelete(BMCode);
      if (result)
      {
        DataGridViewCommonOperate.DeleteRow(gvBusinessMethod);
      }
    }

    private void gvBusinessMethod_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvBusinessMethod, CMForgvBusinessMethod, e);
    }

    private string GetBMCode()
    {
      string BMCode = DataGridViewCommonOperate.GetIdentilyVal<string>(gvBusinessMethod, "BMCode");
      return BMCode;
    }
  }
}
