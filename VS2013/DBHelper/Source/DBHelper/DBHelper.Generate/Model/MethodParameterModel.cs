using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Model
{
  public class MethodParameterModel
  {
    public int ParameterID { get; set; }
    public int MethodID { get; set; }
    public string ParameterName { get; set; }
    public string ParameterDesc { get; set; }
    public string ParameterDataType { get; set; }
    public string ParameterDirection { get; set; }
    public string ParameterValidateType { get; set; }
    public string ValidateValue { get; set; }

  }
}
