namespace DBHelper
{
  partial class InternalMethodSQLSt
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnOK = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.Statement = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 358);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(804, 45);
      this.panel2.TabIndex = 6;
      // 
      // btnOK
      // 
      this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnOK.Location = new System.Drawing.Point(700, 6);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 32);
      this.btnOK.TabIndex = 7;
      this.btnOK.Text = "保存";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.Statement);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(545, 358);
      this.panel1.TabIndex = 7;
      // 
      // Statement
      // 
      this.Statement.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Statement.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.Statement.Location = new System.Drawing.Point(0, 0);
      this.Statement.Multiline = true;
      this.Statement.Name = "Statement";
      this.Statement.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.Statement.Size = new System.Drawing.Size(545, 358);
      this.Statement.TabIndex = 3;
      this.Statement.WordWrap = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.groupBox1.Location = new System.Drawing.Point(545, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(259, 358);
      this.groupBox1.TabIndex = 8;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "高级功能";
      // 
      // InternalMethodSQLSt
      // 
      this.AcceptButton = this.btnOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "InternalMethodSQLSt";
      this.Text = "SQL语句";
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox Statement;

  }
}