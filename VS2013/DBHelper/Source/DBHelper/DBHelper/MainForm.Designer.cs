namespace DBHelper
{
  partial class MainForm
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
      this.menuBar = new System.Windows.Forms.MenuStrip();
      this.miInternalMethod = new System.Windows.Forms.ToolStripMenuItem();
      this.miInternalMethodList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
      this.miQuery = new System.Windows.Forms.ToolStripMenuItem();
      this.miInsert = new System.Windows.Forms.ToolStripMenuItem();
      this.miUpdate = new System.Windows.Forms.ToolStripMenuItem();
      this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
      this.miProcedure = new System.Windows.Forms.ToolStripMenuItem();
      this.miBusinesMethod = new System.Windows.Forms.ToolStripMenuItem();
      this.miBusinesMethodList = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
      this.miAddBusinesMethod = new System.Windows.Forms.ToolStripMenuItem();
      this.miDeveloper = new System.Windows.Forms.ToolStripMenuItem();
      this.miModifyPwd = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.miChangeDatabase = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.miMgrDeveloper = new System.Windows.Forms.ToolStripMenuItem();
      this.menuBar.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuBar
      // 
      this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInternalMethod,
            this.miBusinesMethod,
            this.miDeveloper});
      this.menuBar.Location = new System.Drawing.Point(0, 0);
      this.menuBar.Name = "menuBar";
      this.menuBar.Size = new System.Drawing.Size(1255, 25);
      this.menuBar.TabIndex = 1;
      this.menuBar.Text = "menuStrip1";
      // 
      // miInternalMethod
      // 
      this.miInternalMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInternalMethodList,
            this.toolStripSeparator3,
            this.miQuery,
            this.miInsert,
            this.miUpdate,
            this.miDelete,
            this.miProcedure});
      this.miInternalMethod.Name = "miInternalMethod";
      this.miInternalMethod.Size = new System.Drawing.Size(92, 21);
      this.miInternalMethod.Text = "元素方法管理";
      // 
      // miInternalMethodList
      // 
      this.miInternalMethodList.Name = "miInternalMethodList";
      this.miInternalMethodList.Size = new System.Drawing.Size(172, 22);
      this.miInternalMethodList.Text = "元素方法列表";
      this.miInternalMethodList.Click += new System.EventHandler(this.miInternalMethodList_Click);
      // 
      // toolStripSeparator3
      // 
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
      // 
      // miQuery
      // 
      this.miQuery.Enabled = false;
      this.miQuery.Name = "miQuery";
      this.miQuery.Size = new System.Drawing.Size(172, 22);
      this.miQuery.Text = "创建查询语句方法";
      this.miQuery.Click += new System.EventHandler(this.miQuery_Click);
      // 
      // miInsert
      // 
      this.miInsert.Enabled = false;
      this.miInsert.Name = "miInsert";
      this.miInsert.Size = new System.Drawing.Size(172, 22);
      this.miInsert.Text = "创建插入语句方法";
      this.miInsert.Click += new System.EventHandler(this.miInsert_Click);
      // 
      // miUpdate
      // 
      this.miUpdate.Enabled = false;
      this.miUpdate.Name = "miUpdate";
      this.miUpdate.Size = new System.Drawing.Size(172, 22);
      this.miUpdate.Text = "创建更新语句方法";
      this.miUpdate.Click += new System.EventHandler(this.miUpdate_Click);
      // 
      // miDelete
      // 
      this.miDelete.Enabled = false;
      this.miDelete.Name = "miDelete";
      this.miDelete.Size = new System.Drawing.Size(172, 22);
      this.miDelete.Text = "创建删除语句方法";
      this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
      // 
      // miProcedure
      // 
      this.miProcedure.Enabled = false;
      this.miProcedure.Name = "miProcedure";
      this.miProcedure.Size = new System.Drawing.Size(172, 22);
      this.miProcedure.Text = "创建存储过程方法";
      this.miProcedure.Click += new System.EventHandler(this.miProcedure_Click);
      // 
      // miBusinesMethod
      // 
      this.miBusinesMethod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miBusinesMethodList,
            this.toolStripSeparator4,
            this.miAddBusinesMethod});
      this.miBusinesMethod.Name = "miBusinesMethod";
      this.miBusinesMethod.Size = new System.Drawing.Size(92, 21);
      this.miBusinesMethod.Text = "业务方法管理";
      // 
      // miBusinesMethodList
      // 
      this.miBusinesMethodList.Name = "miBusinesMethodList";
      this.miBusinesMethodList.Size = new System.Drawing.Size(148, 22);
      this.miBusinesMethodList.Text = "业务方法列表";
      this.miBusinesMethodList.Click += new System.EventHandler(this.miBusinesMethodList_Click);
      // 
      // toolStripSeparator4
      // 
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
      // 
      // miAddBusinesMethod
      // 
      this.miAddBusinesMethod.Enabled = false;
      this.miAddBusinesMethod.Name = "miAddBusinesMethod";
      this.miAddBusinesMethod.Size = new System.Drawing.Size(148, 22);
      this.miAddBusinesMethod.Text = "添加业务方法";
      this.miAddBusinesMethod.Click += new System.EventHandler(this.miAddBusinesMethod_Click);
      // 
      // miDeveloper
      // 
      this.miDeveloper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miModifyPwd,
            this.toolStripSeparator1,
            this.miChangeDatabase,
            this.toolStripSeparator2,
            this.miMgrDeveloper});
      this.miDeveloper.Name = "miDeveloper";
      this.miDeveloper.Size = new System.Drawing.Size(80, 21);
      this.miDeveloper.Text = "操作员管理";
      // 
      // miModifyPwd
      // 
      this.miModifyPwd.Name = "miModifyPwd";
      this.miModifyPwd.Size = new System.Drawing.Size(136, 22);
      this.miModifyPwd.Text = "修改密码";
      this.miModifyPwd.Click += new System.EventHandler(this.miModifyPwd_Click);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
      // 
      // miChangeDatabase
      // 
      this.miChangeDatabase.Name = "miChangeDatabase";
      this.miChangeDatabase.Size = new System.Drawing.Size(136, 22);
      this.miChangeDatabase.Text = "改变数据库";
      this.miChangeDatabase.Click += new System.EventHandler(this.miChangeDatabase_Click);
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
      // 
      // miMgrDeveloper
      // 
      this.miMgrDeveloper.Enabled = false;
      this.miMgrDeveloper.Name = "miMgrDeveloper";
      this.miMgrDeveloper.Size = new System.Drawing.Size(136, 22);
      this.miMgrDeveloper.Text = "管理操作员";
      this.miMgrDeveloper.Click += new System.EventHandler(this.miMgrDeveloper_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1255, 692);
      this.Controls.Add(this.menuBar);
      this.IsMdiContainer = true;
      this.MainMenuStrip = this.menuBar;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "通用数据持久层管理系统";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.menuBar.ResumeLayout(false);
      this.menuBar.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuBar;
    private System.Windows.Forms.ToolStripMenuItem miInternalMethod;
    private System.Windows.Forms.ToolStripMenuItem miInternalMethodList;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripMenuItem miQuery;
    private System.Windows.Forms.ToolStripMenuItem miInsert;
    private System.Windows.Forms.ToolStripMenuItem miUpdate;
    private System.Windows.Forms.ToolStripMenuItem miDelete;
    private System.Windows.Forms.ToolStripMenuItem miProcedure;
    private System.Windows.Forms.ToolStripMenuItem miBusinesMethod;
    private System.Windows.Forms.ToolStripMenuItem miBusinesMethodList;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripMenuItem miAddBusinesMethod;
    private System.Windows.Forms.ToolStripMenuItem miDeveloper;
    private System.Windows.Forms.ToolStripMenuItem miModifyPwd;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem miChangeDatabase;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem miMgrDeveloper;
  }
}