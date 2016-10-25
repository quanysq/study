using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 外观模式（Facade Pattern) 
  /// </summary>
  public class C10
  {
    public static void Execute()
    {
      //外观
      Mortgage mortgage = new Mortgage();

      Customer customer = new Customer("Ann McKinsey");
      bool eligable = mortgage.IsEligible(customer, 125000);

      Console.WriteLine("\n" + customer.Name +
          " has been " + (eligable ? "Approved" : "Rejected"));
      Console.ReadLine();
    }
  }

  //外观类
  public class Mortgage
  {
    private Bank bank = new Bank();
    private Loan loan = new Loan();
    private Credit credit = new Credit();

    public bool IsEligible(Customer cust, int amount)
    {
      Console.WriteLine("{0} applies for {1:C} loan\n", cust.Name, amount);

      bool eligible = true;

      if (!bank.HasSufficientSavings(cust, amount))
      {
        eligible = false;
      }
      else if (!loan.HasNoBadLoans(cust))
      {
        eligible = false;
      }
      else if (!credit.HasGoodCredit(cust))
      {
        eligible = false;
      }

      return eligible;
    }
  }

  //银行子系统
  public class Bank
  {
    public bool HasSufficientSavings(Customer c, int amount)
    {
      Console.WriteLine("Check bank for " + c.Name);
      return true;
    }
  }

  //信用证子系统
  public class Credit
  {
    public bool HasGoodCredit(Customer c)
    {
      Console.WriteLine("Check credit for " + c.Name);
      return true;
    }
  }

  //贷款子系统
  public class Loan
  {
    public bool HasNoBadLoans(Customer c)
    {
      Console.WriteLine("Check loans for " + c.Name);
      return true;
    }
  }

  //顾客类
  public class Customer
  {
    private string name;

    public Customer(string name)
    {
      this.name = name;
    }

    public string Name
    {
      get { return name; }
    }
  }

  /*
   * 适用性：
      1．为一个复杂子系统提供一个简单接口。
      2．提高子系统的独立性。
      3．在层次化结构中，可以使用Facade模式定义系统中每一层的入口。
   * 
   * Facade模式的一个要点：
   * 从客户程序的角度来看，Facade模式不仅简化了整个组件系统的接口，同时对于组件内部与外部客户程序来说，从某种程度上
   * 也达到了一种“解耦”的效果----内部子系统的任何变化不会影响到Facade接口的变化。
   * 
   * Facade设计模式更注重从架构的层次去看整个系统，而不是单个类的层次。Facdae很多时候更是一种架构设计模式。
   * 
   * 注意区分Facade模式、Adapter模式、Bridge模式与Decorator模式。Facade模式注重简化接口，Adapter模式注重转换接口，
   * Bridge模式注重分离接口（抽象）与其实现，Decorator模式注重稳定接口的前提下为对象扩展功能。
   */
}
