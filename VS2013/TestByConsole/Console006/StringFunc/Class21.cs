using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Console006.StringFunc
{
  /// <summary>
  /// 正则表达式修改字符串中的密码
  /// </summary>
  public class C21
  {
    public static void Execute()
    {
      //OS模板数据
      string jsonData = "{\"esights\":[\"192.168.10.72\"],\"data\":{\"templateName\":\"OSExample01\",\"templateType\":\"OS\",\"templateDesc\":\"OSExample01\",\"templateProp\":{\"osType\":\"6\",\"softSourceName\":\"6\",\"admPassword\":\"Abc12345~\",\"confirmPassword\":\"Abc12345~\",\"hostOwnerName\":\"\",\"hostOwnerCompany\":\"\",\"cdKey\":\"----\",\"osDeployPolicy\":\"1\",\"disk\":[{\"serialNumber\":1,\"paritions\":[{\"serialNumber\":1,\"fileSystem\":\"0\",\"driver\":\"C:\",\"capacity\":\"100\",\"unit\":\"1\",\"isUseFreeCapacity\":false},{\"serialNumber\":2,\"fileSystem\":\"0\",\"driver\":\"D:\",\"capacity\":\"\",\"unit\":\"1\",\"isUseFreeCapacity\":false}]}]}}}";
      //软件源数据
      //string jsonData = "{\"esights\":[\"192.168.10.72\"],\"data\":{\"softwareName\":\"SoftwareTaskExample\",\"softwareDescription\":\"Software Task Example\",\"softwareType\":\"Windows\",\"softwareVersion\":\"Windows Server 2008 R2 x64\",\"softwareLanguage\":\"Chinese\",\"softwareEdition\":\"Enterprise\",\"sourceName\":\"simple.ios\",\"sftpserverIP\":\"192.168.10.38\",\"username\":\"testuser\",\"password\":\"testuser\"}}";
      //升级包数据
      //string jsonData = "{\"esights\":[\"192.168.10.72\"],\"data\":{\"basepackageName\":\"package2\",\"basepackageDescription\":\"\",\"basepackageType\":\"Firmware\",\"fileList\":\"RH2288H_V3-iBMC-V243.zip,RH2288H_V3-iBMC-V243.zip.asc\",\"sftpserverIP\":\"192.168.10.38\",\"username\":\"testuser\",\"password\":\"Test@123.4\"}}";
      //eSight配置数据
      //string jsonData = "{\"hostIp\":\"192.168.10.72\",\"aliasName\":\"\",\"hostPort\":32102,\"loginAccount\":\"openApiUser\",\"loginPwd\":\"Simple.0\"}";
      //不包含Password
      //string jsonData = "{\"esight\":\"192.168.10.72\",\"param\":{\"servertype\":\"rack\",\"start\":1,\"size\":10}}";
      Console.WriteLine(jsonData);
      Console.WriteLine("====================");
      
      //提取数据
      MatchCollection matches = Regex.Matches(jsonData, "\"([A-Za-z0-9_]*)password\":\"(.*?)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      foreach (Match match in matches)
      {
        if (string.IsNullOrWhiteSpace(match.Value)) continue;

        Console.WriteLine(match.Value);
        Console.WriteLine("====================");

        
      }

      string newJsonData = null;
      string replacement = "\"${str}\":\"********\"";
      string pattern1 = "\"(?<str>([A-Za-z0-9_]*)password)\":\"(.*?)\"";
      newJsonData = Regex.Replace(jsonData, pattern1, replacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      string pattern2 = "\"(?<str>([A-Za-z0-9_]*)pwd)\":\"(.*?)\"";
      newJsonData = Regex.Replace(newJsonData, pattern2, replacement, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);

      Console.WriteLine(newJsonData);
    }
  }
}
