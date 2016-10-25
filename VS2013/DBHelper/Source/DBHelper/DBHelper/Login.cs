using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.BLL;
using DBHelper.Model;
using DBHelper.Common;

namespace DBHelper
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          UserInfoBLL userinfobll = new UserInfoBLL();
          bool LoginStatus = userinfobll.Login(Usercode.Text, Pwd.Text);
          if (!LoginStatus)
          {
            DBHelperMessage.Alert("登录失败，请检查用户名和密码!");
          }
          else
          {
            this.DialogResult = DialogResult.OK;
            this.Close();
          }
        }
    }
}
