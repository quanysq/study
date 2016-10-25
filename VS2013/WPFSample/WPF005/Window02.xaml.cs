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
  /// Interaction logic for Window02.xaml
  /// </summary>
  public partial class Window02 : Window
  {
    public Window02()
    {
      InitializeComponent();
    }

    private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = !string.IsNullOrEmpty(this.nameTextBox.Text);
      e.Handled = true;
    }

    private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      string name = this.nameTextBox.Text;
      if (e.Parameter.ToString() == "Teacher")
      {
        this.listBoxNewItems.Items.Add(string.Format("New Teacher: {0}, 学而不厌, 诲人不倦", name));
      }
      else if (e.Parameter.ToString() == "Student")
      {
        this.listBoxNewItems.Items.Add(string.Format("New Student: {0}, 好好学习, 天天向上", name));
      }

      e.Handled = true;
    }
  }
}
