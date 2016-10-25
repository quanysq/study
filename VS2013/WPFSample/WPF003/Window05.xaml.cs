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

namespace WPF003
{
  /// <summary>
  /// Interaction logic for Window05.xaml
  /// </summary>
  public partial class Window05 : Window
  {
    public Window05()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Human human = new Human();
      School.SetGrade(human, 6);
      int grade = School.GetGrade(human);
      MessageBox.Show(grade.ToString());
    }
  }
}
