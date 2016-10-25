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
using System.Xml.Linq;

namespace WPF002
{
  /// <summary>
  /// Interaction logic for Window15.xaml
  /// </summary>
  public partial class Window15 : Window
  {
    public Window15()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      XDocument xdoc = XDocument.Load(@"D:\VS2013\WPFSample\RawData2.xml");

      this.listViewStudents.ItemsSource =
        from element in xdoc.Descendants("Student")
        where element.Attribute("Name").Value.StartsWith("T")
        select new Student02()
        {
          Id   = int.Parse(element.Attribute("Id").Value),
          Name = element.Attribute("Name").Value,
          Age  = int.Parse(element.Attribute("Age").Value)
        };
    }
  }
}
