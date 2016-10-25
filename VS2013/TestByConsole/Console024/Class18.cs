using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 中介者模式(Mediator Pattern) 
  /// </summary>
  public class C18
  {
    public static void Execute()
    {
      //create chatroom
      Chatroom chatroom = new Chatroom();
      //Create participants and register them
      Participant George = new Beatle("George");
      Participant Paul = new Beatle("Paul");
      Participant Ringo = new Beatle("Ringo");
      Participant John = new Beatle("John");
      Participant Yoko = new Beatle("Yoko");
      chatroom.Register(George);
      chatroom.Register(Paul);
      chatroom.Register(Ringo);
      chatroom.Register(John);
      chatroom.Register(Yoko);

      //chatting participants
      Yoko.Send("John", "Hi John");
      Paul.Send("Ringo", "All you need is love");
      Ringo.Send("George", "My sweet Lord");
      Paul.Send("John", "Can't buy me love");
      John.Send("Yoko", "My sweet love");
    }
  }

  //Mediator
  abstract class AbstractChatroom
  {
    public abstract void Register(Participant participant);
    public abstract void Send(string from, string to, string message);
  }

  //ConcreteMediator
  class Chatroom : AbstractChatroom
  {
    private Hashtable participants = new Hashtable();
    public override void Register(Participant participant)
    {
      if (participants[participant.Name] == null)
      {
        participants[participant.Name] = participant;
      }
      participant.Chatroom = this;
    }
    public override void Send(string from, string to, string message)
    {
      Participant pto = (Participant)participants[to];
      if (pto != null)
      {
        pto.Receive(from, message);
      }
    }
  }

  //AbstractColleague
  class Participant
  {
    private Chatroom chatroom;
    private string name;

    //Constructor
    public Participant(string name)
    {
      this.name = name;
    }
    //Properties
    public string Name
    {
      get { return name; }
    }
    public Chatroom Chatroom
    {
      set { chatroom = value; }
      get { return chatroom; }

    }
    public void Send(string to, string message)
    {
      chatroom.Send(name, to, message);
    }
    public virtual void Receive(string from, string message)
    {
      Console.WriteLine("{0} to {1}:'{2}'", from, name, message);
    }
  }

  //ConcreteColleaguel
  class Beatle : Participant
  {
    //Constructor
    public Beatle(string name)
      : base(name)
    { }
    public override void Receive(string from, string message)
    {
      Console.Write("To a Beatle: ");
      base.Receive(from, message);
    }
  }

  //ConcreteColleague2
  class NonBeatle : Participant
  {
    //Constructor
    public NonBeatle(string name)
      : base(name)
    { }
    public override void Receive(string from, string message)
    {
      Console.Write("To a non-Beatle:");
      base.Receive(from, message);
    }
  }

  /*
   * 适用性：
      1.一组对象以定义良好但是复杂的方式进行通信。产生的相互依赖关系结构混乱且难以理解。
      2.一个对象引用其他很多对象并且直接与这些对象通信，导致难以复用该对象。
      3.想定制一个分布在多个类中的行为，而又不想生成太多的子类。
   * 
   * Mediator实现要点：
      1.将多个对象间复杂的关联关系解耦，Mediator模式将多个对象间的控制逻辑进行集中管理，变“多
        个对象互相关系”为“多个对象和一个中介者关联”，简化了系统的维护，抵御了可能的变化。
      2.随着控制逻辑的复杂化，Mediator具体对象的实现可能相当复杂。 这时候可以对Mediator对象进行分解处理。
      3.Facade模式是解耦系统外到系统内(单向)的对象关系关系;Mediator模式是解耦系统内各个对象之间(双向)的关联关系。
   */
}
