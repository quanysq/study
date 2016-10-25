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
  public partial class BusinessMethodParameter : BusinessMethodSubFormTemplate
  {
    public BusinessMethodParameter()
    {
      InitializeComponent();
      gvParameter.AutoGenerateColumns = false;
    }

    private void BusinessMethodParameter_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvParameter);
      BindDataGridViewComboBoxColumn();
      DataTable dt = BusinessMethodPMList();
      gvInternalMethodLoad(dt);
    }

    private void gvInternalMethodLoad(DataTable dt)
    {
      gvParameter.DataSource = dt;
    }

    private DataTable BusinessMethodPMList()
    {
      BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
      DataTable dt                        = businessmethodbll.BusinessMethodPMList(BMCode);
      return dt;
    }

    private void BindDataGridViewComboBoxColumn()
    {
      EnumManager<Enums.ParameterDataType>.Bind2DataGridViewComboBoxColumn(ParameterDataType);
      EnumManager<Enums.ParameterDirection>.Bind2DataGridViewComboBoxColumn(ParameterDirection);
      EnumManager<Enums.ParameterValidateType>.Bind2DataGridViewComboBoxColumn(ParameterValidateType);
    }

    private void btnExtractParameter_Click(object sender, EventArgs e)
    {
      try
      {
        BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
        DataTable dt                        = businessmethodbll.BusinessMethodPMSave(BMCode);
        gvInternalMethodLoad(dt);
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private void gvParameter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      string FieldName   = gvParameter.Columns[e.ColumnIndex].Name;
      string FieldValue  = CommonUtil.TranNull<string>(gvParameter.CurrentCell.Value);
      if (string.IsNullOrWhiteSpace(FieldValue)) return;
      string ParameterID = Common.DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameter, e.RowIndex);
      BusinessMethodPMUpdate(FieldName, FieldValue, ParameterID);
    }

    private void BusinessMethodPMUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
        businessmethodbll.BusinessMethodPMUpdate(FieldName, FieldValue, ParameterID);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
