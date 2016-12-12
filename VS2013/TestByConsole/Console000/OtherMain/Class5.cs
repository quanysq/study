using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console000
{
  interface ITest
  {
    void SayHello();
  }

  abstract class absTest : ITest
  {
    public void SayOK()
    {
      Console.WriteLine("OK");
    }

    public abstract void SayHello();
  }

  class relTest : absTest
  {
    public void SayNo()
    {
      Console.WriteLine("No");
    }

    public override void SayHello()
    {
      Console.WriteLine("Hello!");
    }
  }

  class Class5
  {
    public static void Execute(string[] args)
    {
      //only has 1 method
      ITest iTest = new relTest();
      iTest.SayHello();

      //has 2 methods
      absTest absTest = new relTest();
      absTest.SayOK();
      absTest.SayHello();

      //has 3 methods
      relTest relTest = new relTest();
      relTest.SayOK();
      relTest.SayNo();
      relTest.SayHello();
    }

    
  }
}
