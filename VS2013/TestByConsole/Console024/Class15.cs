using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 迭代器模式(Iterator Pattern) 
  /// </summary>
  public class C15
  {
    public static void Execute()
    {
      IIterator iterator;

      IList list = new ConcreteList();

      iterator = list.GetIterator();

      while (iterator.MoveNext())
      {
        int i = (int)iterator.CurrentItem();
        Console.WriteLine(i.ToString());

        iterator.Next();
      }

    }
  }

  /// <summary>
  /// 抽象聚集
  /// 首先有一个抽象的聚集，所谓的聚集就是就是数据的集合，可以循环去访问它。它只有一个方法GetIterator()让子类去实现，用来获得一个迭代器对象。
  /// </summary>
  public interface IList
  {
    IIterator GetIterator();
  }

  /// <summary>
  /// 抽象迭代器
  /// 抽象的迭代器，它是用来访问聚集的类，封装了一些方法，用来把聚集中的数据按顺序读取出来。
  /// 通常会有MoveNext()、CurrentItem()、Fisrt()、Next()等几个方法让子类去实现。
  /// </summary>
  public interface IIterator
  {
    bool MoveNext();

    Object CurrentItem();

    void First();

    void Next();
  }

  /// <summary>
  /// 具体聚集
  /// 具体的聚集，它实现了抽象聚集中的唯一的方法，同时在里面保存了一组数据，
  /// 这里我们加上Length属性和GetElement()方法是为了便于访问聚集中的数据。
  /// </summary>
  public class ConcreteList : IList
  {
    int[] list;

    public ConcreteList()
    {
      list = new int[] { 1, 2, 3, 4, 5 };
    }

    public IIterator GetIterator()
    {
      return new ConcreteIterator(this);
    }

    public int Length
    {
      get { return list.Length; }
    }

    public int GetElement(int index)
    {
      return list[index];
    }
  }

  /// <summary>
  /// 具体迭代器，实现了抽象迭代器中的四个方法，在它的构造函数中需要接受一个具体聚集类型的参数，在这里面我们可以根据实际的情况去编写不同的迭代方式。
  /// </summary>
  public class ConcreteIterator : IIterator
  {
    private ConcreteList list;

    private int index;

    public ConcreteIterator(ConcreteList list)
    {
      this.list = list;

      index = 0;
    }

    public bool MoveNext()
    {
      if (index < list.Length)

        return true;

      else

        return false;
    }

    public Object CurrentItem()
    {
      return list.GetElement(index);
    }

    public void First()
    {
      index = 0;
    }

    public void Next()
    {
      if (index < list.Length)
      {
        index++;
      }
    }
  }

  /*
   * 适用性：   
      1．访问一个聚合对象的内容而无需暴露它的内部表示。
      2．支持对聚合对象的多种遍历。
      3．为遍历不同的聚合结构提供一个统一的接口(即, 支持多态迭代)。
   * Iterator实现要点：
      1．迭代抽象：访问一个聚合对象的内容而无需暴露它的内部表示。
      2．迭代多态：为遍历不同的集合结构提供一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作。
      3．迭代器的健壮性考虑：遍历的同时更改迭代器所在的集合结构，会导致问题。
   */
}
