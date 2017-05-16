namespace WinFormSample02
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.txButton1 = new WinFormSample02.Controls.TXButton();
      this.txTextBox2 = new WinFormSample02.Controls.TXTextBox();
      this.txTextBox1 = new WinFormSample02.Controls.TXTextBox();
      this.SuspendLayout();
      // 
      // txButton1
      // 
      this.txButton1.Image = global::WinFormSample02.Properties.Resources.expand;
      this.txButton1.Location = new System.Drawing.Point(12, 94);
      this.txButton1.Name = "txButton1";
      this.txButton1.Size = new System.Drawing.Size(208, 45);
      this.txButton1.TabIndex = 2;
      this.txButton1.Text = "txButton1";
      this.txButton1.UseVisualStyleBackColor = true;
      // 
      // txTextBox2
      // 
      this.txTextBox2.BackColor = System.Drawing.Color.Transparent;
      this.txTextBox2.BorderColor = System.Drawing.Color.Red;
      this.txTextBox2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.txTextBox2.ForeColor = System.Drawing.SystemColors.WindowText;
      this.txTextBox2.HeightLightBolorColor = System.Drawing.Color.Blue;
      this.txTextBox2.Image = null;
      this.txTextBox2.ImageSize = new System.Drawing.Size(0, 0);
      this.txTextBox2.Location = new System.Drawing.Point(12, 63);
      this.txTextBox2.Name = "txTextBox2";
      this.txTextBox2.Padding = new System.Windows.Forms.Padding(2);
      this.txTextBox2.PasswordChar = '\0';
      this.txTextBox2.Required = false;
      this.txTextBox2.Size = new System.Drawing.Size(180, 25);
      this.txTextBox2.TabIndex = 1;
      // 
      // txTextBox1
      // 
      this.txTextBox1.BackColor = System.Drawing.Color.Transparent;
      this.txTextBox1.BorderColor = System.Drawing.Color.Maroon;
      this.txTextBox1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.txTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.txTextBox1.HeightLightBolorColor = System.Drawing.Color.Blue;
      this.txTextBox1.Image = ((System.Drawing.Image)(resources.GetObject("txTextBox1.Image")));
      this.txTextBox1.ImageAlignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.txTextBox1.ImageSize = new System.Drawing.Size(14, 14);
      this.txTextBox1.Location = new System.Drawing.Point(12, 12);
      this.txTextBox1.Name = "txTextBox1";
      this.txTextBox1.Padding = new System.Windows.Forms.Padding(2);
      this.txTextBox1.PasswordChar = '\0';
      this.txTextBox1.Required = false;
      this.txTextBox1.Size = new System.Drawing.Size(244, 34);
      this.txTextBox1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(538, 458);
      this.Controls.Add(this.txButton1);
      this.Controls.Add(this.txTextBox2);
      this.Controls.Add(this.txTextBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.TXTextBox txTextBox1;
    private Controls.TXTextBox txTextBox2;
    private Controls.TXButton txButton1;
  }
}

