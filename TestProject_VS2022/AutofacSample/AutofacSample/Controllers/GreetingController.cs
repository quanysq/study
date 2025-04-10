using AutofacSample.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutofacSample.Controllers
{
    [RoutePrefix("api/Greeting")]
    public class GreetingController : ApiController
    {
        private readonly IGreeter _greeter;

        /// <summary>
        /// 通过构造方法注入 IGreeter
        /// </summary>
        /// <param name="greeter"></param>
        public GreetingController(IGreeter greeter)
        {
            _greeter = greeter;
        }

        [HttpGet]
        [Route("greet")]
        public IHttpActionResult Greet(string name)
        {
            var message = _greeter.Greet(name);
            return Ok(message);
        }
    }
}
