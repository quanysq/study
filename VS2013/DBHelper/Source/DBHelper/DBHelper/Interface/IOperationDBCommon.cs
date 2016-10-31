using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Interface
{
  interface IOperationDBCommon
  {
    List<string> ExtractParamerFromStoredProcedure(string StoredProcedureName);
  }
}
