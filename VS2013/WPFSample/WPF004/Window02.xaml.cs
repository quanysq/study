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
  /// Interaction logic for Window02.xaml
  /// </summary>
  public partial class Window02 : Window
  {
    public Window02()
    {
      InitializeComponent();
    }

    private void ReportTimeHandler(object sender, ReportTimeEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      string timeStr = e.ClickTime.ToLongTimeString();
      string content = string.Format("{0} 到达 {1}", timeStr, element.Name);
      this.listBox.Items.Add(content);

      if (element == this.grid_2) e.Handled = true;
    }
  }
}
