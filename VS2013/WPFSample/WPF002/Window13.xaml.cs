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

namespace WPF002
{
  /// <summary>
  /// Interaction logic for Window13.xaml
  /// </summary>
  public partial class Window13 : Window
  {
    public Window13()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      List<Student02> stuList = new List<Student02>()
      {
        new Student02(){ Id=0, Name="Tim", Age=29 },
        new Student02(){ Id=1, Name="Tom", Age=28 },
        new Student02(){ Id=2, Name="Kyle", Age=27 },
        new Student02(){ Id=3, Name="Tony", Age=26 },
        new Student02(){ Id=4, Name="Vina", Age=25 },
        new Student02(){ Id=5, Name="Mike", Age=24 },
      };

      this.listViewStudents.ItemsSource = from stu in stuList where stu.Name.StartsWith("T") select stu;
    }
  }
}
