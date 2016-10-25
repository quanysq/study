using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console023
{
  /// <summary>
  /// 多线程
  /// </summary>
  public class C2
  {
    public static void Execute()
    {
      //单例程情况下，多个合同时会变得很慢

      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "WuDaokou", To = "LinDa Road", Fee = 500 });
      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "XiDan", To = "WangFujing", Fee = 1000 });
      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "XiangShan", To = "The Forbidden City", Fee = 10000 });

      Thread thread = null;

      while (HouseMovingCompany.Instance.Contracts.Count > 0)
      {
        thread = new Thread(new ThreadStart(HouseMovingCompany.Instance.MoveHouse));
        thread.Start();
      }
    }

    /// <summary>
    /// 准备成立一家搬家公司，准备好将来和客户签的合同书
    /// </summary>
    public class Contract
    {
      public string ID { get; private set; }
      public string From { get; set; }
      public string To { get; set; }
      public decimal Fee { get; set; }

      public Contract()
      {
        this.ID = DateTime.Now.ToBinary().ToString().Replace("-", String.Empty);
      }
    }

    /// <summary>
    /// 申请注册一家公司，并组建好初创团队，哪怕目前还只有老板一个人
    /// </summary>
    public class HouseMovingCompany
    {
      private static HouseMovingCompany _instance = null;
      public static HouseMovingCompany Instance
      {
        get { return (_instance == null ? _instance = new HouseMovingCompany() : _instance); }
      }

      public List<Contract> Contracts { get; private set; }

      public HouseMovingCompany()
      {
        this.Contracts = new List<Contract>();
      }

      public void MoveHouse()
      {
        if (this.Contracts == null || this.Contracts.Count == 0)
        {
          return;
        }

        Contract contract = null;

        lock (this.Contracts)
        {
          contract = this.Contracts[0];
          this.Contracts.RemoveAt(0);
        }

        if (!String.IsNullOrEmpty(contract.From) && !String.IsNullOrEmpty(contract.To))
        {
          Console.WriteLine("Move the house from {0} to {1}.", contract.From, contract.To);
        }

        Thread.Sleep(5000);
      }
    }
  }

  /*
   * 要开启一个新线程，需要以下的初始化：
      ThreadStart startDownload = new ThreadStart( DownLoad ); //线程起始设置：即每个线程都执行DownLoad()，注意：DownLoad()必须为不带有参数的方法
      Thread downloadThread = new Thread( startDownload ); //实例化要开启的新类
      downloadThread.Start();//开启线程
   * 
   * 现在有多个线程都在对Contracts中的元素进行存取，我们不得不提防一些意外发生。这就是在使用多线程的时候常常需要考虑的并发问题，
   * 所以我们用了lock关键字，当一个线程要操作Contracts时，它先把Contracts锁起来，其实就是声明一下：“现在我在操作它，你们谁都不要动，
   * 等我弄完了再说。”在lock块结束时被锁定的对象才会被解锁，其它的线程现在才可以去操作它。
   */
}
