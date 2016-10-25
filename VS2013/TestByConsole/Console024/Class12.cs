using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console024
{
  /// <summary>
  /// 代理模式(Proxy Pattern)
  /// </summary>
  public class C12
  {
    public static void Execute()
    {
      IMath proxy = new MathProxy();

      double addresult = proxy.Add(2, 3);
      Console.WriteLine(addresult);
      double subresult = proxy.Sub(6, 4);
      Console.WriteLine(subresult);
      double mulresult = proxy.Mul(2, 3);
      Console.WriteLine(mulresult);
      double devresult = proxy.Dev(2, 3);
      Console.WriteLine(devresult);
    }
  }

  public interface IMath
  {
    double Add(double x, double y);

    double Sub(double x, double y);

    double Mul(double x, double y);

    double Dev(double x, double y);
  }

  public class Math : IMath
  {
    public double Add(double x, double y)
    {
      return x + y;
    }

    public double Sub(double x, double y)
    {
      return x - y;
    }

    public double Mul(double x, double y)
    {
      return x * y;
    }

    public double Dev(double x, double y)
    {
      return x / y;
    }
  }

  public class MathProxy : IMath
  {
    private IMath math = new Math();

    // 以下的方法中，可能不仅仅是简单的调用Math类的方法

    public double Add(double x, double y)
    {
      return math.Add(x, y);
    }

    public double Sub(double x, double y)
    {
      return math.Sub(x, y);
    }

    public double Mul(double x, double y)
    {
      return math.Mul(x, y);
    }

    public double Dev(double x, double y)
    {
      return math.Dev(x, y);
    }
  }


  /*
   * 人们对复杂的软件系统常有一种处理手法，即增加一层间接层，从而对系统获得一种更为灵活、满足特定需求的解决方案。
   * 
   * 对于程序中的接口Imath，并不是必须的，大多数情况下，我们为了保持对对象操作的透明性，并强制实现类实现代理类所要调用的所有的方法，
   * 我们会让它们实现与同一个接口。但是我们说代理类它其实只是在一定程度上代表了原来的实现类，所以它们有时候也可以不实现于同一个接口。
   * 
   * 代理模式实现要点：
      1．远程（Remote）代理：为一个位于不同的地址空间的对象提供一个局域代表对象。这个不同的地址空间可以是在本机器中，也可是在另一台机器中。
         远程代理又叫做大使（Ambassador）。好处是系统可以将网络的细节隐藏起来，使得客户端不必考虑网络的存在。客户完全可以认为被代理的对象是局
         域的而不是远程的，而代理对象承担了大部份的网络通讯工作。由于客户可能没有意识到会启动一个耗费时间的远程调用，因此客户没有必要的思想准备。
      2．虚拟（Virtual）代理：根据需要创建一个资源消耗较大的对象，使得此对象只在需要时才会被真正创建。使用虚拟代理模式的好处就是代理对象可以在
         必要的时候才将被代理的对象加载；代理可以对加载的过程加以必要的优化。当一个模块的加载十分耗费资源的情况下，虚拟代理的好处就非常明显。
      3．Copy-on-Write代理：虚拟代理的一种。把复制（克隆）拖延到只有在客户端需要时，才真正采取行动。
      4．保护（Protect or Access）代理：控制对一个对象的访问，如果需要，可以给不同的用户提供不同级别的使用权限。保护代理的好处是它可以在运行
         时间对用户的有关权限进行检查，然后在核实后决定将调用传递给被代理的对象。
      5．Cache代理：为某一个目标操作的结果提供临时的存储空间，以便多个客户端可以共享这些结果。
      6．防火墙（Firewall）代理：保护目标，不让恶意用户接近。
      7．同步化（Synchronization）代理：使几个用户能够同时使用一个对象而没有冲突。
      8．智能引用（Smart Reference）代理：当一个对象被引用时，提供一些额外的操作，比如将对此对象调用的次数记录下来等。
   * 
   * 虚拟代理(Virtual Proxy)也是一种常用的代理模式，对于一些占用系统资源较多或者加载时间较长的对象，可以给这些对象提供一个虚拟代理。
   * 在真实对象创建成功之前虚拟代理扮演真实对象的替身，而当真实对象创建之后，虚拟代理将用户的请求转发给真实对象。
   * 通常，在以下两种情况下可以考虑使用虚拟代理：
   * (1) 由于对象本身的复杂性或者网络等原因导致一个对象需要较长的加载时间，此时可以用一个加载时间相对较短的代理对象来代表真实对象。
   * 通常在实现时可以结合多线程技术，一个线程用于显示代理对象，其他线程用于加载真实对象。这种虚拟代理模式可以应用在程序启动的时候，
   * 由于创建代理对象在时间和处理复杂度上要少于创建真实对象，因此，在程序启动时，可以用代理对象代替真实对象初始化，大大加速了系统的启动时间。
   * 当需要使用真实对象时，再通过代理对象来引用，而此时真实对象可能已经成功加载完毕，可以缩短用户的等待时间。
   * (2) 当一个对象的加载十分耗费系统资源的时候，也非常适合使用虚拟代理。虚拟代理可以让那些占用大量内存或处理起来非常复杂的对象推迟到使用
   * 它们的时候才创建，而在此之前用一个相对来说占用资源较少的代理对象来代表真实对象，再通过代理对象来引用真实对象。为了节省内存，在第一次
   * 引用真实对象时再创建对象，并且该对象可被多次重用，在以后每次访问时需要检测所需对象是否已经被创建，因此在访问该对象时需要进行存在性检测，
   * 这需要消耗一定的系统时间，但是可以节省内存空间，这是一种用时间换取空间的做法。
   * 无论是以上哪种情况，虚拟代理都是用一个“虚假”的代理对象来代表真实对象，通过代理对象来间接引用真实对象，可以在一定程度上提高系统的性能。
   */
}
