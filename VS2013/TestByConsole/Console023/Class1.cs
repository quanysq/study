using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console023
{
  /// <summary>
  /// 单例程
  /// </summary>
  public class C1
  {
    public static void Execute()
    {
      //单例程情况下，多个合同时会变得很慢

      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "WuDaokou", To = "LinDa Road", Fee = 500 });
      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "XiDan", To = "WangFujing", Fee = 1000 });
      HouseMovingCompany.Instance.Contracts.Add(new Contract { From = "XiangShan", To = "The Forbidden City", Fee = 10000 });

      while (HouseMovingCompany.Instance.Contracts.Count > 0)
      {
        HouseMovingCompany.Instance.MoveHouse();
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

        Contract contract = contract = this.Contracts[0];
        this.Contracts.RemoveAt(0);

        if (!String.IsNullOrEmpty(contract.From) && !String.IsNullOrEmpty(contract.To))
        {
          Console.WriteLine("Move the house from {0} to {1}.", contract.From, contract.To);
        }

        Thread.Sleep(5000);
      }
    }
  }
}
