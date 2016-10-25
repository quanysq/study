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
  public partial class InternalMethodSP : InternalMethodTemplete
  {
    public InternalMethodSP()
    {
      InitializeComponent();
    }

    private void InternalMethodSP_Load(object sender, EventArgs e)
    {
      FunctionTypeLoad();
      Init();
    }

    private void FunctionTypeLoad()
    {
      ListControlOperater.BindEmpty2ListCtr(cbbFunctionType);
      EnumManager<FunctionType>.Bind2ComboBox(cbbFunctionType);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      InternalMethodModel internalmethodmodel = new InternalMethodModel()
      {
        MethodID     = this.MethodID,
        DatabaseID   = Common.Common.OperateDbID,
        ClassifyID   = this.ClassifyID,
        MethodName   = this.MethodName.Text.Trim(),
        MethodDesc   = this.MethodDesc.Text.Trim(),
        MethodType   = EnumManager<MethodType>.Enum2EnumName(this.MethodType),
        FunctionType = ListControlOperater.GetComboBoxKey(cbbFunctionType),
        SuccessMsg   = this.SuccessMsg.Text.Trim(),
        FailMsg      = this.FailMsg.Text.Trim()
      };
      SaveInternalMethod(internalmethodmodel);
    }

    protected override void LoadData()
    {
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable result                    = internalmethodbll.InternalMethodDDLSP(MethodID.ToString());
      if (result.Rows.Count == 0) return;
      ClassifyID                          = CommonUtil.TranNull<int>(result.Rows[0]["ClassifyID"]);
      MethodName.Text                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodName"]);
      MethodDesc.Text                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodDesc"]);
      MethodType                          = EnumManager<MethodType>.EnumName2Enum(result.Rows[0]["MethodType"]);
      FunctionType                        = EnumManager<FunctionType>.EnumName2Enum(result.Rows[0]["FunctionType"]);
      SuccessMsg.Text                     = CommonUtil.TranNull<string>(result.Rows[0]["SuccessMsg"]);
      FailMsg.Text                        = CommonUtil.TranNull<string>(result.Rows[0]["FailMsg"]);
      string sFunctionType                = EnumManager<FunctionType>.Enum2EnumName(this.FunctionType);
      ListControlOperater.SetListCtrSelectedItem(cbbFunctionType, sFunctionType);
    }


  }
}
