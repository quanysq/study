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
  /// Interaction logic for Window03.xaml
  /// </summary>
  public partial class Window03 : Window
  {
    public Window03()
    {
      InitializeComponent();

      this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button_Click));
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string strOriginalSource = string.Format("VisualTree start point: {0}, type is {1}", (e.OriginalSource as FrameworkElement).Name, e.OriginalSource.GetType().Name);

      string strSource = string.Format("LogicalTree start point: {0}, type is {1}", (e.Source as FrameworkElement).Name, e.Source.GetType().Name);

      MessageBox.Show(strOriginalSource + "\r\n" + strSource);
    }
  }
}
