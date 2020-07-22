using GeneratorLogAnalyze.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmVerifySpecificCert : Form
  {
    public FrmVerifySpecificCert()
    {
      InitializeComponent();

      txtCertFile.Text = @"D:\Work\TestData\Cert\LDAP\vm235w.cer";
    }

    private void btnVerify_Click(object sender, EventArgs e)
    {
      var certFile = txtCertFile.Text.Trim();
      var certContent = txtCertContent.Text.Trim();

      if (string.IsNullOrWhiteSpace(certFile) && 
          string.IsNullOrWhiteSpace(certContent))
      {
        MessageBox.Show("必须输入证书路径或者证书的 Base64 内容\r\n注意：config 中的证书内容需要先解密", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      StringBuilder sb = new StringBuilder(1024);
      try
      {
        txtResult.Text = "";
        sb.AppendLine("Start verifying the specific certificate...");
        X509Certificate2 certificate2 = null;
        if (!string.IsNullOrWhiteSpace(certFile))
        {
          certificate2 = new X509Certificate2(certFile);
          txtCertContent.Text = CertUtil.ExportToPEM(certificate2);
        }
        else
        {
          byte[] certBytes = Encoding.UTF8.GetBytes(certContent);
          certificate2 = new X509Certificate2(certBytes);
        }
        CertUtil.VerifyCert(certificate2, sb, null);
      }
      catch (Exception ex)
      {
        sb.AppendLine("Error found in verifying the specific certificate: ");
        sb.AppendLine(string.Format("[{0}]", ex));
      }
      txtResult.Text = sb.ToString();
    }
  }
}
