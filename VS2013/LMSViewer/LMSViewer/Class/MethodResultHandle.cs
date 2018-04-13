using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSViewer
{
  public class MethodResultHandleFactory
  {
    public string GetResultAfterHandle(string MethodReturnType, object OriginalResult)
    {
      MethodResultHandle mrh = null;
      if (MethodReturnType.Equals("System.IO.MemoryStream", StringComparison.OrdinalIgnoreCase))
      {
        mrh = new MemoryStreamResultHandle();
      }
      else if (MethodReturnType.Equals("String", StringComparison.OrdinalIgnoreCase))
      {
        mrh = new StringResultHandle();
      }
      else
      {
        return string.Format("Error: don't support this type: [{0}]", MethodReturnType);
      }
      return mrh.ConvertOriginalResult(OriginalResult);
    }
  }

  public abstract class MethodResultHandle
  {
    public abstract string ConvertOriginalResult(object OriginalResult);
  }

  public class MemoryStreamResultHandle : MethodResultHandle
  {
    public override string ConvertOriginalResult(object OriginalResult)
    {
      StreamReader sr = null;
      MemoryStream ms = null;
      try
      {
        ms                  = (MemoryStream)OriginalResult;
        ms.Position         = 0;
        sr                  = new StreamReader(ms);
        string handleresult = sr.ReadToEnd();
        return handleresult;
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (ms != null) ms.Close();
        if (sr != null) sr.Close();
      }
    }
  }

  public class StringResultHandle : MethodResultHandle
  {
    public override string ConvertOriginalResult(object OriginalResult)
    {
      return OriginalResult.ToString();
    }
  }
}
