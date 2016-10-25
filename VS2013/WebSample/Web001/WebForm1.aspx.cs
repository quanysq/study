using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web001
{
  public partial class WebForm1 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnDownLoadCatalog_ServerClick(object sender, EventArgs e)
    {
      Response.Redirect(@"http://tus50.bdna.com/Components\SQL2014_SharedManagementObjects_x64_ENU.msi");
    }
  }
}