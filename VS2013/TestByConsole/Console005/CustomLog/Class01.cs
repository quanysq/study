using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library001;

namespace Console005.CustomLog
{
  class C01
  {
    public static void Execute()
    {
      CustomLogger.DEFAULT.Debug("debug aaaa");
      CustomLogger.DEFAULT.DebugFormat("debugformat aaaa {0}", "test");
      CustomLogger.DEFAULT.Info("info aaaa");
      CustomLogger.DEFAULT.InfoFormat("infoformat aaaa {0}", "test");
      CustomLogger.DEFAULT.Warn("warn aaaa");
      CustomLogger.DEFAULT.WarnFormat("warnformat aaaa {0}", "test");
      CustomLogger.DEFAULT.Error("error aaaa");
      CustomLogger.DEFAULT.ErrorFormat("errorformat aaaa {0}", "test");
      Console.WriteLine("OK!");
    }
  }
}
