using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBHelper.BLL;
using System.ServiceProcess;

namespace DBHelper
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      bool CanOpenMainForm = false;
      Login LoginFrm = new Login();
      LoginFrm.ShowDialog();
      if (LoginFrm.DialogResult == DialogResult.OK)
      {
        bool HasChooseDatabase = UserInfoBLL.CheckChooseDatabase();
        if (!HasChooseDatabase)
        {
          ChooseDatabase ChooseDatabaseFrm = new ChooseDatabase();
          ChooseDatabaseFrm.ShowDialog();
          if (ChooseDatabaseFrm.DialogResult == DialogResult.OK)
          {
            CanOpenMainForm = true;
          }
        }
        else
        {
          UserInfoBLL.GetChooseDatabase();
          CanOpenMainForm = true;
        }

        if (CanOpenMainForm)
        {
          Application.Run(new MainForm());
        }
      }
    }

    static bool IsServiceExisted(string ServiceName)
    {
      //TODO
      return true;
    }

    static void StartService(string ServiceName)
    {
      //TODO
    }
  }
}
