using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console043
{
  public class BackupRestoreHelp
  {
    private readonly string connectionString;
    private readonly string RestoreDB;
    private readonly string BackFile;
    private readonly string BackupDB;
    private readonly string DefaultDirForRestore;

    public BackupRestoreHelp()
    {
      connectionString     = ConfigurationManager.AppSettings["masterdbconn"];
      RestoreDB            = ConfigurationManager.AppSettings["RestoreDB"];
      BackFile             = ConfigurationManager.AppSettings["BackFile"];
      BackupDB             = ConfigurationManager.AppSettings["BackupDB"];
      DefaultDirForRestore = ConfigurationManager.AppSettings["DefaultDirForRestore"];
    }

    /// <summary>
    /// 备份指定的数据库文件
    /// </summary>
    public void BackUpDataBase()
    {
      if (File.Exists(BackFile)) File.Delete(BackFile);

      SqlConnection conn      = null;
      SqlCommand comm         = null;

      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        string sql       = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", BackupDB, BackFile);
        comm             = new SqlCommand(sql, conn);
        comm.CommandType = CommandType.Text;
        comm.ExecuteNonQuery();
        Console.WriteLine("Backup [{0}] successful, bakfile is [{1}]", BackupDB, BackFile);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Backup [{0}] failed", BackupDB);
        throw ex;
      }
      finally
      {
        if (comm != null) comm.Dispose();
        if (conn != null) conn.Close();
      }
    }

    /// <summary>
    /// 还原数据库，需要关闭所有与被还原的数据库相连的连接
    /// </summary>
    public void RestoreDatabase()
    {
      if (!File.Exists(BackFile))
      {
        Console.WriteLine("[{0}] does not found.", BackFile);
        return;
      }

      List<string> dbprocesslist = GetDBProcess();
      KillDBProcess(dbprocesslist);
      RestoreDatabaseCore();
    }

    private List<string> GetDBProcess()
    {
      List<string> dbprocesslist = new List<string>();
      SqlConnection conn         = null;
      SqlCommand comm            = null;
      SqlDataReader dr           = null;
      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        string sql       = string.Format("SELECT spid FROM sysprocesses INNER JOIN sysdatabases ON sysprocesses.dbid=sysdatabases.dbid WHERE sysdatabases.Name='{0}'", RestoreDB);
        comm             = new SqlCommand(sql, conn);
        dr               = comm.ExecuteReader();
        while (dr.Read())
        {
          dbprocesslist.Add(dr[0].ToString());
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Get [{0}] Process failed.", RestoreDB);
        throw ex;
      }
      finally
      {
        if (dr != null) dr.Close();
        if (comm != null) comm.Dispose();
        if (conn != null) conn.Close();
      }
      return dbprocesslist;
    }

    private void KillDBProcessCore(string dbprocessid, SqlConnection conn)
    {
      SqlCommand comm = null;
      try
      {
        string sql = string.Format("KILL {0}", dbprocessid);
        comm       = new SqlCommand(sql, conn);
        comm.ExecuteNonQuery();
        Console.WriteLine("Kill DBProcess [{0}] successful.", dbprocessid);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Kill DBProcess [{0}] failed.", dbprocessid);
        throw;
      }
      finally
      {
        if (comm != null) comm.Dispose();
      }
    }

    private void KillDBProcess(List<string> dbprocesslist)
    {
      if (dbprocesslist.Count == 0) return;

      string connectionString = ConfigurationManager.AppSettings["masterdbconn"];
      SqlConnection conn      = null;

      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        foreach (string spid in dbprocesslist)
        {
          KillDBProcessCore(spid, conn);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (conn != null) conn.Close();
      }
    }

    private void RestoreDatabaseCore()
    {
      SqlConnection conn      = null;
      SqlCommand comm         = null;

      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        Dictionary<string, string> LogicalNameDic = GetLogicalNameFromBakupfile();
        Dictionary<string, string> FileNameDic    = GetFileNameFromRestoreDB();

        StringBuilder sql = new StringBuilder(1024);
        sql.AppendLine(string.Format("RESTORE DATABASE {0} FROM DISK = '{1}' ", RestoreDB, BackFile));
        if (LogicalNameDic.Count == 2 && FileNameDic.Count == 2)
        {
          sql.AppendLine(string.Format("with move '{0}' to '{1}'", LogicalNameDic["DBName"], FileNameDic["DBName"]));
          sql.AppendLine(string.Format("    ,move '{0}' to '{1}'", LogicalNameDic["LogName"], FileNameDic["LogName"]));
          sql.AppendLine("                  ,replace");
        }
        comm             = new SqlCommand(sql.ToString(), conn);
        comm.CommandType = CommandType.Text;
        comm.ExecuteNonQuery();
        Console.WriteLine("Restore [{0}] successful", RestoreDB);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Restore [{0}] failed", RestoreDB);
        throw ex;
      }
      finally
      {
        if (comm != null) comm.Dispose();
        if (conn != null) conn.Close();
      }
    }

    private Dictionary<string, string> GetLogicalNameFromBakupfile()
    {
      Dictionary<string, string> LogicalNameDic = new Dictionary<string, string>();
      SqlConnection conn         = null;
      SqlCommand comm            = null;
      SqlDataReader dr           = null;
      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        string sql       = string.Format("restore filelistonly from disk='{0}'", BackFile);
        comm             = new SqlCommand(sql, conn);
        dr               = comm.ExecuteReader();
        while (dr.Read())
        {
          string DataType    = dr["Type"].ToString();
          string LogicalName = dr["LogicalName"].ToString();
          if (DataType.Equals("D"))
          {
            LogicalNameDic.Add("DBName", LogicalName);
          }
          else
          {
            LogicalNameDic.Add("LogName", LogicalName);
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dr != null) dr.Close();
        if (comm != null) comm.Dispose();
        if (conn != null) conn.Close();
      }
      return LogicalNameDic;
    }

    private Dictionary<string, string> GetFileNameFromRestoreDB()
    {
      Dictionary<string, string> FileNameDic = new Dictionary<string, string>();
      SqlConnection conn         = null;
      SqlCommand comm            = null;
      SqlDataReader dr           = null;
      try
      {
        conn = new SqlConnection(connectionString);
        conn.Open();

        bool hasrestoredb = HasRestoreDB(conn);
        if (!hasrestoredb)
        {
          FileNameDic.Add("DBName", string.Format(@"{0}\{1}.mdf", DefaultDirForRestore, RestoreDB));
          FileNameDic.Add("LogName", string.Format(@"{0}\{1}_log.ldf", DefaultDirForRestore, RestoreDB));
          return FileNameDic;
        }

        string sql        = string.Format("select filename from [{0}].[dbo].sysfiles", RestoreDB);
        comm              = new SqlCommand(sql, conn);
        dr                = comm.ExecuteReader();
        while (dr.Read())
        {
          string FileName = dr[0].ToString();
          string Ext      = Path.GetExtension(FileName);
          if (Ext.Equals(".mdf", StringComparison.OrdinalIgnoreCase))
          {
            FileNameDic.Add("DBName", FileName);
          }
          else
          {
            FileNameDic.Add("LogName", FileName);
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (dr != null) dr.Close();
        if (comm != null) comm.Dispose();
        if (conn != null) conn.Close();
      }
      return FileNameDic;
    }

    private bool HasRestoreDB(SqlConnection conn)
    {
      string sql = string.Format("select count(1) from sys.databases where name='{0}'", RestoreDB);
      using (SqlCommand com = new SqlCommand(sql, conn))
      {
        object o = com.ExecuteScalar();
        if (o == null || Convert.ToInt32(o) == 0) return false;
        return true;
      }
    }
  }
}
