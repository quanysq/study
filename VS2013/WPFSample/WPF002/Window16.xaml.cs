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
  /// Interaction logic for Window16.xaml
  /// </summary>
  public partial class Window16 : Window
  {
    public Window16()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      ObjectDataProvider odp = new ObjectDataProvider();
      odp.ObjectInstance = new Calculator();
      odp.MethodName = "Add";
      odp.MethodParameters.Add("100");
      odp.MethodParameters.Add("200");
      MessageBox.Show(odp.Data.ToString());
    }
  }
}
