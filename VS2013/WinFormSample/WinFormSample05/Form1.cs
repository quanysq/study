using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data.SQLite;

namespace WinFormSample05
{
  public partial class Form1 : Form
  {
    private ChromiumWebBrowser webView;
    private string gpFullName = string.Empty;
    private string gpName = string.Empty;
    private StringBuilder sData = new StringBuilder(1024);
    private string filepath = string.Empty;
    private GPModel gpData = new GPModel();
    private bool hasCheck = false;
    private Button objBtn = null;
    private List<Button> btnList = null;
    ConfigModel configModel = null;
    public Form1()
    {
      InitializeComponent();
      InitUI();
    }

    /// <summary>
    /// 初始化 UI，加载按钮文字等
    /// </summary>
    private void InitUI()
    {
      //1. 初始化 Chrome
      var setting = new CefSettings();
      Cef.Initialize(setting);

      //2. 读取配置
      string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gupiaosetting.config");
      configModel = XmlUtil.Deserialize<ConfigModel>(configFilePath);

      //3. 加载股票到按钮
      label2.Text = string.Format("{0} {1}", configModel.DataType, configModel.DataTypeNote);
      var i = 0;
      btnList = panel2.Controls.OfType<Button>().OrderBy(x => x.TabIndex).ToList();
      foreach (var gp in configModel.GPPool.GuPiaoPool)
      {
        var btn = btnList[i];
        btn.Text = gp.GPFullName;
        btn.Tag = gp;
        i++;
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      btnGP1_Click(btnGP1, null);
    }

    #region "采集数据"
    private void btnLineofDay_Click(object sender, EventArgs e)
    {
      var script = "";
      if (configModel.DataType == 1)
      {
        script = "$(\"[hxc3-data-type='hxc3KlineQfqDay']\").click();";
      }
      else if (configModel.DataType == 2)
      {
        script = "$(\"[hxc3-data-type='hxc3KlineQfqWeek']\").click();";
      }
      
      webView.ExecuteScriptAsync(script);
    }

    private void btnLineOfWeek_Click_1(object sender, EventArgs e)
    {
      if (configModel.DataType == 1)
      {
        System.Windows.Forms.MessageBox.Show("点错了，当前是采集日线图数据！");
        return;
      }
      var script = "$(\"[hxc3-data-type='hxc3KlineQfqWeek']\").click();";
      webView.ExecuteScriptAsync(script);
    }

    private void btnData_Click(object sender, EventArgs e)
    {
      if (!hasCheck)
      {
        if (System.Windows.Forms.MessageBox.Show(
          "开始之前，你检查配置了吗？", 
          "确认", 
          MessageBoxButtons.YesNo, 
          MessageBoxIcon.Question) == DialogResult.No)
        {
          return;
        }
      }
      hasCheck = true;
      GetKLine();
      GetMvLine();
      GetMACD();
      GetKDJ();
      GetRSI();
      GetVol();
      //WriteToTxt();
      //WriteToExcel();
      WriteToSQLite();
      label1.Text = label1.Text + " [OK]";
      //System.Windows.Forms.MessageBox.Show("OK");
      objBtn.BackColor = System.Drawing.SystemColors.GrayText;
    }
    #endregion

    #region "GuPiao Data"
    // K 线
    private void GetKLine()
    {
      var script = "$('.hxc3-hxc3KlinePricePane-hover').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var kData = response.Result.ToString();
          string[] kDataArr = kData.Split(new Char[] { ' ', '：' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======K线数据=======");
          sData.AppendLine(kData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d);
          }
          gpData.Open = TranNull<double>(kDataArr[2]);
          gpData.Highest = TranNull<double>(kDataArr[4]);
          gpData.Lowest = TranNull<double>(kDataArr[6]);
          gpData.Close = TranNull<double>(kDataArr[8]);
          gpData.Range = kDataArr[12];
          gpData.RangeNum = TranNull<double>(kDataArr[12].Replace("%",""));
        }
      }).Wait();
    }

