using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace Console016
{
  /// <summary>
  /// IIS and ApplicationPool
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      //C1.Execute();
      C2.SetApplicationPoolIdleTimeut("EFSample");
    }
  }
}
