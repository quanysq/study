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

namespace WPF006
{
  /// <summary>
  /// Interaction logic for Window06.xaml
  /// </summary>
  public partial class Window06 : Window
  {
    public Window06()
    {
      InitializeComponent();
    }

    private void StackPanel_Click(object sender, RoutedEventArgs e)
    {
      MenuItem mi = e.OriginalSource as MenuItem;
      XmlElement xe = mi.Header as XmlElement;
      MessageBox.Show(xe.Attributes["Name"].Value);
    }
  }
}
