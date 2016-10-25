using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console042
{
  class Program
  {
    static void Main(string[] args)
    {
      Lazy<Big> lazyBig = new Lazy<Big>();
      lazyBig.Value.ID = 20;
      Console.WriteLine(lazyBig.Value.ID);

      Lazy<Big> lazyBig2 = new Lazy<Big>(() => new Big(100));
      Console.WriteLine(lazyBig2.Value.ID);

      Lazy<Big> lazyBig3 = new Lazy<Big>(() => BigFactory.Build());
      Console.WriteLine(lazyBig3.Value.ID);
    }
  }

  public class Big
  {
    public int ID { get; set; }

    public Big()
    {

    }

    public Big(int id)
    {
      this.ID = id;
    }
  }

  public class BigFactory
  {
    public static Big Build()
    {
      return new Big(110);
    }
  }
}
