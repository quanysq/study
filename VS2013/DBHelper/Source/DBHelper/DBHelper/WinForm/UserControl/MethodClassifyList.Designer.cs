namespace DBHelper
{
  partial class MethodClassifyList
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
      this.components = new System.ComponentModel.Container();
      this.panel1 = new System.Windows.Forms.Panel();
      this.btnAddMethodClassify = new System.Windows.Forms.Button();
      this.lstMethodClassify = new System.Windows.Forms.ListBox();
      this.cmMethodClassify = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.miDeleteMethodClassify = new System.Windows.Forms.ToolStripMenuItem();
      this.panel1.SuspendLayout();
      this.cmMethodClassify.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnAddMethodClassify);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(300, 38);
      this.panel1.TabIndex = 1;
      // 
      // btnAddMethodClassify
      // 
      this.btnAddMethodClassify.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnAddMethodClassify.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.btnAddMethodClassify.Location = new System.Drawing.Point(153, 0);
      this.btnAddMethodClassify.Name = "btnAddMethodClassify";
      this.btnAddMethodClassify.Padding = new System.Windows.Forms.Padding(5);
      this.btnAddMethodClassify.Size = new System.Drawing.Size(147, 38);
      this.btnAddMethodClassify.TabIndex = 0;
      this.btnAddMethodClassify.Text = "添加元素方法类别";
      this.btnAddMethodClassify.UseVisualStyleBackColor = true;
      this.btnAddMethodClassify.Click += new System.EventHandler(this.btnAddMethodClassify_Click);
      // 
      // lstMethodClassify
      // 
      this.lstMethodClassify.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstMethodClassify.Font = new System.Drawing.Font("SimSun", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.lstMethodClassify.FormattingEnabled = true;
      this.lstMethodClassify.ItemHeight = 14;
      this.lstMethodClassify.Location = new System.Drawing.Point(0, 38);
      this.lstMethodClassify.Name = "lstMethodClassify";
      this.lstMethodClassify.Size = new System.Drawing.Size(300, 412);
      this.lstMethodClassify.TabIndex = 2;
      this.lstMethodClassify.SelectedIndexChanged += new System.EventHandler(this.lstMethodClassify_SelectedIndexChanged);
      this.lstMethodClassify.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstMethodClassify_MouseUp);
      // 
      // cmMethodClassify
      // 
      this.cmMethodClassify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDeleteMethodClassify});
      this.cmMethodClassify.Name = "contextMenuStrip1";
      this.cmMethodClassify.Size = new System.Drawing.Size(101, 26);
      // 
      // miDeleteMethodClassify
      // 
      this.miDeleteMethodClassify.Name = "miDeleteMethodClassify";
      this.miDeleteMethodClassify.Size = new System.Drawing.Size(100, 22);
      this.miDeleteMethodClassify.Text = "删除";
      this.miDeleteMethodClassify.Click += new System.EventHandler(this.miDeleteMethodClassify_Click);
      // 
      // MethodClassifyList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstMethodClassify);
      this.Controls.Add(this.panel1);
      this.Name = "MethodClassifyList";
      this.Size = new System.Drawing.Size(300, 450);
      this.Load += new System.EventHandler(this.MethodClassifyList_Load);
      this.panel1.ResumeLayout(false);
      this.cmMethodClassify.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnAddMethodClassify;
    private System.Windows.Forms.ListBox lstMethodClassify;
    private System.Windows.Forms.ContextMenuStrip cmMethodClassify;
    private System.Windows.Forms.ToolStripMenuItem miDeleteMethodClassify;

  }
}
