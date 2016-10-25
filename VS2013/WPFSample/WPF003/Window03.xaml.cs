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
  /// Interaction logic for Window03.xaml
  /// </summary>
  public partial class Window03 : Window
  {
    public Window03()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Student01 stu = new Student01();
      stu.Name = this.textBox1.Text;
      this.textBox2.Text = stu.Name;
    }
  }
}
