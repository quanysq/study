using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 命令模式(Command Pattern)
  /// </summary>
  public class C14
  {
    public static void Execute()
    {
      Document doc = new Document();


      DocumentCommand discmd = new DisplayCommand(doc);

      DocumentCommand undcmd = new UndoCommand(doc);

      DocumentCommand redcmd = new RedoCommand(doc);


      DocumentInvoker invoker = new DocumentInvoker(discmd, undcmd, redcmd);

      invoker.Display();

      invoker.Undo();

      invoker.Redo();

    }
  }

  /// <summary>
  /// 文档类--行为的实现者(角色：Receiver)
  /// </summary>
  public class Document
  {
    /// <summary>
    /// 显示操作
    /// </summary>
    public void Display()
    {
      Console.WriteLine("Display");
    }

    /// <summary>
    /// 撤销操作
    /// </summary>
    public void Undo()
    {
      Console.WriteLine("Undo");
    }

    /// <summary>
    /// 恢复操作
    /// </summary>
    public void Redo()
    {
      Console.WriteLine("Redo");
    }
  }

  /// <summary>
  /// 抽象命令
  /// </summary>
  public abstract class DocumentCommand
  {
    protected Document _document;

    public DocumentCommand(Document doc)
    {
      this._document = doc;
    }

    /// <summary>
    /// 执行
    /// </summary>
    public abstract void Execute();

  }

  /// <summary>
  /// 显示命令
  /// </summary>
  public class DisplayCommand : DocumentCommand
  {
    public DisplayCommand(Document doc)
      : base(doc)
    {

    }

    public override void Execute()
    {
      _document.Display();
    }
  }


  /// <summary>
  /// 撤销命令
  /// </summary>
  public class UndoCommand : DocumentCommand
  {
    public UndoCommand(Document doc)
      : base(doc)
    {

    }

    public override void Execute()
    {
      _document.Undo();
    }
  }

  /// <summary>
  /// 重做命令
  /// </summary>
  public class RedoCommand : DocumentCommand
  {
    public RedoCommand(Document doc)
      : base(doc)
    {

    }

    public override void Execute()
    {
      _document.Redo();
    }
  }

  /// <summary>
  /// Invoker（调用者）角色
  /// 这其实相当于一个中间角色，使用这样的一个中间层也是经常使用的手法，即把A对B的依赖转换为A对C的依赖。
  /// </summary>
  public class DocumentInvoker
  {
    DocumentCommand _discmd;
    DocumentCommand _undcmd;
    DocumentCommand _redcmd;

    public DocumentInvoker(DocumentCommand discmd, DocumentCommand undcmd, DocumentCommand redcmd)
    {
      this._discmd = discmd;
      this._undcmd = undcmd;
      this._redcmd = redcmd;
    }

    public void Display()
    {
      _discmd.Execute();
    }

    public void Undo()
    {
      _undcmd.Execute();
    }

    public void Redo()
    {
      _redcmd.Execute();
    }
  }


  /*
   * 耦合是软件不能抵御变化灾难的根本性原因
   * 
   * 适用性：
      1．使用命令模式作为"CallBack"在面向对象系统中的替代。"CallBack"讲的便是先将一个函数登记上，然后在以后调用此函数。
      2．需要在不同的时间指定请求、将请求排队。一个命令对象和原先的请求发出者可以有不同的生命期。换言之，原先的请求发出者
          可能已经不在了，而命令对象本身仍然是活动的。这时命令的接收者可以是在本地，也可以在网络的另外一个地址。命令对象
          可以在串形化之后传送到另外一台机器上去。
      3．系统需要支持命令的撤消(undo)。命令对象可以把状态存储起来，等到客户端需要撤销命令所产生的效果时，可以调用undo()方法，
          把命令所产生的效果撤销掉。命令对象还可以提供redo()方法，以供客户端在需要时，再重新实施命令效果。
      4．如果一个系统要将系统中所有的数据更新到日志里，以便在系统崩溃时，可以根据日志里读回所有的数据更新命令，重新调用
          Execute()方法一条一条执行这些命令，从而恢复系统在崩溃前所做的数据更新。
   * 
   * 同时我们也可以看到，本来这三个命令仅仅是三个方法而已，但是通过Command模式却把它们提到了类的层面，这其实是违背了面向对象的原则，
   * 但它却优雅的解决了分离命令的请求者和命令的执行者的问题，在使用Command模式的时候，一定要判断好使用它的时机。
   * 
   * Command实现要点：
      1．Command模式的根本目的在于将“行为请求者”与“行为实现者”解耦，在面向对象语言中，常见的实现手段是“将行为抽象为对象”。
      2．实现Command接口的具体命令对象ConcreteCommand有时候根据需要可能会保存一些额外的状态信息。
      3．通过使用Compmosite模式，可以将多个命令封装为一个“复合命令”MacroCommand。
      4．Command模式与C#中的Delegate有些类似。但两者定义行为接口的规范有所区别：Command以面向对象中的“接口-实现”来定义行为接口规范，
          更严格，更符合抽象原则；Delegate以函数签名来定义行为接口规范，更灵活，但抽象能力比较弱。
      5．使用命令模式会导致某些系统有过多的具体命令类。某些系统可能需要几十个，几百个甚至几千个具体命令类，这会使命令模式在这样的系统里变得不实际。
   * 
   * Command的优缺点：
      命令允许请求的一方和接收请求的一方能够独立演化，从而且有以下的优点：
          1.命令模式使新的命令很容易地被加入到系统里。
          2.允许接收请求的一方决定是否要否决（Veto）请求。
          3.能较容易地设计-个命令队列。
          4.可以容易地实现对请求的Undo和Redo。
          5.在需要的情况下，可以较容易地将命令记入日志。
          6.命令模式把请求一个操作的对象与知道怎么执行一个操作的对象分割开。
          7.命令类与其他任何别的类一样，可以修改和推广。
          8.你可以把命令对象聚合在一起，合成为合成命令。比如宏命令便是合成命令的例子。合成命令是合成模式的应用。
          9.由于加进新的具体命令类不影响其他的类，因此增加新的具体命令类很容易。
 
      命令模式的缺点如下：
          1.使用命令模式会导致某些系统有过多的具体命令类。某些系统可能需要几十个，几百个甚至几千个具体命令类，这会使命令模式在这样的系统里变得不实际。
   */
}
