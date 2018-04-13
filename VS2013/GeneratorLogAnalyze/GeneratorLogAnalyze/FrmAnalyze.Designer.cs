namespace GeneratorLogAnalyze
{
  partial class FrmAnalyze
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
      this.txtLogFile = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.btnAnalyze = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtLogFile
      // 
      this.txtLogFile.Location = new System.Drawing.Point(73, 6);
      this.txtLogFile.Multiline = true;
      this.txtLogFile.Name = "txtLogFile";
      this.txtLogFile.Size = new System.Drawing.Size(754, 23);
      this.txtLogFile.TabIndex = 11;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(12, 9);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(55, 13);
      this.Label1.TabIndex = 10;
      this.Label1.Text = "日志文件";
      // 
      // btnAnalyze
      // 
      this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAnalyze.Location = new System.Drawing.Point(833, 6);
      this.btnAnalyze.Name = "btnAnalyze";
      this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
      this.btnAnalyze.TabIndex = 16;
      this.btnAnalyze.Text = "开始";
      this.btnAnalyze.UseVisualStyleBackColor = true;
      this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(12, 35);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtResult.Size = new System.Drawing.Size(896, 626);
      this.txtResult.TabIndex = 17;
      // 
      // FrmAnalyze
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(914, 673);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.btnAnalyze);
      this.Controls.Add(this.txtLogFile);
      this.Controls.Add(this.Label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmAnalyze";
      this.Text = "Generator 日志分析";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.TextBox txtLogFile;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Button btnAnalyze;
    internal System.Windows.Forms.TextBox txtResult;
  }
}