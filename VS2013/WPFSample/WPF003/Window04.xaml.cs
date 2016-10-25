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
  /// Interaction logic for Window04.xaml
  /// </summary>
  public partial class Window04 : Window
  {
    public Window04()
    {
      InitializeComponent();

      Student01 stu = new Student01();
      stu.SetBinding(Student01.NameProperty, new Binding("Text") { Source = textBox1 });
      textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      
    }
  }
}
