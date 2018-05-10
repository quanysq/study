using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneratorLogAnalyze.Common;

namespace GeneratorLogAnalyze
{
  public partial class FrmEncrypt : Form
  {
    public FrmEncrypt()
    {
      InitializeComponent();
    }

    private void btnEncrypt_Click(object sender, EventArgs e)
    {
      string txt = txtEnctrypt.Text.Trim();
      string strEncrypt = EncryptUtil.SafeEncode(txt);
      txtResult.Text = strEncrypt;
    }

    private void btnDeencrypt_Click(object sender, EventArgs e)
    {
      string txt = txtEnctrypt.Text.Trim();
      string strEncrypt = EncryptUtil.SafeDecode(txt);
      txtResult.Text = strEncrypt;
    }
  }
}
