using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DBHelper.DAO.DAOModel;
using DBHelper.Common;
using DBHelper.Util;
using System.Data;

namespace DBHelper.DAO
{
  public class SQLHelper
  {
    #region Field
    private readonly string sqlconnectionstr = "";
    private SQLSatement sqlsatement          = null;
    #endregion

    #region Property
    private string[] paramevalues;
    public string[] ParameValues
    {
      get { return paramevalues; }
      set { paramevalues = value; }
    }

    private string[] formatvalues;
    public string[] FormatValues
    {
      get { return formatvalues; }
      set { formatvalues = value; }
    }
    #endregion

    public SQLHelper(string daoxmlpath)
    {
      sqlconnectionstr = Common.Common.LocalConnection;
      sqlsatement      = DaoXmlHelper.ReadDaoXml(daoxmlpath);
    }

    public T ExecuteSQL<T>()
    {
      SetParameValues();
      SetFormatValues();

      using (SqlConnection cn = new SqlConnection(sqlconnectionstr))
      {
        cn.Open();

        object result = null;
        switch ((OperateType)sqlsatement.operatetype)
        {
          case OperateType.Query:
            result = ExecuteSQLForQuery(cn);
            break;
          case OperateType.DDL:
            result = ExecuteSQLForDDL(cn);
            break;
          case OperateType.Single:
            result = ExcuteSQLForSingle(cn);
            break;
          default:
            throw new NotSupportedException("sorry, don't support this type.");
        }

        return CommonUtil.TranNull<T>(result);
      }
    }

    private DataTable ExecuteSQLForQuery(SqlConnection cn)
    {
      DataTable dt       = new DataTable();
      SqlCommand cmd     = null;
      SqlDataAdapter sda = null;

      try
      {
        SQLConverterFactory scf = new SQLConverterFactory(sqlsatement);
        SQLConverter sc         = scf.GetSQLConverter();
        cmd                     = sc.ConvertSQLString(cn);
        sda                     = new SqlDataAdapter(cmd);
        sda.Fill(dt);
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        if (cmd != null) cmd.Dispose();
        if (sda != null) sda.Dispose();
      }

      return dt;
    }

    private int ExecuteSQLForDDL(SqlConnection cn)
    {
      int result = 0;
      SqlCommand cmd = null;

      try
      {
        SQLConverterFactory scf = new SQLConverterFactory(sqlsatement);
        SQLConverter sc         = scf.GetSQLConverter();
        cmd                     = sc.ConvertSQLString(cn);
        result                  = cmd.ExecuteNonQuery();
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        if (cmd != null) cmd.Dispose();
      }

      return result;
    }

    private object ExcuteSQLForSingle(SqlConnection cn)
    {
      object result = null;
      SqlCommand cmd = null;

      try
      {
        SQLConverterFactory scf = new SQLConverterFactory(sqlsatement);
        SQLConverter sc         = scf.GetSQLConverter();
        cmd                     = sc.ConvertSQLString(cn);
        result                  = cmd.ExecuteScalar();
      }
      catch (Exception)
      {
        throw;
      }
      finally
      {
        if (cmd != null) cmd.Dispose();
      }

      return result;
    }
    private void SetParameValues()
    {
      if (sqlsatement.sqlparames.Length == 0 || paramevalues == null || paramevalues.Length == 0) return;

      for (int i = 0; i < sqlsatement.sqlparames.Length; i++)
      {
        var sqlparame = sqlsatement.sqlparames[i];
        sqlparame.paramevalue = paramevalues[i];
      }
    }

    private void SetFormatValues()
    {
      if (sqlsatement.formatdetails.Length == 0 || formatvalues == null || formatvalues.Length == 0) return;

      for (int i = 0; i < sqlsatement.formatdetails.Length; i++)
      {
        SQLSatementFormatinfo fi = sqlsatement.formatdetails[i];
        fi.realdata = formatvalues[i];
      }
    }
  }
  //=====================================================================================================
  public enum ParameType
  {
    Normal,
    Parames,
    Format
  }
  public enum OperateType
  {
    Query,
    DDL,
    Single
  }
  //=====================================================================================================
  #region SQLConverterFactory
  public class SQLConverterFactory
  {
    private SQLSatement sqlsatement = null;

    public SQLConverterFactory(SQLSatement sqlsatement)
    {
      this.sqlsatement = sqlsatement;
    }

    public SQLConverter GetSQLConverter()
    {
      switch ((ParameType)sqlsatement.paramtype)
      {
        case ParameType.Normal:
          return new NormalConverter(sqlsatement);
        case ParameType.Parames:
          return new ParameConverter(sqlsatement);
        case ParameType.Format:
          return new ForamtConverter(sqlsatement);
        default:
          throw new NotSupportedException("Don't support this type.");
      }
    }
  }

  public abstract class SQLConverter
  {
    protected SQLSatement sqlsatement = null;

    protected SQLConverter(SQLSatement sqlsatement)
    {
      this.sqlsatement = sqlsatement;
    }

    public abstract SqlCommand ConvertSQLString(SqlConnection cn);
  }

  public class ForamtConverter : SQLConverter
  {
    public ForamtConverter(SQLSatement sqlsatement) : base(sqlsatement)
    {

    }

    public override SqlCommand ConvertSQLString(SqlConnection cn)
    {
      string[] formatdata = new string[sqlsatement.formatdetails.Length];
      for (int i = 0; i < sqlsatement.formatdetails.Length; i++)
      {
        SQLSatementFormatinfo fi = sqlsatement.formatdetails[i];
        formatdata[i] = fi.realdata;
      }
      string sql = string.Format(sqlsatement.sql, formatdata);
      SqlCommand cmd = new SqlCommand(sql, cn);
      return cmd;
    }
  }

  public class ParameConverter : SQLConverter
  {
    public ParameConverter(SQLSatement sqlsatement) : base(sqlsatement)
    {

    }

    public override SqlCommand ConvertSQLString(SqlConnection cn)
    {
      SqlCommand cmd = new SqlCommand(sqlsatement.sql, cn);
      foreach (var sqlparame in sqlsatement.sqlparames)
      {
        SqlParameter sqlparameter  = new SqlParameter();
        sqlparameter.ParameterName = sqlparame.name;
        sqlparameter.SqlDbType     = CommonUtil.SqlTypeString2SqlType(sqlparame.dbtype);
        sqlparameter.Value         = sqlparame.paramevalue;
        cmd.Parameters.Add(sqlparameter);
      }
      return cmd;
    }
  }

  public class NormalConverter : SQLConverter
  {
    public NormalConverter(SQLSatement sqlsatement) : base(sqlsatement)
    {

    }

    public override SqlCommand ConvertSQLString(SqlConnection cn)
    {
      SqlCommand cmd = new SqlCommand(sqlsatement.sql, cn);
      return cmd;
    }
  }
  #endregion
}