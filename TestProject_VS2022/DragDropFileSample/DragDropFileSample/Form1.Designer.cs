namespace DragDropFileSample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFiles = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtFiles
            // 
            txtFiles.AllowDrop = true;
            txtFiles.Location = new Point(12, 43);
            txtFiles.Multiline = true;
            txtFiles.Name = "txtFiles";
            txtFiles.Size = new Size(542, 249);
            txtFiles.TabIndex = 0;
            txtFiles.DragDrop += txtFiles_DragDrop;
            txtFiles.DragEnter += txtFiles_DragEnter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 20);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "文件列表：";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 318);
            Controls.Add(label1);
            Controls.Add(txtFiles);
            Name = "Form1";
            Text = "拖放文件例子";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFiles;
        private Label label1;
    }
}
