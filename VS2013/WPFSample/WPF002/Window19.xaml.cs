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
  /// Interaction logic for Window19.xaml
  /// </summary>
  public partial class Window19 : Window
  {
    public Window19()
    {
      InitializeComponent();

      Binding binding = new Binding("Value") { Source = this.slider1 };
      binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
      RangeValidationRule rvr = new RangeValidationRule();
      rvr.ValidatesOnTargetUpdated = true;
      binding.ValidationRules.Add(rvr);
      binding.NotifyOnValidationError = true;
      this.textBox1.SetBinding(TextBox.TextProperty, binding);

      this.textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
    }

    void ValidationError(object sender, RoutedEventArgs e)
    {
      if (Validation.GetErrors(this.textBox1).Count > 0)
      {
        this.textBox1.ToolTip = Validation.GetErrors(this.textBox1)[0].ErrorContent.ToString();
      }
    }
  }
}
