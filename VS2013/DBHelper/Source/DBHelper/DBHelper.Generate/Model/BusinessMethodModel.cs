using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class BusinessMethodModel
  {
    public string BMCode { get; set; }
    public int DatabaseID { get; set; }
    public int ClassifyID { get; set; }
    public string BMDesc { get; set; }
    public string FunctionType { get; set; }
    public string CreateUser { get; set; }
    public DateTime CreateDate { get; set; }
    public string UpdateUser { get; set; }
    public DateTime UpdateDate { get; set; }
    public string UpdateReson { get; set; }

  }
}
