namespace DBHelper
{
  partial class ModifyPwd
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
      this.btnChange = new System.Windows.Forms.Button();
      this.NewPwd = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.OldPwd = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.ConfrimPwd = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnChange
      // 
      this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnChange.Location = new System.Drawing.Point(132, 170);
      this.btnChange.Name = "btnChange";
      this.btnChange.Size = new System.Drawing.Size(75, 35);
      this.btnChange.TabIndex = 4;
      this.btnChange.Text = "登录";
      this.btnChange.UseVisualStyleBackColor = true;
      this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
      // 
      // NewPwd
      // 
      this.NewPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.NewPwd.Location = new System.Drawing.Point(132, 83);
      this.NewPwd.Name = "NewPwd";
      this.NewPwd.PasswordChar = '*';
      this.NewPwd.Size = new System.Drawing.Size(189, 23);
      this.NewPwd.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(48, 85);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "新密码";
      // 
      // OldPwd
      // 
      this.OldPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.OldPwd.Location = new System.Drawing.Point(132, 41);
      this.OldPwd.Name = "OldPwd";
      this.OldPwd.PasswordChar = '*';
      this.OldPwd.Size = new System.Drawing.Size(189, 23);
      this.OldPwd.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(48, 42);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 17);
      this.label1.TabIndex = 5;
      this.label1.Text = "旧密码";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label3.Location = new System.Drawing.Point(48, 127);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(78, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "确认新密码";
      // 
      // ConfrimPwd
      // 
      this.ConfrimPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.ConfrimPwd.Location = new System.Drawing.Point(132, 126);
      this.ConfrimPwd.Name = "ConfrimPwd";
      this.ConfrimPwd.PasswordChar = '*';
      this.ConfrimPwd.Size = new System.Drawing.Size(189, 23);
      this.ConfrimPwd.TabIndex = 3;
      // 
      // ModifyPwd
      // 
      this.AcceptButton = this.btnChange;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(396, 237);
      this.Controls.Add(this.btnChange);
      this.Controls.Add(this.ConfrimPwd);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.NewPwd);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.OldPwd);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.Name = "ModifyPwd";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "更改密码";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnChange;
    private System.Windows.Forms.TextBox NewPwd;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox OldPwd;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox ConfrimPwd;
  }
}