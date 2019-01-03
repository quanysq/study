using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web004.Common;

namespace Web004.Controllers
{
    public class BasicAuthController : ApiController
    {
      [HttpGet]
      [BasicAuthorize]
      public string HelloWorld()
      {
        return "Hello basic authentication";
      }
    }
}
