using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Transactions;
using System.IO;
namespace DBHelper.DAO.Tests
{
  [TestClass()]
  public class SQLHelperTests
  {
    [TestMethod()]
    public void ExecuteSQLForQueryTest()
    {
      string xmlpath  = @"../../DAO/XMLExample/TestFormat.xml";
      SQLHelper sh    = new SQLHelper(xmlpath);
      sh.FormatValues = new string[] { "Admin" };
      DataTable dt    = sh.ExecuteSQL<DataTable>();
      int r           = dt.Rows.Count;

      Assert.IsTrue(r > 0);
    }

    
    [TestMethod()]
    public void ExecuteSQLForDDLTest()
    {
      using (TransactionScope scope = new TransactionScope())
      {
        string xmlpath  = @"../../DAO/XMLExample/TestParameter.xml";
        SQLHelper sh    = new SQLHelper(xmlpath);
        sh.ParameValues = new string[] { "UserTester", "测试用户", "123456" };
        int r           = sh.ExecuteSQL<int>();
        Assert.AreEqual(r, 1);
      }
    }

    [TestMethod()]
    public void ExecuteSQLForSingleTest()
    {
      string xmlpath  = @"../../DAO/XMLExample/TestSingle.xml";
      SQLHelper sh    = new SQLHelper(xmlpath);
      int i        = sh.ExecuteSQL<int>();
      Assert.IsTrue(i > 0);
    }
  }
}
