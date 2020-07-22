using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
    }

    private void MenuItemExtractor_Click(object sender, EventArgs e)
    {
      var frm = new Form1();
      frm.MdiParent = this;
      frm.Show();
    }

    private void MenuItemAnalyze_Click(object sender, EventArgs e)
    {
      var frm = new FrmAnalyze();
      frm.MdiParent = this;
      frm.Show();
    }

    private void MenuItemDateSubtract_Click(object sender, EventArgs e)
    {
      var frm = new FrmDateSubtract();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

    private void MenuItemEncrypt_Click(object sender, EventArgs e)
    {
      var frm = new FrmEncrypt();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

    private void MenuItemConver2Base64_Click(object sender, EventArgs e)
    {
      var frm = new FrmConvert2Base64();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

    private void MenuItemIP_Click(object sender, EventArgs e)
    {
      var frm = new FrmIPByHostname();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

    private void MenuItemADCert_Click(object sender, EventArgs e)
    {
      var frm = new FrmVerifyADCert();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

    private void MenuItemSpecificCert_Click(object sender, EventArgs e)
    {
      var frm = new FrmVerifySpecificCert();
      frm.MdiParent = this;
      frm.MinimizeBox = false;
      frm.MaximizeBox = false;
      frm.StartPosition = FormStartPosition.CenterScreen;
      frm.Show();
    }

  }
}
