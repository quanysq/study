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
  public partial class AddMethodClassify : Form
  {
    public int ClassifyType { get; set; }

    public AddMethodClassify()
    {
      InitializeComponent();
    }

    private void btnAddClassify_Click(object sender, EventArgs e)
    {
      try
      {
        MethodClassifyModel methodclassifymodel = new MethodClassifyModel()
        {
          DatabaseID   = Common.Common.OperateDbID,
          ClassifyName = this.ClassifyName.Text.Trim(),
          ClassifyType = this.ClassifyType
        };
        MethodClassifyBLL methodclassifybll = new MethodClassifyBLL();
        bool result                         = methodclassifybll.InsertMethodClassify(methodclassifymodel);
        if (result)
        {
          this.DialogResult = DialogResult.OK;
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
