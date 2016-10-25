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
  /// Interaction logic for Window18.xaml
  /// </summary>
  public partial class Window18 : Window
  {
    public Window18()
    {
      InitializeComponent();

      //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
      //rs.AncestorLevel  = 1;              //指以Binding目标控件为起点的层级偏移量
      //rs.AncestorType   = typeof(Grid);   //此属性告诉Binding寻找哪个类型的对象作为自己的源，不是这个类型的对象会被跳过
      //Binding binding   = new Binding("Name") { RelativeSource = rs };
      //this.textBox1.SetBinding(TextBox.TextProperty, binding);

      /*
       *上面这段代码的意思是告诉Binding从自己的第一层依次向外找，找到第一个Grid类型对象后把它当作自己的源 
       */

      RelativeSource rs = new RelativeSource();
      rs.Mode = RelativeSourceMode.Self;
      Binding binding   = new Binding("Name") { RelativeSource = rs };
      this.textBox1.SetBinding(TextBox.TextProperty, binding);

      /*
       *上面这段代码是TextBox关联自身的Name属性 
       */
    }
  }
}
