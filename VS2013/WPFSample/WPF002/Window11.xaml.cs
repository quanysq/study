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
using System.Xml;

namespace WPF002
{
  /// <summary>
  /// Interaction logic for Window11.xaml
  /// </summary>
  public partial class Window11 : Window
  {
    public Window11()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //写法一
      //XmlDocument doc = new XmlDocument();
      //doc.Load(@"D:\VS2013\WPFSample\RawData.xml");

      //XmlDataProvider xdp = new XmlDataProvider();
      //xdp.Document = doc;

      //写法二
      XmlDataProvider xdp = new XmlDataProvider();
      xdp.Source = new Uri(@"D:\VS2013\WPFSample\RawData.xml");

      //使用XPath选择需要暴露的数据
      //现在是需要暴露一组Student
      xdp.XPath = @"/StudentList/Student";

      this.listViewStudents.DataContext = xdp;
      this.listViewStudents.SetBinding(ListView.ItemsSourceProperty, new Binding());
    }
  }
}
