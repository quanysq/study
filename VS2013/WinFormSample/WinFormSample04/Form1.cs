using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample04
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      this.Load += Form1_Load;
    }

    void Form1_Load(object sender, EventArgs e)
    {
      var setting = new CefSettings();
      Cef.Initialize(setting, true, false);

      string url = "https://www.baidu.com";
      var webView = new ChromiumWebBrowser(url);

      this.tableLayoutPanel1.Controls.Add(webView, 0, 1);
    }
  }
}
