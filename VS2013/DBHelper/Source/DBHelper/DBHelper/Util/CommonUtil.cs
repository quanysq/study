using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DBHelper.Util
{
  public static class CommonUtil
  {
    public static T ConvertString2OtherType<T>(string s)
    {
      return (T)Convert.ChangeType(s, typeof(T));
    }

    public static SqlDbType SqlTypeString2SqlType(string sqlTypeString)
    {
      SqlDbType dbType = SqlDbType.Variant;   //默认为Object

      switch (sqlTypeString)
      {
        case "string":
          dbType = SqlDbType.VarChar;
          break;
        case "int":
          dbType = SqlDbType.Int;
          break;
        case "varchar":
          dbType = SqlDbType.VarChar;
          break;
        case "bit":
          dbType = SqlDbType.Bit;
          break;
        case "datetime":
          dbType = SqlDbType.DateTime;
          break;
        case "decimal":
          dbType = SqlDbType.Decimal;
          break;
        case "float":
          dbType = SqlDbType.Float;
          break;
        case "image":
          dbType = SqlDbType.Image;
          break;
        case "money":
          dbType = SqlDbType.Money;
          break;
        case "ntext":
          dbType = SqlDbType.NText;
          break;
        case "nvarchar":
          dbType = SqlDbType.NVarChar;
          break;
        case "smalldatetime":
          dbType = SqlDbType.SmallDateTime;
          break;
        case "smallint":
          dbType = SqlDbType.SmallInt;
          break;
        case "text":
          dbType = SqlDbType.Text;
          break;
        case "bigint":
          dbType = SqlDbType.BigInt;
          break;
        case "binary":
          dbType = SqlDbType.Binary;
          break;
        case "char":
          dbType = SqlDbType.Char;
          break;
        case "nchar":
          dbType = SqlDbType.NChar;
          break;
        case "numeric":
          dbType = SqlDbType.Decimal;
          break;
        case "real":
          dbType = SqlDbType.Real;
          break;
        case "smallmoney":
          dbType = SqlDbType.SmallMoney;
          break;
        case "sql_variant":
          dbType = SqlDbType.Variant;
          break;
        case "timestamp":
          dbType = SqlDbType.Timestamp;
          break;
        case "tinyint":
          dbType = SqlDbType.TinyInt;
          break;
        case "uniqueidentifier":
          dbType = SqlDbType.UniqueIdentifier;
          break;
        case "varbinary":
          dbType = SqlDbType.VarBinary;
          break;
        case "xml":
          dbType = SqlDbType.Xml;
          break;
      }
      return dbType;
    }

    public static T TranNull<T>(object obj)
    {
      if (obj == null) return default(T);
      if (obj is T) return (T)obj;
      try
      {
        return (T)Convert.ChangeType(obj, typeof(T));
      }
      catch
      {
        return default(T);
      }
    }
  }
}