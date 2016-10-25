using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace UnitTestTools
{
  class ClsReflection
  {
    private Type ClassType       = null;
    private MethodInfo[] Mis     = null;
    private Object ClassInstance = null;

    public ClsReflection(string AssemblyName, string NamespaceName, string ClassName)
    {
      ClassType     = GetSpecifiedClassType(AssemblyName, NamespaceName, ClassName);
      Mis           = GetMethods();
      ClassInstance = CreateClassInstance();
    }

    private Type GetSpecifiedClassType(string AssemblyName, string NamespaceName, string ClassName)
    {
      Assembly ass       = Assembly.LoadFrom(AssemblyName);
      string ClassString = NamespaceName + "." + ClassName;
      Type t             = ass.GetType(ClassString, true, true);
      return t;
    }

    private MethodInfo[] GetMethods()
    {
      return ClassType.GetMethods();
    }

    private Object CreateClassInstance()
    {
      object o = Activator.CreateInstance(ClassType);
      return o;
    }

    public List<string> GetMethodList()
    {
      List<string> LMSMethodList = (from l in Mis orderby l.Name select l.Name).ToList();
      return LMSMethodList;
    }

    private MethodInfo GetMethodInfoByName(string methodname)
    {
      MethodInfo mi = Mis.FirstOrDefault(x => x.Name.Equals(methodname, StringComparison.OrdinalIgnoreCase));
      return mi;
    }

    public List<UnitTestResult> ExecuteMethod(string methodname)
    {
      List<UnitTestResult> UnitTestResultList = new List<UnitTestResult>();
      MethodInfo mi                           = GetMethodInfoByName(methodname);
      UnitTestResult UtResult                 = ExecuteMethod(mi);
      UnitTestResultList.Add(UtResult);
      return UnitTestResultList;
    }

    private UnitTestResult ExecuteMethod(MethodInfo Mi)
    {
      UnitTestResult UtResult = new UnitTestResult();

      if (!Mi.Name.EndsWith("_Test"))
      {
        UtResult.TestMethodName = Mi.Name;
        UtResult.Status         = ResultStatus.Fail;
        UtResult.Exception      = new Exception(string.Format("Haven't test the [{0}] method, because it isn't an test method.", Mi.Name));
        return UtResult;
      }

      UtResult.TestMethodName = Mi.Name.Replace("_Test", "");
      try
      {
        object o      = Mi.Invoke(ClassInstance, null);
        bool b        = (bool)o;
        {
          UtResult.Status = b ? ResultStatus.Success : ResultStatus.Fail;
          UtResult.Exception = b ? null : (new Exception(string.Format("Test {0} failed.", UtResult.TestMethodName)));
        }
      }
      catch (Exception ex)
      {
        UtResult.Status = ResultStatus.Fail;
        UtResult.Exception = ex;
      }
      return UtResult;
    }

    public List<UnitTestResult> ExecuteAllMethods()
    {
      List<UnitTestResult> UnitTestResultList = new List<UnitTestResult>();

      foreach (MethodInfo Mi in Mis)
      {
        UnitTestResult UtResult = ExecuteMethod(Mi);
        UnitTestResultList.Add(UtResult);
      }

      return UnitTestResultList;
    }
  }

  class UnitTestResult
  {
    public string TestMethodName { get; set; }
    public ResultStatus Status { get; set; }
    public Exception Exception { get; set; }
  }

  enum ResultStatus
  {
    Success,
    Fail
  }
}
