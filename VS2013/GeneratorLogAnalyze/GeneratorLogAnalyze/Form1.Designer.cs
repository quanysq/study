namespace GeneratorLogAnalyze
{
  partial class Form1
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
      this.btnAnalyze = new System.Windows.Forms.Button();
      this.txtResult = new System.Windows.Forms.TextBox();
      this.txtCondiEnd = new System.Windows.Forms.TextBox();
      this.Label3 = new System.Windows.Forms.Label();
      this.txtCondiBegin = new System.Windows.Forms.TextBox();
      this.Label2 = new System.Windows.Forms.Label();
      this.txtLogFile = new System.Windows.Forms.TextBox();
      this.Label1 = new System.Windows.Forms.Label();
      this.txtCondiEndinclude = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnAnalyze
      // 
      this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAnalyze.Location = new System.Drawing.Point(824, 121);
      this.btnAnalyze.Name = "btnAnalyze";
      this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
      this.btnAnalyze.TabIndex = 15;
      this.btnAnalyze.Text = "开始";
      this.btnAnalyze.UseVisualStyleBackColor = true;
      this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
      // 
      // txtResult
      // 
      this.txtResult.Location = new System.Drawing.Point(14, 150);
      this.txtResult.Multiline = true;
      this.txtResult.Name = "txtResult";
      this.txtResult.ReadOnly = true;
      this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtResult.Size = new System.Drawing.Size(885, 509);
      this.txtResult.TabIndex = 14;
      // 
      // txtCondiEnd
      // 
      this.txtCondiEnd.Location = new System.Drawing.Point(88, 92);
      this.txtCondiEnd.Multiline = true;
      this.txtCondiEnd.Name = "txtCondiEnd";
      this.txtCondiEnd.Size = new System.Drawing.Size(811, 23);
      this.txtCondiEnd.TabIndex = 13;
      // 
      // Label3
      // 
      this.Label3.AutoSize = true;
      this.Label3.Location = new System.Drawing.Point(13, 95);
      this.Label3.Name = "Label3";
      this.Label3.Size = new System.Drawing.Size(67, 13);
      this.Label3.TabIndex = 12;
      this.Label3.Text = "条件结束行";
      // 
      // txtCondiBegin
      // 
      this.txtCondiBegin.Location = new System.Drawing.Point(88, 51);
      this.txtCondiBegin.Name = "txtCondiBegin";
      this.txtCondiBegin.Size = new System.Drawing.Size(811, 20);
      this.txtCondiBegin.TabIndex = 11;
      // 
      // Label2
      // 
      this.Label2.AutoSize = true;
      this.Label2.Location = new System.Drawing.Point(13, 54);
      this.Label2.Name = "Label2";
      this.Label2.Size = new System.Drawing.Size(67, 13);
      this.Label2.TabIndex = 10;
      this.Label2.Text = "条件起始行";
      // 
      // txtLogFile
      // 
      this.txtLogFile.Location = new System.Drawing.Point(88, 14);
      this.txtLogFile.Name = "txtLogFile";
      this.txtLogFile.Size = new System.Drawing.Size(811, 20);
      this.txtLogFile.TabIndex = 9;
      // 
      // Label1
      // 
      this.Label1.AutoSize = true;
      this.Label1.Location = new System.Drawing.Point(13, 17);
      this.Label1.Name = "Label1";
      this.Label1.Size = new System.Drawing.Size(55, 13);
      this.Label1.TabIndex = 8;
      this.Label1.Text = "日志文件";
      // 
      // txtCondiEndinclude
      // 
      this.txtCondiEndinclude.Location = new System.Drawing.Point(88, 121);
      this.txtCondiEndinclude.Multiline = true;
      this.txtCondiEndinclude.Name = "txtCondiEndinclude";
      this.txtCondiEndinclude.Size = new System.Drawing.Size(731, 23);
      this.txtCondiEndinclude.TabIndex = 17;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(914, 673);
      this.Controls.Add(this.txtCondiEndinclude);
      this.Controls.Add(this.btnAnalyze);
      this.Controls.Add(this.txtResult);
      this.Controls.Add(this.txtCondiEnd);
      this.Controls.Add(this.Label3);
      this.Controls.Add(this.txtCondiBegin);
      this.Controls.Add(this.Label2);
      this.Controls.Add(this.txtLogFile);
      this.Controls.Add(this.Label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Generator 日志提取器（正则）";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    internal System.Windows.Forms.Button btnAnalyze;
    internal System.Windows.Forms.TextBox txtResult;
    internal System.Windows.Forms.TextBox txtCondiEnd;
    internal System.Windows.Forms.Label Label3;
    internal System.Windows.Forms.TextBox txtCondiBegin;
    internal System.Windows.Forms.Label Label2;
    internal System.Windows.Forms.TextBox txtLogFile;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.TextBox txtCondiEndinclude;
  }
}

