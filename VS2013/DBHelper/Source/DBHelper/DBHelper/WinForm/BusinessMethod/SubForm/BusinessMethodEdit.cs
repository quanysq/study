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
  public partial class BusinessMethodEdit : BusinessMethodSubFormTemplate
  {
    public BusinessMethodEdit()
    {
      InitializeComponent();
    }

    private void BusinessMethodEdit_Load(object sender, EventArgs e)
    {
      FunctionTypeLoad();
      LoadData();
    }

    private void FunctionTypeLoad()
    {
      ListControlOperater.BindEmpty2ListCtr(cbbFunctionType);
      EnumManager<FunctionType>.Bind2ComboBox(cbbFunctionType);
    }

    private void GenterateBMCode()
    {
      try
      {
        BusinessMethodBLL businessmethodbll = new BusinessMethodBLL();
        this.BMCode                         = businessmethodbll.BusinessMethodCode();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void LoadData()
    {
      if (CanNext)
      {
        GenterateBMCode();
        txtBMCode.Text = BMCode;
      }
      else
      { 
        BusinessMethodBLL businessmethodbll     = new BusinessMethodBLL();
        BusinessMethodModel businessmethodmodel = businessmethodbll.BusinessMethodQuery(BMCode);
        txtBMCode.Text                          = businessmethodmodel.BMCode;
        BMDesc.Text                             = businessmethodmodel.BMDesc;
        ListControlOperater.SetListCtrSelectedItem(cbbFunctionType, businessmethodmodel.FunctionType);
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      BusinessMethodSave();
      AfterBusinessMethodSave();
    }

    private void BusinessMethodSave()
    {
      try
      {
        BusinessMethodModel businessmethodmodel = new BusinessMethodModel()
        {
          BMCode       = this.BMCode,
          DatabaseID   = Common.Common.OperateDbID,
          ClassifyID   = ((BusinessMethodList)this.Owner).ClassifyID,
          BMDesc       = BMDesc.Text.Trim(),
          FunctionType = ListControlOperater.GetComboBoxKey(cbbFunctionType),
          UpdateReson  = ""
        };
        BusinessMethodBLL businessmethodbll     = new BusinessMethodBLL();
        string result                           = businessmethodbll.BusinessMethodSave(businessmethodmodel);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void AfterBusinessMethodSave()
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      ((BusinessMethodList)this.Owner).BusinessMethodListLoad();
      this.Close();
    }
  }
}