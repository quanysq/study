using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.DataGridViewSample
{
  public partial class SpanHeaderFrm : Form
  {
    public SpanHeaderFrm()
    {
      InitializeComponent();

      spanHeaderDataGridView1.AutoGenerateColumns = false;

      DataTable dt = new DataTable();
      dt.Columns.Add("1");
      dt.Columns.Add("2");
      dt.Columns.Add("3");
      dt.Columns.Add("4");
      dt.Rows.Add("中国", "上海", "5000", "7000");
      dt.Rows.Add("中国", "北京", "3000", "5600");
      dt.Rows.Add("美国", "纽约", "6000", "8600");
      dt.Rows.Add("美国", "华劢顿", "8000", "9000");
      dt.Rows.Add("英国", "伦敦", "7000", "8800");
      this.spanHeaderDataGridView1.DataSource = dt;
      this.spanHeaderDataGridView1.ColumnHeadersHeight = 40;
      this.spanHeaderDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      //this.spanHeaderDataGridView1.MergeColumnNames.Add("Column1");
      this.spanHeaderDataGridView1.AddSpanHeader(2, 2, "人口数量（男，女）");

      Load += SpanHeaderFrm_Load;
    }

    void SpanHeaderFrm_Load(object sender, EventArgs e)
    {
      SpanHeader(2, 2, "Operation");
      //spanHeaderDataGridView1.Scroll += spanHeaderDataGridView1_Scroll;
    }

    void spanHeaderDataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
      spanHeaderDataGridView1.ReDrawHead();
    }

    void SpanHeader(int colIndex, int colCount, string colText)
    {
      
      Label lblHeader = new Label();
      lblHeader.Name = "lblHeader";
      lblHeader.AutoSize = false;
      lblHeader.TextAlign = ContentAlignment.MiddleCenter;
      lblHeader.Text = colText;
      lblHeader.BackColor = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
      lblHeader.Font = dataGridView1.ColumnHeadersDefaultCellStyle.Font;

      int lblHeaderWidth = 0;
      for (int i = 0 ; i < colCount; i++)
      {
        int j = colIndex + i;
        lblHeaderWidth = lblHeaderWidth + dataGridView1.Columns[j].Width;
      }
      lblHeaderWidth = lblHeaderWidth - 2;
      int lblHeaderHeight = dataGridView1.ColumnHeadersHeight - 2;

      MessageBox.Show(string.Format("lblHeaderWidth: {0}, lblHeaderHeight: {1}", lblHeaderWidth, lblHeaderHeight));

      lblHeader.Size = new Size(lblHeaderWidth, lblHeaderHeight);

      Rectangle rect = dataGridView1.GetCellDisplayRectangle(colIndex, -1, true);
      
      int locationLeft = rect.Location.X + 1;
      int locationTop = rect.Location.Y + 1;

      MessageBox.Show(string.Format("locationLeft: {0}, locationTop: {1}", locationLeft, locationTop));

      lblHeader.Location = new Point(locationLeft, locationTop);

      dataGridView1.Controls.Add(lblHeader);
    }

  }
}