    // 均线
    private void GetMvLine()
    {
      var script = "$('.hxc3-hxc3KlinePricePane-hover-ma').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var mvData = response.Result.ToString();
          string[] kDataArr = mvData.Split(new Char[] { ' ', '：' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======均线数据=======");
          sData.AppendLine(mvData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d);
          }
          gpData.MA5 = TranNull<double>(kDataArr[1]);
          gpData.MA10 = TranNull<double>(kDataArr[3]);
          gpData.MA30 = TranNull<double>(kDataArr[5]);
        }
      }).Wait();
    }

    // 成交量
    private void GetVol()
    {
      var script = "$('.hxc3-hxc3KlineVolPane-hover').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var mvData = response.Result.ToString();
          string[] kDataArr = mvData.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======成交量=======");
          sData.AppendLine(mvData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d.Replace("量", "").Replace("万", ""));
          }
          gpData.Volume = TranNull<double>(kDataArr[1].Replace("量", "").Replace("万", ""));
        }
      }).Wait();
    }

    // MACD
    private void GetMACD()
    {
      var script = "$('.hxc3-TechMACDPane-hover').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var mvData = response.Result.ToString();
          string[] kDataArr = mvData.Split(new Char[] { ' ', '：' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======MACD=======");
          sData.AppendLine(mvData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d);
          }
          gpData.Macd = TranNull<double>(kDataArr[1]);
          gpData.Diff = TranNull<double>(kDataArr[3]);
          gpData.Def = TranNull<double>(kDataArr[5]);
        }
      }).Wait();
    }


    // KDJ
    private void GetKDJ()
    {
      var script = "$(\"[data-indexname='KDJ']\").click(); $('.hxc3-TechKDJPane-hover').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var mvData = response.Result.ToString();
          string[] kDataArr = mvData.Split(new Char[] { ' ', '：' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======KDJ=======");
          sData.AppendLine(mvData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d);
          }
          gpData.K = TranNull<double>(kDataArr[1]);
          gpData.D = TranNull<double>(kDataArr[3]);
          gpData.J = TranNull<double>(kDataArr[5]);
        }
      }).Wait();
    }

    // RSI
    private void GetRSI()
    {
      var script = "$(\"[data-indexname='RSI']\").click(); $('.hxc3-TechRSIPane-hover').text();";
      webView.EvaluateScriptAsync(script).ContinueWith(x =>
      {
        var response = x.Result;
        if (response.Success && response.Result != null)
        {
          var mvData = response.Result.ToString();
          string[] kDataArr = mvData.Split(new Char[] { ' ', '：' }, StringSplitOptions.RemoveEmptyEntries);

          sData.AppendLine("=======RSI=======");
          sData.AppendLine(mvData.ToString());
          foreach (var d in kDataArr)
          {
            sData.AppendLine(d);
          }
          gpData.RSI6 = TranNull<double>(kDataArr[1]);
          gpData.RSI12 = TranNull<double>(kDataArr[3]);
          gpData.RIS24 = TranNull<double>(kDataArr[5]);
        }
      }).Wait();
    }
    #endregion

    #region "写数据"
    private void WriteToExcel()
    {
      IWorkbook wk = null;
      string xlsFile = ExcelConfig.ExcelFile;
      using (var fs = new FileStream(xlsFile, FileMode.Open, FileAccess.ReadWrite))
      {
        wk = new HSSFWorkbook(fs);
        ISheet sheet = wk.GetSheet(gpName);
        IRow row = sheet.GetRow(ExcelConfig.RowNum) ?? sheet.CreateRow(ExcelConfig.RowNum);

        // CellOfOpen
        ICell CellOfOpen = row.CreateCell(ExcelConfig.CellOfOpen);
        CellOfOpen.SetCellType(CellType.Numeric);
        CellOfOpen.SetCellValue(gpData.Open);

        // CellOfClose
        ICell CellOfClose = row.CreateCell(ExcelConfig.CellOfClose);
        CellOfClose.SetCellType(CellType.Numeric);
        CellOfClose.SetCellValue(gpData.Close);

        // CellOfHighest
        ICell CellOfHighest = row.CreateCell(ExcelConfig.CellOfHighest);
        CellOfHighest.SetCellType(CellType.Numeric);
        CellOfHighest.SetCellValue(gpData.Highest);

        // CellOfLowest
        ICell CellOfLowest = row.CreateCell(ExcelConfig.CellOfLowest);
        CellOfLowest.SetCellType(CellType.Numeric);
        CellOfLowest.SetCellValue(gpData.Lowest);

        // CellOfRange
        ICell CellOfRange = row.CreateCell(ExcelConfig.CellOfRange);
        CellOfRange.SetCellType(CellType.String);
        CellOfRange.SetCellValue(gpData.Range);

        // CellOfM5
        ICell CellOfM5 = row.CreateCell(ExcelConfig.CellOfM5);
        CellOfM5.SetCellType(CellType.Numeric);
        CellOfM5.SetCellValue(gpData.MA5);

        // CellOfM10
        ICell CellOfM10 = row.CreateCell(ExcelConfig.CellOfM10);
        CellOfM10.SetCellType(CellType.Numeric);
        CellOfM10.SetCellValue(gpData.MA10);

        // CellOfM30
        ICell CellOfM30 = row.CreateCell(ExcelConfig.CellOfM30);
        CellOfM30.SetCellType(CellType.Numeric);
        CellOfM30.SetCellValue(gpData.MA30);

        // CellOfMacd
        ICell CellOfMacd = row.CreateCell(ExcelConfig.CellOfMacd);
        CellOfMacd.SetCellType(CellType.Numeric);
        CellOfMacd.SetCellValue(gpData.Macd);

        // CellOfDiff
        ICell CellOfDiff = row.CreateCell(ExcelConfig.CellOfDiff);
        CellOfDiff.SetCellType(CellType.Numeric);
        CellOfDiff.SetCellValue(gpData.Diff);

        // CellOfDea
        ICell CellOfDea = row.CreateCell(ExcelConfig.CellOfDea);
        CellOfDea.SetCellType(CellType.Numeric);
        CellOfDea.SetCellValue(gpData.Def);

        // CellOfK
        ICell CellOfK = row.CreateCell(ExcelConfig.CellOfK);
        CellOfK.SetCellType(CellType.Numeric);
        CellOfK.SetCellValue(gpData.K);

        // CellOfD
        ICell CellOfD = row.CreateCell(ExcelConfig.CellOfD);
        CellOfD.SetCellType(CellType.Numeric);
        CellOfD.SetCellValue(gpData.D);

        // CellOfJ
        ICell CellOfJ = row.CreateCell(ExcelConfig.CellOfJ);
        CellOfJ.SetCellType(CellType.Numeric);
        CellOfJ.SetCellValue(gpData.J);

        // CellOfRSI6
        ICell CellOfRSI6 = row.CreateCell(ExcelConfig.CellOfRSI6);
        CellOfRSI6.SetCellType(CellType.Numeric);
        CellOfRSI6.SetCellValue(gpData.RSI6);

        // CellOfRSI12
        ICell CellOfRSI12 = row.CreateCell(ExcelConfig.CellOfRSI12);
        CellOfRSI12.SetCellType(CellType.Numeric);
        CellOfRSI12.SetCellValue(gpData.RSI12);

        // CellOfRSI24
        ICell CellOfRSI24 = row.CreateCell(ExcelConfig.CellOfRSI24);
        CellOfRSI24.SetCellType(CellType.Numeric);
        CellOfRSI24.SetCellValue(gpData.RIS24);

        // CellOfVol
        ICell CellOfVol = row.CreateCell(ExcelConfig.CellOfVol);
        CellOfVol.SetCellType(CellType.Numeric);
        CellOfVol.SetCellValue(gpData.Volume);
      }

      using (var fs = new FileStream(xlsFile, FileMode.Open, FileAccess.ReadWrite))
      {
        wk.Write(fs);
      }
    }

    private void WriteToTxt()
    {
      string toDay = DateTime.Today.ToString("yyyyMMdd");
      string filepath = string.Format(@"D:\Temp\GP\{1}\{0}-{1}.txt", gpFullName, toDay);
      string dir = Path.GetDirectoryName(filepath);
      if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

      using (StreamWriter sw = new StreamWriter(filepath))
      {
        sw.Write(sData.ToString());
      }
    }

    private void WriteToSQLite()
    {
      SQLiteConnection conn = null;
      SQLiteCommand cmd = null;
      try
      {
        string dbPath = string.Format(@"Data Source = {0}\{1}", AppDomain.CurrentDomain.BaseDirectory, @"gupiao.db");
        conn = new SQLiteConnection(dbPath);
        conn.Open();

        var sql = "";
        var isExist = hasRecord(conn, gpData.DataType, gpData.CreateDate, gpData.GPCode);
        if (isExist)
        {
          sql = @"
UPDATE GuPiao SET 
 Open=@Open, 
 Close=@Close, 
 Highest=@Highest, 
 Lowest=@Lowest,
 Range=@Range,
 RangeNum=@RangeNum, 
 MA5=@MA5,
 MA10=@MA10,
 MA30=@MA30,
 Volume=@Volume,
 Macd=@Macd,
 Diff=@Diff,
 Def=@Def,
 K=@K,
 D=@D,
 J=@J,
 RSI6=@RSI6,
 RSI12=@RSI12,
 RIS24=@RIS24
WHERE DataType=@DataType and CreateDate=@CreateDate and GPCode=@GPCode";
        }
        else
        {
          sql = @"
INSERT INTO GuPiao(DataType, CreateDate, CreateDateWeek, GPFullName, GPName, 
                   GPCode, Open, Close, Highest, Lowest, Range, RangeNum, MA5, 
                   MA10, MA30, Volume, Macd, Diff, Def, K, D, J, RSI6, RSI12, RIS24) 
           VALUES(@DataType, @CreateDate, @CreateDateWeek, @GPFullName, @GPName, 
                  @GPCode, @Open, @Close, @Highest, @Lowest, @Range, @RangeNum, @MA5, 
                  @MA10, @MA30, @Volume, @Macd, @Diff, @Def, @K, @D, @J, @RSI6, @RSI12, @RIS24)";
        }
        cmd = new SQLiteCommand(conn);
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@DataType", gpData.DataType);
        cmd.Parameters.AddWithValue("@CreateDate", gpData.CreateDate);
        cmd.Parameters.AddWithValue("@CreateDateWeek", gpData.CreateDateWeek);
        cmd.Parameters.AddWithValue("@GPFullName", gpData.GPFullName);
        cmd.Parameters.AddWithValue("@GPName", gpData.GPName);
        cmd.Parameters.AddWithValue("@GPCode", gpData.GPCode);
        cmd.Parameters.AddWithValue("@Open", gpData.Open);
        cmd.Parameters.AddWithValue("@Close", gpData.Close);
        cmd.Parameters.AddWithValue("@Highest", gpData.Highest);
        cmd.Parameters.AddWithValue("@Lowest", gpData.Lowest);
        cmd.Parameters.AddWithValue("@Range", gpData.Range);
        cmd.Parameters.AddWithValue("@RangeNum", gpData.RangeNum);
        cmd.Parameters.AddWithValue("@MA5", gpData.MA5);
        cmd.Parameters.AddWithValue("@MA10", gpData.MA10);
        cmd.Parameters.AddWithValue("@MA30", gpData.MA30);
        cmd.Parameters.AddWithValue("@Volume", gpData.Volume);
        cmd.Parameters.AddWithValue("@Macd", gpData.Macd);
        cmd.Parameters.AddWithValue("@Diff", gpData.Diff);
        cmd.Parameters.AddWithValue("@Def", gpData.Def);
        cmd.Parameters.AddWithValue("@K", gpData.K);
        cmd.Parameters.AddWithValue("@D", gpData.D);
        cmd.Parameters.AddWithValue("@J", gpData.J);
        cmd.Parameters.AddWithValue("@RSI6", gpData.RSI6);
        cmd.Parameters.AddWithValue("@RSI12", gpData.RSI12);
        cmd.Parameters.AddWithValue("@RIS24", gpData.RIS24);
        cmd.ExecuteNonQuery();
        label1.Text = label1.Text + " [" + (isExist ? "Update" : "Insert") + "]";
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (cmd != null) cmd.Dispose();
        if (conn != null) conn.Dispose();
      }
    }

    private bool hasRecord(SQLiteConnection conn, int DataType, string CreateDate, string GPCode)
    {
      using (var cmd = new SQLiteCommand(conn))
      {
        cmd.CommandText = "SELECT count(1) from Gupiao a where a.gpcode=@GPCode and a.datatype=@DataType and a.CreateDate=@CreateDate";
        cmd.Parameters.AddWithValue("@DataType", gpData.DataType);
        cmd.Parameters.AddWithValue("@CreateDate", gpData.CreateDate);
        cmd.Parameters.AddWithValue("@GPCode", gpData.GPCode);
        object result = cmd.ExecuteScalar();
        int flag = TranNull<int>(result);
        return flag > 0;
      }
    }
    #endregion

    #region "加载股票网页"
    private void btnGP1_Click(object sender, EventArgs e)
    {
      var btn = (Button)sender;
      if (btn.Text.Trim() == "")
      {
        System.Windows.Forms.MessageBox.Show("无效的股票", "说明");
        return;
      }
      objBtn = btn;
      gpFullName = btn.Text;
      gpName = ((GPInfo)btn.Tag).GPName;
      label1.Text = gpFullName;
      var code = ((GPInfo)btn.Tag).GPCode;
      string url = string.Format("http://stockpage.10jqka.com.cn/HQ_v4.html#hs_{0}", code);
      LoadUrl(url);

      gpData.DataType = configModel.DataType;
      gpData.CreateDate = DateTime.Today.ToString("yyyy-MM-dd");
      gpData.CreateDateWeek = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
      gpData.GPFullName = gpFullName;
      gpData.GPName = gpName;
      gpData.GPCode = code;

      btnLineofDay.Focus();
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      var tabIndex = objBtn.TabIndex + 1;
      var btnNext = btnList.Find(x => x.TabIndex == tabIndex);
      btnGP1_Click(btnNext, null);
    }

    private void LoadUrl(string url)
    {
      webView = new ChromiumWebBrowser(url);
      this.panel3.Controls.Clear();
      this.panel3.Controls.Add(webView);
    }
    #endregion

    private static T TranNull<T>(object obj)
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
