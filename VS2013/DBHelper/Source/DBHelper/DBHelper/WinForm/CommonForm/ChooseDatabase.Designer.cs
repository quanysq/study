namespace DBHelper
{
  partial class ChooseDatabase
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.DataBaseType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.ConnectionName = new System.Windows.Forms.TextBox();
      this.btnTest = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.lblTestResult = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // DataBaseType
      // 
      this.DataBaseType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.DataBaseType.FormattingEnabled = true;
      this.DataBaseType.Location = new System.Drawing.Point(174, 28);
      this.DataBaseType.Name = "DataBaseType";
      this.DataBaseType.Size = new System.Drawing.Size(262, 25);
      this.DataBaseType.TabIndex = 0;
      this.DataBaseType.SelectedIndexChanged += new System.EventHandler(this.DataBaseType_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(48, 82);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(120, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Connection Name";
      // 
      // ConnectionName
      // 
      this.ConnectionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConnectionName.Location = new System.Drawing.Point(174, 79);
      this.ConnectionName.Name = "ConnectionName";
      this.ConnectionName.Size = new System.Drawing.Size(262, 23);
      this.ConnectionName.TabIndex = 1;
      // 
      // btnTest
      // 
      this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnTest.Location = new System.Drawing.Point(174, 360);
      this.btnTest.Name = "btnTest";
      this.btnTest.Size = new System.Drawing.Size(106, 35);
      this.btnTest.TabIndex = 8;
      this.btnTest.Text = "测试连接";
      this.btnTest.UseVisualStyleBackColor = true;
      this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
      // 
      // btnOK
      // 
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(174, 411);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(106, 35);
      this.btnOK.TabIndex = 9;
      this.btnOK.Text = "确定";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // lblTestResult
      // 
      this.lblTestResult.AutoSize = true;
      this.lblTestResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.lblTestResult.Location = new System.Drawing.Point(286, 369);
      this.lblTestResult.Name = "lblTestResult";
      this.lblTestResult.Size = new System.Drawing.Size(0, 17);
      this.lblTestResult.TabIndex = 1;
      // 
      // ChooseDatabase
      // 
      this.AcceptButton = this.btnTest;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(532, 467);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnTest);
      this.Controls.Add(this.ConnectionName);
      this.Controls.Add(this.lblTestResult);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.DataBaseType);
      this.MaximizeBox = false;
      this.Name = "ChooseDatabase";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "选择数据库";
      this.Load += new System.EventHandler(this.ChooseDatabase_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox DataBaseType;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox ConnectionName;
    private System.Windows.Forms.Button btnTest;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label lblTestResult;
  }
}