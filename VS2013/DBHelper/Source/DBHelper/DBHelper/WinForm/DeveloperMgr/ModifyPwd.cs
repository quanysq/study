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
  public partial class ModifyPwd : Form
  {
    public ModifyPwd()
    {
      InitializeComponent();
    }

    private void btnChange_Click(object sender, EventArgs e)
    {
      try
      {
        UserInfoModel.Instance.Pwd = NewPwd.Text.Trim();
        UserInfoBLL userinfobll = new UserInfoBLL();
        bool result = userinfobll.ModifyPwd(UserInfoModel.Instance);
        if (result)
        {
          this.Close();
        }
      }
      catch (Exception ex)
      {
        DBHelperMessage.Error(ex);
      }
    }
  }
}
