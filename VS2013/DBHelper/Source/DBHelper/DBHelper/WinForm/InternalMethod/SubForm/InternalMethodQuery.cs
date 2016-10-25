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
  public partial class InternalMethodQuery : InternalMethodTemplete
  {
    public InternalMethodQuery()
    {
      InitializeComponent();
    }

    private void InternalMethodQuery_Load(object sender, EventArgs e)
    {
      Init();
    }

    private void FunctionType_Paging_Click(object sender, EventArgs e)
    {
      FunctionType = Enums.FunctionType.Select_Paging;
    }

    private void FunctionType_Rows_Click(object sender, EventArgs e)
    {
      FunctionType = Enums.FunctionType.Select_Rows;
    }

    private void FunctionType_View_Click(object sender, EventArgs e)
    {
      FunctionType = Enums.FunctionType.Select_View;
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
        FunctionType = EnumManager<FunctionType>.Enum2EnumName(this.FunctionType)
      };
      SaveInternalMethod(internalmethodmodel);
    }

    protected override void LoadData()
    {
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      DataTable result                    = internalmethodbll.InternalMethodQuery(MethodID.ToString());
      if (result.Rows.Count == 0) return;
      ClassifyID                          = CommonUtil.TranNull<int>(result.Rows[0]["ClassifyID"]);
      MethodName.Text                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodName"]);
      MethodDesc.Text                     = CommonUtil.TranNull<string>(result.Rows[0]["MethodDesc"]);
      MethodType                          = EnumManager<MethodType>.EnumName2Enum(result.Rows[0]["MethodType"]);
      FunctionType                        = EnumManager<FunctionType>.EnumName2Enum(result.Rows[0]["FunctionType"]);
      SetFunctionTypeRadioStatus(FunctionType);
    }

    private void SetFunctionTypeRadioStatus(FunctionType FunctionType)
    {
      switch (FunctionType)
      {
        case Enums.FunctionType.Select_Paging:
          FunctionType_Paging.Checked = true;
          break;
        case Enums.FunctionType.Select_Rows:
          FunctionType_Rows.Checked = true;
          break;
        case Enums.FunctionType.Select_View:
          FunctionType_View.Checked = true;
          break;
        default:
          throw new NotSupportedException("不支持此类型！");
      }
    }
  }
}
