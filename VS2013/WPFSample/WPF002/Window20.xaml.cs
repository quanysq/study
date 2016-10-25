using System;
using System.Collections.Generic;
using System.IO;
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
  /// Interaction logic for Window20.xaml
  /// </summary>
  public partial class Window20 : Window
  {
    public Window20()
    {
      InitializeComponent();
    }

    private void buttonLoad_Click(object sender, RoutedEventArgs e)
    {
      List<Plane> planeList = new List<Plane>()
      {
        new Plane(){ Category=Category.Bomber, Name="B-1", State=State.Unknown },
        new Plane(){ Category=Category.Bomber, Name="B-2", State=State.Unknown },
        new Plane(){ Category=Category.Fighter, Name="F-22", State=State.Unknown },
        new Plane(){ Category=Category.Fighter, Name="Su-47", State=State.Unknown },
        new Plane(){ Category=Category.Bomber, Name="B-52", State=State.Unknown },
        new Plane(){ Category=Category.Fighter, Name="J-10", State=State.Unknown }
      };

      this.listBoxPlane.ItemsSource = planeList;
    }

    private void buttonSave_Click(object sender, RoutedEventArgs e)
    {
      StringBuilder sb = new StringBuilder();
      foreach (Plane p in listBoxPlane.Items)
      {
        sb.AppendLine(string.Format("Category={0}, Name={1}, State={2}", p.Category, p.Name, p.State));
      }

      File.WriteAllText(@"D:\VS2013\WPFSample\PlaneList.txt", sb.ToString());
    }
  }
}
