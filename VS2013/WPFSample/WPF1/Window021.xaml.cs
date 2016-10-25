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
namespace WPF001
{
  /// <summary>
  /// Interaction logic for Window021.xaml
  /// </summary>
  public partial class Window021 : Window
  {
    public Window021()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      XmlDocument doc = new XmlDocument();
      doc.Load(@"D:\VS2013\WPFSample\WPF1\Resource\RawData.xml");

      XmlDataProvider xdp = new XmlDataProvider();
      xdp.Document = doc;

      //使用XPath选择需要暴露的数据
      //现在是需要暴露一组Student
      xdp.XPath = @"/StudentList/Student";

      this.listview1.DataContext = xdp;
      this.listview1.SetBinding(ListView.ItemsSourceProperty, new Binding());
    }
  }
}
