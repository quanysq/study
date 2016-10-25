namespace DBHelper
{
    partial class Login
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
      this.label1 = new System.Windows.Forms.Label();
      this.Usercode = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.Pwd = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(65, 49);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "用户名";
      // 
      // Usercode
      // 
      this.Usercode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.Usercode.Location = new System.Drawing.Point(121, 48);
      this.Usercode.Name = "Usercode";
      this.Usercode.Size = new System.Drawing.Size(189, 23);
      this.Usercode.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(65, 88);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 17);
      this.label2.TabIndex = 0;
      this.label2.Text = "密码";
      // 
      // Pwd
      // 
      this.Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.Pwd.Location = new System.Drawing.Point(121, 87);
      this.Pwd.Name = "Pwd";
      this.Pwd.PasswordChar = '*';
      this.Pwd.Size = new System.Drawing.Size(189, 23);
      this.Pwd.TabIndex = 2;
      // 
      // btnLogin
      // 
      this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnLogin.Location = new System.Drawing.Point(121, 126);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(75, 35);
      this.btnLogin.TabIndex = 3;
      this.btnLogin.Text = "登录";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // Login
      // 
      this.AcceptButton = this.btnLogin;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(396, 202);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.Pwd);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.Usercode);
      this.Controls.Add(this.label1);
      this.Name = "Login";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "登录";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Usercode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Pwd;
        private System.Windows.Forms.Button btnLogin;
    }
}