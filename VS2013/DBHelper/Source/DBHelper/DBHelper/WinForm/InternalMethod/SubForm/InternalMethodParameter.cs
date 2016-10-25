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
  public partial class InternalMethodParameter : InternalMethodStatementTemplate
  {
    private string StoredProcedureName;
    private MethodType MethodType;
    private FunctionType FunctionType;

    public InternalMethodParameter()
    {
      InitializeComponent();
      gvParameter.AutoGenerateColumns = false;
    }

    private void InternalMethodParameter_Load(object sender, EventArgs e)
    {
      MethodParameterMain();
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvParameter);
      MethodParameterListLoad();
    }

    public void MethodParameterMain()
    {
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      internalmethodbll.MethodParameterMain(MethodID.ToString(), ref StoredProcedureName, ref MethodType, ref FunctionType);
    }

    private void MethodParameterListLoad()
    {
      BindDataGridViewComboBoxColumn();

      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable dt                        = internalmethodbll.MethodParameterList(MethodID.ToString());
      gvParameter.DataSource              = dt;
    }

    private void BindDataGridViewComboBoxColumn()
    {
      EnumManager<Enums.ParameterDataType>.Bind2DataGridViewComboBoxColumn(ParameterDataType);
      EnumManager<Enums.ParameterDirection>.Bind2DataGridViewComboBoxColumn(ParameterDirection);
      EnumManager<Enums.ParameterValidateType>.Bind2DataGridViewComboBoxColumn(ParameterValidateType);
    }

    private void btnExtractParameter_Click(object sender, EventArgs e)
    {
      string FullStatement = MethodType == Enums.MethodType.SQLStatement ? GetFullStatement() : StoredProcedureName;
      List<string> ParameterList = ExtractParamer(this.MethodType, FullStatement);
      foreach (string ParameterName in ParameterList)
      {
        MethodParameterSaveMain(ParameterName);
      }
      MethodParameterListLoad();
    }

    private string GetFullStatement()
    {
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      string FullStatement                = internalmethodbll.MethodParameterAllStatement(MethodID.ToString());
      return FullStatement;
    }

    private void MethodParameterSaveMain(string ParameterName)
    {
      try
      {
        MethodParameterModel methodparametermodel = new MethodParameterModel()
        {
          ParameterID           = 0,
          MethodID              = this.MethodID,
          ParameterName         = ParameterName,
          ParameterDataType     = EnumManager<Enums.ParameterDataType>.Enum2EnumName(Enums.ParameterDataType.Varchar),
          ParameterDirection    = EnumManager<Enums.ParameterDirection>.Enum2EnumName(Enums.ParameterDirection.In),
          ParameterValidateType = EnumManager<Enums.ParameterValidateType>.Enum2EnumName(Enums.ParameterValidateType.None)
        };
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        internalmethodbll.MethodParameterSaveMain(methodparametermodel);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void MethodParameterUpdate(string FieldName, string FieldValue, string ParameterID)
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        internalmethodbll.MethodParameterUpdate(FieldName, FieldValue, ParameterID);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void gvParameter_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      string FieldName   = gvParameter.Columns[e.ColumnIndex].Name;
      string FieldValue  = CommonUtil.TranNull<string>(gvParameter.CurrentCell.Value);
      if (string.IsNullOrWhiteSpace(FieldValue)) return;
      if (FieldName.Equals("ParameterName", StringComparison.Ordinal))
      {
        MethodParameterSaveMain(FieldValue);
        AfterSaveMain();
      }
      else
      {
        string ParameterID = Common.DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameter, e.RowIndex);
        MethodParameterUpdate(FieldName, FieldValue, ParameterID);
      }
    }

    private void btnAddParameter_Click(object sender, EventArgs e)
    {
      int Rowindex = gvParameter.Rows.Count-1;
      DataGridViewCommonOperate.SetCellFocus(gvParameter, Rowindex, 1);
    }

    private void AfterSaveMain()
    {
      MethodParameterListLoad();
      int Rowindex = gvParameter.Rows.Count-2;
      DataGridViewCommonOperate.SetCellFocus(gvParameter, Rowindex, 2);
    }

    private void miDelete_Click(object sender, EventArgs e)
    {
      int RowIndex = gvParameter.CurrentCell.RowIndex;
      string ParameterID = Common.DataGridViewCommonOperate.GetIdentilyVal<string>(gvParameter, RowIndex);
      MethodParameterDelete(ParameterID);
      DataGridViewCommonOperate.DeleteRow(gvParameter, RowIndex);
    }

    private void gvParameter_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvParameter, CMgvParameter, e);
    }

    private void MethodParameterDelete(string ParameterID)
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        internalmethodbll.MethodParameterDelete(ParameterID);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      //TODO
      DBHelperMessage.Info("测试成功！");
    }
  }
}
