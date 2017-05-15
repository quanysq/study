using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormSample01.WizardSample.WizardClass;

namespace WinFormSample01.WizardSample
{
  public partial class WizardMainFrm : Form
  {
    #region Field
    List<WizardPageTemplate> WizardSubPageList = new List<WizardPageTemplate>();
    WizardPageTemplate CurrentSubPage = null;
    #endregion

    #region Inner class
    enum OperationType
    {
      None,
      Back,
      Next
    }
    #endregion

    public WizardMainFrm()
    {
      InitializeComponent();
      AddWizardSubPage();
      this.Load += WizardMainFrm_Load;
    }

    void AddWizardSubPage()
    {
      WizardPageTemplate WizardSubPage1 = new WizardPageUc01() { IsFirstPage = true,  IsLastPage = false, PageOrder = 1 };
      WizardPageTemplate WizardSubPage2 = new WizardPageUc02() { IsFirstPage = false, IsLastPage = false, PageOrder = 2 };
      WizardPageTemplate WizardSubPage3 = new WizardPageUc03() { IsFirstPage = false, IsLastPage = true,  PageOrder = 3 };
      WizardSubPageList.Add(WizardSubPage1);
      WizardSubPageList.Add(WizardSubPage2);
      WizardSubPageList.Add(WizardSubPage3);
    }

    void WizardMainFrm_Load(object sender, EventArgs e)
    {
      try
      {
        //string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WizardSample", "WizardConfig.config");
        //ConfigEntity configEntity = XmlUtil.DeSerialize<ConfigEntity>(configPath);

        InitOperator();
        LoadWizardSubPage(OperationType.None);

        btnBack.Click += btnBack_Click;
        btnNext.Click += btnNext_Click;
        btnCancel.Click += btnCancel_Click;

        lblLine.AutoSize = false;
        lblLine.BorderStyle = BorderStyle.Fixed3D;
        lblLine.Height = 2;
        lblLine.Width = pnlMessage.Width;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    void InitOperator()
    {
      ConfigEntity configEntity = new ConfigEntity();
      ConfigOperator.Instance.ConfigEntity = configEntity;
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult dialogResult = MessageBox.Show("确实要退出向导吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
      if (dialogResult == System.Windows.Forms.DialogResult.OK)
      {
        Close();
      }
    }

    void btnNext_Click(object sender, EventArgs e)
    {
      CurrentSubPage.SaveData();
      if (!CurrentSubPage.ValidationStatus)
      {
        ShowErrorMessage(CurrentSubPage.ValidationMessage);
        return;
      }
      else
      {
        if (!string.IsNullOrEmpty(CurrentSubPage.ValidationMessage))
        {
          ShowSuccessMessage(CurrentSubPage.ValidationMessage);
        }
      }

      if (CurrentSubPage.IsLastPage)
      {
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WizardSample", "WizardConfigSave.config");
        ConfigOperator.Instance.SaveConfig(configPath);
        MessageBox.Show("提交成功");
        this.Close();
        return;
      }

      LoadWizardSubPage(OperationType.Next);

      btnBack.Visible = true;
      if (CurrentSubPage.IsLastPage)
      {
        btnNext.Text = "提交";
      }
    }

    void btnBack_Click(object sender, EventArgs e)
    {
      if (CurrentSubPage.IsFirstPage) return;

      LoadWizardSubPage(OperationType.Back);

      btnNext.Text = "Next";
      if (CurrentSubPage.IsFirstPage)
      {
        btnBack.Visible = false;
      }
    }

    void LoadWizardSubPage(OperationType operationType)
    {
      lblMessage.Visible = false;
      pnlSubPage.Controls.Clear();
      if (CurrentSubPage == null)
      {
        CurrentSubPage = WizardSubPageList.First(x => x.PageOrder == 1);
        btnBack.Visible = false;
      }
      else
      {
        if (operationType == OperationType.Next)
        {
          CurrentSubPage = WizardSubPageList.First(x => x.PageOrder == CurrentSubPage.PageOrder + 1 );
        }
        else if (operationType == OperationType.Back)
        {
          CurrentSubPage = WizardSubPageList.First(x => x.PageOrder == CurrentSubPage.PageOrder - 1 );
        }
      }
      if (CurrentSubPage != null)
      {
        pnlSubPage.Controls.Add(CurrentSubPage);
      }
    }

    void ShowErrorMessage(string errorMessage)
    {
      lblMessage.Text = errorMessage;
      lblMessage.ForeColor = Color.Red;
      CalcMessageLeftPosition();
      lblMessage.Visible = true;
    }

    void ShowSuccessMessage(string successMessage)
    {
      lblMessage.Text = successMessage;
      lblMessage.ForeColor = Color.Blue;
      CalcMessageLeftPosition();
      lblMessage.Visible = true;
    }

    void CalcMessageLeftPosition()
    {
      int totalWidth = pnlMessage.Width;
      int lblMessageWidth = lblMessage.Width;
      int x = (totalWidth - lblMessageWidth) / 2;
      lblMessage.Left = x;
    }
  }
}
