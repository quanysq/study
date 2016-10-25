namespace DBHelper
{
  partial class Error
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
      this.txtMessage = new System.Windows.Forms.TextBox();
      this.txtStackTrace = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtMessage
      // 
      this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtMessage.Location = new System.Drawing.Point(2, 2);
      this.txtMessage.Name = "txtMessage";
      this.txtMessage.ReadOnly = true;
      this.txtMessage.Size = new System.Drawing.Size(709, 23);
      this.txtMessage.TabIndex = 0;
      // 
      // txtStackTrace
      // 
      this.txtStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtStackTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtStackTrace.Location = new System.Drawing.Point(2, 31);
      this.txtStackTrace.Multiline = true;
      this.txtStackTrace.Name = "txtStackTrace";
      this.txtStackTrace.ReadOnly = true;
      this.txtStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtStackTrace.Size = new System.Drawing.Size(709, 394);
      this.txtStackTrace.TabIndex = 1;
      this.txtStackTrace.WordWrap = false;
      // 
      // Error
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(713, 429);
      this.Controls.Add(this.txtStackTrace);
      this.Controls.Add(this.txtMessage);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Error";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Error";
      this.Load += new System.EventHandler(this.Error_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtMessage;
    private System.Windows.Forms.TextBox txtStackTrace;
  }
}