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
  /// Interaction logic for Window018.xaml
  /// </summary>
  public partial class Window018 : Window
  {
    Student stu;
    public Window018()
    {
      InitializeComponent();

      //准备数据源
      stu = new Student();

      //准备Binding
      Binding binding = new Binding();
      binding.Source = stu;
      binding.Path = new PropertyPath("Name");

      //使用Binding连接数据源与Binding目标
      //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
      textBoxName.SetBinding(TextBox.TextProperty, new Binding("Name"){ Source = stu = new Student() });
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      stu.Name += "Name";
    }
  }
}
