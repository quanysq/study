using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormSample01.WizardSample.WizardClass;

namespace WinFormSample01.WizardSample
{
  public partial class WizardPageUc01 : WizardPageTemplate
  {
    public WizardPageUc01()
    {
      InitializeComponent();
    }

    public override void SaveData()
    {
      if (ConfigOperator.Instance.ConfigEntity.BaseInfo == null)
      {
        ConfigOperator.Instance.ConfigEntity.BaseInfo = new BaseInfo();
      }

      ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateName = txtTemplateName.Text.Trim();
      ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateType = txtTemplateType.Text.Trim();
      ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateDesc = txtTemplateDesc.Text.Trim();

      ValidationMessage = "存储数据成功";
      ValidationStatus = true;
    }

    protected override void DisplayData()
    {
      if (ConfigOperator.Instance.ConfigEntity.BaseInfo == null) return;

      txtTemplateName.Text = ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateName;
      txtTemplateType.Text = ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateType;
      txtTemplateDesc.Text = ConfigOperator.Instance.ConfigEntity.BaseInfo.TemplateDesc;
    }
  }
}
