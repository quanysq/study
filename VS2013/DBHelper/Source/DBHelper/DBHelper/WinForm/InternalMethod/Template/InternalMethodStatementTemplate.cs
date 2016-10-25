using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.Enums;
using DBHelper.Model;
using System.Text.RegularExpressions;
using DBHelper.BLL;

namespace DBHelper
{
  public class InternalMethodStatementTemplate : Form
  {
    public int MethodID { get; set; }

    public static List<string> ExtractParamer(MethodType MethodType, string strsql)
    {
      if (MethodType == Enums.MethodType.SQLStatement)
      {
        return ExtractParamerFromSqlStatement(strsql);
      }
      else
      {
        return ExtractParamerFromStoredProcedure(strsql);
      }
    }

    private static List<string> ExtractParamerFromSqlStatement(string strsql)
    { 
      List<string> ParamerList = new List<string>();
      string pattern           = @"@([A-Za-z0-9_-]+)";
      Regex reg                = new Regex(pattern);
      var MatcheList           = reg.Matches(strsql);
      foreach (Match item in MatcheList)
      {
        if (!ParamerList.Contains(item.Value)) ParamerList.Add(item.Value);
      }
      return ParamerList;
    }

    private static List<string> ExtractParamerFromStoredProcedure(string StoredProcedureName)
    { 
      InternalMethodBLL internalmethodbll = new InternalMethodBLL();
      List<string> ParamerList            = internalmethodbll.MethodParameterSP(StoredProcedureName);
      return ParamerList;
    }
  }
}
