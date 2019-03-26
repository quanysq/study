using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library001
{
  public static class CustomLogger
  {
    public static ICustomLog DEFAULT = new Logger("DEFAULT_LOG");
    public static ICustomLog WEB = new Logger("WEB_LOG");
    public static ICustomLog UPDATER = new Logger("UPDATER_LOG");
    public static ICustomLog SETUP = new Logger("SETUP_LOG");
    public static void InitHomePath(string homePath)
    {
      DEFAULT = new Logger(homePath, "DEFAULT_LOG");
      WEB = new Logger(homePath, "WEB_LOG");
      UPDATER = new Logger(homePath, "UPDATER_LOG");
      SETUP = new Logger(homePath, "SETUP_LOG");
    }
  }
}
