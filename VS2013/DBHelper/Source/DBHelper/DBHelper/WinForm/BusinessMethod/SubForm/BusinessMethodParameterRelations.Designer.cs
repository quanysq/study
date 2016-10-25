namespace DBHelper
{
  partial class BusinessMethodParameterRelations
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBind = new System.Windows.Forms.Button();
      this.gvSelected = new System.Windows.Forms.DataGridView();
      this.MethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FunctionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.gvParameterRelations = new System.Windows.Forms.DataGridView();
      this.gvParameterRelations_BMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvParameterRelations_MethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvParameterRelations_MethodParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvParameterRelations_BMParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CMForgvSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miMoveup = new System.Windows.Forms.ToolStripMenuItem();
      this.miMovedown = new System.Windows.Forms.ToolStripMenuItem();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvSelected)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvParameterRelations)).BeginInit();
      this.CMForgvSelected.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.btnBind);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 365);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(380, 38);
      this.panel2.TabIndex = 2;
      // 
      // btnBind
      // 
      this.btnBind.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnBind.Location = new System.Drawing.Point(301, 6);
      this.btnBind.Name = "btnBind";
      this.btnBind.Size = new System.Drawing.Size(74, 25);
      this.btnBind.TabIndex = 3;
      this.btnBind.Text = "确定";
      this.btnBind.UseVisualStyleBackColor = true;
      this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
      // 
      // gvSelected
      // 
      this.gvSelected.AllowUserToAddRows = false;
      this.gvSelected.AllowUserToDeleteRows = false;
      this.gvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MethodID,
            this.MethodName,
            this.MethodDesc,
            this.MethodType,
            this.FunctionType,
            this.CreateUser,
            this.CreateDate});
      this.gvSelected.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvSelected.Location = new System.Drawing.Point(0, 0);
      this.gvSelected.Name = "gvSelected";
      this.gvSelected.ReadOnly = true;
      this.gvSelected.RowTemplate.Height = 23;
      this.gvSelected.Size = new System.Drawing.Size(420, 403);
      this.gvSelected.TabIndex = 4;
      this.gvSelected.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSelected_CellMouseDown);
      this.gvSelected.CurrentCellChanged += new System.EventHandler(this.gvSelected_CurrentCellChanged);
      // 
      // MethodID
      // 
      this.MethodID.DataPropertyName = "MethodID";
      this.MethodID.Frozen = true;
      this.MethodID.HeaderText = "ID";
      this.MethodID.Name = "MethodID";
      this.MethodID.ReadOnly = true;
      this.MethodID.Width = 70;
      // 
      // MethodName
      // 
      this.MethodName.DataPropertyName = "MethodName";
      this.MethodName.Frozen = true;
      this.MethodName.HeaderText = "元素方法名";
      this.MethodName.Name = "MethodName";
      this.MethodName.ReadOnly = true;
      // 
      // MethodDesc
      // 
      this.MethodDesc.DataPropertyName = "MethodDesc";
      this.MethodDesc.HeaderText = "元素方法描述";
      this.MethodDesc.Name = "MethodDesc";
      this.MethodDesc.ReadOnly = true;
      this.MethodDesc.Width = 300;
      // 
      // MethodType
      // 
      this.MethodType.DataPropertyName = "MethodType";
      this.MethodType.HeaderText = "方法类别";
      this.MethodType.Name = "MethodType";
      this.MethodType.ReadOnly = true;
      // 
      // FunctionType
      // 
      this.FunctionType.DataPropertyName = "FunctionType";
      this.FunctionType.HeaderText = "方法功能";
      this.FunctionType.Name = "FunctionType";
      this.FunctionType.ReadOnly = true;
      // 
      // CreateUser
      // 
      this.CreateUser.DataPropertyName = "CreateUser";
      this.CreateUser.HeaderText = "创建用户";
      this.CreateUser.Name = "CreateUser";
      this.CreateUser.ReadOnly = true;
      // 
      // CreateDate
      // 
      this.CreateDate.DataPropertyName = "CreateDate";
      this.CreateDate.HeaderText = "创建时间";
      this.CreateDate.Name = "CreateDate";
      this.CreateDate.ReadOnly = true;
      this.CreateDate.Width = 120;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.gvSelected);
      this.splitContainer1.Panel1MinSize = 420;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.gvParameterRelations);
      this.splitContainer1.Panel2.Controls.Add(this.panel2);
      this.splitContainer1.Panel2MinSize = 300;
      this.splitContainer1.Size = new System.Drawing.Size(804, 403);
      this.splitContainer1.SplitterDistance = 420;
      this.splitContainer1.TabIndex = 1;
      // 
      // gvParameterRelations
      // 
      this.gvParameterRelations.AllowUserToAddRows = false;
      this.gvParameterRelations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvParameterRelations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvParameterRelations_BMCode,
            this.gvParameterRelations_MethodID,
            this.gvParameterRelations_MethodParameterName,
            this.gvParameterRelations_BMParameterName});
      this.gvParameterRelations.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvParameterRelations.Location = new System.Drawing.Point(0, 0);
      this.gvParameterRelations.Name = "gvParameterRelations";
      this.gvParameterRelations.RowTemplate.Height = 23;
      this.gvParameterRelations.Size = new System.Drawing.Size(380, 365);
      this.gvParameterRelations.TabIndex = 5;
      this.gvParameterRelations.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvParameterRelations_CellEndEdit);
      // 
      // gvParameterRelations_BMCode
      // 
      this.gvParameterRelations_BMCode.DataPropertyName = "BMCode";
      this.gvParameterRelations_BMCode.HeaderText = "BMCode";
      this.gvParameterRelations_BMCode.Name = "gvParameterRelations_BMCode";
      this.gvParameterRelations_BMCode.ReadOnly = true;
      this.gvParameterRelations_BMCode.Visible = false;
      this.gvParameterRelations_BMCode.Width = 70;
      // 
      // gvParameterRelations_MethodID
      // 
      this.gvParameterRelations_MethodID.DataPropertyName = "MethodID";
      this.gvParameterRelations_MethodID.HeaderText = "MethodID";
      this.gvParameterRelations_MethodID.Name = "gvParameterRelations_MethodID";
      this.gvParameterRelations_MethodID.ReadOnly = true;
      this.gvParameterRelations_MethodID.Visible = false;
      // 
      // gvParameterRelations_MethodParameterName
      // 
      this.gvParameterRelations_MethodParameterName.DataPropertyName = "MethodParameterName";
      this.gvParameterRelations_MethodParameterName.HeaderText = "元素参数";
      this.gvParameterRelations_MethodParameterName.Name = "gvParameterRelations_MethodParameterName";
      this.gvParameterRelations_MethodParameterName.ReadOnly = true;
      this.gvParameterRelations_MethodParameterName.Width = 180;
      // 
      // gvParameterRelations_BMParameterName
      // 
      this.gvParameterRelations_BMParameterName.DataPropertyName = "BMParameterName";
      this.gvParameterRelations_BMParameterName.HeaderText = "业务参数";
      this.gvParameterRelations_BMParameterName.Name = "gvParameterRelations_BMParameterName";
      this.gvParameterRelations_BMParameterName.Width = 180;
      // 
      // CMForgvSelected
      // 
      this.CMForgvSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoveup,
            this.miMovedown});
      this.CMForgvSelected.Name = "CMForgvSelected";
      this.CMForgvSelected.Size = new System.Drawing.Size(101, 48);
      // 
      // miMoveup
      // 
      this.miMoveup.Name = "miMoveup";
      this.miMoveup.Size = new System.Drawing.Size(100, 22);
      this.miMoveup.Text = "上移";
      this.miMoveup.Click += new System.EventHandler(this.miMoveup_Click);
      // 
      // miMovedown
      // 
      this.miMovedown.Name = "miMovedown";
      this.miMovedown.Size = new System.Drawing.Size(100, 22);
      this.miMovedown.Text = "下移";
      this.miMovedown.Click += new System.EventHandler(this.miMovedown_Click);
      // 
      // BusinessMethodParameterRelations
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.splitContainer1);
      this.Name = "BusinessMethodParameterRelations";
      this.Text = "BusinessMethodParameterRelations";
      this.Load += new System.EventHandler(this.BusinessMethodParameterRelations_Load);
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvSelected)).EndInit();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvParameterRelations)).EndInit();
      this.CMForgvSelected.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBind;
    private System.Windows.Forms.DataGridView gvSelected;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.DataGridView gvParameterRelations;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodID;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodName;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodDesc;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodType;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvParameterRelations_BMCode;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvParameterRelations_MethodID;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvParameterRelations_MethodParameterName;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvParameterRelations_BMParameterName;
    private System.Windows.Forms.ContextMenuStrip CMForgvSelected;
    private System.Windows.Forms.ToolStripMenuItem miMoveup;
    private System.Windows.Forms.ToolStripMenuItem miMovedown;

  }
}