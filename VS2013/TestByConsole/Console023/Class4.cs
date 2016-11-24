using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console023
{
  class C4
  {
    public static void Execute()
    {
      Console.WriteLine("Start");
      Task.Run(() =>
      {
        for (int i = 0; i < 10; i++)
        {
          Console.WriteLine(i);
        }
      });

      Task.Run(() => {
        for (int i = 20; i < 30; i++)
        {
          Console.WriteLine(i);
        }
      });

      Console.WriteLine("End");
    }
  }
}
