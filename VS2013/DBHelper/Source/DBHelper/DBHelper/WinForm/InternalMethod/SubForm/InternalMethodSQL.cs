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
using System.Transactions;

namespace DBHelper
{
  public partial class InternalMethodSQL : InternalMethodStatementTemplate
  {
    private int CurrentStatementID = 0;

    public InternalMethodSQL()
    {
      InitializeComponent();
      gvSQL.AutoGenerateColumns = false;
    }

    private void InternalMethodSQL_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvSQL);
      MethodStatementListLoad();
      SetControlTip();
    }
    
    private void SetControlTip()
    {
      TipCustome.SetToolTip(Statement, "双击编辑SQL语句");
    }

    private void MethodStatementListLoad()
    {
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable result = internalmethodbll.MethodStatementList(MethodID.ToString());
      gvSQL.DataSource = result;
    }

    private void MethodStatementSaveMain(string Tag)
    {
      try
      {
        bool isAdd = CurrentStatementID == 0;
        MethodStatementModel methodstatementmodel = new MethodStatementModel()
        {
          StatementID = CurrentStatementID,
          MethodID    = this.MethodID,
          Tag         = Tag
        };
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        CurrentStatementID = internalmethodbll.MethodStatementSaveMain(methodstatementmodel);
        AfterMethodStatementSaveMain(isAdd);
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }

    private void gvSQL_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
      string Tag = Common.DataGridViewCommonOperate.GetIdentilyVal<string>(gvSQL, e.RowIndex, "Tag");
      if (string.IsNullOrWhiteSpace(Tag)) return;
      MethodStatementSaveMain(Tag);
    }

    private void gvSQL_CurrentCellChanged(object sender, EventArgs e)
    {
      if (gvSQL.CurrentCell == null || gvSQL.CurrentRow.IsNewRow)
      {
        CurrentStatementID = 0;
        return;
      }
      CurrentStatementID = Common.DataGridViewCommonOperate.GetIdentilyVal<int>(gvSQL, gvSQL.CurrentCell.RowIndex);
      MethodStatementDisplay();
      MethodStatementConditionalDisplay();
    }

    private void HasConditional_CheckedChanged(object sender, EventArgs e)
    {
      pnlCondition.Enabled = HasConditional.Checked;
      btnOK.Enabled        = HasConditional.Checked;
      if (HasConditional.Checked) btnExtractParameter_Click(null, null);
    }

    private void btnExtractParameter_Click(object sender, EventArgs e)
    {
      BindConditionType();
      BindParameter();
      BindExpectBehavior();
    }

    private void BindEmpty2ComboBox(ComboBox cbb)
    {
      ListControlOperater.BindEmpty2ListCtr(cbb);
    }
    private void BindParameter(List<string> list, ComboBox cbb)
    {
      cbb.Items.Clear();
      BindEmpty2ComboBox(cbb);
      ListControlOperater.Bind2ListCtr(list, cbb);
    }

    private void BindParameter()
    {
      string strsql = Statement.Text.TrimStart();
      List<string> ParamerList = ExtractParamer(MethodType.SQLStatement, strsql);
      BindParameter(ParamerList, ParameterName1);
      BindParameter(ParamerList, ParameterName2);
      BindParameter(ParamerList, ParameterName3);
      BindParameter(ParamerList, ParameterName4);
      BindParameter(ParamerList, ParameterName5);
    }

    private void BindExpectBehavior(ComboBox cbb)
    {
      cbb.Items.Clear();
      BindEmpty2ComboBox(cbb);
      EnumManager<BehaviorType>.Bind2ComboBox(cbb);
    }

    private void BindExpectBehavior()
    {
      BindExpectBehavior(ExpectBehavior1);
      BindExpectBehavior(ExpectBehavior2);
      BindExpectBehavior(ExpectBehavior3);
      BindExpectBehavior(ExpectBehavior4);
      BindExpectBehavior(ExpectBehavior5);
    }

    private void BindConditionType(ComboBox cbb)
    {
      cbb.Items.Clear();
      BindEmpty2ComboBox(cbb);
      EnumManager<ConditionType>.Bind2ComboBox(cbb);
    }

    private void BindConditionType()
    {
      BindConditionType(ConditionType1);
      BindConditionType(ConditionType2);
      BindConditionType(ConditionType3);
      BindConditionType(ConditionType4);
      BindConditionType(ConditionType5);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      using (TransactionScope ts = new TransactionScope())
      {
        if (HasConditional.Checked)
        {
          SaveMethodStatementConditional();
        }
        ts.Complete();

        lblSaveMsg.Text = "保存成功";
      }
    }

    private void SaveMethodStatementConditional()
    {
      try
      {
        for (int i = 1; i <= 5; i++)
        {
          string rn                  = i.ToString();
          TextBox txtConditionalID   = pnlCondition.Controls[string.Format("ConditionalID{0}", rn)] as TextBox;
          ComboBox cbbConditionType  = pnlCondition.Controls[string.Format("ConditionType{0}", rn)] as ComboBox;
          ComboBox cbbParameterName  = pnlCondition.Controls[string.Format("ParameterName{0}", rn)] as ComboBox;
          ComboBox cbbExpectBehavior = pnlCondition.Controls[string.Format("ExpectBehavior{0}", rn)] as ComboBox;
          TextBox txtCompareValue    = pnlCondition.Controls[string.Format("CompareValue{0}", rn)] as TextBox;

          int ConditionalID          = CommonUtil.ConvertString2OtherType<int>(txtConditionalID.Text.Trim());
          string ConditionType       = GetComboBoxValue(cbbConditionType);
          string ParameterName       = GetComboBoxValue(cbbParameterName);
          string ExpectBehavior      = GetComboBoxValue(cbbExpectBehavior);
          string CompareValue        = txtCompareValue.Text.Trim();

          if (string.IsNullOrWhiteSpace(ParameterName) || string.IsNullOrWhiteSpace(ExpectBehavior))
          {
            continue;
          }

          MethodStatementConditionalModel methodstatementconditionalmodel = new MethodStatementConditionalModel()
          {
            ConditionalID = ConditionalID,
            StatementID = CurrentStatementID,
            MethodID = MethodID,
            ConditionType = ConditionType,
            ParameterName = ParameterName,
            ExpectBehavior = ExpectBehavior,
            CompareValue = CompareValue
          };
          InternalMethodBLL internalmethodbll = new InternalMethodBLL();
          txtConditionalID.Text = CommonUtil.TranNull<string>(internalmethodbll.MethodStatementConditionalSave(methodstatementconditionalmodel));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private string GetComboBoxValue(ComboBox cbb)
    {
      return ListControlOperater.GetComboBoxKey(cbb);
    }

    private void gvSQL_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
      DataGridViewCommonOperate.ShowContextMenu(gvSQL, CMForgvSQL, e);
    }

    private void OpenSQLEditForm()
    {
      InternalMethodSQLSt Frm = new InternalMethodSQLSt();
      Frm.StatementID         = CurrentStatementID;
      Frm.StatementText       = Statement.Text;
      Frm.Owner               = this;
      Frm.ShowDialog();
      if (Frm.DialogResult == DialogResult.OK)
      {
        Statement.Text = Frm.StatementText;
      }
    }

    private void AfterMethodStatementSaveMain(bool isAdd)
    {
      if (isAdd)
      {
        OpenSQLEditForm();
        MethodStatementListLoad();
      }
    }

    private void IsOrderby_Click(object sender, EventArgs e)
    {
      string FieldName = "IsOrderby";
      string FieldValue = CommonUtil.TranNull<int>(IsOrderby.Checked).ToString();
      MethodStatementUpdateStatus(FieldName, FieldValue);
    }

    private void HasConditional_Click(object sender, EventArgs e)
    {
      string FieldName = "HasConditional";
      string FieldValue = CommonUtil.TranNull<int>(HasConditional.Checked).ToString();
      MethodStatementUpdateStatus(FieldName, FieldValue);
    }

    private void MethodStatementUpdateStatus(string FieldName, string FieldValue)
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        bool result                         = internalmethodbll.MethodStatementUpdateStatus(FieldName, FieldValue, CurrentStatementID.ToString());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void MethodStatementDisplay()
    {
      InitMethodStatementControl();
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable dt                        = internalmethodbll.MethodStatementDisplay(CurrentStatementID.ToString());
      if (dt.Rows.Count == 0) return;
      Statement.Text                      = CommonUtil.TranNull<string>(dt.Rows[0]["Statement"]);
      IsOrderby.Checked                   = CommonUtil.TranNull<bool>(dt.Rows[0]["IsOrderby"]);
      HasConditional.Checked              = CommonUtil.TranNull<bool>(dt.Rows[0]["HasConditional"]);
    }

    private void MethodStatementConditionalDisplay()
    {
      InitMethodStatementConditionalControl();
      if (!pnlCondition.Enabled) return;
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable dt                        = internalmethodbll.MethodStatementConditionalDisplay(CurrentStatementID.ToString());
      if (dt.Rows.Count == 0) return;
      int i = 0;
      foreach (DataRow dr in dt.Rows)
      {
        i++;
        string rn                  = i.ToString();
        TextBox txtConditionalID   = pnlCondition.Controls[string.Format("ConditionalID{0}", rn)] as TextBox;
        ComboBox cbbConditionType  = pnlCondition.Controls[string.Format("ConditionType{0}", rn)] as ComboBox;
        ComboBox cbbParameterName  = pnlCondition.Controls[string.Format("ParameterName{0}", rn)] as ComboBox;
        ComboBox cbbExpectBehavior = pnlCondition.Controls[string.Format("ExpectBehavior{0}", rn)] as ComboBox;
        TextBox txtCompareValue    = pnlCondition.Controls[string.Format("CompareValue{0}", rn)] as TextBox;

        txtConditionalID.Text = CommonUtil.TranNull<string>(dr["ConditionalID"]);
        ListControlOperater.SetListCtrSelectedItem(cbbConditionType, CommonUtil.TranNull<string>(dr["ConditionType"]));
        ListControlOperater.SetListCtrSelectedItem(cbbParameterName, CommonUtil.TranNull<string>(dr["ParameterName"]));
        ListControlOperater.SetListCtrSelectedItem(cbbExpectBehavior, CommonUtil.TranNull<string>(dr["ExpectBehavior"]));
        txtCompareValue.Text = CommonUtil.TranNull<string>(dr["CompareValue"]);
      }
    }

    private void InitMethodStatementControl()
    {
      Statement.Text         = "";    
      IsOrderby.Checked      = false;
      HasConditional.Checked = false;
    }

    private void InitMethodStatementConditionalControl()
    {
      for (int i = 1; i <= 5; i++)
      {
        string rn                       = i.ToString();
        TextBox txtConditionalID        = pnlCondition.Controls[string.Format("ConditionalID{0}", rn)] as TextBox;
        ComboBox cbbConditionType       = pnlCondition.Controls[string.Format("ConditionType{0}", rn)] as ComboBox;
        ComboBox cbbParameterName       = pnlCondition.Controls[string.Format("ParameterName{0}", rn)] as ComboBox;
        ComboBox cbbExpectBehavior      = pnlCondition.Controls[string.Format("ExpectBehavior{0}", rn)] as ComboBox;
        TextBox txtCompareValue         = pnlCondition.Controls[string.Format("CompareValue{0}", rn)] as TextBox;

        txtConditionalID.Text           = "0";
        ListControlOperater.SetListCtrDaultSelectItem(cbbConditionType);
        ListControlOperater.SetListCtrDaultSelectItem(cbbParameterName);
        ListControlOperater.SetListCtrDaultSelectItem(cbbExpectBehavior);
        txtCompareValue.Text            = "";
      }
    }

    private void MethodStatementMove(string IsMoveUp)
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        bool result                         = internalmethodbll.MethodStatementMove(CurrentStatementID.ToString(), IsMoveUp);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void miMoveUp_Click(object sender, EventArgs e)
    {
      MethodStatementMove(((int)SQLStatementMove.MoveUp).ToString());
      MethodStatementListLoad();
    }

    private void miMoveDown_Click(object sender, EventArgs e)
    {
      MethodStatementMove(((int)SQLStatementMove.MoveDown).ToString());
      MethodStatementListLoad();
    }

    private void miDelete_Click(object sender, EventArgs e)
    {
      MethodStatementDelete();
      MethodStatementListLoad();
    }

    public void MethodStatementDelete()
    {
      try
      {
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        bool result                         = internalmethodbll.MethodStatementDelete(CurrentStatementID.ToString());
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void Statement_DoubleClick(object sender, EventArgs e)
    {
      OpenSQLEditForm();
    }

    private void btnMgrParameter_Click(object sender, EventArgs e)
    {
      OpenInternalMethodStatementForm.OpenParameterForm(MethodID);
    }
  }
}
