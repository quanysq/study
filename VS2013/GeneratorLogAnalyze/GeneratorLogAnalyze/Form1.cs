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
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void btnAnalyze_Click(object sender, EventArgs e)
    {
      var logFile         = txtLogFile.Text.Trim();
      var condiBegin      = txtCondiBegin.Text.Trim();
      var condiEnd        = txtCondiEnd.Text.Trim();
      var condiEndInclude = txtCondiEndinclude.Text.Trim().Split('#');

      if (string.IsNullOrWhiteSpace(logFile))
      {
        MessageBox.Show("Please input the log file path!");
        return;
      }

      using (StreamReader sr = new StreamReader(logFile, Encoding.UTF8))
      {
        bool insert = false;
        StringBuilder temp = new StringBuilder(1024);
        StringBuilder result = new StringBuilder(1024);
        int i = 0;

        while (true)
        {
          string lineLog = sr.ReadLine();
          if (lineLog == null) break;

          bool regexCondiBegin = Regex.IsMatch(lineLog, condiBegin);

          if (regexCondiBegin)
          {
            insert = true;
            temp.AppendLine(lineLog);
          }
          else
          {
            //continue;
            bool regexCondiEnd = Regex.IsMatch(lineLog, condiEnd);
            if (regexCondiEnd)
            {
              insert = false;

              bool valid = true;
              foreach (var item in condiEndInclude) 
              {
                if (lineLog.IndexOf(item) == -1)
                {
                  valid = false;
                  break;
                }
              }

              if (valid)
              {
                i++;
                temp.AppendLine(lineLog);
                temp.AppendLine("====================="+ i.ToString() +"====================");
                temp.AppendLine("");

                result.Append(temp);
              }

              temp.Clear();
            }
            else if (insert)
            {
              temp.AppendLine(lineLog);
            }
            else
            {
              continue;
            }
          }
        }

        if (result.Length == 0)
        {
          txtResult.Text = "done";
        }
        else
        {
          txtResult.Text = result.ToString();
        }
      }
    }
  }
}
