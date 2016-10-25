using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 备忘录模式(Memento Pattern)
  /// </summary>
  public class C20
  {
    public static void Execute()
    {
      SalesProspect s = new SalesProspect();
      s.Name = "xiaoming";
      s.Phone = "(010)65236523";
      s.Budget = 28000.0;

      //Store internal state
      ProspectMemory m = new ProspectMemory();
      m.Memento = s.SaveMemento();

      //Continue changing originator
      s.Name = "deke";
      s.Phone = "(029)85423657";
      s.Budget = 80000.0;

      //Restore saved state 
      s.RestoreMemento(m.Memento);
    }
  }

  /// <summary>
  /// 备忘本
  /// </summary>
  class Memento
  {
    private string name;
    private string phone;
    private double budget;

    //Constructor
    public Memento(string name, string phone, double budget)
    {
      this.name = name;
      this.phone = phone;
      this.budget = budget;
    }
    //Properties
    public string Name
    {
      get { return name; }
      set { name = value; }
    }
    public string Phone
    {
      get { return phone; }
      set { phone = value; }
    }
    public double Budget
    {
      get { return budget; }
      set { budget = value; }
    }
  }

  class ProspectMemory
  {
    private Memento memento;

    //Property
    public Memento Memento
    {
      set { memento = value; }
      get { return memento; }
    }
  }

  //Originator
  class SalesProspect
  {
    private string name;
    private string phone;
    private double budget;

    //Properties
    public string Name
    {
      get { return name; }
      set { name = value; Console.WriteLine("Name:" + name); }
    }
    public string Phone
    {
      get { return phone; }
      set { phone = value; Console.WriteLine("Phone:" + phone); }
    }
    public double Budget
    {
      get { return Budget; }
      set { budget = value; Console.WriteLine("Budget:" + budget); }
    }
    public Memento SaveMemento()
    {
      Console.WriteLine("\nSaving state --\n");
      return new Memento(name, phone, budget);
    }
    public void RestoreMemento(Memento memento)
    {
      Console.WriteLine("\nRestoring state --\n");
      this.Name = memento.Name;
      this.Phone = memento.Phone;
      this.Budget = memento.Budget;
    }
  }

  /*
   * 适用性：
      1.必须保存一个对象某一个时刻的(部分)状态，这样以后需要时它才能恢复到先前的状态。
      2.如果一个用接口来让其它对象直接得到这些状态，将会暴露对象的实现细节并破坏对象的封装性。
   * 
   * Memento需要注意的几个要点：
      1.备忘录(Memento)存储原发器(Originator)对象的内部状态，在需要时恢复原发器状态。Memento模式适用于“由原发器管理，
        却又必须存储在原发器之外的信息”。
      2.在实现Memento模式中，要防止原发器以外的对象访问备忘录对象。备忘录对象有两个接口，一个为原发器的宽接口;一个为其他对象使用的窄接口。
      3.在实现Memento模式时，要考虑拷贝对象状态的效率问题，如果对象开销比较大，可以采用某种增量式改变来改进Memento模式。
   */
}
