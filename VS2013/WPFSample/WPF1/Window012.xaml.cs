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

namespace WPF001
{
  /// <summary>
  /// Interaction logic for Window012.xaml
  /// </summary>
  public partial class Window012 : Window
  {
    public static string WindowTitle = "山高月小";
    public static string ShowText { get { return "水落石出"; } }
    public Window012()
    {
      InitializeComponent();
    }
  }
}
