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
  public class DataTypeConverter_Test
  {
    [TestMethod()]
    public void ConvertDataTypeTest()
    {
      object obj = true;
      bool bol = ConverterUtil.ConvertDataType<bool>(obj);
      Assert.IsTrue(bol);
    }

    [TestMethod()]
    public void ConvertDataType_NotBool_Test()
    {
      object obj = "ABC";
      bool bol = ConverterUtil.ConvertDataType<bool>(obj);
      Assert.IsFalse(bol);
    }

    [TestMethod()]
    public void ConvertDataType_String_Test()
    {
      string str = "True";
      bool bol = ConverterUtil.ConvertDataType<bool>(str);
      Assert.IsTrue(bol);
    }
  }
}
