using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace Console006.XMLFunc
{
  /// <summary>
  /// Linq to Xml
  /// </summary>
  class C9
  {
    public static void Execute()
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
  }
}
