using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPF002
{
  class Student01: INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    private string name;

    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        //激发事件
        if (this.PropertyChanged != null)
        {
          this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
          this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sex"));
        }
      }
    }

    private string sex;
    public string Sex
    {
      get { return sex; }
      set
      {
        sex = value;
        if (this.PropertyChanged != null)
        {
          this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Sex"));
        }
      }
    }
  }

  class Student02
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }

  class Calculator
  {
    //加法
    public string Add(string arg1, string arg2)
    {
      double x = 0;
      double y = 0;
      double z = 0;
      if (double.TryParse(arg1, out x) && double.TryParse(arg2, out y))
      {
        z = x + y;
        return z.ToString();
      }
      return "Input Error!";
    }
  }

  #region Converter    
  /// <summary>
  /// 种类
  /// </summary>
  public enum Category
  {
    Bomber,
    Fighter
  }

  /// <summary>
  /// 状态
  /// </summary>
  public enum State
  {
    Available,
    Locked,
    Unknown
  }

  /// <summary>
  /// 飞机
  /// </summary>
  public class Plane
  {

    public Category Category { get; set; }

    public string Name { get; set; }

    public State State { get; set; }
  }
  #endregion
}
