using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormSample01.DataGridViewSample;
using WinFormSample01.BackgroundWorkerSample;
using WinFormSample01.WizardSample;
using WinFormSample01.ComBoBoxSample;
using WinFormSample01.ToolTipSample;
using WinFormSample01.LineSample;

namespace WinFormSample01
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      button4.Click += button4_Click;
      button5.Click += button5_Click;
      button6.Click += button6_Click;
      button7.Click += button7_Click;
      button8.Click += button8_Click;
    }

    void button8_Click(object sender, EventArgs e)
    {
      LineFrm frm = new LineFrm();
      frm.Show();
    }

    void button7_Click(object sender, EventArgs e)
    {
      ToolTipStyleFrm frm = new ToolTipStyleFrm();
      frm.Show();
    }

    void button6_Click(object sender, EventArgs e)
    {
      ItemToolTipFrm frm = new ItemToolTipFrm();
      frm.Show();
    }

    void button5_Click(object sender, EventArgs e)
    {
      SpanHeaderFrm frm = new SpanHeaderFrm();
      frm.Show();
    }

    void button4_Click(object sender, EventArgs e)
    {
      WizardMainFrm frm = new WizardMainFrm();
      frm.Show();
    }

    //NestedDatagridview
    private void button1_Click(object sender, EventArgs e)
    {
      NestedDatagridviewFrm frm = new NestedDatagridviewFrm();
      frm.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      FullSelectedFrm frm = new FullSelectedFrm();
      frm.Show();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      BackgroundWorkerFrm frm = new BackgroundWorkerFrm();
      frm.Show();
    }
  }
}
