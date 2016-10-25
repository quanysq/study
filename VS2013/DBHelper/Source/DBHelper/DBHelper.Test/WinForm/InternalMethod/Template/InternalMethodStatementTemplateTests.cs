using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBHelper.Enums;

namespace DBHelper.Tests
{
  [TestClass()]
  public class InternalMethodStatementTemplateTests
  {
    [TestMethod()]
    public void ExtractParamerFromSqlStatementTest()
    {
      string strsql = 
@"
UPDATE MethodStatement SET 
	Statement=@Statement, 
	IsOrderby=@IsOrderby,
	HasConditional=@HasConditional
WHERE StatementID=@StatementID and Statement=@Statement
";
      List<string> l = InternalMethodStatementTemplate.ExtractParamer(MethodType.SQLStatement, strsql);
      Assert.IsTrue(l.Count == 4);
    }
  }
}
