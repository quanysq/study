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
  /// Interaction logic for Window04.xaml
  /// </summary>
  public partial class Window04 : Window
  {
    public Window04()
    {
      InitializeComponent();

      List<string> stringList = new List<string>() { "Tim", "Tom", "Blog" };
      this.textbox1.SetBinding(TextBox.TextProperty, new Binding("/") { Source = stringList });
      this.textbox2.SetBinding(TextBox.TextProperty, new Binding("/Length") { Source = stringList, Mode = BindingMode.OneWay });
      this.textbox3.SetBinding(TextBox.TextProperty, new Binding("/[2]") { Source = stringList, Mode = BindingMode.OneWay });
    }
  }
}
