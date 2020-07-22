using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console002
{
  /// <summary>
  /// WMI 操作
  /// https://www.codeproject.com/Articles/28161/Using-WMI-to-manipulate-services-Install-Uninstall
  /// https://stackoverflow.com/questions/3938588/how-does-one-start-and-stop-services-using-wmi-from-net
  /// https://stackoverflow.com/questions/14479992/how-to-get-return-value-of-the-format-method-of-the-win32-volume-class-using-voi
  /// </summary>
  class C9
  {
    public enum ReturnValue
    {
      Success = 0,
      NotSupported = 1,
      AccessDenied = 2,
      DependentServicesRunning = 3,
      InvalidServiceControl = 4,
      ServiceCannotAcceptControl = 5,
      ServiceNotActive = 6,
      ServiceRequestTimeout = 7,
      UnknownFailure = 8,
      PathNotFound = 9,
      ServiceAlreadyRunning = 10,
      ServiceDatabaseLocked = 11,
      ServiceDependencyDeleted = 12,
      ServiceDependencyFailure = 13,
      ServiceDisabled = 14,
      ServiceLogonFailure = 15,
      ServiceMarkedForDeletion = 16,
      ServiceNoThread = 17,
      StatusCircularDependency = 18,
      StatusDuplicateName = 19,
      StatusInvalidName = 20,
      StatusInvalidParameter = 21,
      StatusInvalidServiceAccount = 22,
      StatusServiceExists = 23,
      ServiceAlreadyPaused = 24,
      ServiceNotFound = 25
    }

    public static void Execute(string[] args)
    {
      if (args.Length == 0)
      {
        Console.WriteLine("please enter the service name.");
        return;
      }
      string service = args[0];
      string operation = args[1];

      GetServiceListByManagementObjectSearcher();

      if (operation.Equals("stop", StringComparison.InvariantCultureIgnoreCase))
      {
        Console.WriteLine("Service [{0}] is stopping...", service);
        StopService(service);
        GetServiceState(service, "Stopped");
      }
      else if (operation.Equals("start", StringComparison.InvariantCultureIgnoreCase))
      {
        Console.WriteLine("Service [{0}] is starting...", service);
        StartService(service);
        GetServiceState(service, "Running");
      }
    }

    private static void GetServiceListByManagementObjectSearcher()
    {
      string connectString = "SELECT * FROM Win32_Service";
      SelectQuery selectQuery = new SelectQuery(connectString);
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);
      ManagementObjectCollection queryCollection = searcher.Get();
      /*foreach (ManagementObject mo in queryCollection)
      {
        //PropertyDataCollection searcherProperties = mo.Properties;
        //foreach (PropertyData sp in searcherProperties)
        //{
        //  Console.WriteLine("Name = {0, -20}, Value = {1, -20}", sp.Name, sp.Value);
        //}
        Console.WriteLine("{0, -20} [{1, -40}]", "Service: ", mo["Name"]);
      }*/
      Console.WriteLine("Service count: [{0}]", queryCollection.Count);
    }

    private static ReturnValue StartService(string svcName)
    {
      string objPath = string.Format("Win32_Service.Name='{0}'", svcName);
      using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
      {
        try
        {
          ManagementBaseObject outParams = service.InvokeMethod("StartService", null, null);
          Console.WriteLine("{0,-35} {1,-40}", "Return Value", outParams["ReturnValue"]);
          return (ReturnValue)Enum.Parse(typeof(ReturnValue), outParams["ReturnValue"].ToString());
        }
        catch (Exception ex)
        {
          Console.WriteLine("Exception: [{0}]", ex);
          if (ex.Message.ToLower().Trim() == "not found" || ex.GetHashCode() == 41149443)
            return ReturnValue.ServiceNotFound;
          else
            throw ex;
        }
      }
    }

    private static ReturnValue StopService(string svcName)
    {
      string objPath = string.Format("Win32_Service.Name='{0}'", svcName);
      using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
      {
        try
        {
          ManagementBaseObject outParams = service.InvokeMethod("StopService", null, null);
          Console.WriteLine("{0,-35} {1,-40}", "Return Value", outParams["ReturnValue"]);
          return (ReturnValue)Enum.Parse(typeof(ReturnValue), outParams["ReturnValue"].ToString());
        }
        catch (Exception ex)
        {
          Console.WriteLine("Exception: [{0}]", ex);
          if (ex.Message.ToLower().Trim() == "not found" || ex.GetHashCode() == 41149443)
            return ReturnValue.ServiceNotFound;
          else
            throw ex;
        }
      }
    }

    public static void GetServiceState(string svcName, string expectedState)
    {
      string _state = string.Empty;
      while (true)
      {
        string objPath = string.Format("Win32_Service.Name='{0}'", svcName);
        using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
        {
          try
          {
            _state = service.Properties["State"].Value.ToString().Trim();
            Console.WriteLine("Service [{0}] status is  [{1}]", svcName, _state);
            if (_state.Equals(expectedState, StringComparison.InvariantCultureIgnoreCase))
            {
              break;
            }
            Thread.Sleep(1000);
          }
          catch (Exception ex)
          {
            throw ex;
          }
        }
      }
      
    }
  }
}
