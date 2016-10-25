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
  public partial class BusinessMethodBindIM : BusinessMethodSubFormTemplate
  {
    public BusinessMethodBindIM()
    {
      InitializeComponent();
      gvInternalMethod.AutoGenerateColumns = false;
      gvSelected.AutoGenerateColumns = false;
    }

    private void BusinessMethodBindIM_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvInternalMethod);
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvSelected);
      gvInternalMethodLoad();
      gvSelectedLoad();
    }

    private void gvInternalMethodLoad()
    {
      string Keyword                      = txtKeyword.Text.Trim();
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      DataTable dt                        = businessmethodbll.BusinessMethodAllIM(Common.Common.OperateDbID.ToString(), Keyword);
      gvInternalMethod.DataSource         = dt;
    }

    protected override void gvSelectedLoad()
    {
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      DataTable dt                        = businessmethodbll.BusinessMethodIMSelected(BMCode);
      gvSelected.DataSource               = dt;
    }

    private void gvInternalMethod_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvInternalMethod, CMForgvInternalMethod, e);
    }

    private void gvSelected_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvSelected, CMForgvSelected, e);
    }

    private void miSelect_Click(object sender, EventArgs e)
    {
      try
      {
        BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel = new BusinessMethod_InternalMethodsModel();
        businessmethod_internalmethodsmodel.BMCode                              = this.BMCode;
        businessmethod_internalmethodsmodel.MethodID                            = DataGridViewCommonOperate.GetIdentilyVal<int>(gvInternalMethod);
        BusinessMethodBLL businessmethodbll                                     = new BusinessMethodBLL();
        bool result = businessmethodbll.BusinessMethodIMSave(businessmethod_internalmethodsmodel);
        if (result)
        {
          gvSelectedLoad();
        }
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private void miMoveup_Click(object sender, EventArgs e)
    {
      BusinessMethodIMMove(((int)SQLStatementMove.MoveUp).ToString(), gvSelected);
    }

    private void miMovedown_Click(object sender, EventArgs e)
    {
      BusinessMethodIMMove(((int)SQLStatementMove.MoveDown).ToString(), gvSelected);
    }

    private void miCancelSelect_Click(object sender, EventArgs e)
    {
      try
      {
        BusinessMethod_InternalMethodsModel businessmethod_internalmethodsmodel = new BusinessMethod_InternalMethodsModel();
        businessmethod_internalmethodsmodel.BMCode                              = this.BMCode;
        businessmethod_internalmethodsmodel.MethodID                            = DataGridViewCommonOperate.GetIdentilyVal<int>(gvSelected);
        BusinessMethodBLL businessmethodbll                                     = new BusinessMethodBLL();
        bool result = businessmethodbll.BusinessMethodIMDelete(businessmethod_internalmethodsmodel);
        if (result)
        {
          DataGridViewCommonOperate.DeleteRow(gvSelected);
        }
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private void btnBind_Click(object sender, EventArgs e)
    {
      if (gvSelected.Rows.Count == 0)
      {
        DBHelperMessage.Alert("请选择元素方法");
        return;
      }
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.Close();
    }
  }
}
