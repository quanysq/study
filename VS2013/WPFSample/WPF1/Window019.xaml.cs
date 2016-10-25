using System;
using System.Collections.Generic;
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

namespace WPF001
{
  /// <summary>
  /// Interaction logic for Window019.xaml
  /// </summary>
  public partial class Window019 : Window
  {
    public Window019()
    {
      InitializeComponent();

      //准备数据源
      List<StudentInfo> stuList = new List<StudentInfo>()
      {
        new StudentInfo(){ Id = 0, Name = "Tim", Age = 29},
        new StudentInfo(){ Id = 1, Name = "Tom", Age = 28},
        new StudentInfo(){ Id = 2, Name = "Kyl", Age = 27},
        new StudentInfo(){ Id = 3, Name = "Ton", Age = 26},
        new StudentInfo(){ Id = 4, Name = "Vin", Age = 25},
        new StudentInfo(){ Id = 5, Name = "Mik", Age = 24},
      };

      //为ListBox设置Binding
      this.listboxstudents.ItemsSource = stuList;
      //this.listboxstudents.DisplayMemberPath = "Name";

      //为TextBox设置Binding
      Binding binding = new Binding("SelectedItem.Id") { Source = this.listboxstudents };
      this.textbox1.SetBinding(TextBox.TextProperty, binding);
    }
  }
}
