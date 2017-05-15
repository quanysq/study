using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.ComBoBoxSample
{
  public partial class ItemToolTipFrm : Form
  {
    ToolTip toolTip = new ToolTip();
    public ItemToolTipFrm()
    {
      InitializeComponent();
      Load += ItemToolTipFrm_Load;
    }

    void ItemToolTipFrm_Load(object sender, EventArgs e)
    {
      comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
      comboBox1.DrawItem += comboBox1_DrawItem;
      comboBox1.DropDownClosed += comboBox1_DropDownClosed;
    }

    void comboBox1_DropDownClosed(object sender, EventArgs e)
    {
      toolTip.Hide(comboBox1);
    }

    void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
      if (e.Index < 0) { return; }
      string text = comboBox1.GetItemText(comboBox1.Items[e.Index]);
      e.DrawBackground();
      using (SolidBrush br = new SolidBrush(e.ForeColor))
      {
        e.Graphics.DrawString(text, e.Font, br, e.Bounds);
      }
      if ((e.State & DrawItemState.Selected) == DrawItemState.Selected && comboBox1.DroppedDown)
      {
        //comboBox1.DroppedDown保证只有显示下拉页的时候才显示tooltip
        toolTip.Show(text, comboBox1, e.Bounds.Right, e.Bounds.Bottom);
      }
      e.DrawFocusRectangle();
    }
  }
}
