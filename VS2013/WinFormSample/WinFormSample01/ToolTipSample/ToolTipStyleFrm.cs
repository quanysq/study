using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.ToolTipSample
{
  public partial class ToolTipStyleFrm : Form
  {
    public ToolTipStyleFrm()
    {
      InitializeComponent();
      Load += ToolTipStyleFrm_Load;
    }

    void ToolTipStyleFrm_Load(object sender, EventArgs e)
    {
      toolTip1.AutomaticDelay = 0;  //获取或设置工具提示的自动延迟。
      toolTip1.AutoPopDelay = 5000;//保持显示时间, 毫秒
      toolTip1.InitialDelay = 100;//经过显示时间
      toolTip1.ReshowDelay = 500;
      toolTip1.ShowAlways = false;
      toolTip1.IsBalloon = true;  //气泡窗口
      toolTip1.ToolTipTitle = "消息"; //标题
      toolTip1.ToolTipIcon = ToolTipIcon.Info;//图标
      toolTip1.UseFading = true;

      textBox1.Enter += textBox1_Enter;
      textBox1.LostFocus += textBox1_LostFocus;

      textBox2.Enter += textBox2_Enter;
      textBox2.LostFocus += textBox2_LostFocus;
    }

    void textBox2_LostFocus(object sender, EventArgs e)
    {
      toolTip1.Hide(textBox2);
    }

    void textBox2_Enter(object sender, EventArgs e)
    {
      //toolTip1.SetToolTip(textBox2, "hahas");

      toolTip1.Show("Hello, I am ToolTip2", textBox2);
      toolTip1.Active = true;
    }

    void textBox1_LostFocus(object sender, EventArgs e)
    {
      toolTip1.Hide(textBox1);
    }

    void textBox1_Enter(object sender, EventArgs e)
    {
      //toolTip1.SetToolTip(textBox1, "haha");

      int _x = textBox1.Location.X;
      int _y = textBox1.Location.Y;
      toolTip1.Show("Hello, I am ToolTip", textBox1, _x, _y);
      toolTip1.Active = true;
    }
  }
}
