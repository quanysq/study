using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Observer2;

namespace Console024
{
  /// <summary>
  /// 观察者模式-拉模式
  /// </summary>
  public class C16_2
  {
    public static void Execute()
    {
      Subject subject = new BankAccount(2000);
      subject.AddObserver(new Emailer("abcdwxc@163.com", subject));
      subject.AddObserver(new Mobile(13901234567, subject));

      subject.WithDraw();

    }
  }
}

namespace Observer2
{
  public abstract class Subject
  {
    private List<IObserverAccount> Observers = new List<IObserverAccount>();


    private double _money;

    public double Money
    {
      get { return _money; }
    }
    public Subject(double money)
    {
      this._money = money;
    }
    public void WithDraw()
    {
      foreach (IObserverAccount ob in Observers)
      {
        ob.Update();

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
    void Update();
  }

  public class BankAccount : Subject
  {
    public BankAccount(double money)
      : base(money)
    { }

  }

  public class Emailer : IObserverAccount
  {
    private string _emalier;
    private Subject _subject;
    public Emailer(string emailer, Subject subject)
    {
      this._emalier = emailer;
      this._subject = subject;
    }
    public void Update()
    {
      //..
      Console.WriteLine("Notified : Emailer is {0}, You withdraw  {1:C} ", _emalier, _subject.Money);
    }
  }

  public class Mobile : IObserverAccount
  {
    private long _phoneNumber;
    private Subject _subject;
    public Mobile(long phoneNumber, Subject subject)
    {
      this._phoneNumber = phoneNumber;
      this._subject = subject;
    }
    public void Update()
    {
      Console.WriteLine("Notified :Phone number is {0} You withdraw  {1:C} ", _phoneNumber, _subject.Money);
    }
  }

}
