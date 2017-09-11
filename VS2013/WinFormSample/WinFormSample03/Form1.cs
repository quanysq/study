using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace WinFormSample03
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
      var setting = new CefSharp.CefSettings();
      CefSharp.Cef.Initialize(setting);

      string url = "https://www.baidu.com";
      var webView = new ChromiumWebBrowser(url);

      this.panel1.Controls.Clear();
      this.panel1.Controls.Add(webView);

    }
  }
}
