using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web001
{
  public partial class ClientCertTest : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      HttpClientCertificate hcc = Request.ClientCertificate;      //返回浏览器证书
      byte[] certbytes = hcc.Certificate;                         //二进制流读取整个证书
      X509Certificate2 cert = new X509Certificate2(certbytes);    //表示证书
      Response.Write(cert.Subject);
    }
  }
}