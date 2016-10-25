namespace DBHelper
{
  partial class MSSQLDetail
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.DBHost_MSSQL = new System.Windows.Forms.TextBox();
      this.Catalog_MSSQL = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.DBPwd_MSSQL = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.DBUser_MSSQL = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // DBHost_MSSQL
      // 
      this.DBHost_MSSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.DBHost_MSSQL.Location = new System.Drawing.Point(127, 3);
      this.DBHost_MSSQL.Name = "DBHost_MSSQL";
      this.DBHost_MSSQL.Size = new System.Drawing.Size(262, 23);
      this.DBHost_MSSQL.TabIndex = 2;
      // 
      // Catalog_MSSQL
      // 
      this.Catalog_MSSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.Catalog_MSSQL.Location = new System.Drawing.Point(127, 131);
      this.Catalog_MSSQL.Name = "Catalog_MSSQL";
      this.Catalog_MSSQL.Size = new System.Drawing.Size(262, 23);
      this.Catalog_MSSQL.TabIndex = 5;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(1, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(87, 17);
      this.label2.TabIndex = 19;
      this.label2.Text = "Data Source";
      // 
      // DBPwd_MSSQL
      // 
      this.DBPwd_MSSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.DBPwd_MSSQL.Location = new System.Drawing.Point(127, 89);
      this.DBPwd_MSSQL.Name = "DBPwd_MSSQL";
      this.DBPwd_MSSQL.PasswordChar = '*';
      this.DBPwd_MSSQL.Size = new System.Drawing.Size(262, 23);
      this.DBPwd_MSSQL.TabIndex = 4;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label3.Location = new System.Drawing.Point(1, 46);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(75, 17);
      this.label3.TabIndex = 20;
      this.label3.Text = "UserName";
      // 
      // DBUser_MSSQL
      // 
      this.DBUser_MSSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.DBUser_MSSQL.Location = new System.Drawing.Point(127, 43);
      this.DBUser_MSSQL.Name = "DBUser_MSSQL";
      this.DBUser_MSSQL.Size = new System.Drawing.Size(262, 23);
      this.DBUser_MSSQL.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label4.Location = new System.Drawing.Point(1, 92);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(69, 17);
      this.label4.TabIndex = 21;
      this.label4.Text = "Password";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label5.Location = new System.Drawing.Point(0, 134);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(70, 17);
      this.label5.TabIndex = 22;
      this.label5.Text = "DataBase";
      // 
      // MSSQLDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.DBHost_MSSQL);
      this.Controls.Add(this.Catalog_MSSQL);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.DBPwd_MSSQL);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.DBUser_MSSQL);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label5);
      this.Name = "MSSQLDetail";
      this.Size = new System.Drawing.Size(395, 159);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox DBHost_MSSQL;
    private System.Windows.Forms.TextBox Catalog_MSSQL;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox DBPwd_MSSQL;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox DBUser_MSSQL;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;

  }
}
