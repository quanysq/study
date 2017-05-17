namespace WinFormSample02
{
  partial class Form1
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
      System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "aabc,aaaabc",
            "a",
            "b"}, -1);
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.txListView1 = new WinFormSample02.Controls.TXListView();
      this.Col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.Col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.txButton1 = new WinFormSample02.Controls.TXButton();
      this.txTextBox2 = new WinFormSample02.Controls.TXTextBox();
      this.txTextBox1 = new WinFormSample02.Controls.TXTextBox();
      this.SuspendLayout();
      // 
      // txListView1
      // 
      this.txListView1.BackColor = System.Drawing.Color.White;
      this.txListView1.BorderColor = System.Drawing.Color.YellowGreen;
      this.txListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col1,
            this.Col2});
      this.txListView1.Font = new System.Drawing.Font("SimSun", 9.6F);
      this.txListView1.FullRowSelect = true;
      this.txListView1.HeaderBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
      this.txListView1.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
      listViewItem1.Checked = true;
      listViewItem1.StateImageIndex = 1;
      this.txListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
      this.txListView1.Location = new System.Drawing.Point(12, 145);
      this.txListView1.Name = "txListView1";
      this.txListView1.OwnerDraw = true;
      this.txListView1.RowBackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
      this.txListView1.RowBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
      this.txListView1.SelectedBeginColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
      this.txListView1.SelectedEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(225)))), ((int)(((byte)(253)))));
      this.txListView1.Size = new System.Drawing.Size(344, 176);
      this.txListView1.TabIndex = 3;
      this.txListView1.UseCompatibleStateImageBehavior = false;
      this.txListView1.View = System.Windows.Forms.View.Details;
      // 
      // Col1
      // 
      this.Col1.Text = "Col2";
      this.Col1.Width = 100;
      // 
      // Col2
      // 
      this.Col2.Text = "Col2";
      // 
      // txButton1
      // 
      this.txButton1.Image = global::WinFormSample02.Properties.Resources.expand;
      this.txButton1.Location = new System.Drawing.Point(12, 94);
      this.txButton1.Name = "txButton1";
      this.txButton1.Size = new System.Drawing.Size(208, 45);
      this.txButton1.TabIndex = 2;
      this.txButton1.Text = "txButton1";
      this.txButton1.UseVisualStyleBackColor = true;
      // 
      // txTextBox2
      // 
      this.txTextBox2.BackColor = System.Drawing.Color.Transparent;
      this.txTextBox2.BorderColor = System.Drawing.Color.Red;
      this.txTextBox2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.txTextBox2.ForeColor = System.Drawing.SystemColors.WindowText;
      this.txTextBox2.HeightLightBolorColor = System.Drawing.Color.Blue;
      this.txTextBox2.Image = null;
      this.txTextBox2.ImageSize = new System.Drawing.Size(0, 0);
      this.txTextBox2.Location = new System.Drawing.Point(12, 63);
      this.txTextBox2.Name = "txTextBox2";
      this.txTextBox2.Padding = new System.Windows.Forms.Padding(2);
      this.txTextBox2.PasswordChar = '\0';
      this.txTextBox2.Required = false;
      this.txTextBox2.Size = new System.Drawing.Size(180, 25);
      this.txTextBox2.TabIndex = 1;
      // 
      // txTextBox1
      // 
      this.txTextBox1.BackColor = System.Drawing.Color.Transparent;
      this.txTextBox1.BorderColor = System.Drawing.Color.Maroon;
      this.txTextBox1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
      this.txTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
      this.txTextBox1.HeightLightBolorColor = System.Drawing.Color.Blue;
      this.txTextBox1.Image = ((System.Drawing.Image)(resources.GetObject("txTextBox1.Image")));
      this.txTextBox1.ImageAlignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.txTextBox1.ImageSize = new System.Drawing.Size(14, 14);
      this.txTextBox1.Location = new System.Drawing.Point(12, 12);
      this.txTextBox1.Name = "txTextBox1";
      this.txTextBox1.Padding = new System.Windows.Forms.Padding(2);
      this.txTextBox1.PasswordChar = '\0';
      this.txTextBox1.Required = false;
      this.txTextBox1.Size = new System.Drawing.Size(244, 34);
      this.txTextBox1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(538, 458);
      this.Controls.Add(this.txListView1);
      this.Controls.Add(this.txButton1);
      this.Controls.Add(this.txTextBox2);
      this.Controls.Add(this.txTextBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private Controls.TXTextBox txTextBox1;
    private Controls.TXTextBox txTextBox2;
    private Controls.TXButton txButton1;
    private Controls.TXListView txListView1;
    private System.Windows.Forms.ColumnHeader Col1;
    private System.Windows.Forms.ColumnHeader Col2;
  }
}

