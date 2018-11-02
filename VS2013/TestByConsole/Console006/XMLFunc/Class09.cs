using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using System.IO;
using System.Xml;

namespace Console006.XMLFunc
{
  /// <summary>
  /// Linq to Xml
  /// XmlElement2XElement
  /// XElement2XmlElement
  /// Compare 2 XElement
  /// </summary>
  class C9
  {
    public static void Execute()
    {
      // QueryXml();
      // AddElementUsingXElementObj();
      AddElementUsingString("Configuration");
      // AddElementUsingStringMultiElement("/Configuration/LDAP/ValueDict");
      // AddAttribute2Element("//Configuration/mytest", "Type", "member");
      // DeleteAttributeFromElement("//Configuration/mytest", "Type");
      // DeleteElement("//Configuration/mytest");
      // UpdateAttribute("//Configuration/LDAP", "Type", "ABC");
      // UpdateElement("//Configuration/mytest", @"<mname type=""user"">jacky</mname>", true);
      // ReplaceValue("5.1.0", "5.2.0");
      // XmlElement2XElement();
      // XElement2XmlElement();
    }

    // test successful
    private static void QueryXml()
    {
      //string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      string xmlPath = @"D:\Work\TestData\Conf\xml\xml_same_element.xml";
      XDocument xml = XDocument.Load(xmlPath);

      var elementList = (from x in xml.Element("Configuration").Elements() select x).ToList<XElement>();
      foreach (var element in elementList)
      {
        //Console.WriteLine("[{0}]'s node count: [{1}]", element.Name, element.Nodes().Count());
        string elementContent = element.ToString()
                                       .Trim()
                                       .Replace(" ", "")
                                       .Replace("\n", "")
                                       .Replace("\r", "")
                                       .Replace("\r\n", "");
        Console.WriteLine("[{0}] value: [{1}]", element.Name, elementContent);
        Console.WriteLine("[{0}] hashcode: [{1}]", element.Name, elementContent.GetHashCode());
        Console.WriteLine("[{0}] is empty: [{0}]", string.IsNullOrWhiteSpace(element.Value));
      }
    }

    private static List<string> GetUS51PatchsetList()
    {
      List<string> US51List = new List<string>();
      string filepath = @"D:\VS2013\TestByConsole\Console028\XML\US51Patchset.txt";
      using (StreamReader sr = new StreamReader(filepath))
      {
        while (sr.Peek() >= 0)
        {
          US51List.Add(sr.ReadLine());
        }
      }
      return US51List;
    }

    // test successful
    private static void AddElementUsingXElementObj()
    {
      //List<string> US51List = new List<string>() 
      //{ 
      //  "US51_DLLS.zip", 
      //  "US51_Analyze_NBIDLLS.zip", 
      //  "US51_For_UserConsole.zip", 
      //  "US51_PatchSetReadme_UserConsole.zip", 
      //  "US51_PatchSetVersion_UserConsole.zip", 
      //  "US51_PatchSetReadme_DataPlatform.zip", 
      //  "US51_PatchSetVersion_DataPlatform.zip", 
      //  "US51_SyncForce.zip" 
      //};
      List<string> US51List = GetUS51PatchsetList();
      US51List = US51List.Select(u => u.Trim()).ToList();
      US51List.ForEach(u => Console.WriteLine(u + "_b"));
      Console.WriteLine(US51List.Count);

      string xmlpath = @"D:\VS2013\TestByConsole\Console028\XML\UpdaterSchedule_US51.conf";
      XElement xml = XElement.Load(xmlpath);

      List<XElement> xmlUS51 = (from x in xml.Descendants("File_Info") where US51List.Contains(x.Element("FileName").Value) select x).ToList<XElement>();

      if (xmlUS51.Count > 0)
      {
        foreach (XElement xe in xmlUS51)
        {
          Console.WriteLine("Inserting to [{0}]", xe.Element("FileName").Value);
          XElement xxe = xe.Element("RequiredVersions");

          XElement s = xxe.Elements().FirstOrDefault(x => x.Value == "abc");
          if (s == null) xxe.Add(new XElement("string", "abc"));
        }

        xml.Save(xmlpath);
        Console.WriteLine("Edit xml successful by \"Linq to Xml\"!");
      }
      else
      {
        Console.WriteLine("Not found node.");
      }
    }

