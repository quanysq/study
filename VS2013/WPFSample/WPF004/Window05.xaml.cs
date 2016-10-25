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

namespace WPF004
{
  /// <summary>
  /// Interaction logic for Window05.xaml
  /// </summary>
  public partial class Window05 : Window
  {
    public Window05()
    {
      InitializeComponent();

      //为外层Grid添加路由事件侦听器
      Student.AddNameChangedHandler(this.gridMain, new RoutedEventHandler(StudentNameChangedHandler));
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      Student stu = new Student() { Id = 101, Name = "Tim" };
      stu.Name = "Tom";

      //准备事件消息并发送路由事件
      RoutedEventArgs arg = new RoutedEventArgs(Student.NameChangedEvent, stu);
      this.button1.RaiseEvent(arg);
    }

    //Grid捕捉到NameChangedEvent后的处理器
    private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
    {
      MessageBox.Show((e.OriginalSource as Student).Id.ToString());
    }
  }
}
