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
using System.Reflection;

namespace DBHelper
{
  public partial class DeveloperMgr : Form
  {
    public DeveloperMgr()
    {
      InitializeComponent();
      gvUser.AutoGenerateColumns = false;
    }

    private void DeveloperMgr_Load(object sender, EventArgs e)
    {
      Common.DataGridViewCommonOperate.SetGridViewHeadStyle(gvUser);
      gvUserLoad();
    }

    

    private void gvUserLoad()
    {
      UserInfoBLL userinfobll = new UserInfoBLL();
      DataTable dt            = userinfobll.UserInfoList();
      gvUser.DataSource       = dt;
    }

    private void gvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      string[] arrpower = { "IsAddSelf", "IsEditSelf", "IsDeleteSelf", "IsEditOther", "IsDeleteOther", "HasDeleted"  };
      string columnname = gvUser.Columns[e.ColumnIndex].Name;
      if (!arrpower.Contains(columnname)) return;
      
      string FieldName = columnname;
      string FieldValue = "1"; 
      if (!columnname.Equals("HasDeleted"))
      {
        FieldValue = CommonUtil.TranNull<int>(gvUser.CurrentCell.EditedFormattedValue).ToString();
      }
      string UserID = Common.DataGridViewCommonOperate.GetIdentilyVal<string>(gvUser, e.RowIndex);
      bool result   = UserEidt(FieldName, FieldValue, UserID);
      if (result && columnname.Equals("HasDeleted"))
      {
        Common.DataGridViewCommonOperate.DeleteRow(gvUser, e.RowIndex);
      }
    }

    private bool UserEidt(string FieldName, string FieldValue, string UserID)
    {
      bool result = false;
      try
      {
        UserInfoBLL userinfobll = new UserInfoBLL();
        result                  = userinfobll.UserEdit(FieldName, FieldValue, UserID);
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
      return result;
    }

    private void btnNewDeveloper_Click(object sender, EventArgs e)
    {
      try
      {
        string Usercode = txtUsercode.Text.Trim();
        string Username = txtUsername.Text.Trim();
        UserInfoBLL userinfobll = new UserInfoBLL();
        bool result             = userinfobll.UserAdd(Usercode, Username);
        if (result)
        {
          gvUserLoad();
          txtUsercode.Text = "";
          txtUsername.Text = "";
          txtUsercode.Focus();
        }
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }
  }
}


