using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBHelper.Enums;

namespace DBHelper.Generate
{
  public class XmlBusinessMethodModel
  {
    public string BMCode { get; set; }
    public DBType DBType { get; set; }
    public string ConnectionStr { get; set; }
    public string BMDesc { get; set; }
    public FunctionType FunctionType { get; set; }
    public List<XmlBusinessInternalMethodModel> InternalMethodList { get; set; }
    public List<XmlBusinessParameterModel> BusinessParameterList { get; set; }

  }

  public class XmlBusinessInternalMethodModel
  {
    public int MethodID { get; set; }
    public List<XmlParameterRelationModel> ParameterRelationList { get; set; }
  }

  public class XmlParameterRelationModel
  {
    public string BMParameterName { get; set; }
    public string MethodParameterName { get; set; }
  }

  public class XmlBusinessParameterModel
  {
    public string ParameterName { get; set; }
    public string ParameterDesc { get; set; }
    public ParameterDataType ParameterDataType { get; set; }
    public ParameterDirection ParameterDirection { get; set; }
    public ParameterValidateType ParameterValidateType { get; set; }
    public string ConstValue { get; set; }
    public string DefaultValue { get; set; }
  }

}
