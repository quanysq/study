using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBHelper
{
  public partial class Error : Form
  {
    public Exception Exception { get; set; }

    public Error()
    {
      InitializeComponent();
    }

    private void Error_Load(object sender, EventArgs e)
    {
      if (Exception != null)
      {
        txtMessage.Text = Exception.Message;
        txtStackTrace.Text = Exception.StackTrace;
      }
    }
  }
}
