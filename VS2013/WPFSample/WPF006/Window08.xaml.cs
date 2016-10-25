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
  /// Interaction logic for Window08.xaml
  /// </summary>
  public partial class Window08 : Window
  {
    public Window08()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      TextBlock tb = this.cp.ContentTemplate.FindName("textBlockName", this.cp) as TextBlock;
      MessageBox.Show(tb.Text);

      Student stu = this.cp.Content as Student;
      MessageBox.Show(stu.Name);
    }
  }
}
