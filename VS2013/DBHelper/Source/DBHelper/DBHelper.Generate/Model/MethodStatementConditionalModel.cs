using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class MethodStatementConditionalModel
  {
    public int ConditionalID { get; set; }
    public int StatementID { get; set; }
    public int MethodID { get; set; }
    public string ConditionType { get; set; }
    public string ParameterName { get; set; }
    public string ExpectBehavior { get; set; }
    public string CompareValue { get; set; }

  }
}
