using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web004.Models;
using Newtonsoft.Json;

namespace Web004.Controllers
{
  [RoutePrefix("rest/openapi/client/v1")]
  public class EventCenterClientController : ApiController
  {
    [HttpPost]
    [Route("ReceiveFiles")]
    public HttpResponseMessage ReceiveFiles(string configFile)
    {
      // 1. Convert config file to NodeFilesMode object
      // ...

      // 2. Receive files code
      // ...

      // 3. return json result
      RestfulResult result = new RestfulResult();
      result.Status = true;
      result.Message = "";
      result.Data = "";

      string jsonResult = JsonConvert.SerializeObject(result);
      return new HttpResponseMessage { Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json") };
    }

    [HttpPost]
    [Route("ExecuteNode")]
    public HttpResponseMessage ExecuteNode(string configFile, string OperateType)
    {
      // 1. Convert config file to NodeMode object
      // ...

      // 2. Execute Node
      // ...

      // 3. return json result
      RestfulResult result = new RestfulResult();
      result.Status = true;
      result.Message = "";
      result.Data = "";

      string jsonResult = JsonConvert.SerializeObject(result);
      return new HttpResponseMessage { Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json") };
    }

    [Route("MyTest")]
    [HttpGet]
    public HttpResponseMessage MyTest()
    {
      //NodeFilesMode NodeFilesMode

      // 1. Receive files code
      // ...
      // 2. return json result
      RestfulResult result = new RestfulResult();
      result.Status = true;
      result.Message = "";
      result.Data = "1";

      string jsonResult = JsonConvert.SerializeObject(result);
      return new HttpResponseMessage { Content = new StringContent(jsonResult, System.Text.Encoding.UTF8, "application/json") };
    }
  }
}
