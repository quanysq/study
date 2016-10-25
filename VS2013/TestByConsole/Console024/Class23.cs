using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 状态模式(State Pattern)
  /// </summary>
  public class C23
  {
    public static void Execute()
    {
      // Open a new account
      Account account = new Account("Jim Johnson");

      // Apply financial transactions
      account.Deposit(500.0);
      account.Deposit(300.0);
      account.Deposit(550.0);
      account.PayInterest();
      account.Withdraw(2000.00);
      account.Withdraw(1100.00);
    }
  }


  #region State
  abstract class State
  {
    protected Account account;
    protected double balance;

    protected double interest;
    protected double lowerLimit;
    protected double upperLimit;

    // Properties
    public Account Account
    {
      get { return account; }
      set { account = value; }
    }

    public double Balance
    {
      get { return balance; }
      set { balance = value; }
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
    public abstract void PayInterest();
  }

  // "ConcreteState" - Account is overdrawn
  class RedState : State
  {
    double serviceFee;

    // Constructor
    public RedState(State state)
    {
      this.balance = state.Balance;
      this.account = state.Account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = -100.0;
      upperLimit = 0.0;
      serviceFee = 15.00;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      amount = amount - serviceFee;
      Console.WriteLine("No funds available for withdrawal!");
    }

    public override void PayInterest()
    {
      // No interest is paid
    }

    private void StateChangeCheck()
    {
      if (balance > upperLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }

  // "ConcreteState" - Silver is non-interest bearing state
  class SilverState : State
  {
    // Overloaded constructors

    public SilverState(State state) :
      this(state.Balance, state.Account)
    {
    }

    public SilverState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a datasource
      interest = 0.0;
      lowerLimit = 0.0;
      upperLimit = 1000.0;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }

    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }

    private void StateChangeCheck()
    {
      if (balance < lowerLimit)
      {
        account.State = new RedState(this);
      }
      else if (balance > upperLimit)
      {
        account.State = new GoldState(this);
      }
    }
  }

  // "ConcreteState" - Interest bearing state
  class GoldState : State
  {
    // Overloaded constructors
    public GoldState(State state)
      : this(state.Balance, state.Account)
    {
    }

    public GoldState(double balance, Account account)
    {
      this.balance = balance;
      this.account = account;
      Initialize();
    }

    private void Initialize()
    {
      // Should come from a database
      interest = 0.05;
      lowerLimit = 1000.0;
      upperLimit = 10000000.0;
    }

    public override void Deposit(double amount)
    {
      balance += amount;
      StateChangeCheck();
    }

    public override void Withdraw(double amount)
    {
      balance -= amount;
      StateChangeCheck();
    }

    public override void PayInterest()
    {
      balance += interest * balance;
      StateChangeCheck();
    }

    private void StateChangeCheck()
    {
      if (balance < 0.0)
      {
        account.State = new RedState(this);
      }
      else if (balance < lowerLimit)
      {
        account.State = new SilverState(this);
      }
    }
  }
  #endregion

  #region Context
  class Account
  {
    private State state;
    private string owner;

    // Constructor
    public Account(string owner)
    {
      // New accounts are 'Silver' by default
      this.owner = owner;
      state = new SilverState(0.0, this);
    }

    // Properties
    public double Balance
    {
      get { return state.Balance; }
    }

    public State State
    {
      get { return state; }
      set { state = value; }
    }

    public void Deposit(double amount)
    {
      state.Deposit(amount);
      Console.WriteLine("Deposited {0:C} --- ", amount);
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
      Console.WriteLine("");
    }

    public void Withdraw(double amount)
    {
      state.Withdraw(amount);
      Console.WriteLine("Withdrew {0:C} --- ", amount);
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
    }

    public void PayInterest()
    {
      state.PayInterest();
      Console.WriteLine("Interest Paid --- ");
      Console.WriteLine(" Balance = {0:C}", this.Balance);
      Console.WriteLine(" Status = {0}\n", this.State.GetType().Name);
    }
  }
  #endregion

  /*
   * 适用性：
      1.一个对象的行为取决于它的状态，并且它必须在运行时刻根据状态改变它的行为。
      2.一个操作中含有庞大的多分支的等条件语句，且这些分支依赖于该对象的状态。这个状态通常用一个或多个枚举常量表示。
        通常，有多个操作包含这一相同的条件结构。State模式将每一个分支放入一个独立的类中。这使得你可根据对象自身的情况
        将对象的状态作为一个对象，这一对象可以不依赖于其他对象而独立变化。
   * 
   * State模式的几个要点：
      1.State模式将所有一个特定状态相关的行为都放入一个State的子类对象中，在对象状态切换时，
        切换相应的对象;但同时维持State的接口，这样实现了具体操作与状态转换之间的解耦。
      2.为不同的状态引入不同的对象使得状态转换变得更加明确，而且可以保证不会出现状态不一致的情况，
        因为转换是原子性的----即要么彻底转换过来，要么不转换。
      3.如果State对象没有实例变量，那么各个上下文可以共享 同一个State对象，从而节省对象开销。
   */
}
