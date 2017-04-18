using Console006.LocalFunc.I18N;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console006.LocalFunc
{
  public class C1
  {
    public static void Execute()
    {
      Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name); //return en-US

      string local1 = LanguageHelper.GetString("Hello_World");
      Console.WriteLine(local1);

      string local2 = LanguageHelper.GetStringDefault("Hello_World");
      Console.WriteLine(local2);

      string local3 = I18NRes.Welcome_use_T4;
      Console.WriteLine(local3);
    }

    public static void Execute2()
    {
      Console.WriteLine(en.Hello_World);
      Console.WriteLine(zh_CN.Hello_World);
      //Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("zh-CN");
    }
  }

  public class LanguageHelper
  {
    public static string GetString(string key)
    {
      string language = "zh-CN";
      return GetString(key, language);
    }

    public static string GetStringDefault(string key)
    {
      return GetString(key, "en");
    }

    private static string GetString(string key, string language)
    {
      string baseName = string.Format("Console006.LocalFunc.I18N.{0}", language);
      ResourceManager rm = new ResourceManager(baseName, Assembly.GetExecutingAssembly());
      var ci = new CultureInfo(language);
      return rm.GetString(key, ci);
    }

    /*
     * 如果语言编号不正确，返回System.Globalization.CultureNotFoundException
     * 如果没有对应的资源文件，返回System.Resources.MissingManifestResourceException
     */ 
  }
}
