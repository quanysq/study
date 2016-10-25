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
  public partial class BusinessMethodParameterRelations : BusinessMethodSubFormTemplate
  {
    public BusinessMethodParameterRelations()
    {
      InitializeComponent();
      gvSelected.AutoGenerateColumns = false;
      gvParameterRelations.AutoGenerateColumns = false;
    }

    private void BusinessMethodParameterRelations_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvSelected);
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvParameterRelations);
      gvSelectedLoad();
    }

    protected override void gvSelectedLoad()
    {
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      DataTable dt                        = businessmethodbll.BusinessMethodIMSelected(BMCode);
      gvSelected.DataSource               = dt;
    }

    private void gvParameterRelationsLoad(DataTable dt)
    {
      gvParameterRelations.DataSource = null;
      if (dt == null) return;
      gvParameterRelations.DataSource = dt;
      //DataGridViewCommonOperate.SetCellFocus(gvParameterRelations, 0, 4);
    }

    private void gvSelected_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvSelected, CMForgvSelected, e);
    }

    private void gvSelected_CurrentCellChanged(object sender, EventArgs e)
    {
      if (gvSelected.CurrentCell == null) return;
      BusinessMethodPRSave();
    }

    private void miMoveup_Click(object sender, EventArgs e)
    {
      BusinessMethodIMMove(((int)SQLStatementMove.MoveUp).ToString(), gvSelected);
    }

    private void miMovedown_Click(object sender, EventArgs e)
    {
      BusinessMethodIMMove(((int)SQLStatementMove.MoveDown).ToString(), gvSelected);
    }

    private void BusinessMethodPRSave()
    {
      BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel = new BusinessMethod_ParameterRelationsModel();
      businessmethod_parameterrelationsmodel.BMCode                                 = this.BMCode;
      businessmethod_parameterrelationsmodel.MethodID                               = DataGridViewCommonOperate.GetIdentilyVal<int>(gvSelected);
      BusinessMethodBLL businessmethodbll                                           = new BusinessMethodBLL();
      DataTable dt                                                                  = businessmethodbll.BusinessMethodPRSave(businessmethod_parameterrelationsmodel);
      gvParameterRelationsLoad(dt);
    }

    private void BusinessMethodPRUpdate(BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel)
    {
      try
      {
        BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
        bool result                         = businessmethodbll.BusinessMethodPRUpdate(businessmethod_parameterrelationsmodel);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void gvParameterRelations_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      if (gvParameterRelations.Columns[e.ColumnIndex].Name.Equals("BMParameterName", StringComparison.OrdinalIgnoreCase)) return;
      BusinessMethod_ParameterRelationsModel businessmethod_parameterrelationsmodel = new BusinessMethod_ParameterRelationsModel();
      businessmethod_parameterrelationsmodel.BMParameterName                        = DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameterRelations, "gvParameterRelations_BMParameterName");
      businessmethod_parameterrelationsmodel.BMCode                                 = DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameterRelations, "gvParameterRelations_BMCode");
      businessmethod_parameterrelationsmodel.MethodID                               = DataGridViewCommonOperate.GetIdentilyVal<int>(gvParameterRelations, "gvParameterRelations_MethodID");
      businessmethod_parameterrelationsmodel.MethodParameterName                    = DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameterRelations, "gvParameterRelations_MethodParameterName");
      BusinessMethodPRUpdate(businessmethod_parameterrelationsmodel);
    }

    private void btnBind_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
  }
}
