using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console003
{
  [XmlRoot("Xml")]
  public class XmlActionModel
  {
    public XmlActionModel() { }

    [XmlAttribute("xmlfile")]
    public string XmlFilePath { get; set; }

    [XmlElement("addelement")]
    public List<ElementInfo> ElementAddList { get; set; }

    public bool HasAddElement
    {
      get
      {
        if (ElementAddList == null || ElementAddList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("addattribute")]
    public List<AttributeInfo> AttributeAddList { get; set; }

    public bool HasAddAttribute
    {
      get
      {
        if (AttributeAddList == null || AttributeAddList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("deleteelement")]
    public List<ElementInfo> ElementDeleteList { get; set; }

    public bool HasDeleteElement
    {
      get
      {
        if (ElementDeleteList == null || ElementDeleteList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("deleteattribute")]
    public List<AttributeInfo> AttributeDeleteList { get; set; }

    public bool HasDeleteAttribute
    {
      get
      {
        if (AttributeDeleteList == null || AttributeDeleteList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("updateelement")]
    public List<UpdateElementInfo> ElementUpdateList { get; set; }

    public bool HasUpdateElement
    {
      get
      {
        if (ElementUpdateList == null || ElementUpdateList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("updateattribute")]
    public List<AttributeInfo> AttributeUpdateList { get; set; }

    public bool HasUpdateAttribute
    {
      get
      {
        if (ElementUpdateList == null || ElementUpdateList.Count == 0) return false;
        return true;
      }
    }

    [XmlElement("replacevalue")]
    public List<ReplaceValueInfo> ReplaceValueList { get; set; }

    public bool HasReplaceValue
    {
      get
      {
        if (ReplaceValueList == null || ReplaceValueList.Count == 0) return false;
        return true;
      }
    }
  }

  public class ElementInfo
  {
    [XmlAttribute("xmlnode")]
    public string XmlNode { get; set; }

    [XmlElement("element")]
    public List<string> ElementList { get; set; }
  }

  public class AttributeInfo
  {
    [XmlAttribute("xmlnode")]
    public string XmlNode { get; set; }

    [XmlElement("attribute")]
    public List<AttributeDetail> AttributeList { get; set; }
  }

  public class AttributeDetail
  {
    [XmlAttribute("name")]
    public string AttributeName { get; set; }

    [XmlAttribute("value")]
    public string AttributeValue { get; set; }
  }

  public class UpdateElementInfo
  {
    [XmlAttribute("xmlnode")]
    public string XmlNode { get; set; }

    [XmlAttribute("contentformat")]
    public ContentFormat ContentFormat { get; set; }

    [XmlAttribute("append")]
    public bool IsAppend { get; set; }

    [XmlElement("content")]
    public List<string> ElementContentList { get; set; }
  }
  
  /*public class UpdateElementContentInfo
  {
    [XmlAttribute("xmlformat")]
    public bool XmlFormat { get; set; }

    [XmlText]
    public string ElementContent { get; set; }
  }*/

  public class ReplaceValueInfo
  {
    [XmlAttribute("oldvalue")]
    public string OldValue { get; set; }

    [XmlAttribute("newvalue")]
    public string NewValue { get; set; }
  }

  public enum ContentFormat
  {
    Xml,
    Text
  }
}
