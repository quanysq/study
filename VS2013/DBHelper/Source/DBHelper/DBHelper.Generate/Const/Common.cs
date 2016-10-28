using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Const
{
  public static class Common
  {
    public static readonly string LocalConnection = ConfigurationManager.AppSettings["LocalConnection"];
  }
}
