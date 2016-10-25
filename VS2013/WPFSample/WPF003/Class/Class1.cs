using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WPF003
{
  class Student01: DependencyObject
  {
    //CLR属性包装器
    public string Name
    {
      get { return (string)GetValue(NameProperty); }
      set { SetValue(NameProperty, value); }
    }

    //创建依赖属性
    public static readonly DependencyProperty NameProperty =
      DependencyProperty.Register("Name", typeof(string), typeof(Student01));

    //SetBinding包装
    public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
    {
      return BindingOperations.SetBinding(this, dp, binding);
    }
  }

  /// <summary>
  /// 测试propdp快捷键
  /// </summary>
  class TestPropDP : DependencyObject
  {
    public int MyProperty
    {
      get { return (int)GetValue(MyPropertyProperty); }
      set { SetValue(MyPropertyProperty, value); }
    }

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register("MyProperty", typeof(int), typeof(TestPropDP), new PropertyMetadata(0));

    
  }

  #region 附加属性
  /// <summary>
  /// 附加属性（使用propa快捷键）
  /// </summary>
  class School : DependencyObject
  {
    public static int GetGrade(DependencyObject obj)
    {
      return (int)obj.GetValue(GradeProperty);
    }

    public static void SetGrade(DependencyObject obj, int value)
    {
      obj.SetValue(GradeProperty, value);
    }

    // Using a DependencyProperty as the backing store for Grade.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty GradeProperty =
        DependencyProperty.RegisterAttached("Grade", typeof(int), typeof(School), new PropertyMetadata(0));

  }

  class Human : DependencyObject
  {

  }
  #endregion
}
