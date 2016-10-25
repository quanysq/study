using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 解释器模式(Interpreter Pattern) 
  /// </summary>
  public class C17
  {
    public static void Execute()
    {
      string roman = "五千四百三十二"; //5432
      Context context = new Context(roman);

      //Build the 'parse tree'
      ArrayList tree = new ArrayList();
      tree.Add(new OneExpression());
      tree.Add(new TenExpression());
      tree.Add(new HundredExpression());
      tree.Add(new ThousandExpression());

      //Interpret
      foreach (Expression exp in tree)
      {
        exp.Interpret(context);
      }
      Console.WriteLine("{0} = {1}", roman, context.Data);

    }
  }

  //创建一个抽象类Expression，来描述共同的操作。
  public abstract class Expression
  {
    protected Dictionary<string, int> table = new Dictionary<string, int>(9);
    public Expression()
    {
      table.Add("一", 1);
      table.Add("二", 2);
      table.Add("三", 3);
      table.Add("四", 4);
      table.Add("五", 5);
      table.Add("六", 6);
      table.Add("七", 7);
      table.Add("八", 8);
      table.Add("九", 9);
    }
    public virtual void Interpret(Context context)
    {
      if (context.Statement.Length == 0)
      {
        return;
      }
      foreach (string key in table.Keys)
      {
        int value = table[key];
        if (context.Statement.EndsWith(key + GetPostifix()))
        {
          context.Data += value * Multiplier();
          context.Statement = context.Statement.Substring(0, context.Statement.Length - this.GetLength());
        }

        if (context.Statement.EndsWith("零"))
        {
          context.Statement = context.Statement.Substring(0, context.Statement.Length - 1);
        }
        if (context.Statement.Length == 0)
        {
          return;
        }
      }
    }

    public abstract string GetPostifix();
    public abstract int Multiplier();
    public virtual int GetLength()
    {
      return this.GetPostifix().Length + 1;
    }
  }
  //然后创建一个公共类Context,定义一些全局信息。
  public class Context
  {
    private string statement;
    private int data;

    //Constructor
    public Context(string statement)
    {
      this.statement = statement;
    }
    //Properties
    public string Statement
    {
      get { return statement; }
      set { statement = value; }
    }
    public int Data
    {
      get { return data; }
      set { data = value; }
    }
  }

  public class OneExpression : Expression
  {
    public override string GetPostifix()
    {
      return "";
    }
    public override int Multiplier() { return 1; }
    public override int GetLength()
    {
      return 1;
    }
  }
  public class TenExpression : Expression
  {
    public override string GetPostifix()
    {
      return "十";
    }
    public override int Multiplier() { return 10; }
    public override int GetLength()
    {
      return 2;
    }
  }
  public class HundredExpression : Expression
  {
    public override string GetPostifix()
    {
      return "百";
    }
    public override int Multiplier() { return 100; }
    public override int GetLength()
    {
      return 2;
    }
  }
  public class ThousandExpression : Expression
  {
    public override string GetPostifix()
    {
      return "千";
    }
    public override int Multiplier() { return 1000; }
    public override int GetLength()
    {
      return 2;
    }
  }

  /*
   * 适用性：
      1.当有一个语言需要解释执行，并且你可将该语言中的句子表示为一个抽象语法树时，可使用解释器模式。
        而当存在以下情况时该模式效果最好：
      2.该文法简单对于复杂的文法，文法的类层次变得庞大而无法管理。此时语法分析程序生成器这样的工具是更好的选择。
        它们无需构建抽象语法树即可解释表达工，这样可以节省空间而且还可能节省时间。
      3.效率不是一个关键问题最高效的解释器通常不是通过直接解释语法分析树实现的，而是首先将它们转换成另一种
        形式。例如：正则表达式通常被转换成状态机。但即使在这种情况下，转换器仍可用解释器模式实现，该模式仍是有用的。
   * 
   * Interpreter实现要点：
      1.Interpreter模式的应用场合是interpreter模式应用中的难点，只有满足"业务规则频繁变化，且类似的模式不断重复出现，
        并且容易抽象为语法规则的问题"才适合使用Interpreter模式。
      2.使用Interpreter模式来表示文法规则，从而可以使用面向对象技巧来方便地“扩展”文法。
      3.Interpreter模式比较适合简单的文法表示，对于复杂的文法表示，Interpreter模式会产生比较大的类层次结构，
        需要求助于语法分析生成器这样的标准工具。
   */
}
