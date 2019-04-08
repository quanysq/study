using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web004.Models
{
  public enum ExecuteType
  {
    Cmd,
    Others
  }

  public enum MonitorType
  {
    Null
  }

  public enum MonitorOperation
  {
    Null
  }

  public enum NodeExecuteType
  {
    Start,
    Stop,
    Restar
  }

  [XmlRoot("configuration")]
  public class NodeMode
  {
    public NodeInfo NodeInfo { get; set; }

    [XmlElement("FileName")]
    public List<string> FileList { get; set; }

    public Executer Executer { get; set; }
    public List<Monitor> Monitors { get; set; }
  }

  public class Executer
  {
    public ExecuteType ExecuteType { get; set; }
    public List<TaskParam> Parameters { get; set; }
  }

  public class TaskParam
  {
    [XmlElement("param_name")]
    public string ParamName { get; set; }

    [XmlElement("param_value")]
    public string ParamValue { get; set; }
  }

  public class Monitor
  {
    public MonitorType MonitorType { get; set; }
    public MonitorOperation Operation { get; set; }
    public string Parameters { get; set; }
  }

}