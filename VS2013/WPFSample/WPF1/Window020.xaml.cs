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
  /// Interaction logic for Window020.xaml
  /// </summary>
  public partial class Window020 : Window
  {
    List<StudentInfo> stuList = null;

    public Window020()
    {
      InitializeComponent();

      stuList = new List<StudentInfo>()
      {
        new StudentInfo(){ Id = 0, Name = "Tim", Age = 29},
        new StudentInfo(){ Id = 1, Name = "Tom", Age = 28},
        new StudentInfo(){ Id = 2, Name = "Kyl", Age = 27},
        new StudentInfo(){ Id = 3, Name = "Ton", Age = 26},
        new StudentInfo(){ Id = 4, Name = "Vin", Age = 25},
        new StudentInfo(){ Id = 5, Name = "Mik", Age = 24},
      };
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.listview1.ItemsSource = stuList;
    }
  }
}
