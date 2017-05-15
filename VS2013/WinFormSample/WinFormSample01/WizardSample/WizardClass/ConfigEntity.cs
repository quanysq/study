using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormSample01.WizardSample.WizardClass
{
  [XmlRoot("configuration")]
  public class ConfigEntity
  {

    public BaseInfo BaseInfo { get; set; }

    public OSSetting OSSetting { get; set; }
    
    public DiskSetting DiskSetting { get; set; }
  }

  public class BaseInfo
  {
    public string TemplateName { get; set; }
    public string TemplateType { get; set; }
    public string TemplateDesc { get; set; }
  }

  public class OSSetting
  {
    public int OSType { get; set; }
    public string SoftSourceName { get; set; }
  }

  public class DiskSetting
  {
    [XmlElement("DiskInfo")]
    public List<DiskInfo> DiskInfoList { get; set; }
  }

  public class DiskInfo
  {
    public int SerialNumber { get; set; }

    [XmlElement("Parition")]
    public List<Parition> ParitionList { get; set; }
  }

  public class Parition
  {
    public int SerialNumber { get; set; }
    public string FileSystem { get; set; }
    public string Driver { get; set; }
    public string Capacity { get; set; }
    public int Unit { get; set; }
    public bool IsUseFreeCapacity { get; set; }
  }
}
