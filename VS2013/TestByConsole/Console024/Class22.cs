using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVisitor;

namespace Console024
{
  /// <summary>
  /// 访问者模式(Visitor Pattern)
  /// </summary>
  public class C22
  {
    public static void Execute()
    {
      // Setup employee collection
      Employees e = new Employees();
      e.Attach(new Clerk());
      e.Attach(new MyVisitor.Director());
      e.Attach(new MyVisitor.President());

      // Employees are 'visited'
      e.Accept(new IncomeVisitor());
      e.Accept(new VacationVisitor());
    }
  }

}
namespace MyVisitor
{
  // "Visitor"
  interface IVisitor
  {
    void Visit(Element element);
  }

  // "ConcreteVisitor1"
  class IncomeVisitor : IVisitor
  {
    public void Visit(Element element)
    {
      Employee employee = element as Employee;

      // Provide 10% pay raise
      employee.Income *= 1.10;
      Console.WriteLine("{0} {1}'s new income: {2:C}",
        employee.GetType().Name, employee.Name,
        employee.Income);
    }
  }

  // "ConcreteVisitor2"
  class VacationVisitor : IVisitor
  {
    public void Visit(Element element)
    {
      Employee employee = element as Employee;

      // Provide 3 extra vacation days
      Console.WriteLine("{0} {1}'s new vacation days: {2}",
        employee.GetType().Name, employee.Name,
        employee.VacationDays);
    }
  }

  class Clerk : Employee
  {
    // Constructor
    public Clerk() : base("Hank", 25000.0, 14)
    {
    }
  }

  class Director : Employee
  {
    // Constructor
    public Director() : base("Elly", 35000.0, 16)
    {
    }
  }

  class President : Employee
  {
    // Constructor
    public President() : base("Dick", 45000.0, 21)
    {
    }
  }

  // "Element"
  abstract class Element
  {
    public abstract void Accept(IVisitor visitor);
  }

  // "ConcreteElement"
  class Employee : Element
  {
    string name;
    double income;
    int vacationDays;

    // Constructor
    public Employee(string name, double income, int vacationDays)
    {
      this.name = name;
      this.income = income;
      this.vacationDays = vacationDays;
    }

    // Properties
    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public double Income
    {
      get { return income; }
      set { income = value; }
    }

    public int VacationDays
    {
      get { return vacationDays; }
      set { vacationDays = value; }
    }

    public override void Accept(IVisitor visitor)
    {
      visitor.Visit(this);
    }
  }

  // "ObjectStructure"

  class Employees
  {
    private ArrayList employees = new ArrayList();

    public void Attach(Employee employee)
    {
      employees.Add(employee);
    }

    public void Detach(Employee employee)
    {
      employees.Remove(employee);
    }

    public void Accept(IVisitor visitor)
    {
      foreach (Employee e in employees)
      {
        e.Accept(visitor);
      }
      Console.WriteLine();
    }
  }

  /*
   * 适用性：
      1.一个对象结构包含很多类对象，它们有不同的接口，而你想对这些对象实施一些依赖于其具体类的操作。
      2.需要对一个对象结构中的对象进行很多不同的并且不相关的操作，而你想避免让这些操作"污染"这些对象的类。
        Visitor使得你可以将相关的操作集中起来定义在一个类中。当该对象结构被很多应用共享时，用Visitor模式让每个应用仅包含需要用到的操作。
      3.定义对象结构的类很少改变，但经常需要在结构上定义新的操作。改变对象结构类需要重定义对所有访问者的接口，这可能需要很大的代价。
        如果对象结构类经常改变，那么可能还是在这些类中定义这些操作较好。
   * 
   * Visoitr模式的几个要点：
      1.Visitor模式通过所谓双重分发(double dispatch)来实现在不更改Element类层次结构的前提下，
        在运行时透明地为类层次结构上的各个类动态添加新的操作。
      2.所谓双重分发却Visotor模式中间包括了两个多态分发（注意其中的多态机制);第一个为accept方法的多态辨析;第二个为visitor方法的多态辨析。
      3.Visotor模式的最大缺点在于扩展类层次结构(增添新的Element子类），会导致Visitor类的改变。
        因此Visiotr模式适用"Element"类层次结构稳定，而其中的操作却经常面临频繁改动". 
   * 
   * 涉及角色
      1.Visitor 抽象访问者角色，为该对象结构中具体元素角色声明一个访问操作接口。该操作接口的名字和参数标识了发送访问
        请求给具体访问者的具体元素角色，这样访问者就可以通过该元素角色的特定接口直接访问它。
      2.ConcreteVisitor.具体访问者角色，实现Visitor声明的接口。
      3.Element 定义一个接受访问操作(accept())，它以一个访问者(Visitor)作为参数。
      4.ConcreteElement 具体元素，实现了抽象元素(Element)所定义的接受操作接口。
      5.ObjectStructure 结构对象角色，这是使用访问者模式必备的角色。它具备以下特性：能枚举它的元素；
        可以提供一个高层接口以允许访问者访问它的元素；如有需要，可以设计成一个复合对象或者一个聚集（如一个列表或无序集合）。
   * 
   * 在访问者模式中，主要包括下面几个角色：
      1.抽象访问者：抽象类或者接口，声明访问者可以访问哪些元素，具体到程序中就是visit方法中的参数定义哪些对象是可以被访问的。
      2.访问者：实现抽象访问者所声明的方法，它影响到访问者访问到一个类后该干什么，要做什么事情。
      3.抽象元素类：接口或者抽象类，声明接受哪一类访问者访问，程序上是通过accept方法中的参数来定义的。抽象元素一般有两类方法，一部分是本身的业务逻辑，另外就是允许接收哪类访问者来访问。
      4.元素类：实现抽象元素类所声明的accept方法，通常都是visitor.visit(this)，基本上已经形成一种定式了。
      5.结构对象：一个元素的容器，一般包含一个容纳多个不同类、不同接口的容器，如List、Set、Map等，在项目中一般很少抽象出这个角色。
   */
}
