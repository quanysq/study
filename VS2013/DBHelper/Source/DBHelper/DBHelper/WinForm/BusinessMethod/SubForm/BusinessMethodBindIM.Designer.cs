namespace DBHelper
{
  partial class BusinessMethodBindIM
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.gvInternalMethod = new System.Windows.Forms.DataGridView();
      this.MethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FunctionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnlSplit1 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnQuery = new System.Windows.Forms.Button();
      this.txtKeyword = new System.Windows.Forms.TextBox();
      this.gvSelected = new System.Windows.Forms.DataGridView();
      this.pnlSplit2 = new System.Windows.Forms.Panel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnBind = new System.Windows.Forms.Button();
      this.CMForgvInternalMethod = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miSelect = new System.Windows.Forms.ToolStripMenuItem();
      this.CMForgvSelected = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miMoveup = new System.Windows.Forms.ToolStripMenuItem();
      this.miMovedown = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.miCancelSelect = new System.Windows.Forms.ToolStripMenuItem();
      this.gvSelected_MethodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_MethodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_MethodDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_MethodType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_FunctionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gvSelected_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvInternalMethod)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvSelected)).BeginInit();
      this.panel2.SuspendLayout();
      this.CMForgvInternalMethod.SuspendLayout();
      this.CMForgvSelected.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.gvInternalMethod);
      this.splitContainer1.Panel1.Controls.Add(this.pnlSplit1);
      this.splitContainer1.Panel1.Controls.Add(this.panel1);
      this.splitContainer1.Panel1MinSize = 420;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.gvSelected);
      this.splitContainer1.Panel2.Controls.Add(this.pnlSplit2);
      this.splitContainer1.Panel2.Controls.Add(this.panel2);
      this.splitContainer1.Panel2MinSize = 300;
      this.splitContainer1.Size = new System.Drawing.Size(804, 403);
      this.splitContainer1.SplitterDistance = 420;
      this.splitContainer1.TabIndex = 0;
      // 
      // gvInternalMethod
      // 
      this.gvInternalMethod.AllowUserToAddRows = false;
      this.gvInternalMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvInternalMethod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MethodID,
            this.MethodName,
            this.MethodDesc,
            this.MethodType,
            this.FunctionType,
            this.CreateUser,
            this.CreateDate});
      this.gvInternalMethod.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvInternalMethod.Location = new System.Drawing.Point(0, 42);
      this.gvInternalMethod.Name = "gvInternalMethod";
      this.gvInternalMethod.RowTemplate.Height = 23;
      this.gvInternalMethod.Size = new System.Drawing.Size(420, 361);
      this.gvInternalMethod.TabIndex = 3;
      this.gvInternalMethod.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvInternalMethod_CellMouseDown);
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
      // pnlSplit1
      // 
      this.pnlSplit1.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlSplit1.Location = new System.Drawing.Point(0, 38);
      this.pnlSplit1.Name = "pnlSplit1";
      this.pnlSplit1.Size = new System.Drawing.Size(420, 4);
      this.pnlSplit1.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.btnQuery);
      this.panel1.Controls.Add(this.txtKeyword);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(420, 38);
      this.panel1.TabIndex = 1;
      // 
      // btnQuery
      // 
      this.btnQuery.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnQuery.Location = new System.Drawing.Point(296, 6);
      this.btnQuery.Name = "btnQuery";
      this.btnQuery.Size = new System.Drawing.Size(74, 25);
      this.btnQuery.TabIndex = 3;
      this.btnQuery.Text = "查询";
      this.btnQuery.UseVisualStyleBackColor = true;
      // 
      // txtKeyword
      // 
      this.txtKeyword.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtKeyword.Location = new System.Drawing.Point(16, 8);
      this.txtKeyword.Name = "txtKeyword";
      this.txtKeyword.Size = new System.Drawing.Size(274, 23);
      this.txtKeyword.TabIndex = 2;
      // 
      // gvSelected
      // 
      this.gvSelected.AllowUserToAddRows = false;
      this.gvSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvSelected.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gvSelected_MethodID,
            this.gvSelected_MethodName,
            this.gvSelected_MethodDesc,
            this.gvSelected_MethodType,
            this.gvSelected_FunctionType,
            this.gvSelected_CreateUser,
            this.gvSelected_CreateDate});
      this.gvSelected.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvSelected.Location = new System.Drawing.Point(0, 42);
      this.gvSelected.Name = "gvSelected";
      this.gvSelected.RowTemplate.Height = 23;
      this.gvSelected.Size = new System.Drawing.Size(380, 361);
      this.gvSelected.TabIndex = 4;
      this.gvSelected.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvSelected_CellMouseDown);
      // 
      // pnlSplit2
      // 
      this.pnlSplit2.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlSplit2.Location = new System.Drawing.Point(0, 38);
      this.pnlSplit2.Name = "pnlSplit2";
      this.pnlSplit2.Size = new System.Drawing.Size(380, 4);
      this.pnlSplit2.TabIndex = 3;
      // 
      // panel2
      // 
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.btnBind);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
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
      this.btnBind.Text = "绑定";
      this.btnBind.UseVisualStyleBackColor = true;
      this.btnBind.Click += new System.EventHandler(this.btnBind_Click);
      // 
      // CMForgvInternalMethod
      // 
      this.CMForgvInternalMethod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSelect});
      this.CMForgvInternalMethod.Name = "CMForgvInternalMethod";
      this.CMForgvInternalMethod.Size = new System.Drawing.Size(101, 26);
      // 
      // miSelect
      // 
      this.miSelect.Name = "miSelect";
      this.miSelect.Size = new System.Drawing.Size(100, 22);
      this.miSelect.Text = "选择";
      this.miSelect.Click += new System.EventHandler(this.miSelect_Click);
      // 
      // CMForgvSelected
      // 
      this.CMForgvSelected.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miMoveup,
            this.miMovedown,
            this.toolStripSeparator1,
            this.miCancelSelect});
      this.CMForgvSelected.Name = "CMForgvSelected";
      this.CMForgvSelected.Size = new System.Drawing.Size(125, 76);
      // 
      // miMoveup
      // 
      this.miMoveup.Name = "miMoveup";
      this.miMoveup.Size = new System.Drawing.Size(124, 22);
      this.miMoveup.Text = "上移";
      this.miMoveup.Click += new System.EventHandler(this.miMoveup_Click);
      // 
      // miMovedown
      // 
      this.miMovedown.Name = "miMovedown";
      this.miMovedown.Size = new System.Drawing.Size(124, 22);
      this.miMovedown.Text = "下移";
      this.miMovedown.Click += new System.EventHandler(this.miMovedown_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
      // 
      // miCancelSelect
      // 
      this.miCancelSelect.Name = "miCancelSelect";
      this.miCancelSelect.Size = new System.Drawing.Size(124, 22);
      this.miCancelSelect.Text = "取消选择";
      this.miCancelSelect.Click += new System.EventHandler(this.miCancelSelect_Click);
      // 
      // gvSelected_MethodID
      // 
      this.gvSelected_MethodID.DataPropertyName = "MethodID";
      this.gvSelected_MethodID.Frozen = true;
      this.gvSelected_MethodID.HeaderText = "ID";
      this.gvSelected_MethodID.Name = "gvSelected_MethodID";
      this.gvSelected_MethodID.ReadOnly = true;
      this.gvSelected_MethodID.Width = 70;
      // 
      // gvSelected_MethodName
      // 
      this.gvSelected_MethodName.DataPropertyName = "MethodName";
      this.gvSelected_MethodName.Frozen = true;
      this.gvSelected_MethodName.HeaderText = "元素方法名";
      this.gvSelected_MethodName.Name = "gvSelected_MethodName";
      this.gvSelected_MethodName.ReadOnly = true;
      // 
      // gvSelected_MethodDesc
      // 
      this.gvSelected_MethodDesc.DataPropertyName = "MethodDesc";
      this.gvSelected_MethodDesc.HeaderText = "元素方法描述";
      this.gvSelected_MethodDesc.Name = "gvSelected_MethodDesc";
      this.gvSelected_MethodDesc.ReadOnly = true;
      this.gvSelected_MethodDesc.Width = 300;
      // 
      // gvSelected_MethodType
      // 
      this.gvSelected_MethodType.DataPropertyName = "MethodType";
      this.gvSelected_MethodType.HeaderText = "方法类别";
      this.gvSelected_MethodType.Name = "gvSelected_MethodType";
      this.gvSelected_MethodType.ReadOnly = true;
      // 
      // gvSelected_FunctionType
      // 
      this.gvSelected_FunctionType.DataPropertyName = "FunctionType";
      this.gvSelected_FunctionType.HeaderText = "方法功能";
      this.gvSelected_FunctionType.Name = "gvSelected_FunctionType";
      this.gvSelected_FunctionType.ReadOnly = true;
      // 
      // gvSelected_CreateUser
      // 
      this.gvSelected_CreateUser.DataPropertyName = "CreateUser";
      this.gvSelected_CreateUser.HeaderText = "创建用户";
      this.gvSelected_CreateUser.Name = "gvSelected_CreateUser";
      this.gvSelected_CreateUser.ReadOnly = true;
      // 
      // gvSelected_CreateDate
      // 
      this.gvSelected_CreateDate.DataPropertyName = "CreateDate";
      this.gvSelected_CreateDate.HeaderText = "创建时间";
      this.gvSelected_CreateDate.Name = "gvSelected_CreateDate";
      this.gvSelected_CreateDate.ReadOnly = true;
      this.gvSelected_CreateDate.Width = 120;
      // 
      // BusinessMethodBindIM
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(804, 403);
      this.Controls.Add(this.splitContainer1);
      this.Name = "BusinessMethodBindIM";
      this.Text = "BusinessMethodBindIM";
      this.Load += new System.EventHandler(this.BusinessMethodBindIM_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvInternalMethod)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvSelected)).EndInit();
      this.panel2.ResumeLayout(false);
      this.CMForgvInternalMethod.ResumeLayout(false);
      this.CMForgvSelected.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnQuery;
    private System.Windows.Forms.TextBox txtKeyword;
    private System.Windows.Forms.Panel pnlSplit1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnBind;
    private System.Windows.Forms.Panel pnlSplit2;
    private System.Windows.Forms.DataGridView gvInternalMethod;
    private System.Windows.Forms.DataGridView gvSelected;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodID;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodName;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodDesc;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodType;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
    private System.Windows.Forms.ContextMenuStrip CMForgvInternalMethod;
    private System.Windows.Forms.ContextMenuStrip CMForgvSelected;
    private System.Windows.Forms.ToolStripMenuItem miSelect;
    private System.Windows.Forms.ToolStripMenuItem miMoveup;
    private System.Windows.Forms.ToolStripMenuItem miMovedown;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem miCancelSelect;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_MethodID;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_MethodName;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_MethodDesc;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_MethodType;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_FunctionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_CreateUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn gvSelected_CreateDate;

  }
}