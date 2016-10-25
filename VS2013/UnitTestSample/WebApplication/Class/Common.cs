using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication.Class
{
  public class Common
  {
    public static string ReadTxt()
    {
      string filepath = HttpContext.Current.Server.MapPath("~/File/01.txt");

      using (StringReader sr = new StringReader(filepath))
      {
        string s = sr.ReadToEnd();
        return s;
      }
    }

    public static string ReadTxt(string filepath)
    {
      using (StreamReader sr = new StreamReader(filepath))
      {
        string s = sr.ReadToEnd();
        return s;
      }
    }

    public static string GetFiltPath(string file)
    {
      string filepath = HttpContext.Current.Server.MapPath(file);
      return filepath;
    }

    public static string GetFiltPath(HttpContextBase Context, string file)
    {
      string filepath = Context.Server.MapPath(file);
      return filepath;
    }

    public static string GetFiltPath(HttpContext Context, string file)
    {
      string filepath = Context.Server.MapPath(file);
      return filepath;
    }
  }
}