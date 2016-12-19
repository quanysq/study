using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console006.RandomFunc
{
  /// <summary>
  /// 延迟加载
  /// </summary>
  class C8
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

  class Big
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

  class BigFactory
  {
    public static Big Build()
    {
      return new Big(110);
    }
  }
}
