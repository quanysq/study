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
  public partial class FullSelectedFrm : Form
  {
    List<Customer> customers = null;

    public FullSelectedFrm()
    {
      InitializeComponent();
      this.dataGridView1.AutoGenerateColumns = false;
      this.Load += FullSelectedFrm_Load;
    }

    void FullSelectedFrm_Load(object sender, EventArgs e)
    {
      AddFullSelect();

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

    void AddFullSelect()
    {
      CheckBox chkFullSelected = new CheckBox();
      chkFullSelected.Name = "chkFullSelected";
      chkFullSelected.Text = "";
      chkFullSelected.Checked = false;
      Rectangle rect = dataGridView1.GetCellDisplayRectangle(0, -1, true);
      chkFullSelected.Size = new Size(13, 13);
      int locationLeft = rect.Location.X + dataGridView1.Columns[0].Width / 2 - 13 / 2 - 1;
      int locationTop = rect.Location.Y + 3;
      chkFullSelected.Location = new Point(locationLeft, locationTop);
      chkFullSelected.CheckedChanged += ChkFullSelected_CheckedChanged;
      if (!dataGridView1.Controls.ContainsKey("chkFullSelected"))
      {
        dataGridView1.Controls.Add(chkFullSelected);
      }
    }

    private void ChkFullSelected_CheckedChanged(object sender, EventArgs e)
    {
      dataGridView1.BeginEdit(false);
      for (int i = 0; i < dataGridView1.Rows.Count; i++)
      {
        dataGridView1.Rows[i].Cells["Selected"].Value = ((CheckBox)sender).Checked;
      }
      dataGridView1.EndEdit();
    }
  }
}
