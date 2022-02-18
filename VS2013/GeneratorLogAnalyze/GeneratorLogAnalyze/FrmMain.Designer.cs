namespace GeneratorLogAnalyze
{
  partial class FrmMain
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.MenuMain = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemExtractor = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemAnalyze = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuSimpleTools = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemDateSubtract = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemEncrypt = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemConver2Base64 = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemIP = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuCertificate = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemADCert = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemSpecificCert = new System.Windows.Forms.ToolStripMenuItem();
      this.MenuItemTUS = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuMain,
            this.MenuSimpleTools,
            this.MenuCertificate});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1352, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // MenuMain
      // 
      this.MenuMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemExtractor,
            this.MenuItemAnalyze});
      this.MenuMain.Name = "MenuMain";
      this.MenuMain.Size = new System.Drawing.Size(126, 20);
      this.MenuMain.Text = "Generator 日志分析";
      // 
      // MenuItemExtractor
      // 
      this.MenuItemExtractor.Name = "MenuItemExtractor";
      this.MenuItemExtractor.Size = new System.Drawing.Size(126, 22);
      this.MenuItemExtractor.Text = "日志提取";
      this.MenuItemExtractor.Click += new System.EventHandler(this.MenuItemExtractor_Click);
      // 
      // MenuItemAnalyze
      // 
      this.MenuItemAnalyze.Name = "MenuItemAnalyze";
      this.MenuItemAnalyze.Size = new System.Drawing.Size(126, 22);
      this.MenuItemAnalyze.Text = "日志分析";
      this.MenuItemAnalyze.Click += new System.EventHandler(this.MenuItemAnalyze_Click);
      // 
      // MenuSimpleTools
      // 
      this.MenuSimpleTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemDateSubtract,
            this.MenuItemEncrypt,
            this.MenuItemConver2Base64,
            this.MenuItemIP,
            this.MenuItemTUS});
      this.MenuSimpleTools.Name = "MenuSimpleTools";
      this.MenuSimpleTools.Size = new System.Drawing.Size(84, 20);
      this.MenuSimpleTools.Text = "简便小工具";
      // 
      // MenuItemDateSubtract
      // 
      this.MenuItemDateSubtract.Name = "MenuItemDateSubtract";
      this.MenuItemDateSubtract.Size = new System.Drawing.Size(152, 22);
      this.MenuItemDateSubtract.Text = "日期相减";
      this.MenuItemDateSubtract.Click += new System.EventHandler(this.MenuItemDateSubtract_Click);
      // 
      // MenuItemEncrypt
      // 
      this.MenuItemEncrypt.Name = "MenuItemEncrypt";
      this.MenuItemEncrypt.Size = new System.Drawing.Size(152, 22);
      this.MenuItemEncrypt.Text = "BDNA加解密";
      this.MenuItemEncrypt.Click += new System.EventHandler(this.MenuItemEncrypt_Click);
      // 
      // MenuItemConver2Base64
      // 
      this.MenuItemConver2Base64.Name = "MenuItemConver2Base64";
      this.MenuItemConver2Base64.Size = new System.Drawing.Size(152, 22);
      this.MenuItemConver2Base64.Text = "Covert2Base64";
      this.MenuItemConver2Base64.Click += new System.EventHandler(this.MenuItemConver2Base64_Click);
      // 
      // MenuItemIP
      // 
      this.MenuItemIP.Name = "MenuItemIP";
      this.MenuItemIP.Size = new System.Drawing.Size(152, 22);
      this.MenuItemIP.Text = "Get IP";
      this.MenuItemIP.Click += new System.EventHandler(this.MenuItemIP_Click);
      // 
      // MenuCertificate
      // 
      this.MenuCertificate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemADCert,
            this.MenuItemSpecificCert});
      this.MenuCertificate.Name = "MenuCertificate";
      this.MenuCertificate.Size = new System.Drawing.Size(45, 20);
      this.MenuCertificate.Text = "证书";
      // 
      // MenuItemADCert
      // 
      this.MenuItemADCert.Name = "MenuItemADCert";
      this.MenuItemADCert.Size = new System.Drawing.Size(217, 22);
      this.MenuItemADCert.Text = "验证 LDAP/AD Server 证书";
      this.MenuItemADCert.Click += new System.EventHandler(this.MenuItemADCert_Click);
      // 
      // MenuItemSpecificCert
      // 
      this.MenuItemSpecificCert.Name = "MenuItemSpecificCert";
      this.MenuItemSpecificCert.Size = new System.Drawing.Size(217, 22);
      this.MenuItemSpecificCert.Text = "验证指定证书";
      this.MenuItemSpecificCert.Click += new System.EventHandler(this.MenuItemSpecificCert_Click);
      // 
      // MenuItemTUS
      // 
      this.MenuItemTUS.Name = "MenuItemTUS";
      this.MenuItemTUS.Size = new System.Drawing.Size(152, 22);
      this.MenuItemTUS.Text = "解密 TUS 参数";
      this.MenuItemTUS.Click += new System.EventHandler(this.MenuItemTUS_Click);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1352, 805);
      this.Controls.Add(this.menuStrip1);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "FrmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Generator 日志分析器";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem MenuMain;
    private System.Windows.Forms.ToolStripMenuItem MenuItemExtractor;
    private System.Windows.Forms.ToolStripMenuItem MenuItemAnalyze;
    private System.Windows.Forms.ToolStripMenuItem MenuSimpleTools;
    private System.Windows.Forms.ToolStripMenuItem MenuItemDateSubtract;
    private System.Windows.Forms.ToolStripMenuItem MenuItemEncrypt;
    private System.Windows.Forms.ToolStripMenuItem MenuItemConver2Base64;
    private System.Windows.Forms.ToolStripMenuItem MenuItemIP;
    private System.Windows.Forms.ToolStripMenuItem MenuCertificate;
    private System.Windows.Forms.ToolStripMenuItem MenuItemADCert;
    private System.Windows.Forms.ToolStripMenuItem MenuItemSpecificCert;
    private System.Windows.Forms.ToolStripMenuItem MenuItemTUS;
  }
}