using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer1;

namespace Console024
{
  /// <summary>
  /// 观察者模式-推模式
  /// </summary>
  class C16_1
  {
    public static void Execute()
    {
      Subject subject = new BankAccount(2000);
      subject.AddObserver(new Emailer("abcdwxc@163.com"));
      subject.AddObserver(new Mobile(13901234567));

      subject.WithDraw();
    }
  }
}

namespace Observer1
{
  public abstract class Subject
  {
    private List<IObserverAccount> Observers = new List<IObserverAccount>();

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
      foreach (IObserverAccount ob in Observers)
      {
        ob.Update(this);
      }
    }
    public void AddObserver(IObserverAccount observer)
    {
      Observers.Add(observer);
    }
    public void RemoverObserver(IObserverAccount observer)
    {
      Observers.Remove(observer);
    }

  }

  public interface IObserverAccount
  {
    void Update(Subject subject);
  }

  public class BankAccount : Subject
  {
    public BankAccount(double money)
      : base(money)
    {

    }
  }

  public class Emailer : IObserverAccount
  {
    private string _emalier;
    public Emailer(string emailer)
    {
      this._emalier = emailer;
    }
    public void Update(Subject subject)
    {
      Console.WriteLine("Notified : Emailer is {0}, You withdraw  {1:C} ", _emalier, subject.Money);
    }
  }

  public class Mobile : IObserverAccount
  {
    private long _phoneNumber;
    public Mobile(long phoneNumber)
    {
      this._phoneNumber = phoneNumber;
    }
    public void Update(Subject subject)
    {
      Console.WriteLine("Notified :Phone number is {0} You withdraw  {1:C} ", _phoneNumber, subject.Money);
    }
  }


}
