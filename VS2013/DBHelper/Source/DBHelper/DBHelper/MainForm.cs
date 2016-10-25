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
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      if (UserInfoBLL.isAdministrator)
      {
        miMgrDeveloper.Enabled = true;
      }

      miInternalMethodList_Click(null, null);
    }

    private void miInternalMethodList_Click(object sender, EventArgs e)
    {
      Form InternalMethodListFrm = FindFormByName("InternalMethodList");
      if (InternalMethodListFrm == null)
      {
        InternalMethodListFrm           = new InternalMethodList();
        InternalMethodListFrm.MdiParent = this;
        InternalMethodListFrm.Dock      = DockStyle.Fill;
        InternalMethodListFrm.Show();
      }
      else
      {
        InternalMethodListFrm.Activate();
      }
    }

    private void miQuery_Click(object sender, EventArgs e)
    {
      OpenInternalMethodSubForm.OpenQueryForm(this, 0);
    }

    private void miInsert_Click(object sender, EventArgs e)
    {
      OpenInternalMethodSubForm.OpenInsertForm(this, 0);
    }

    private void miUpdate_Click(object sender, EventArgs e)
    {
      OpenInternalMethodSubForm.OpenUpdateForm(this, 0);
    }

    private void miDelete_Click(object sender, EventArgs e)
    {
      OpenInternalMethodSubForm.OpenDeleteForm(this, 0);
    }

    private void miProcedure_Click(object sender, EventArgs e)
    {
      OpenInternalMethodSubForm.OpenProcedureForm(this, 0);
    }

    private void miBusinesMethodList_Click(object sender, EventArgs e)
    {
      Form BusinessMethodListFrm = FindFormByName("BusinessMethodList");
      if (BusinessMethodListFrm == null)
      {
        BusinessMethodListFrm           = new BusinessMethodList();
        BusinessMethodListFrm.MdiParent = this;
        BusinessMethodListFrm.Dock      = DockStyle.Fill;
        BusinessMethodListFrm.Show();
      }
      else
      {
        BusinessMethodListFrm.Activate();
      }
    }

    private void miAddBusinesMethod_Click(object sender, EventArgs e)
    {
      OpenBusinessMethodSubForm.OpenEditForm(this, string.Empty, CanNext: true);
    }

    private void miModifyPwd_Click(object sender, EventArgs e)
    {
      ModifyPwd ModifyPwdFrm = new ModifyPwd();
      ModifyPwdFrm.MdiParent = this;
      ModifyPwdFrm.Show();
    }

    private void miChangeDatabase_Click(object sender, EventArgs e)
    {
      ChooseDatabase ChooseDatabaseFrm = new ChooseDatabase();
      ChooseDatabaseFrm.MdiParent      = this;
      ChooseDatabaseFrm.Show();
    }

    private void miMgrDeveloper_Click(object sender, EventArgs e)
    {
      DeveloperMgr DeveloperMgrFrm = new DeveloperMgr();
      DeveloperMgrFrm.MdiParent    = this;
      DeveloperMgrFrm.Show();
    }

    public void CloseAllForm()
    {
      foreach (Form frm in MdiChildren)
      {
        frm.Close();
      }
    }

    public void EnableInternalMethodMenu()
    {
      this.miQuery.Enabled     = true;
      this.miInsert.Enabled    = true;
      this.miUpdate.Enabled    = true;
      this.miDelete.Enabled    = true;
      this.miProcedure.Enabled = true;
    }

    public void DisableInternalMethodMenu()
    {
      this.miQuery.Enabled     = false;
      this.miInsert.Enabled    = false;
      this.miUpdate.Enabled    = false;
      this.miDelete.Enabled    = false;
      this.miProcedure.Enabled = false;
    }

    public void EnableBusinessMethodMenu()
    {
      this.miAddBusinesMethod.Enabled = true;
    }

    public void DisableBusinessMethodMenu()
    {
      this.miAddBusinesMethod.Enabled = false;
    }

    public Form FindFormByName(string FormName)
    {
      Form Frm = (from frm in MdiChildren where frm.Name.Equals(FormName, StringComparison.OrdinalIgnoreCase) select frm).FirstOrDefault();
      return Frm;
    }
  }
}
