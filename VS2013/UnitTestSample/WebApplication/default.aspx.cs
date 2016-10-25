using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Class;

namespace WebApplication
{
  public partial class _default : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //string s = Common.GetFiltPath("~/File/01.txt");
      //string s = Common.GetFiltPath(new HttpContextWrapper(HttpContext.Current), "~/File/01.txt");
      string s = Common.ReadTxt(@"D:\VS2013\UnitTestSample\WebApplication\File\01.txt");
    }
  }
}