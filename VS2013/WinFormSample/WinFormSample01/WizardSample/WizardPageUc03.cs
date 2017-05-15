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
  public partial class WizardPageUc03 : WizardPageTemplate
  {
    public WizardPageUc03()
    {
      InitializeComponent();
    }

    public override void SaveData()
    {
      if (ConfigOperator.Instance.ConfigEntity.DiskSetting == null)
      {
        ConfigOperator.Instance.ConfigEntity.DiskSetting = new DiskSetting();
      }

      DiskInfo diskInfo = new DiskInfo();
      Parition parition = new Parition();
      List<Parition> paritionList = new List<Parition>();
      List<DiskInfo> diskInfoList = new List<DiskInfo>();

      diskInfo.SerialNumber = Convert.ToInt32(txtSerialNumber.Text.Trim());
      parition.SerialNumber = Convert.ToInt32(txtParitionSerialNumber.Text.Trim());
      parition.FileSystem = txtParitionFileSystem.Text.Trim();
      parition.Driver = txtParitionDriver.Text.Trim();
      parition.Capacity = txtParitionUnit.Text.Trim();
      parition.Unit = Convert.ToInt32(txtParitionUnit.Text.Trim());
      parition.IsUseFreeCapacity = chbParitionIsUseFreeCapacity.Checked;

      paritionList.Add(parition);
      diskInfo.ParitionList = paritionList;
      diskInfoList.Add(diskInfo);
      ConfigOperator.Instance.ConfigEntity.DiskSetting.DiskInfoList = diskInfoList;

      ValidationMessage = "存储数据成功";
      ValidationStatus = true;
    }

    protected override void DisplayData()
    {
      //if (ConfigOperator.Instance.ConfigEntity.DiskSetting == null) return;

      
    }
  }
}
