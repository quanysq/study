using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Enums
{
  public enum DBType
  {
    MsSqlServer,
    Oracle
  }

  public enum MethodType
  {
    SQLStatement,
    StoredProcedure
  }

  public enum FunctionType
  {
    Select_View,
    Select_Paging,
    Select_Rows,
    Insert,
    Update,
    Delete
  }

  public enum BehaviorType
  {
    Equal,
    NotEqual,
    Null,
    NotNull,
    GreaterThan,
    GreaterThan_Equal,
    LessThan,
    LessThan_Equal,
    InList
  }

  public enum ParameterDataType
  {
    Int,
    Varchar,
    Nvarchar,
    Text,
    Datetime,
    Bool
  }

  public enum ParameterDirection
  {
    In,
    Out,
    InOut
  }

  public enum ParameterValidateType
  {
    None,
    Required,
    Range,
    GreaterThan,
    LessThan,
    InList
  }

  public enum ConditionType
  {
    And,
    Or
  }

  public enum SQLStatementMove
  {
    MoveDown,
    MoveUp
  }
}
