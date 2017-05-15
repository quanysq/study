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
  public partial class WizardPageUc02 : WizardPageTemplate
  {
    public WizardPageUc02()
    {
      InitializeComponent();
    }

    public override void SaveData()
    {
      if (ConfigOperator.Instance.ConfigEntity.OSSetting == null)
      {
        ConfigOperator.Instance.ConfigEntity.OSSetting = new OSSetting();
      }

      ConfigOperator.Instance.ConfigEntity.OSSetting.OSType = Convert.ToInt32(txtOSType.Text.Trim());
      ConfigOperator.Instance.ConfigEntity.OSSetting.SoftSourceName = txtSoftSourceName.Text.Trim();

      ValidationMessage = "存储数据成功";
      ValidationStatus = true;
    }

    protected override void DisplayData()
    {
      if (ConfigOperator.Instance.ConfigEntity.OSSetting == null) return;

      txtOSType.Text = ConfigOperator.Instance.ConfigEntity.OSSetting.OSType.ToString();
      txtSoftSourceName.Text = ConfigOperator.Instance.ConfigEntity.OSSetting.SoftSourceName;
    }
  }
}
