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
  public partial class InternalMethodSQLSt : Form
  {
    public int StatementID { get; set; }
    public string StatementText { get; set; }

    public InternalMethodSQLSt()
    {
      InitializeComponent();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      UpdateMethodStatement();
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void UpdateMethodStatement()
    {
      try
      {
        StatementText = Statement.Text.TrimStart();
        MethodStatementModel methodstatementmodel = new MethodStatementModel()
        {
          StatementID = this.StatementID,
          Statement   = this.StatementText
        };
        InternalMethodBLL internalmethodbll = new InternalMethodBLL();
        bool result = internalmethodbll.MethodStatementUpdateStatement(methodstatementmodel);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
