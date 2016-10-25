using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 策略模式(Strategy Pattern)
  /// </summary>
  public class C21
  {
    public static void Execute()
    {
      //Two contexts following different strategies 
      SortdList studentRecords = new SortdList();

      studentRecords.Add("Satu");
      studentRecords.Add("Jim");
      studentRecords.Add("Palo");
      studentRecords.Add("Terry");
      studentRecords.Add("Annaro");

      studentRecords.SetSortStrategy(new QuickSort());
      studentRecords.Sort();

      studentRecords.SetSortStrategy(new ShellSort());
      studentRecords.Sort();

      studentRecords.SetSortStrategy(new MergeSort());
      studentRecords.Sort();
    }
  }


  //Stategy  表达抽象算法
  abstract class SortStrategy
  {
    public abstract void Sort(ArrayList list);
  }

  //ConcreteStrategy
  class ShellSort : SortStrategy
  {
    public override void Sort(System.Collections.ArrayList list)
    {
      list.Sort(); //no-implement
      Console.WriteLine("ShellSorted List");

    }
  }

  //ConcreteStrategy
  class MergeSort : SortStrategy
  {
    public override void Sort(System.Collections.ArrayList list)
    {
      list.Sort(); //no-implement
      Console.WriteLine("MergeSort List ");
    }
  }
  //ConcreteStrategy
  class QuickSort : SortStrategy
  {
    public override void Sort(System.Collections.ArrayList list)
    {
      list.Sort(); //Default is Quicksort
      Console.WriteLine("QuickSorted List");
    }
  }

  //Context
  class SortdList
  {
    private ArrayList list = new ArrayList();
    private SortStrategy sortstrategy;  //对象组合
    public void SetSortStrategy(SortStrategy sortstrategy)
    {
      this.sortstrategy = sortstrategy;
    }
    public void Add(string name)
    {
      list.Add(name);
    }
    public void Sort()
    {
      sortstrategy.Sort(list);
      //Display results 
      foreach (string name in list)
      {
        Console.WriteLine(" " + name);
      }
      Console.WriteLine();
    }
  }


  /*
   * 适用性：
      1.许多相关的类仅仅是行为有异。“策略”提供了一种用多个行为中的一个行为来配置一个类的方法。
      2.需要使用一个算法的不同变体。例如，你可能会定义一些反映不同的空间/时间权衡的算法。当这些变体实现为一个算法的类层次时[H087]，可以使用策略模式。    
      3.算法使用客户不应该知道数据。可使用策略模式以避免暴露复杂的，与算法相关的数据结构。
      4.一个类定义了多种行为，并且这些行为在这个类的操作中以多个条件语句的形式出现。将相关的条件分支移入它们各自的Strategy类中以代替这些条件语句。
   * 
   * Strategy模式的几个要点：
      1.Strategy及其子类为组件提供了一系列可重用的算法，从而可以使得类型在运行时方便地根据需要在各个算法之间进行切换。所谓封装算法，支持算法的变化。
      2.Strategy模式提供了用条件判断语句以外的另一种选择，消除条件判断语句，就是在解耦合。含有许多条件判断语句的代码通常都需要Strategy模式。
      3.与State类似，如果Strategy对象没有实例变量，那么各个上下文可以共享同一个Strategy对象，从而节省对象开销。
   */
}
