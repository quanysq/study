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
  public partial class FrmDateSubtract : Form
  {
    public FrmDateSubtract()
    {
      InitializeComponent();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      var d2 = DateTime.Parse(txtDate1.Text.Trim());
      var d1 = DateTime.Parse(txtDate2.Text.Trim());
      TimeSpan ts1 = new TimeSpan(d1.Ticks);
      TimeSpan ts2 = new TimeSpan(d2.Ticks);
      TimeSpan ts = ts2.Subtract(ts1);

      StringBuilder sb = new StringBuilder(1024);
      sb.AppendLine(string.Format("ts: {0}", ts));
      sb.AppendLine(string.Format("ts.Hours: {0}", ts.Hours));
      sb.AppendLine(string.Format("ts.Minutes: {0}", ts.Minutes));
      sb.AppendLine(string.Format("ts.Seconds: {0}", ts.Seconds));
      sb.AppendLine("");
      sb.AppendLine(string.Format("ts.TotalDays: {0}", ts.TotalDays));
      sb.AppendLine(string.Format("ts.Hours: {0}", ts.Hours));
      sb.AppendLine(string.Format("ts.Minutes: {0}", ts.Minutes));
      sb.AppendLine(string.Format("ts.TotalSeconds: {0}", ts.TotalSeconds));

      txtResult.Text = sb.ToString();
    }
  }
}
