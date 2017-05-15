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
  /// <summary>
  /// 参考 https://www.codeproject.com/Articles/848637/Nested-DataGridView-in-windows-forms-csharp
  /// </summary>
  public partial class NestedDatagridviewFrm : Form
  {
    List<Customer> customers = null;

    public NestedDatagridviewFrm()
    {
      InitializeComponent();
      this.dataGridView1.AutoGenerateColumns = false;
      this.Load += NestedDatagridview_Load;
      this.dataGridView1.CellContentClick += dataGridView1_CellContentClick;
      this.dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
    }

    void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
      for (int i = 0; i < dataGridView1.Rows.Count; i++ )
      {
        dataGridView1.Rows[i].Cells["Expand"].Tag = ExpandFlag.Open;
      }
    }

    void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      //int x = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.X;
      //MessageBox.Show("X: " + x.ToString());

      //int y = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.Y;
      //MessageBox.Show("Y: " + y.ToString());

      string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
      if (columnName.Equals("Expand", StringComparison.OrdinalIgnoreCase))
      {
        ExpandFlag expandFlag = (ExpandFlag)dataGridView1.CurrentCell.Tag;
        if (expandFlag == ExpandFlag.Open)
        {
          dataGridView1.CurrentCell.Value = global::WinFormSample01.Properties.Resources.icon_minus_16x16;
          dataGridView1.CurrentCell.Tag = ExpandFlag.Close;
        }
        else
        {
          dataGridView1.CurrentCell.Value = global::WinFormSample01.Properties.Resources.icon_add_16x16;
          dataGridView1.CurrentCell.Tag = ExpandFlag.Open;

          if (dataGridView1.Controls.ContainsKey("myButton"))
          {
            dataGridView1.Controls.RemoveByKey("myButton");
          }

          return;
        }

        //int cellLeft = 0;
        //for (int i = this.dataGridView1.FirstDisplayedCell.ColumnIndex; i < e.ColumnIndex + 1; i++)
        //{
        //  cellLeft = cellLeft + this.dataGridView1.Columns[i].Width;
        //}
        //int cellTop = 0;
        //for (int j = this.dataGridView1.FirstDisplayedCell.RowIndex; j < e.RowIndex + 1; j++)
        //{
        //  cellTop = cellTop + this.dataGridView1.Rows[j].Height;
        //}
        //cellLeft = this.dataGridView1.RowHeadersWidth + cellLeft;
        //cellTop = this.dataGridView1.ColumnHeadersHeight + cellTop;

        int cellLeft = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.X;
        int cellTop = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location.Y;
        cellLeft = this.dataGridView1.Columns[e.ColumnIndex].Width + cellLeft;
        cellTop = this.dataGridView1.Rows[e.RowIndex].Height + cellTop;

        string s = cellLeft.ToString() + "," + cellTop.ToString();
        MessageBox.Show(s);

        if (dataGridView1.Controls.ContainsKey("myButton"))
        {
          dataGridView1.Controls.RemoveByKey("myButton");
        }

        DataGridView gridView = new DataGridView();
        gridView.Name = "myButton";
        gridView.DataSource = customers;
        gridView.Location = new Point(cellLeft, cellTop);
        dataGridView1.Controls.Add(gridView);
      }
      //string s = dataGridView1.CurrentCell.Value.ToString();
      //MessageBox.Show(s);

    }

    void NestedDatagridview_Load(object sender, EventArgs e)
    {
      LoadData();

      dataGridView1.DataSource = customers;
    }

    void LoadData()
    {
      customers = new List<Customer>()
      {
        new Customer() { ID=1, CName="Name1", Sex="Sex1", AddressList=new List<Address>() { new Address() { City="City1", Street="Street1"}}},
        new Customer() { ID=2, CName="Name2", Sex="Sex2", AddressList=new List<Address>() { new Address() { City="City2", Street="Street2"}}}
      };

    }

    enum ExpandFlag
    {
      Open,
      Close
    }
  }
}
