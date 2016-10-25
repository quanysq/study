using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF002
{
  /// <summary>
  /// Interaction logic for Window14.xaml
  /// </summary>
  public partial class Window14 : Window
  {
    public Window14()
    {
      InitializeComponent();
    }

    private DataTable GetDataTable()
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("Id", typeof(System.Int32));
      dt.Columns.Add("Name", typeof(System.String));
      dt.Columns.Add("Age", typeof(System.Int32));
      DataRow dr;
      string[] Names = { "Tom", "Tim", "Kyle", "Tony", "Vina", "Mike" };
      for (int i = 0; i < 6; i++)
      {
        dr         = dt.NewRow();
        dr["Id"]   = i;
        dr["Name"] = Names[i];
        dr["Age"]  = 21 + i;
        dt.Rows.Add(dr);
      }
      return dt;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      DataTable dt = this.GetDataTable();

      this.listViewStudents.ItemsSource =
        from row in dt.Rows.Cast<DataRow>()
        where Convert.ToString(row["Name"]).StartsWith("T")
        select new Student02()
        {
          Id   = int.Parse(row["Id"].ToString()),
          Name = row["Name"].ToString(),
          Age  = int.Parse(row["Age"].ToString())
        };
    }
  }
}
