using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console006.Class;

namespace Console006.CollectionsFunc
{
  /// <summary>
  /// 泛型
  /// </summary>
  class C7
  {
    public static void Execute()
    {
      Wallet<BankCard> w = new Wallet<BankCard>();
      w.Add(new BankCard(1, 4, 1) { ID = 1, Name = "2", Password = "3" });
      Console.WriteLine(w.Count);

      Wallet<Test_Not_WalletThingBase_Class> w2 = new Wallet<Test_Not_WalletThingBase_Class>();
      w2.Add(new Test_Not_WalletThingBase_Class() { ID = 1, TD = 2 });
      Console.WriteLine(w2.Count);

      Console.ReadLine();
    }
  }
}
