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

namespace WPF006
{
  /// <summary>
  /// Interaction logic for Window07.xaml
  /// </summary>
  public partial class Window07 : Window
  {
    public Window07()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      TextBox tb = this.uc.Template.FindName("textBox1", this.uc) as TextBox;
      tb.Text = "Hello WPF";
      StackPanel sp = tb.Parent as StackPanel;
      (sp.Children[1] as TextBox).Text = "Hello ControlTemplate";
      (sp.Children[2] as TextBox).Text = "I can find you!";
    }
  }
}
