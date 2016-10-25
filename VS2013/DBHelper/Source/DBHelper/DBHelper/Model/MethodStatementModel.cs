using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class MethodStatementModel
  {
    public int StatementID { get; set; }
    public int MethodID { get; set; }
    public int OrderID { get; set; }
    public string Tag { get; set; }
    public string Statement { get; set; }
    public int IsOrderby { get; set; }
    public int HasConditional { get; set; }
  }
}
