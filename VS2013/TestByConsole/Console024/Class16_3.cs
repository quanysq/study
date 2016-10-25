using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer3;

namespace Console024
{
  /// <summary>
  /// 观察者模式-NET实现观察者模式
  /// 用事件和委托来实现Observer模式我认为更加的简单和优雅，也是一种更好的解决方案。
  /// </summary>
  public class C16_3
  {
    public static void Execute()
    {
      Subject subject = new Subject(2000);
      Emailer emailer = new Emailer("abcdwxc@163.com");
      subject.NotifyEvent += new NotifyEventHandler(emailer.Update);


      subject.WithDraw();
    }
  }
}

namespace Observer3
{
  public delegate void NotifyEventHandler(object sender);
  public class Subject
  {
    public event NotifyEventHandler NotifyEvent;

    private double _money;
    public Subject(double money)
    {
      this._money = money;
    }

    public double Money
    {
      get { return _money; }
    }

    public void WithDraw()
    {
      OnNotifyChange();
    }
    public void OnNotifyChange()
    {
      if (NotifyEvent != null)
      {
        NotifyEvent(this);
      }

    }

  }

  public class Emailer
  {
    private string _emalier;
    public Emailer(string emailer)
    {
      this._emalier = emailer;
    }
    public void Update(object obj)
    {
      if (obj is Subject)
      {
        Subject subject = (Subject)obj;

        Console.WriteLine("Notified : Emailer is {0}, You withdraw  {1:C} ", _emalier, subject.Money);
      }
    }
  }

}


