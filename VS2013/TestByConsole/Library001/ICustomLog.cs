using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library001
{
    public interface ICustomLog
    {
      void Log(object msg);
      void Log(Exception ex);
      void Log(object msg, Exception ex);
      void Debug(object msg);
      void Debug(object msg, Exception ex);
      void DebugFormat(string msg, params object[] args);
      void Info(object msg);
      void Info(object msg, Exception ex);
      void InfoFormat(string msg, params object[] args);
      void Warn(object msg);
      void Warn(object msg, Exception ex);
      void WarnFormat(string msg, params object[] args);
      void Error(object msg);
      void Error(object msg, Exception ex);
      void ErrorFormat(string msg, params object[] args);
      void Fatal(object msg);
      void Fatal(object msg, Exception ex);
      void FatalFormat(string msg, params object[] args);

      log4net.ILog RawLog { get; }
    }
}
