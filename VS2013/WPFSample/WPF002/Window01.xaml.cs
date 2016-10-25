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
  /// Interaction logic for Window01.xaml
  /// </summary>
  public partial class Window01 : Window
  {
    Student01 stu;

    public Window01()
    {
      InitializeComponent();

      //准备数据源
      stu = new Student01();

      //准备Binding
      Binding binding = new Binding();
      binding.Source = stu;
      binding.Path = new PropertyPath("Name");
      binding.Mode = BindingMode.TwoWay;
      binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

      //使用Binding连接数据源与Binging目标
      //BindingOperations.SetBinding(this.textbox1, TextBox.TextProperty, binding);
      this.textbox1.SetBinding(TextBox.TextProperty, binding);
      this.textbox2.SetBinding(TextBox.TextProperty, new Binding("Sex") { Source = stu });
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      MessageBox.Show(stu.Name + "," + stu.Sex);
      //stu.Name += "Name";
      //stu.Sex += "Sex";
    }
  }
}
