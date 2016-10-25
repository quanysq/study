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
  /// Interaction logic for Window01.xaml
  /// </summary>
  public partial class Window01 : Window
  {
    public Window01()
    {
      InitializeComponent();
      this.gridBoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.ButtonClicked));
    }

    private void ButtonClicked(object sender, RoutedEventArgs e)
    {
      MessageBox.Show((e.OriginalSource as FrameworkElement).Name);
    }
  }
}
