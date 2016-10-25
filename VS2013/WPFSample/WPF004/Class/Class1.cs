using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF004
{
  #region 自定义路由事件
  /// <summary>
  /// 用于承载时间消息的事件参数
  /// </summary>
  public class ReportTimeEventArgs: RoutedEventArgs
  {
    public ReportTimeEventArgs(RoutedEvent routedEvent, object source)
      : base(routedEvent, source)
    {

    }

    public DateTime ClickTime { get; set; }
  }

  /// <summary>
  /// 创建一个Button类的派生类并按前述步骤为其添加路由事件
  /// </summary>
  public class TimeButton : Button
  {
    //声明并注册路由事件
    public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
      ("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));

    //CLR事件包装器
    public event RoutedEventHandler ReportTime
    {
      add { this.AddHandler(ReportTimeEvent, value); }
      remove { this.RemoveHandler(ReportTimeEvent, value); }
    }

    //激发路由事件，借用Cick事件的激发方法
    protected override void OnClick()
    {
      base.OnClick();       //保证 Button 原有功能正常使用、Click事件能否被激发

      ReportTimeEventArgs args = new ReportTimeEventArgs(ReportTimeEvent, this);
      args.ClickTime = DateTime.Now;
      this.RaiseEvent(args);
    }
  }
  #endregion

  #region 附加事件
  public class Student
  {
    //声明并定义路由事件
    public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent
      ("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Student));

    //为界面元素添加路由事件侦听
    public static void AddNameChangedHandler(DependencyObject d, RoutedEventHandler h)
    {
      UIElement e = d as UIElement;
      if (e != null)
      {
        e.AddHandler(Student.NameChangedEvent, h);
      }
    }

    //移除侦听
    public static void RemoveNameChangedHandler(DependencyObject d, RoutedEventHandler h)
    {
      UIElement e = d as UIElement;
      if (e != null)
      {
        e.RemoveHandler(Student.NameChangedEvent, h);
      }
    }

    public int Id { get; set; }
    public string Name { get; set; }
  }
  #endregion
}
