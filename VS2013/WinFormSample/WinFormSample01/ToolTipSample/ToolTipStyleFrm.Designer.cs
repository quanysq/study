namespace WinFormSample01.ToolTipSample
{
  partial class ToolTipStyleFrm
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
      this.components = new System.ComponentModel.Container();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.textBox2 = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(32, 47);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(177, 20);
      this.textBox1.TabIndex = 0;
      // 
      // toolTip1
      // 
      this.toolTip1.IsBalloon = true;
      this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
      this.toolTip1.ToolTipTitle = "提示";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(32, 94);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(177, 20);
      this.textBox2.TabIndex = 1;
      // 
      // ToolTipStyleFrm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 262);
      this.Controls.Add(this.textBox2);
      this.Controls.Add(this.textBox1);
      this.Name = "ToolTipStyleFrm";
      this.Text = "ToolTipStyleFrm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.TextBox textBox2;
  }
}