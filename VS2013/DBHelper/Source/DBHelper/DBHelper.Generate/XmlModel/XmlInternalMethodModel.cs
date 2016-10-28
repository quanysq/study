using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Enums;

namespace DBHelper.Generate
{
  public class XmlInternalMethodModel
  {
    public XmlInternalMethodModel() { }

    public int MethodID { get; set; }
    public string ConnectionStr { get; set; }
    public string MethodName { get; set; }
    public string MethodDesc { get; set; }
    public MethodType MethodType { get; set; }
    public FunctionType FunctionType { get; set; }
    public string SuccessMsg { get; set; }
    public string FailMsg { get; set; }
    public List<XmlMethodStatementModel> MethodStatementList { get; set; }
    public List<XmlMethodParameterModel> MethodParameterList { get; set; }
  }

  public class XmlMethodStatementModel
  {
    public int OrderID { get; set; }
    public string Tag { get; set; }
    public string Statement { get; set; }
    public bool IsOrderby { get; set; }
    public bool HasConditional { get; set; }
    public List<XmlMethodStatementConditionalModel> StatementConditionalList { get; set; }
  }

  public class XmlMethodStatementConditionalModel
  {
    public string ConditionType { get; set; }
    public string ParameterName { get; set; }
    public BehaviorType ExpectBehavior { get; set; }
    public string CompareValue { get; set; }
  }

  public class XmlMethodParameterModel
  {
    public string ParameterName { get; set; }
    public string ParameterDesc { get; set; }
    public ParameterDataType ParameterDataType { get; set; }
    public ParameterDirection ParameterDirection { get; set; }
    public ParameterValidateType ParameterValidateType { get; set; }
    public string ValidateValue { get; set; }
  }
}
