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
  /// Interaction logic for Window17.xaml
  /// </summary>
  public partial class Window17 : Window
  {
    public Window17()
    {
      InitializeComponent();
      this.SetBinding();
    }

    private void SetBinding()
    {
      //创建并配置ObjectDataProvider对象
      ObjectDataProvider odp = new ObjectDataProvider();
      odp.ObjectInstance = new Calculator();
      odp.MethodName = "Add";
      odp.MethodParameters.Add("0");
      odp.MethodParameters.Add("0");

      //以ObjectDataProvider对象为Source创建Binding
      Binding bindingToArg1 = new Binding("MethodParameters[0]")
      {
        Source = odp,
        BindsDirectlyToSource = true,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
      };

      Binding bindingToArg2 = new Binding("MethodParameters[1]")
      {
        Source = odp,
        BindsDirectlyToSource = true,
        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
      };

      Binding bindingToResult = new Binding(".") { Source = odp };

      //将Binding关联到UI元素上
      this.textBoxArg1.SetBinding(TextBox.TextProperty, bindingToArg1);
      this.textBoxArg2.SetBinding(TextBox.TextProperty, bindingToArg2);
      this.textBoxResult.SetBinding(TextBox.TextProperty, bindingToResult);
    }
  }
}
