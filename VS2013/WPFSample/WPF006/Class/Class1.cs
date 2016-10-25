using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF006
{
  #region DataTemplate例子
  public class Car
  {
    public string Automaker { get; set; }
    public string Name { get; set; }
    public string Year { get; set; }
    public string TopSpeed { get; set; }
  }

  /// <summary>
  /// 厂商名称转换为Logo图片路径
  /// </summary>
  public class AutomakerToLogoPathConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      string uriStr = string.Format(@"Resources/{0}.ico", (string)value);
      return new BitmapImage(new Uri(uriStr, UriKind.Relative));
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }

  /// <summary>
  /// 汽车名称转换为照片路径
  /// </summary>
  public class NameToPhotoPathConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      string uriStr = string.Format(@"Resources/{0}.jpg", (string)value);
      return new BitmapImage(new Uri(uriStr, UriKind.Relative));
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
  #endregion

  public class Unit
  {
    public int Price { get; set; }
    public string Year { get; set; }
  }

  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Skill { get; set; }
    public bool HasJob { get; set; }
  }

    class Student02
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }

  #region DataTrigger
  public class L2BConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      int textLength = (int)value;
      return textLength > 6;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
  #endregion
}
