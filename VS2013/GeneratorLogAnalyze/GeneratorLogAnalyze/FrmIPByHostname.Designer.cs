namespace GeneratorLogAnalyze
{
  partial class FrmIPByHostname
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
      this.txtHostname = new System.Windows.Forms.TextBox();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.btnIP = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtHostname
      // 
      this.txtHostname.Location = new System.Drawing.Point(13, 2);
      this.txtHostname.Multiline = true;
      this.txtHostname.Name = "txtHostname";
      this.txtHostname.Size = new System.Drawing.Size(709, 109);
      this.txtHostname.TabIndex = 1;
      this.txtHostname.Text = "Please Input Host Name";
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(13, 146);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.Size = new System.Drawing.Size(708, 308);
      this.txtResult.TabIndex = 17;
      // 
      // btnIP
      // 
      this.btnIP.Location = new System.Drawing.Point(12, 117);
      this.btnIP.Name = "btnIP";
      this.btnIP.Size = new System.Drawing.Size(75, 23);
      this.btnIP.TabIndex = 16;
      this.btnIP.Text = "获取 IP";
      this.btnIP.UseVisualStyleBackColor = true;
      this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
      // 
      // FrmIPByHostname
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(733, 457);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnIP);
      this.Controls.Add(this.txtHostname);
      this.Name = "FrmIPByHostname";
      this.Text = "通过 Host Name 获取 IP";
      this.Load += new System.EventHandler(this.FrmIPByHostname_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtHostname;
    internal System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.Button btnIP;
  }
}