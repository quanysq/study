using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBHelper.Common
{
  class DBHelperMessage
  {
    public static DialogResult Alert(string content)
    {
      return MessageBox.Show(content, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static DialogResult Info(string content)
    {
      return MessageBox.Show(content, "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static DialogResult Error(Exception ex)
    {
      DBHelper.Error ErrorFrm = new DBHelper.Error();
      ErrorFrm.Exception = ex;
      return ErrorFrm.ShowDialog();
    }

    public static DialogResult Confirm(string content)
    {
      return MessageBox.Show(content, "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    }
  }
}
