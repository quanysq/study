using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmIPByHostname : Form
  {
    public FrmIPByHostname()
    {
      InitializeComponent();
    }

    private void FrmIPByHostname_Load(object sender, EventArgs e)
    {
      txtHostname.SelectAll();
    }
    
    private void btnIP_Click(object sender, EventArgs e)
    {
      try
      {
        string hostName = txtHostname.Text.Trim();
        IPHostEntry host = Dns.GetHostEntry(hostName);
        var ips = new StringBuilder(1024);
        ips.AppendLine(string.Format("Host Address Length: [{0}]", host.AddressList.Length));
        ips.AppendLine(string.Format("Host Name: [{0}]", host.HostName));
        ips.AppendLine("The following is IP list: ");
        ips.AppendLine("===============");
        foreach (var ipInfo in host.AddressList)
        {
          ips.AppendLine(ipInfo.ToString());
        }
        txtResult.Text = ips.ToString();
      }
      catch (System.Net.Sockets.SocketException ex)
      {
        txtResult.Text = ex.Message;
      }
    }
  }
}
