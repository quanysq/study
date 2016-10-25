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

namespace WPF005
{
  /// <summary>
  /// Interaction logic for Window04.xaml
  /// </summary>
  public partial class Window04 : Window
  {
    public Window04()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.Resources["res1"] = new TextBlock() { Text = "天涯共此时" };
      this.Resources["res2"] = new TextBlock() { Text = "天涯共此时" };
    }
  }
}
