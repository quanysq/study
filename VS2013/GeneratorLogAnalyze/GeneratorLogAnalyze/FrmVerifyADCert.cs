using GeneratorLogAnalyze.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmVerifyADCert : Form
  {
    public FrmVerifyADCert()
    {
      InitializeComponent();

      txtServer.Text  = "vm235w.bdnacorp.com";
      txtLogonDN.Text = "CN=NBIAdministrator,CN=Users,DC=qa-nbi,DC=com";
      txtPwd.Text     = "Simple.0";
    }

    private void btnVefify_Click(object sender, EventArgs e)
    {
      string server   = txtServer.Text.Trim();
      string port     = txtPort.Text.Trim();
      string loginDN  = txtLogonDN.Text.Trim();
      string loginPwd = txtPwd.Text.Trim();
      bool isSSL      = chkSSL.Checked;
      string adURL    = string.Format("{0}:{1}", server, port);

      bool result = false;
      txtResult.Text = "";
      StringBuilder sb = new StringBuilder(1024);
      sb.AppendLine("Start testing LDAP/AD server connection...");
      LdapConnection ldapConnection = null;
      try
      {
        ldapConnection = new LdapConnection(adURL);
        TestConnect(loginDN, loginPwd, isSSL, ref ldapConnection, sb);
        result = true;
      }
      catch (Exception ex)
      {
        sb.AppendLine("Error found in binding LDAP/AD: ");
        sb.AppendLine(string.Format("[{0}]", ex));
        result = false;
      }
      finally
      {
        sb.AppendLine(string.Format("LDAP/AD connection test is successful? [{0}]", result));
        if (ldapConnection != null) ldapConnection.Dispose();
      }
      txtResult.Text = sb.ToString();
    }

    private void TestConnect(string loginDN, string loginPassword, bool isSSL, ref LdapConnection ldapConnection, StringBuilder sb)
    {
      var networkCredential = new NetworkCredential(loginDN, loginPassword);
      ldapConnection.SessionOptions.SecureSocketLayer = isSSL;
      if (isSSL)
      {
        ldapConnection.SessionOptions.VerifyServerCertificate = (ldapCon, certificate) => 
        {
          sb.AppendLine(string.Format("Validate LDAP/AD server certificate: [{0}]", ldapCon.SessionOptions.HostName));
          X509Certificate2 certificate2 = new X509Certificate2(certificate);
          CertUtil.VerifyCert(certificate2, sb, () => {
            sb.AppendLine(string.Format("LDAP/AD server Certificate content: \n{0}", CertUtil.ExportToPEM(certificate2)));
          });
          return true;
        };
      }

      ldapConnection.SessionOptions.ProtocolVersion = 3;
      ldapConnection.AuthType = AuthType.Basic;
      ldapConnection.Credential = networkCredential;
      try
      {
        sb.AppendLine("Testing binding");
        ldapConnection.Bind();
        sb.AppendLine("Successfully bound.");
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
