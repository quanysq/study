using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web001
{
  public partial class WebForm6 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      try
      {
        string s = "{\"state\": \"Success\"}";
        
        Response.Write(s);
        Response.Flush();
        Response.End();
      }
      catch (System.Threading.ThreadAbortException te) { }
      catch (Exception se)
      {
        var err = "Error occurred when testing whether TUS is able to connect";
      }
    }
  }
}