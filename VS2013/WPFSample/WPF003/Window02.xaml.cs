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
  /// Interaction logic for Window02.xaml
  /// </summary>
  public partial class Window02 : Window
  {
    Student01 stu;
    public Window02()
    {
      InitializeComponent();
      stu = new Student01();
      Binding binding = new Binding("Text") { Source = textBox1 };
      BindingOperations.SetBinding(stu, Student01.NameProperty, binding);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show(stu.GetValue(Student01.NameProperty).ToString());
    }
  }
}
