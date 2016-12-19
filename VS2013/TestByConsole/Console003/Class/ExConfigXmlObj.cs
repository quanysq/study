using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console003
{
  [XmlRoot("configuration")]
  class ExConfig
  {
    //public ExConfig() { }

    [XmlElement("Connection")]
    public Connection Connection { get; set; }
  }

  class Connection
  {
    [XmlAttribute("Type")]
    public string ConnectionType { get; set; }

    [XmlElement("Property")]
    public List<PropertyDic> PropertyList { get; set; }
  }

  class PropertyDic
  {
    [XmlAttribute("Name")]
    public string PropertyName { get; set; }
    [XmlAttribute("Value")]
    public string PropertyValue { get; set; }

    [XmlText]
    public string PropertyVal { get; set; }
  }
}
