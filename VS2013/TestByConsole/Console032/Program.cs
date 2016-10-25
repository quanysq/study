using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console032
{
  class Program
  {
    static void Main(string[] args)
    {
      is64bit(64);
      is64bit(32);

      OsVer();

      Console.ReadKey();
    }

    static void is64bit(int bitnum)
    {
      Dictionary<string, string> Values = new Dictionary<string, string>();
      Values.Add("ASPNET45", "1");
      Values.Add("WindowsAuthentication", "1");
      Values.Add("ISAPIExtensions", "1");
      Values.Add("ISAPIFilter", "1");
      RegistryView rv = RegistryView.Registry32;
      if (bitnum == 64) rv = RegistryView.Registry64;
      bool isbit = IsRegistryValue(@"SOFTWARE\Microsoft\InetStp\Components", Values, rv);
      if (bitnum == 64 && isbit) Console.WriteLine("is 64 bit");
      if (bitnum == 32 && isbit) Console.WriteLine("is 32 bit");
    }

    public static bool IsRegistryValue(string subKey, Dictionary<string, string> dictValueData, Microsoft.Win32.RegistryView sysbit)
    {
      bool isReady = true;
      if (!IsRegistrySubKey(subKey, sysbit))
      {
        return false;
      }
      else
      {
        using (RegistryKey mainKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, sysbit))
        {
          using (RegistryKey key = mainKey.OpenSubKey(subKey))
          {
            foreach (KeyValuePair<string, string> value in dictValueData)
            {
              IList<string> valueNameList = key.GetValueNames();
              if (!valueNameList.Contains(value.Key))
              {
                isReady = false;
                break;
              }
              foreach (string valueName in valueNameList)
              {
                if (valueName == value.Key)
                {
                  if (key.GetValue(valueName).ToString() != value.Value)
                  {
                    isReady = false;
                    break;
                  }
                  break;
                }
              }
              if (!isReady) break;
            }
          }
        }
        return isReady;
      }
    }

    public static bool IsRegistrySubKey(string subKey, Microsoft.Win32.RegistryView sysbit)
    {
      bool isReady = true;
      using (RegistryKey mainKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, sysbit))
      {
        using (RegistryKey key = mainKey.OpenSubKey(subKey))
        {
          isReady = key != null;
        }
      }
      return isReady;
    }

    public static void OsVer()
    {
      //获取系统信息
      System.OperatingSystem osInfo = System.Environment.OSVersion;
      //获取操作系统ID
      System.PlatformID platformID = osInfo.Platform;
      Console.WriteLine(platformID.ToString());
      //获取主版本号
      int versionMajor = osInfo.Version.Major;
      Console.WriteLine(versionMajor.ToString());

      //获取副版本号
      int versionMinor = osInfo.Version.Minor;
      Console.WriteLine(versionMinor.ToString());

      Console.WriteLine(osInfo.VersionString);

      RegistryKey rk;
      rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
      string s = rk.GetValue("ProductName").ToString();
      Console.WriteLine(s);
      if (s.IndexOf("2012") > -1) Console.WriteLine("is windows 2012");
      rk.Close();
    }
  }
}
