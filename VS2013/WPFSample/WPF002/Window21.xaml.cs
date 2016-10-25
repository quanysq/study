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
  /// Interaction logic for Window21.xaml
  /// </summary>
  public partial class Window21 : Window
  {
    public Window21()
    {
      InitializeComponent();
      this.SetMultiBinding();
    }

    private void SetMultiBinding()
    {
      //准备基础Binding
      Binding b1 = new Binding("Text") { Source = this.textBox1 };
      Binding b2 = new Binding("Text") { Source = this.textBox2 };
      Binding b3 = new Binding("Text") { Source = this.textBox3 };
      Binding b4 = new Binding("Text") { Source = this.textBox4 };

      //准备MultiBinding
      MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };
      mb.Bindings.Add(b1);    //注意：MultiBinding对Add子Binding的顺序是敏感的
      mb.Bindings.Add(b2);
      mb.Bindings.Add(b3);
      mb.Bindings.Add(b4);
      mb.Converter = new LogonMultiBindingConverter();

      //将Button与MultiBinding对象关联
      this.button1.SetBinding(Button.IsEnabledProperty, mb);
    }
  }
}
