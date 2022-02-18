using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormSample05
{
  [XmlRoot("configuration")]
  public class ConfigModel
  {
    public ConfigModel() { }

    public int DataType { get; set; }
    public string DataTypeNote { get; set; }

    public GPPool GPPool { get; set; }
  }

  #region GPPool
  public class GPPool
  {
    [XmlElement("GPInfo")]
    public List<GPInfo> GuPiaoPool { get; set; }
  }

  public class GPInfo
  {
    /// <summary>
    /// 股票名称
    /// </summary>
    [XmlAttribute("Name")]
    public string GPName { get; set; }
    /// <summary>
    /// 股票代码
    /// </summary>
    [XmlAttribute("Code")]
    public string GPCode { get; set; }

    /// <summary>
    /// 股票全称：股票名称+" "+股票代码
    /// </summary>
    [XmlIgnore]
    public string GPFullName
    {
      get
      {
        return string.Format("{0} {1}", GPName, GPCode);
      }
    }
  }
  #endregion
  
}
