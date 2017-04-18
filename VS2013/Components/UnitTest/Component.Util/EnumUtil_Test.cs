using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Component.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Component.Util.Tests
{
  [TestClass()]
  public class EnumUtil_Test
  {
    [TestMethod()]
    public void Enum2EnumNameTest()
    {
      string str = EnumUtil<EnumTest>.Enum2EnumName(EnumTest.NULL);
      Assert.AreEqual(str, "NULL");
    }

    [TestMethod()]
    public void EnumName2EnumTest()
    {
      var enumTest = EnumUtil<EnumTest>.EnumName2Enum("One");
      Assert.IsTrue(enumTest == EnumTest.One);
    }
  }

  internal enum EnumTest
  {
    NULL,
    One,
    Two
  }
}
