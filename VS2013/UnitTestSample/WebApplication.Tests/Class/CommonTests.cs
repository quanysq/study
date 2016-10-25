using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApplication.Class.Tests
{
  [TestClass()]
  public class CommonTests
  {
    [TestMethod()]
    public void ReadTxtTest()
    {
      string filepath = @"D:\VS2013\UnitTestSample\WebApplication\File\01.txt";

      string filenote = Common.ReadTxt(filepath);

      Assert.IsNotNull(filenote);
    }
  }
}
