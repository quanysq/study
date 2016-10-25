namespace DBHelper
{
  partial class DeveloperMgr
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.gvUser = new System.Windows.Forms.DataGridView();
      this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Usercode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IsAddSelf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.IsEditSelf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.IsDeleteSelf = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.IsEditOther = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.IsDeleteOther = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.HasDeleted = new System.Windows.Forms.DataGridViewLinkColumn();
      this.btnNewDeveloper = new System.Windows.Forms.Button();
      this.txtUsercode = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtUsername = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
      this.SuspendLayout();
      // 
      // gvUser
      // 
      this.gvUser.AllowUserToAddRows = false;
      this.gvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.Usercode,
            this.UserName,
            this.IsAddSelf,
            this.IsEditSelf,
            this.IsDeleteSelf,
            this.IsEditOther,
            this.IsDeleteOther,
            this.HasDeleted});
      this.gvUser.Location = new System.Drawing.Point(3, 2);
      this.gvUser.Name = "gvUser";
      this.gvUser.Size = new System.Drawing.Size(857, 440);
      this.gvUser.TabIndex = 0;
      this.gvUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvUser_CellContentClick);
      // 
      // UserID
      // 
      this.UserID.DataPropertyName = "UserID";
      this.UserID.HeaderText = "ID";
      this.UserID.Name = "UserID";
      this.UserID.ReadOnly = true;
      this.UserID.Visible = false;
      // 
      // Usercode
      // 
      this.Usercode.DataPropertyName = "Usercode";
      this.Usercode.HeaderText = "用户名";
      this.Usercode.Name = "Usercode";
      this.Usercode.ReadOnly = true;
      this.Usercode.Width = 80;
      // 
      // UserName
      // 
      this.UserName.DataPropertyName = "Username";
      this.UserName.HeaderText = "姓名";
      this.UserName.Name = "UserName";
      this.UserName.ReadOnly = true;
      this.UserName.Width = 90;
      // 
      // IsAddSelf
      // 
      this.IsAddSelf.DataPropertyName = "IsAddSelf";
      this.IsAddSelf.HeaderText = "添加权限";
      this.IsAddSelf.Name = "IsAddSelf";
      this.IsAddSelf.TrueValue = "1";
      this.IsAddSelf.Width = 80;
      // 
      // IsEditSelf
      // 
      this.IsEditSelf.DataPropertyName = "IsEditSelf";
      this.IsEditSelf.HeaderText = "编辑权限";
      this.IsEditSelf.Name = "IsEditSelf";
      this.IsEditSelf.TrueValue = "1";
      this.IsEditSelf.Width = 80;
      // 
      // IsDeleteSelf
      // 
      this.IsDeleteSelf.DataPropertyName = "IsDeleteSelf";
      this.IsDeleteSelf.HeaderText = "删除权限";
      this.IsDeleteSelf.Name = "IsDeleteSelf";
      this.IsDeleteSelf.TrueValue = "1";
      this.IsDeleteSelf.Width = 80;
      // 
      // IsEditOther
      // 
      this.IsEditOther.DataPropertyName = "IsEditOther";
      this.IsEditOther.HeaderText = "修改他人权限";
      this.IsEditOther.Name = "IsEditOther";
      this.IsEditOther.TrueValue = "1";
      // 
      // IsDeleteOther
      // 
      this.IsDeleteOther.DataPropertyName = "IsDeleteOther";
      this.IsDeleteOther.HeaderText = "删除他人权限";
      this.IsDeleteOther.Name = "IsDeleteOther";
      this.IsDeleteOther.TrueValue = "1";
      // 
      // HasDeleted
      // 
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      this.HasDeleted.DefaultCellStyle = dataGridViewCellStyle1;
      this.HasDeleted.HeaderText = "";
      this.HasDeleted.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.HasDeleted.Name = "HasDeleted";
      this.HasDeleted.Text = "删除";
      this.HasDeleted.UseColumnTextForLinkValue = true;
      this.HasDeleted.Width = 60;
      // 
      // btnNewDeveloper
      // 
      this.btnNewDeveloper.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnNewDeveloper.Location = new System.Drawing.Point(565, 458);
      this.btnNewDeveloper.Name = "btnNewDeveloper";
      this.btnNewDeveloper.Size = new System.Drawing.Size(136, 35);
      this.btnNewDeveloper.TabIndex = 4;
      this.btnNewDeveloper.Text = "增加新开发员";
      this.btnNewDeveloper.UseVisualStyleBackColor = true;
      this.btnNewDeveloper.Click += new System.EventHandler(this.btnNewDeveloper_Click);
      // 
      // txtUsercode
      // 
      this.txtUsercode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtUsercode.Location = new System.Drawing.Point(82, 463);
      this.txtUsercode.Name = "txtUsercode";
      this.txtUsercode.Size = new System.Drawing.Size(189, 23);
      this.txtUsercode.TabIndex = 6;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(26, 464);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(50, 17);
      this.label1.TabIndex = 5;
      this.label1.Text = "用户名";
      // 
      // txtUsername
      // 
      this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtUsername.Location = new System.Drawing.Point(354, 464);
      this.txtUsername.Name = "txtUsername";
      this.txtUsername.Size = new System.Drawing.Size(189, 23);
      this.txtUsername.TabIndex = 8;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(298, 465);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(36, 17);
      this.label2.TabIndex = 7;
      this.label2.Text = "姓名";
      // 
      // DeveloperMgr
      // 
      this.AcceptButton = this.btnNewDeveloper;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(864, 519);
      this.Controls.Add(this.txtUsername);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtUsercode);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnNewDeveloper);
      this.Controls.Add(this.gvUser);
      this.MaximizeBox = false;
      this.Name = "DeveloperMgr";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "开发员管理";
      this.Load += new System.EventHandler(this.DeveloperMgr_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.DataGridView gvUser;
    private System.Windows.Forms.Button btnNewDeveloper;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserID;
    private System.Windows.Forms.DataGridViewTextBoxColumn Usercode;
    private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddSelf;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsEditSelf;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsDeleteSelf;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsEditOther;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsDeleteOther;
    private System.Windows.Forms.DataGridViewLinkColumn HasDeleted;
    private System.Windows.Forms.TextBox txtUsercode;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.Label label2;
  }
}