    // test successful
    private static void AddElementUsingString(string elementName)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var elementList = xml.Descendants(elementName).ToList<XElement>();
      if (elementList == null || elementList.Count == 0)
      {
        Console.WriteLine("No found node: [{0}]", elementName);
        return;
      }
      var element = elementList[0];
      //注意：字符串只能有一个根元素
      string newElementstr = @"
<mytest>
  <mname type=""user"">jacky</mname>
  <mname type=""user"">lubin</mname>
</mytest>
";
      XElement newElement = XElement.Parse(newElementstr);
      bool isNewElementExist = IsXElementExist(element, newElement);
      if (!isNewElementExist)
      {
        element.Add(newElement);
        xml.Save(xmlPath);
        Console.WriteLine("Add element using string successful!");
      }
      else
      {
        Console.WriteLine("[{0}] already exists!", newElement.Name);
      }
    }

    // test successful
    private static void AddElementUsingStringMultiElement(string elementPath)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var element = xml.XPathSelectElement(elementPath);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", elementPath);
        return;
      }

      for (int i = 0; i < 2; i++)
      {
        string newElementstr;
        if (i == 0)
        {
          newElementstr = @"<key><string>URL</string></key>";
        }
        else
        {
          newElementstr = @"<value><string>10.98.101.15:389</string></value>";
        }
        XElement newElement = XElement.Parse(newElementstr);
        element.Add(newElement);
      }

      xml.Save(xmlPath);
      Console.WriteLine("Add mutli-element using string successful!");
    }

    // test successful
    private static void AddAttribute2Element(string elementPath, string attributeName, string attributeValue)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var element = xml.XPathSelectElement(elementPath);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", element);
        return;
      }
      var attribute = new XAttribute(attributeName, attributeValue);
      element.Add(attribute);
      xml.Save(xmlPath);
      Console.WriteLine("Add attribute successful!");
    }

    // test successful
    private static void DeleteAttributeFromElement(string elementPath, string attributeName)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var element = xml.XPathSelectElement(elementPath);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", element);
        return;
      }
      var attribute = element.Attribute(attributeName);
      if (attribute == null)
      {
        Console.WriteLine("No found attribute: [{0}]", attributeName);
        return;
      }
      attribute.Remove();
      xml.Save(xmlPath);
      Console.WriteLine("Delete attribute successful!");
    }

    // test successful
    private static void DeleteElement(string elementPath)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var element = xml.XPathSelectElement(elementPath);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", element);
        return;
      }
      element.Remove();
      xml.Save(xmlPath);
      Console.WriteLine("Delete element successful!");
    }

    // test successful
    private static void UpdateAttribute(string elementPath, string attributeName, string attributeValue)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      // first way
      /*string elementpathWithAttribute = string.Format("{0}[@{1}]", elementPath, attributeName);
      var element = xml.XPathSelectElement(elementpathWithAttribute);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", elementpathWithAttribute);
        return;
      }
      element.SetAttributeValue(attributeName, attributeValue);*/

      // second way
      var elementList = xml.XPathSelectElements(elementPath);
      foreach (var element in elementList)
      {
        var xAttribute = element.Attribute(attributeName);
        if (xAttribute == null)
        {
          continue;
        }
        xAttribute.SetValue(attributeValue);
      }
 
      xml.Save(xmlPath);
      Console.WriteLine("Update attribute successful!");
    }

    // test successful
    private static void UpdateElement(string elementPath, string elementValue, bool elementFormat)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);

      var element = xml.XPathSelectElement(elementPath);
      if (element == null)
      {
        Console.WriteLine("No found node: [{0}]", elementPath);
        return;
      }
      if (elementFormat)
      {
        element.SetValue("");
        var newElement = XElement.Parse(elementValue);
        element.Add(newElement);
      }
      else
      {
        element.SetValue(elementValue);
      }
      
      xml.Save(xmlPath);
      Console.WriteLine("Update element successful!");
    }

    // test successful
    private static void ReplaceValue(string oldValue, string newValue)
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XmlDocument xml = new XmlDocument(); 
      xml.Load(xmlPath);
      var xmlNode = xml.DocumentElement;
      /*string rootName = xml.DocumentElement.Name;
      XmlNode xmlNode = xml.SelectSingleNode(rootName);*/
      string innerxml = xmlNode.InnerXml;
      innerxml = innerxml.Replace(oldValue, newValue);
      xmlNode.InnerXml = innerxml;
      xml.Save(xmlPath);
      Console.WriteLine("Replace [{0}] to [{1}] successful!", oldValue, newValue);
    }

    // test successful
    private static void XmlElement2XElement()
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XmlDocument xml = new XmlDocument();
      xml.Load(xmlPath);
      var xmlElement = xml.DocumentElement.SelectSingleNode("/Configuration/LDAP") as XmlElement;
      var xElem = XElement.Load(xmlElement.CreateNavigator().ReadSubtree());
      Console.WriteLine(xElem.Value.Equals(xmlElement.InnerText, StringComparison.OrdinalIgnoreCase));
    }

    // test successful
    private static void XElement2XmlElement()
    {
      string xmlPath = @"D:\Work\TestData\Conf\Conf\Norm.Configuration.config";
      XDocument xml = XDocument.Load(xmlPath);
      var xElem = xml.Root;
      var doc = new XmlDocument();
      doc.Load(xElem.CreateReader());   // xElem.CreateReader() need to be dispose
      XmlElement xmlElement = doc.DocumentElement;
      Console.WriteLine(xElem.Value.Equals(xmlElement.InnerText, StringComparison.OrdinalIgnoreCase));
    }

    // test successful
    private static bool IsXElementExist(XElement parentElement, XElement newElement)
    {
      var elements = parentElement.Elements(newElement.Name);
      if (elements.Count() == 0) return false;

      bool result = false;
      foreach (var element in elements)
      {
        if (element.Elements().Count() != newElement.Elements().Count())
        {
          continue;
        }

        if (element.Attributes().Count() != newElement.Attributes().Count())
        {
          continue;
        }

        result = CompareXElement(element, newElement);
        if (result) return result;
      }
      return result;
    }

    // test successful
    private static bool CompareXElement(XElement xElement1, XElement xElement2)
    {
      var xElem1 = Normalize(xElement1);
      var xElem2 = Normalize(xElement2);

      var result = XElement.DeepEquals(xElem1, xElem2);
      return result;
    }

    // test successful
    private static XElement Normalize(XElement element)
    {
      if (element.HasElements)
      {
        var attributes = element.Attributes().OrderBy(a => a.Name.ToString());
        return new XElement(element.Name, attributes, element.Elements().OrderBy(a => a.Name.ToString())
                                                                .Select(e => Normalize(e)));
      }

      if (element.IsEmpty || string.IsNullOrEmpty(element.Value))
      {
        return new XElement(element.Name, element.Attributes()
            .OrderBy(a => a.Name.ToString()));
      }

      return new XElement(element.Name, element.Attributes().OrderBy(a => a.Name.ToString()), element.Value);
    }

    /*
     * 寻找 Element 的方法：
     * 1. Elements: 查询 root 直接所属的一级 chirden 元素，写法繁琐，需要从根节点元素一直往下开始写：如root.Elements("baz").Elements("bar")，
     * 2. Descendants: 查询root节点下的所有的指定名字的节点元素，写法比较方便，不需要一级级搜索，直接root.Descendants("name")就可以了
     * 3. XPathSelectElement: 直接按路径找到 element，需要引用 System.Xml.XPath
     * 
     * 比较两个 XElement 是否相同主要是使用 DeepEquals 方法，但这个方法也有局限性：
     * 1. 如果两个 XElement 结构、顺序、值、结束方式都一致，这个方法返回结果是预期的
     * 2. 如果两个 XElement 结构、值、结束方式一致，但顺序不一致，那它会返回 False
     * 3. 如果两个 XElement 结构、值、顺序一致，但结束方式不一致，它也会返回 False
     * 结束方式就是指自结束比如 <book /> 或者 匹配结束比如 <book></book>
     * 总结：所以比较两个 XElement 是否相同，首先将两个 XElement 结构、顺序、值、结束方式调成一致再用 DeepEquals 方法
     */
  }
}
