using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web004.Models
{
  public class RestfulResult
  {
    public bool Status { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
  }
}