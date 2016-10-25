using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 职责链模式(Chain of Responsibility Pattern)
  /// </summary>
  public class C19
  {
    public static void Execute()
    {
      //Setup Chain of Responsibility
      Director Larry = new Director();
      VicePresident Sam = new VicePresident();
      President Tammy = new President();
      
      Larry.SetSuccessor(Sam);  //传递职责
      Sam.SetSuccessor(Tammy);

      //Generate and process purchase requests
      Purchase p = new Purchase(1034, 350.00, "Supplies");
      Larry.ProcessRequest(p);

      p = new Purchase(2037, 24090.10, "Project Y");
      Larry.ProcessRequest(p);

      p = new Purchase(2035, 32590.10, "Project X");
      Larry.ProcessRequest(p);

      p = new Purchase(2036, 122100.00, "Project Y");
      Larry.ProcessRequest(p);
    }
  }

  //Handler
  abstract class Approver
  {
    protected Approver successor;
    public void SetSuccessor(Approver successor)
    {
      this.successor = successor;
    }
    public abstract void ProcessRequest(Purchase purchase);

  }

  //ConcreteHandler
  class Director : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 10000.0)
      {
        Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);

      }
      else if (successor != null)
      {
        successor.ProcessRequest(purchase);
      }
    }
  }

  class VicePresident : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 25000.0)
      {
        Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
      }
      else if (successor != null)
      {
        successor.ProcessRequest(purchase);
      }
    }
  }

  class President : Approver
  {
    public override void ProcessRequest(Purchase purchase)
    {
      if (purchase.Amount < 100000.0)
      {
        Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
      }
      else
      {
        Console.WriteLine("Request! {0} requires an executive meeting!", purchase.Number);
      }
    }
  }

  //Request details
  class Purchase
  {
    private int number;
    private double amount;
    private string purpose;

    //Constructor
    public Purchase(int number, double amount, string purpose)
    {
      this.number = number;
      this.amount = amount;
      this.purpose = purpose;
    }
    //Properties
    public double Amount
    {
      get { return amount; }
      set { amount = value; }
    }
    public string Purpose
    {
      get { return purpose; }
      set { purpose = value; }
    }
    public int Number
    {
      get { return number; }
      set { number = value; }
    }
  }

  /*
   * 适用性：
      1.有多个对象可以处理一个请求，哪个对象处理该请求运行时刻自动确定。
      2.你想在不明确接收者的情况下，向多个对象中的一个提交一个请求。
      3.可处理一个请求的对象集合应被动态指定。
   * 
   * Chain of Responsibility实现要点：
      1.Chain of Responsibility模式的应用场合在于“一个请求可能有多个接受者，但是最后真正的接受者只胡一个”，
        只有这时候请求发送者与接受者的耦合才胡可能出现“变化脆弱”的症状，职责链的目的就是将二者解耦，从而更好地应对变化。
      2.应用了Chain of Responsibility模式后，对象的职责分派将更具灵活性。我们可以在运行时动态添加/修改请求的处理职责。
      3.如果请求传递到职责链的未尾仍得不到处理，应该有一个合理的缺省机制。这也是每一个接受对象的责任，而不是发出请求的对象的责任。
   */
}
