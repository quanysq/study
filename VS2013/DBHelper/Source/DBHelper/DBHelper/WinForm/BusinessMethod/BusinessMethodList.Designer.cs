namespace DBHelper
{
  partial class BusinessMethodList
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
      this.ucMethodClassifyList = new DBHelper.MethodClassifyList();
      this.gvBusinessMethod = new System.Windows.Forms.DataGridView();
      this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.BMCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BMDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FunctionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.MethodNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.pnSplit = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnMove = new System.Windows.Forms.Button();
      this.btnQuery = new System.Windows.Forms.Button();
      this.txtKeyword = new System.Windows.Forms.TextBox();
      this.btnGenerateXml = new System.Windows.Forms.Button();
      this.CMForgvBusinessMethod = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.miBindIM = new System.Windows.Forms.ToolStripMenuItem();
      this.miSetParameterRelations = new System.Windows.Forms.ToolStripMenuItem();
      this.miParameter = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvBusinessMethod)).BeginInit();
      this.panel1.SuspendLayout();
      this.CMForgvBusinessMethod.SuspendLayout();
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
      this.splitContainer1.Panel1.Controls.Add(this.ucMethodClassifyList);
      this.splitContainer1.Panel1MinSize = 250;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.gvBusinessMethod);
      this.splitContainer1.Panel2.Controls.Add(this.pnSplit);
      this.splitContainer1.Panel2.Controls.Add(this.panel1);
      this.splitContainer1.Size = new System.Drawing.Size(990, 518);
      this.splitContainer1.SplitterDistance = 250;
      this.splitContainer1.TabIndex = 1;
      // 
      // ucMethodClassifyList
      // 
      this.ucMethodClassifyList.AddMethodClassifyFrm_Title = "添加业务方法类别";
      this.ucMethodClassifyList.ClassifyType = 2;
      this.ucMethodClassifyList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ucMethodClassifyList.Location = new System.Drawing.Point(0, 0);
      this.ucMethodClassifyList.Name = "ucMethodClassifyList";
      this.ucMethodClassifyList.Size = new System.Drawing.Size(250, 518);
      this.ucMethodClassifyList.TabIndex = 0;
      // 
      // gvBusinessMethod
      // 
      this.gvBusinessMethod.AllowUserToAddRows = false;
      this.gvBusinessMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gvBusinessMethod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.BMCode,
            this.BMDesc,
            this.FunctionType,
            this.MethodNum,
            this.CreateUser,
            this.CreateDate});
      this.gvBusinessMethod.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gvBusinessMethod.Location = new System.Drawing.Point(0, 39);
      this.gvBusinessMethod.Name = "gvBusinessMethod";
      this.gvBusinessMethod.RowTemplate.Height = 23;
      this.gvBusinessMethod.Size = new System.Drawing.Size(736, 479);
      this.gvBusinessMethod.TabIndex = 1;
      this.gvBusinessMethod.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvBusinessMethod_CellDoubleClick);
      this.gvBusinessMethod.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvBusinessMethod_CellMouseDown);
      // 
      // Selected
      // 
      this.Selected.FalseValue = "0";
      this.Selected.HeaderText = "";
      this.Selected.Name = "Selected";
      this.Selected.TrueValue = "1";
      this.Selected.Width = 40;
      // 
      // BMCode
      // 
      this.BMCode.DataPropertyName = "BMCode";
      this.BMCode.HeaderText = "方法代码";
      this.BMCode.Name = "BMCode";
      this.BMCode.ReadOnly = true;
      this.BMCode.Width = 80;
      // 
      // BMDesc
      // 
      this.BMDesc.DataPropertyName = "BMDesc";
      this.BMDesc.HeaderText = "方法描述";
      this.BMDesc.Name = "BMDesc";
      this.BMDesc.ReadOnly = true;
      this.BMDesc.Width = 260;
      // 
      // FunctionType
      // 
      this.FunctionType.DataPropertyName = "FunctionType";
      this.FunctionType.HeaderText = "方法功能";
      this.FunctionType.Name = "FunctionType";
      this.FunctionType.ReadOnly = true;
      // 
      // MethodNum
      // 
      this.MethodNum.DataPropertyName = "MethodNum";
      this.MethodNum.HeaderText = "绑定元素方法";
      this.MethodNum.Name = "MethodNum";
      this.MethodNum.ReadOnly = true;
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
      this.CreateDate.Width = 140;
      // 
      // pnSplit
      // 
      this.pnSplit.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnSplit.Location = new System.Drawing.Point(0, 38);
      this.pnSplit.Name = "pnSplit";
      this.pnSplit.Size = new System.Drawing.Size(736, 1);
      this.pnSplit.TabIndex = 2;
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.btnMove);
      this.panel1.Controls.Add(this.btnQuery);
      this.panel1.Controls.Add(this.txtKeyword);
      this.panel1.Controls.Add(this.btnGenerateXml);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(736, 38);
      this.panel1.TabIndex = 0;
      // 
      // btnMove
      // 
      this.btnMove.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnMove.Location = new System.Drawing.Point(529, 6);
      this.btnMove.Name = "btnMove";
      this.btnMove.Size = new System.Drawing.Size(94, 25);
      this.btnMove.TabIndex = 4;
      this.btnMove.Text = "移至...";
      this.btnMove.UseVisualStyleBackColor = true;
      this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
      // 
      // btnQuery
      // 
      this.btnQuery.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnQuery.Location = new System.Drawing.Point(308, 6);
      this.btnQuery.Name = "btnQuery";
      this.btnQuery.Size = new System.Drawing.Size(74, 25);
      this.btnQuery.TabIndex = 3;
      this.btnQuery.Text = "查询";
      this.btnQuery.UseVisualStyleBackColor = true;
      this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
      // 
      // txtKeyword
      // 
      this.txtKeyword.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.txtKeyword.Location = new System.Drawing.Point(28, 8);
      this.txtKeyword.Name = "txtKeyword";
      this.txtKeyword.Size = new System.Drawing.Size(274, 23);
      this.txtKeyword.TabIndex = 2;
      this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
      // 
      // btnGenerateXml
      // 
      this.btnGenerateXml.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnGenerateXml.Location = new System.Drawing.Point(629, 6);
      this.btnGenerateXml.Name = "btnGenerateXml";
      this.btnGenerateXml.Size = new System.Drawing.Size(94, 25);
      this.btnGenerateXml.TabIndex = 1;
      this.btnGenerateXml.Text = "生成XML";
      this.btnGenerateXml.UseVisualStyleBackColor = true;
      this.btnGenerateXml.Click += new System.EventHandler(this.btnGenerateXml_Click);
      // 
      // CMForgvBusinessMethod
      // 
      this.CMForgvBusinessMethod.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEdit,
            this.toolStripSeparator1,
            this.miBindIM,
            this.miSetParameterRelations,
            this.miParameter,
            this.toolStripSeparator2,
            this.miDelete});
      this.CMForgvBusinessMethod.Name = "CMForgvBusinessMethod";
      this.CMForgvBusinessMethod.Size = new System.Drawing.Size(149, 126);
      // 
      // miEdit
      // 
      this.miEdit.Name = "miEdit";
      this.miEdit.Size = new System.Drawing.Size(148, 22);
      this.miEdit.Text = "编辑";
      this.miEdit.Click += new System.EventHandler(this.miEdit_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
      // 
      // miBindIM
      // 
      this.miBindIM.Name = "miBindIM";
      this.miBindIM.Size = new System.Drawing.Size(148, 22);
      this.miBindIM.Text = "绑定元素方法";
      this.miBindIM.Click += new System.EventHandler(this.miBindIM_Click);
      // 
      // miSetParameterRelations
      // 
      this.miSetParameterRelations.Name = "miSetParameterRelations";
      this.miSetParameterRelations.Size = new System.Drawing.Size(148, 22);
      this.miSetParameterRelations.Text = "设置参数";
      this.miSetParameterRelations.Click += new System.EventHandler(this.miSetParameterRelations_Click);
      // 
      // miParameter
      // 
      this.miParameter.Name = "miParameter";
      this.miParameter.Size = new System.Drawing.Size(148, 22);
      this.miParameter.Text = "管理参数";
      this.miParameter.Click += new System.EventHandler(this.miParameter_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
      // 
      // miDelete
      // 
      this.miDelete.Name = "miDelete";
      this.miDelete.Size = new System.Drawing.Size(148, 22);
      this.miDelete.Text = "删除";
      this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
      // 
      // BusinessMethodList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(990, 518);
      this.Controls.Add(this.splitContainer1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BusinessMethodList";
      this.Text = "业务方法列表";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BusinessMethodList_FormClosed);
      this.Load += new System.EventHandler(this.BusinessMethodList_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvBusinessMethod)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.CMForgvBusinessMethod.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private MethodClassifyList ucMethodClassifyList;
    private System.Windows.Forms.DataGridView gvBusinessMethod;
    private System.Windows.Forms.Panel pnSplit;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnMove;
    private System.Windows.Forms.Button btnQuery;
    private System.Windows.Forms.TextBox txtKeyword;
    private System.Windows.Forms.Button btnGenerateXml;
    private System.Windows.Forms.ContextMenuStrip CMForgvBusinessMethod;
    private System.Windows.Forms.ToolStripMenuItem miEdit;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem miBindIM;
    private System.Windows.Forms.ToolStripMenuItem miSetParameterRelations;
    private System.Windows.Forms.ToolStripMenuItem miParameter;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem miDelete;
    private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
    private System.Windows.Forms.DataGridViewTextBoxColumn BMCode;
    private System.Windows.Forms.DataGridViewTextBoxColumn BMDesc;
    private System.Windows.Forms.DataGridViewTextBoxColumn FunctionType;
    private System.Windows.Forms.DataGridViewTextBoxColumn MethodNum;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateUser;
    private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;

  }
}