using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WPF002
{
  class RangeValidationRule: ValidationRule
  {
    public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
    {
      double d = 0;
      if (double.TryParse(value.ToString(), out d))
      {
        if (d >= 0 && d <= 100)
        {
          return new ValidationResult(true, null);
        }
      }

      return new ValidationResult(false, "Validation Failed");
    }
  }

  public class CategoryToSourceConverter : IValueConverter
  {
    /// <summary>
    /// 将Category转换为Uri
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      Category c = (Category)value;
      switch (c)
      {
        case Category.Bomber:
          return @"\Images\Bomber.ico";
        case Category.Fighter:
          return @"\Images\Fighter.ico";
        default:
          return null;
      }
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }

  public class StateToNullableBoolConverter : IValueConverter
  {
    /// <summary>
    /// 将State转换为bool?
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      State s = (State)value;
      switch (s)
      {
        case State.Locked:
          return false;
        case State.Available:
          return true;
        default:
          return null;
      }
    }

    /// <summary>
    /// 将bool?转换为State
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      bool? nb = (bool?)value;
      switch (nb)
      {
        case true: return State.Available;
        case false: return State.Locked;
        case null:
        default:
          return State.Unknown;
      }
    }
  }

  public class LogonMultiBindingConverter : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (!values.Cast<string>().Any(text => string.IsNullOrEmpty(text)) &&
          values[0].ToString() == values[1].ToString() &&
          values[2].ToString() == values[3].ToString())
      {
        return true;
      }
      return false;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
