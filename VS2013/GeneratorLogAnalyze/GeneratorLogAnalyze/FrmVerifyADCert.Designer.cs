namespace GeneratorLogAnalyze
{
  partial class FrmVerifyADCert
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
      this.Label1 = new System.Windows.Forms.Label();
      this.txtServer = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtLogonDN = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtPwd = new System.Windows.Forms.TextBox();
      this.btnVefify = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.chkSSL = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(20, 11);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(38, 13);
      this.Label1.TabIndex = 11;
      this.Label1.Text = "Server";
      // 
      // txtServer
      // 
      this.txtServer.Location = new System.Drawing.Point(59, 7);
      this.txtServer.Multiline = true;
      this.txtServer.Name = "txtServer";
      this.txtServer.Size = new System.Drawing.Size(627, 23);
      this.txtServer.TabIndex = 12;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(700, 11);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(26, 13);
      this.label2.TabIndex = 13;
      this.label2.Text = "Port";
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(725, 7);
      this.txtPort.Multiline = true;
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(83, 23);
      this.txtPort.TabIndex = 14;
      this.txtPort.Text = "636";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(2, 42);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(56, 13);
      this.label3.TabIndex = 15;
      this.label3.Text = "Logon DN";
      // 
      // txtLogonDN
      // 
      this.txtLogonDN.Location = new System.Drawing.Point(59, 37);
      this.txtLogonDN.Multiline = true;
      this.txtLogonDN.Name = "txtLogonDN";
      this.txtLogonDN.Size = new System.Drawing.Size(627, 23);
      this.txtLogonDN.TabIndex = 16;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(693, 42);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(28, 13);
      this.label4.TabIndex = 17;
      this.label4.Text = "Pwd";
      // 
      // txtPwd
      // 
      this.txtPwd.Location = new System.Drawing.Point(725, 37);
      this.txtPwd.Multiline = true;
      this.txtPwd.Name = "txtPwd";
      this.txtPwd.Size = new System.Drawing.Size(83, 23);
      this.txtPwd.TabIndex = 18;
      // 
      // btnVefify
      // 
      this.btnVefify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnVefify.Location = new System.Drawing.Point(814, 37);
      this.btnVefify.Name = "btnVefify";
      this.btnVefify.Size = new System.Drawing.Size(75, 23);
      this.btnVefify.TabIndex = 19;
      this.btnVefify.Text = "开始";
      this.btnVefify.UseVisualStyleBackColor = true;
      this.btnVefify.Click += new System.EventHandler(this.btnVefify_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(59, 66);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtResult.Size = new System.Drawing.Size(830, 595);
      this.txtResult.TabIndex = 20;
      // 
      // chkSSL
      // 
      this.chkSSL.AutoSize = true;
      this.chkSSL.Checked = true;
      this.chkSSL.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkSSL.Location = new System.Drawing.Point(815, 11);
      this.chkSSL.Name = "chkSSL";
      this.chkSSL.Size = new System.Drawing.Size(46, 17);
      this.chkSSL.TabIndex = 21;
      this.chkSSL.Text = "SSL";
      this.chkSSL.UseVisualStyleBackColor = true;
      // 
      // FrmVerifyADCert
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(895, 667);
      this.Controls.Add(this.chkSSL);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnVefify);
      this.Controls.Add(this.txtPwd);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtLogonDN);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtPort);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtServer);
      this.Controls.Add(this.Label1);
      this.Name = "FrmVerifyADCert";
      this.Text = "验证 LDAP/AD Server 证书";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.TextBox txtServer;
    internal System.Windows.Forms.Label label2;
    internal System.Windows.Forms.TextBox txtPort;
    internal System.Windows.Forms.Label label3;
    internal System.Windows.Forms.TextBox txtLogonDN;
    internal System.Windows.Forms.Label label4;
    internal System.Windows.Forms.TextBox txtPwd;
    internal System.Windows.Forms.Button btnVefify;
    internal System.Windows.Forms.TextBox txtResult;
    private System.Windows.Forms.CheckBox chkSSL;
  }
}