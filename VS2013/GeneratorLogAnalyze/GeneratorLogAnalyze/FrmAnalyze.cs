using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorLogAnalyze
{
  public partial class FrmAnalyze : Form
  {
    public FrmAnalyze()
    {
      InitializeComponent();
    }

    private void btnAnalyze_Click(object sender, EventArgs e)
    {
      var logFile = txtLogFile.Text.Trim();

      if (string.IsNullOrWhiteSpace(logFile))
      {
        MessageBox.Show("Please input the log file path!");
        return;
      }

      var dict = new Dictionary<string, string>();

      using (StreamReader sr = new StreamReader(logFile, Encoding.UTF8))
      {
        var temp = new StringBuilder(1024);
        
        while (true)
        {
          string lineLog = sr.ReadLine();
          if (lineLog == null) break;

          lineLog = lineLog.Trim();

          if (lineLog.StartsWith("====================="))
          {
            var rNo = lineLog.Replace("=", "");
            dict.Add(rNo, temp.ToString());
            temp.Clear();
          }
          else
          {
            temp.AppendLine(lineLog);
          }
        }
      }

      var result = new StringBuilder(1024);
      var maxID  = "0";
      var maxSec = 0d;

      foreach (var item in dict)
      {
        result.AppendLine("");
        result.AppendLine(item.Key);

        using (StringReader sr = new StringReader(item.Value))
        {
          string preLine = "";
          string curLine = "";
          string beginTime = "2001-01-01";

          while (true)
          {
            string lineLog = sr.ReadLine();
            if (lineLog == null) break;

            if (!string.IsNullOrWhiteSpace(curLine))
            {
              preLine = curLine;
            }

            curLine = lineLog;

            
            if (curLine.StartsWith("0 rows exported at"))
            {
              beginTime = ExtractWorld(curLine, "[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}");
              result.AppendLine(string.Format("Beg: [{0}]", beginTime));
            }
            else if (curLine.StartsWith("output file"))
            {
              if (!string.IsNullOrWhiteSpace(preLine))
              {
                string endTime = ExtractWorld(preLine, "[0-9]{4}-[0-9]{2}-[0-9]{2} [0-9]{2}:[0-9]{2}:[0-9]{2}");
                result.AppendLine(string.Format("End: [{0}]", endTime));

                var d1 = DateTime.Parse(beginTime);
                var d2 = DateTime.Parse(endTime);
                TimeSpan ts1 = new TimeSpan(d1.Ticks);
                TimeSpan ts2 = new TimeSpan(d2.Ticks);
                TimeSpan ts = ts2.Subtract(ts1);

                result.AppendLine(string.Format("Time: [{0}h {1}m {2}s]", ts.Hours, ts.Minutes, ts.Seconds));

                if (ts.TotalSeconds > maxSec)
                {
                  maxID = item.Key;
                  maxSec = ts.TotalSeconds;
                }
              }

              string csv = ExtractWorld(curLine, @"([A-Za-z0-9_-]*).csv");
              result.AppendLine(string.Format("CSV: [{0}]", csv));

              string rows = ExtractWorld(curLine, @"at ([0-9]*) rows");
              result.AppendLine(rows);

              string size = ExtractWorld(curLine, @"size ([0-9]*) MB");
              result.AppendLine(size);
            }
          }
        }
      }

      if (result.Length == 0)
      {
        txtResult.Text = "done";
      }
      else
      {
        result.AppendLine("");
        result.AppendLine("==================================================");
        result.AppendLine(string.Format("Max ID: {0}", maxID));
        result.AppendLine(string.Format("Max Sec: {0}", maxSec));
        txtResult.Text = result.ToString();
      }
    }

    private string ExtractWorld(string log, string pattern)
    {
      var match = Regex.Match(log, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Singleline);
      return match.Value;
    }
  }
}
