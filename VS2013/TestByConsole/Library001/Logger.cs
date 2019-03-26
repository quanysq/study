using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library001
{
  class Logger: ICustomLog
  {
    private log4net.ILog log4 = null;
    string _logconfig = "";
    public log4net.ILog RawLog
    {
      get { return log4; }
    }

    public Logger(string logname)
    {
      if (AppDomain.CurrentDomain.SetupInformation.PrivateBinPath != null)
        _logconfig = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "log.config");
      else
        _logconfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.config");
      if (!File.Exists(_logconfig))
      {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        FileInfo dllFile = new FileInfo(myAssembly.Location);
        string path = dllFile.Directory.FullName;
        _logconfig = Path.Combine(path, "log.config");
      }
      log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(_logconfig));
      log4 = GetLogger(logname);
    }
    public Logger(string homePath, string logname)
    {

      //string logconfig = AppDomain.CurrentDomain.BaseDirectory + @"\log.config";
      string logconfig = "";
      logconfig = Path.Combine(homePath, "log.config");
      log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(logconfig));
      log4 = GetLogger(logname);
    }

    private ILog GetLogger(string logname)
    {
      ILog log = LogManager.Exists(logname);
      if (log == null)
        throw new NotSupportedException(string.Format("Not existing logname. [{0}],home=[{1}]", logname, _logconfig));
      else
        return log;
    }

    #region "log interface."

    public void Log(object message)
    {
      log4.Error(message);
    }

    public void Log(Exception e)
    {
      log4.Error(e);
    }

    public void Log(object message, Exception e)
    {
      log4.Error(message, e);
    }

    public void Debug(object msg)
    {
      log4.Debug(msg);
    }
    public void Debug(object msg, Exception ex)
    {
      log4.Debug(msg, ex);
    }

    public void DebugFormat(string msg, params object[] args)
    {
      log4.Debug(string.Format(msg, args));
    }

    public void Info(object msg)
    {
      log4.Info(msg);
    }
    public void Info(object msg, Exception ex)
    {
      log4.Info(msg, ex);
    }

    public void InfoFormat(string msg, params object[] args)
    {
      log4.Info(string.Format(msg, args));
    }

    public void Warn(object msg)
    {
      log4.Warn(msg);
    }
    public void Warn(object msg, Exception ex)
    {
      log4.Warn(msg, ex);
    }

    public void WarnFormat(string msg, params object[] args)
    {
      log4.Warn(string.Format(msg, args));
    }

    public void Error(object msg)
    {
      log4.Error(msg);
    }
    public void Error(object msg, Exception ex)
    {
      log4.Error(msg, ex);
    }

    public void ErrorFormat(string msg, params object[] args)
    {
      log4.Error(string.Format(msg, args));
    }

    public void Fatal(object msg)
    {
      log4.Fatal(msg);
    }
    public void Fatal(object msg, Exception ex)
    {
      log4.Fatal(msg, ex);
    }

    public void FatalFormat(string msg, params object[] args)
    {
      log4.Fatal(string.Format(msg, args));
    }

    #endregion
  }
}
