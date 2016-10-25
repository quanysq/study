using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBHelper.Common.Tests
{
  [TestClass()]
  public class CommonTests
  {
    [TestMethod()]
    public void LocalConnectionTest()
    {
      string LocalConnection = Common.LocalConnection;

      string ExpectValue = "Data Source=127.0.0.1;DataBase=DBHelper;user=sa;password=quanysq123;Max Pool Size=50;Min Pool Size=5;Pooling=true;Connection Lifetime=30;";

      Assert.AreEqual(LocalConnection, ExpectValue);
    }
  }
}
