using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Class;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.IO;
using System.Web.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace WebApplication.Class.Tests
{
  [TestClass()]
  public class UnitTest1
  {
    [TestMethod()]
    public void ReadTxtTest()
    {
      //throw new NotImplementedException();


      //var mockcontext = new Mock<HttpContextBase>();
      //var mockrequest = new Mock<HttpRequestBase>();
      //mockcontext.Setup(c => c.Request).Returns(mockrequest.Object);

      //var mockcontext = new Mock<HttpContextBase>() { DefaultValue = DefaultValue.Mock };

      //TextWriter tw = new StringWriter();
      //HttpWorkerRequest wr = new SimpleWorkerRequest("http://localhost:33123/", @"D:\VS2013\UnitTestSample\WebApplication", "default.aspx", "", tw);
      //HttpContext.Current = new HttpContext(wr);

      //HttpRequest httpRequest = new HttpRequest("", "http://localhost:33123/", "");
      //StringWriter stringWriter = new StringWriter();
      //HttpResponse httpResponse = new HttpResponse(stringWriter);
      //HttpContext httpContextMock = new HttpContext(httpRequest, httpResponse);

      //HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost:33123/default.aspx", ""),new HttpResponse(new StringWriter(new StringBuilder())));
      HttpContext.Current = new HttpContext(new HttpRequest(null, "http://127.0.0.1:8090/UnitTestLocal.aspx", null),new HttpResponse(null));

      var s1 = @"D:\VS2013\UnitTestSample\WebApplication\File\01.txt";
      
      var s2 = WebApplication.Class.Common.GetFiltPath(HttpContext.Current, "~/App_Data/SystemConfig.config"); 
      //var s2 = WebApplication.Class.Common.GetFiltPath("~/File/01.txt");

      Assert.AreEqual(s1, s2);

    }

    [TestMethod]
    [HostType("ASP.NET")]
    [AspNetDevelopmentServerHost(@"D:\VS2013\UnitTestSample\WebApplication", "/")]
    [UrlToTest("http://localhost:33123/default.aspx")]
    public void GetFiltPathTest()
    {
      var s2 = WebApplication.Class.Common.GetFiltPath("~/File/01.txt");

      Assert.AreEqual("1", "1");
    }

    private HttpContextBase CreateHttpContext()
    {
      var context = new Mock<HttpContextBase>();
      var request = new Mock<HttpRequestBase>();
      var response = new Mock<HttpResponseBase>();
      var session = new Mock<HttpSessionStateBase>();
      var server = new Mock<HttpServerUtilityBase>();
      response
          .Setup(rsp => rsp.ApplyAppPathModifier(Moq.It.IsAny<string>()))
          .Returns((string s) => s);

      context.Setup(ctx => ctx.Request).Returns(request.Object);
      context.Setup(ctx => ctx.Response).Returns(response.Object);
      context.Setup(ctx => ctx.Session).Returns(session.Object);
      context.Setup(ctx => ctx.Server).Returns(server.Object);

      return context.Object;
    }

  }
}
