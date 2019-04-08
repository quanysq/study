using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Web004.Models
{
  public enum DownLoadType
  {
    Stream,
    Download
  }

  [XmlRoot("configuration")]
  public class NodeFilesMode
  {
    public NodeInfo NodeInfo { get; set; }
    public List<FileInfo> FileList { get; set; }
    public List<DiskFile> DiskFileList { get; set; }
  }

  public class NodeInfo
  {
    public int FlowID { get; set; }
    public string FlowName { get; set; }
    public int NodeID { get; set; }
    public string NodeName { get; set; }
  }

  public class FileInfo
  {
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string FileBody { get; set; }
    public DownLoadType DownLoadType { get; set; }
  }

  public class DiskFile
  {
    public string FilePath { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}