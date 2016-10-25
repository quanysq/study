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
  /// Interaction logic for Window01.xaml
  /// </summary>
  public partial class Window01 : Window
  {
    public Window01()
    {
      InitializeComponent();

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //直接使用依赖属性
      Student01 stu = new Student01();
      stu.SetValue(Student01.NameProperty, this.textBox1.Text);
      textBox2.Text = (string)stu.GetValue(Student01.NameProperty);
    }
  }
}
