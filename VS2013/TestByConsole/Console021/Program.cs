using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console021
{
  /// <summary>
  /// 泛型
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Wallet<BankCard> w = new Wallet<BankCard>();
      w.Add(new BankCard(1, 4, 1) { ID = 1, Name = "2", Password = "3" });
      Console.WriteLine(w.Count);

      Wallet<Test_Not_WalletThingBase_Class> w2 = new Wallet<Test_Not_WalletThingBase_Class>();
      w2.Add(new Test_Not_WalletThingBase_Class() { ID = 1, TD = 2 });
      Console.WriteLine(w2.Count);

      Console.ReadLine();
    }
  }

  public class WalletThingBase
  {
    protected readonly int MaxLength = 10;
    protected readonly int MaxWidth = 7;
    protected readonly int MaxThickness = 1;

    private int _length = 0;
    public int Length
    {
      get { return this._length; }
      set
      {
        if (value <= 0 || value > this.MaxLength)
        {
          throw new ArgumentException("Length is invalid.");
        }

        this._length = value;
      }
    }

    private int _width = 0;
    public int Width
    {
      get { return this._width; }
      set
      {
        if (value <= 0 || value > this.MaxWidth)
        {
          throw new ArgumentException("Width is invalid.");
        }

        this._width = value;
      }
    }

    private int _thickness = 0;
    public int Thickness
    {
      get { return this._thickness; }
      set
      {
        if (value <= 0 || value > this.MaxThickness)
        {
          throw new ArgumentException("Thickness is invalid.");
        }

        this._thickness = value;
      }
    }

    public WalletThingBase(int length, int width, int thickness)
    {
      this.Length = length;
      this.Width = width;
      this.Thickness = thickness;
    }
  }

  public class BankCard : WalletThingBase
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }

    public BankCard(int length, int width, int thickness)
      : base(length, width, thickness)
    {
    }
  }

  public class CreditCard : BankCard
  {
    public decimal Overdraft { get; set; }

    public CreditCard(int length, int width, int thickness)
      : base(length, width, thickness)
    {
    }
  }

  public class Wallet<T> : CollectionBase
  {
    public Wallet()
    {
      Type baseType = typeof(T).BaseType;

      while (baseType != null
          && baseType != typeof(Object)
          && baseType.BaseType != typeof(Object))
      {
        baseType = baseType.BaseType;
      }

      if (baseType != typeof(WalletThingBase))
      {
        throw new Exception(typeof(T).ToString() + " cannot be put into wallet.");
      }
    }

    public T this[int index]
    {
      get { return (T)List[index]; }
      set { List[index] = value; }
    }

    public int Add(T item)
    {
      return List.Add(item);
    }

    public void Remove(T item)
    {
      List.Remove(item);
    }
  }

  public class Test_Not_WalletThingBase_Class
  {
    public int ID { get; set; }
    public int TD { get; set; }
  }
}
