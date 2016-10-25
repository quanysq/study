using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTest_Moq;

namespace UnitTest_MoqTest
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void SayHellowTest()
    {
      var mock = new Mock<IUnitTestForMoq>();
      mock.Setup(p => p.SayHellow()).Returns("");

      //
      mock.Object.SayHellow();

      //
      Assert.AreEqual("", mock.Object.SayHellow());
    }

    [TestMethod]
    public void GetCountTest()
    {
      var count = 10;
      var mock = new Mock<IUnitTestForMoq>();
      mock.Setup(p => p.GetCount()).Returns(() => count);

      //
      Assert.AreEqual(10, mock.Object.GetCount());
    }

    [TestMethod]
    public void GetPersonByIdTest()
    {

      //创建MOCK对象
      var mock = new Mock<IPersonProvider>();

      //设置MOCK调用行为
      mock.Setup(foo => foo.GetPersonById("1")).Returns(new Person());

      //MOCK调用方法
      mock.Object.GetPersonById("1");

      Assert.AreNotSame(new Person(), mock.Object.GetPersonById("1"));


      var mock1 = new Mock<IPersonProvider>();

      mock1.Setup(foo => foo.GetPersonById(It.IsAny<string>())).Returns(new Person());
      Assert.AreNotSame(new Person(), mock1.Object.GetPersonById("aaa"));
    }

    [TestMethod]
    public void RemovePersonTest()
    {

      var mock = new Mock<IPersonProvider>();

      mock
      .Setup(foo => foo.RemovePerson(It.Is<string>(s => s == "1" || s == "2")))
      .Returns(true);

      Assert.AreEqual(true, mock.Object.RemovePerson("1"));
    }
  }
}
