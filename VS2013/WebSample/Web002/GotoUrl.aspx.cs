using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web002
{
  public partial class GotoUrl : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string _returnUrl = Request["returnUrl"];

      if (string.IsNullOrEmpty(_returnUrl))
      {
        _returnUrl = "~/default.aspx";
      }


      Response.Redirect(_returnUrl);
    }
  }
}