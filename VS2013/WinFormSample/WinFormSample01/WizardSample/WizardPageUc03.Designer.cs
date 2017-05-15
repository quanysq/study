namespace WinFormSample01.WizardSample
{
  partial class WizardPageUc03
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.txtSerialNumber = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtParitionSerialNumber = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtParitionFileSystem = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtParitionDriver = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.txtParitionCapacity = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.txtParitionUnit = new System.Windows.Forms.TextBox();
      this.chbParitionIsUseFreeCapacity = new System.Windows.Forms.CheckBox();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtSerialNumber
      // 
      this.txtSerialNumber.Location = new System.Drawing.Point(110, 30);
      this.txtSerialNumber.Name = "txtSerialNumber";
      this.txtSerialNumber.Size = new System.Drawing.Size(257, 20);
      this.txtSerialNumber.TabIndex = 9;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(30, 30);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(70, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "SerialNumber";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.chbParitionIsUseFreeCapacity);
      this.groupBox1.Controls.Add(this.txtParitionUnit);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.txtParitionCapacity);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.txtParitionDriver);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtParitionFileSystem);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txtParitionSerialNumber);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Location = new System.Drawing.Point(33, 70);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(567, 264);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Parition";
      // 
      // txtParitionSerialNumber
      // 
      this.txtParitionSerialNumber.Location = new System.Drawing.Point(140, 37);
      this.txtParitionSerialNumber.Name = "txtParitionSerialNumber";
      this.txtParitionSerialNumber.Size = new System.Drawing.Size(257, 20);
      this.txtParitionSerialNumber.TabIndex = 11;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(60, 37);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(70, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "SerialNumber";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(60, 75);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 13);
      this.label3.TabIndex = 10;
      this.label3.Text = "FileSystem";
      // 
      // txtParitionFileSystem
      // 
      this.txtParitionFileSystem.Location = new System.Drawing.Point(140, 75);
      this.txtParitionFileSystem.Name = "txtParitionFileSystem";
      this.txtParitionFileSystem.Size = new System.Drawing.Size(257, 20);
      this.txtParitionFileSystem.TabIndex = 11;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(60, 112);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(35, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Driver";
      // 
      // txtParitionDriver
      // 
      this.txtParitionDriver.Location = new System.Drawing.Point(140, 112);
      this.txtParitionDriver.Name = "txtParitionDriver";
      this.txtParitionDriver.Size = new System.Drawing.Size(257, 20);
      this.txtParitionDriver.TabIndex = 11;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(60, 147);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(48, 13);
      this.label5.TabIndex = 10;
      this.label5.Text = "Capacity";
      // 
      // txtParitionCapacity
      // 
      this.txtParitionCapacity.Location = new System.Drawing.Point(140, 147);
      this.txtParitionCapacity.Name = "txtParitionCapacity";
      this.txtParitionCapacity.Size = new System.Drawing.Size(257, 20);
      this.txtParitionCapacity.TabIndex = 11;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(60, 183);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(26, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Unit";
      // 
      // txtParitionUnit
      // 
      this.txtParitionUnit.Location = new System.Drawing.Point(140, 183);
      this.txtParitionUnit.Name = "txtParitionUnit";
      this.txtParitionUnit.Size = new System.Drawing.Size(257, 20);
      this.txtParitionUnit.TabIndex = 11;
      // 
      // chbParitionIsUseFreeCapacity
      // 
      this.chbParitionIsUseFreeCapacity.AutoSize = true;
      this.chbParitionIsUseFreeCapacity.Location = new System.Drawing.Point(140, 220);
      this.chbParitionIsUseFreeCapacity.Name = "chbParitionIsUseFreeCapacity";
      this.chbParitionIsUseFreeCapacity.Size = new System.Drawing.Size(115, 17);
      this.chbParitionIsUseFreeCapacity.TabIndex = 12;
      this.chbParitionIsUseFreeCapacity.Text = "IsUseFreeCapacity";
      this.chbParitionIsUseFreeCapacity.UseVisualStyleBackColor = true;
      // 
      // WizardPageUc03
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtSerialNumber);
      this.Controls.Add(this.label1);
      this.Name = "WizardPageUc03";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSerialNumber;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckBox chbParitionIsUseFreeCapacity;
    private System.Windows.Forms.TextBox txtParitionUnit;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtParitionCapacity;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtParitionDriver;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtParitionFileSystem;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtParitionSerialNumber;
    private System.Windows.Forms.Label label2;

  }
}
