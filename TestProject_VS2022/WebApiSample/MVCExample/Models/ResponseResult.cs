using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class ResponseResult
    {
        public int code { get; set; }
        public object data { get; set; }
        public string msg { get; set; }
        public bool success { get; set; }
    }

    public class AdminUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}