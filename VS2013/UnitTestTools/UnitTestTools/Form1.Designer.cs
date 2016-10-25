namespace UnitTestTools
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
      this.label1 = new System.Windows.Forms.Label();
      this.TxtAssembly = new System.Windows.Forms.TextBox();
      this.TxtNamespace = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.TxtClass = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.BtnSelect = new System.Windows.Forms.Button();
      this.LbMethods = new System.Windows.Forms.ListBox();
      this.BtnSingleTest = new System.Windows.Forms.Button();
      this.BtnMultiTest = new System.Windows.Forms.Button();
      this.TxtTestresult = new System.Windows.Forms.TextBox();
      this.BtnGetmethods = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label1.Location = new System.Drawing.Point(16, 15);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(68, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Assembly";
      // 
      // TxtAssembly
      // 
      this.TxtAssembly.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtAssembly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.TxtAssembly.Location = new System.Drawing.Point(101, 11);
      this.TxtAssembly.Name = "TxtAssembly";
      this.TxtAssembly.Size = new System.Drawing.Size(693, 23);
      this.TxtAssembly.TabIndex = 1;
      // 
      // TxtNamespace
      // 
      this.TxtNamespace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.TxtNamespace.Location = new System.Drawing.Point(101, 42);
      this.TxtNamespace.Name = "TxtNamespace";
      this.TxtNamespace.Size = new System.Drawing.Size(693, 23);
      this.TxtNamespace.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label2.Location = new System.Drawing.Point(16, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(83, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Namespace";
      // 
      // TxtClass
      // 
      this.TxtClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.TxtClass.Location = new System.Drawing.Point(101, 73);
      this.TxtClass.Name = "TxtClass";
      this.TxtClass.Size = new System.Drawing.Size(693, 23);
      this.TxtClass.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.label3.Location = new System.Drawing.Point(16, 73);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(79, 17);
      this.label3.TabIndex = 4;
      this.label3.Text = "ClassName";
      // 
      // BtnSelect
      // 
      this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.BtnSelect.Location = new System.Drawing.Point(800, 11);
      this.BtnSelect.Name = "BtnSelect";
      this.BtnSelect.Size = new System.Drawing.Size(109, 23);
      this.BtnSelect.TabIndex = 6;
      this.BtnSelect.Text = "Choose Assembly";
      this.BtnSelect.UseVisualStyleBackColor = true;
      this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
      // 
      // LbMethods
      // 
      this.LbMethods.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.LbMethods.FormattingEnabled = true;
      this.LbMethods.ItemHeight = 17;
      this.LbMethods.Location = new System.Drawing.Point(19, 102);
      this.LbMethods.Name = "LbMethods";
      this.LbMethods.Size = new System.Drawing.Size(294, 446);
      this.LbMethods.TabIndex = 7;
      // 
      // BtnSingleTest
      // 
      this.BtnSingleTest.Enabled = false;
      this.BtnSingleTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.BtnSingleTest.Location = new System.Drawing.Point(320, 102);
      this.BtnSingleTest.Name = "BtnSingleTest";
      this.BtnSingleTest.Size = new System.Drawing.Size(133, 39);
      this.BtnSingleTest.TabIndex = 8;
      this.BtnSingleTest.Text = "Run Test Method";
      this.BtnSingleTest.UseVisualStyleBackColor = true;
      this.BtnSingleTest.Click += new System.EventHandler(this.BtnSingleTest_Click);
      // 
      // BtnMultiTest
      // 
      this.BtnMultiTest.Enabled = false;
      this.BtnMultiTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.BtnMultiTest.Location = new System.Drawing.Point(459, 102);
      this.BtnMultiTest.Name = "BtnMultiTest";
      this.BtnMultiTest.Size = new System.Drawing.Size(175, 39);
      this.BtnMultiTest.TabIndex = 9;
      this.BtnMultiTest.Text = "Run All Test Methods";
      this.BtnMultiTest.UseVisualStyleBackColor = true;
      this.BtnMultiTest.Click += new System.EventHandler(this.BtnMultiTest_Click);
      // 
      // TxtTestresult
      // 
      this.TxtTestresult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.TxtTestresult.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
      this.TxtTestresult.Location = new System.Drawing.Point(320, 152);
      this.TxtTestresult.Multiline = true;
      this.TxtTestresult.Name = "TxtTestresult";
      this.TxtTestresult.ReadOnly = true;
      this.TxtTestresult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.TxtTestresult.Size = new System.Drawing.Size(589, 396);
      this.TxtTestresult.TabIndex = 10;
      this.TxtTestresult.WordWrap = false;
      // 
      // BtnGetmethods
      // 
      this.BtnGetmethods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.BtnGetmethods.Location = new System.Drawing.Point(800, 73);
      this.BtnGetmethods.Name = "BtnGetmethods";
      this.BtnGetmethods.Size = new System.Drawing.Size(109, 23);
      this.BtnGetmethods.TabIndex = 6;
      this.BtnGetmethods.Text = "Get Test Method";
      this.BtnGetmethods.UseVisualStyleBackColor = true;
      this.BtnGetmethods.Click += new System.EventHandler(this.BtnGetmethods_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.Color.DarkRed;
      this.label4.Location = new System.Drawing.Point(640, 116);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(240, 13);
      this.label4.TabIndex = 11;
      this.label4.Text = "Note: The test method\'s  should end with \"_Test\"";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(926, 557);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.TxtTestresult);
      this.Controls.Add(this.BtnMultiTest);
      this.Controls.Add(this.BtnSingleTest);
      this.Controls.Add(this.LbMethods);
      this.Controls.Add(this.BtnGetmethods);
      this.Controls.Add(this.BtnSelect);
      this.Controls.Add(this.TxtClass);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.TxtNamespace);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.TxtAssembly);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.Text = "UnitTestHelper";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox TxtAssembly;
    private System.Windows.Forms.TextBox TxtNamespace;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox TxtClass;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button BtnSelect;
    private System.Windows.Forms.ListBox LbMethods;
    private System.Windows.Forms.Button BtnSingleTest;
    private System.Windows.Forms.Button BtnMultiTest;
    private System.Windows.Forms.TextBox TxtTestresult;
    private System.Windows.Forms.Button BtnGetmethods;
    private System.Windows.Forms.Label label4;
  }
}

