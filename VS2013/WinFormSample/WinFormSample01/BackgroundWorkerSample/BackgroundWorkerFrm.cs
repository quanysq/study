using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormSample01.BackgroundWorkerSample
{
  public partial class BackgroundWorkerFrm : Form
  {
    BackgroundWorker m_BackgroundWorker;      //声明后台对象

    public BackgroundWorkerFrm()
    {
      InitializeComponent();

      m_BackgroundWorker = new BackgroundWorker();      //实例化后台对象
      m_BackgroundWorker.WorkerReportsProgress = true;      //设置可以通告进度
      m_BackgroundWorker.WorkerSupportsCancellation = true;     //设置可以取消

      m_BackgroundWorker.DoWork += m_BackgroundWorker_DoWork;
      m_BackgroundWorker.ProgressChanged += m_BackgroundWorker_ProgressChanged;
      m_BackgroundWorker.RunWorkerCompleted += m_BackgroundWorker_RunWorkerCompleted;

      button1.Click += button1_Click;

      m_BackgroundWorker.RunWorkerAsync(this);      //启动后台线程
    }

    void button1_Click(object sender, EventArgs e)
    {
      m_BackgroundWorker.CancelAsync();
    }

    void m_BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      if (e.Error != null)
      {
        MessageBox.Show("Error:" + Environment.NewLine + "很严重的错误");
      }
      else if (e.Cancelled)
      {
        MessageBox.Show("Canceled");
      }
      else
      {
        MessageBox.Show("Completed");
      }
    }

    void m_BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      int progress = e.ProgressPercentage;
      label1.Text = string.Format("{0}%", progress);
    }

    void m_BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      BackgroundWorker bw = sender as BackgroundWorker;
      BackgroundWorkerFrm win = e.Argument as BackgroundWorkerFrm;

      int i = 0;
      while (i <= 100)
      {
        if (bw.CancellationPending)
        {
          e.Cancel = true;
          break;
        }

        bw.ReportProgress(i++);

        Thread.Sleep(1000);
      }
    }
  }
}
