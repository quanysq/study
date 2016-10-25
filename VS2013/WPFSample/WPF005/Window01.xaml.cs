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
  /// Interaction logic for Window01.xaml
  /// </summary>
  public partial class Window01 : Window
  {
    public Window01()
    {
      InitializeComponent();
      InitializeCommand();
    }

    //声明并定义命令
    private RoutedCommand clearCmd = new RoutedCommand("Clear", typeof(Window01));

    private void InitializeCommand()
    {
      //把命令赋值给命令源（发送者）并指定快捷键
      this.button1.Command = this.clearCmd;
      this.clearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt));

      //指定命令目标
      this.button1.CommandTarget = this.textBoxA;

      //创建命令关联
      CommandBinding cb = new CommandBinding();
      cb.Command = this.clearCmd;     //只关注与clearCmd相关的事件
      cb.CanExecute += cb_CanExecute;
      cb.Executed += cb_Executed;

      //把命令关联安置在外围控件上
      this.stackPanel.CommandBindings.Add(cb);
    }

    void cb_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      this.textBoxA.Clear();

      //避免继续向上传而降低程序性能
      e.Handled = true;
    }

    void cb_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(this.textBoxA.Text))
      {
        e.CanExecute = false;
      }
      else
      {
        e.CanExecute = true;
      }

      //避免继续向上传而降低程序性能
      e.Handled = true;
    }
  }
}
