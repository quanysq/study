using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormSample01.WizardSample.WizardClass
{
  public class ConfigOperator
  {
    private static volatile ConfigOperator _instance = null;
    private static object lockObject = new object();
    private ConfigOperator() { }
    public static ConfigOperator Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (lockObject)
          {
            if (_instance == null)
            {
              _instance = new ConfigOperator();
            }
          }
        }
        return _instance;
      }
    }

    public ConfigEntity ConfigEntity { get; set; }

    public void SaveConfig(string configPath)
    {
      XmlUtil.Serialize<ConfigEntity>(ConfigEntity, configPath);
    }
  }
}
