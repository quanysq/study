using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.LineSample
{
  public partial class LineFrm : Form
  {
    public LineFrm()
    {
      InitializeComponent();

      Load += LineFrm_Load;
    }

    void LineFrm_Load(object sender, EventArgs e)
    {
      label1.AutoSize = false;
      label1.BorderStyle = BorderStyle.Fixed3D;
      label1.Height = 2;
      label1.Width = 300;
    }
  }
}
