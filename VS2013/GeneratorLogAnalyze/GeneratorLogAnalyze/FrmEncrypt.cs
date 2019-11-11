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

    private void btnEncryptAES_Click(object sender, EventArgs e)
    {
      string txt = txtEnctrypt.Text.Trim();
      string key = txtKey.Text.Trim();
      string strEncrypt = EncryptUtil.AESEncode(txt, key, chkFIPS.Checked);
      txtResult.Text = strEncrypt;
    }

    private void btnDeencryptAES_Click(object sender, EventArgs e)
    {
      string txt = txtEnctrypt.Text.Trim();
      string key = txtKey.Text.Trim();
      string strEncrypt = EncryptUtil.AESDecode(txt, key, chkFIPS.Checked);
      txtResult.Text = strEncrypt;
    }

    private void btnEncryptRSA_Click(object sender, EventArgs e)
    {
      string key = txtKey.Text.Trim();
      if (string.IsNullOrWhiteSpace(key))
      {
        MessageBox.Show("需要输入公有 Key! 如果公有 Key 不能用内置的 AES Key 解密，则需要先使用 AES 解密", "警告");
        return;
      }
      string txt = txtEnctrypt.Text.Trim();
      string strEncrypt = EncryptUtil.RSAEncode(txt, key, chkFIPS.Checked);
      txtResult.Text = strEncrypt;
    }

    private void btnDeencryptRSA_Click(object sender, EventArgs e)
    {
      string key = txtKey.Text.Trim();
      if (string.IsNullOrWhiteSpace(key))
      {
        MessageBox.Show("需要输入私有 Key! 如果私有 Key 不能用内置的 AES Key 解密，则需要先使用 AES 解密", "警告");
        return;
      }
      string txt = txtEnctrypt.Text.Trim();
      string strEncrypt = EncryptUtil.RSADecode(txt, key, chkFIPS.Checked);
      txtResult.Text = strEncrypt;
    }
  }
}
