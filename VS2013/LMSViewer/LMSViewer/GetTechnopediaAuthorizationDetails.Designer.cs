namespace LMSViewer
{
  partial class GetTechnopediaAuthorizationDetails
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
      this.Subscription = new System.Windows.Forms.TextBox();
      this.SubscriptionHash = new System.Windows.Forms.TextBox();
      this.Vertical = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // Subscription
      // 
      this.Subscription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Subscription.Location = new System.Drawing.Point(3, 3);
      this.Subscription.Multiline = true;
      this.Subscription.Name = "Subscription";
      this.Subscription.ReadOnly = true;
      this.Subscription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.Subscription.Size = new System.Drawing.Size(664, 338);
      this.Subscription.TabIndex = 0;
      this.Subscription.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Subscription_KeyUp);
      // 
      // SubscriptionHash
      // 
      this.SubscriptionHash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.SubscriptionHash.Location = new System.Drawing.Point(3, 348);
      this.SubscriptionHash.Name = "SubscriptionHash";
      this.SubscriptionHash.ReadOnly = true;
      this.SubscriptionHash.Size = new System.Drawing.Size(664, 20);
      this.SubscriptionHash.TabIndex = 1;
      // 
      // Vertical
      // 
      this.Vertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.Vertical.Location = new System.Drawing.Point(3, 374);
      this.Vertical.Name = "Vertical";
      this.Vertical.ReadOnly = true;
      this.Vertical.Size = new System.Drawing.Size(664, 20);
      this.Vertical.TabIndex = 2;
      // 
      // GetTechnopediaAuthorizationDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(669, 401);
      this.Controls.Add(this.Vertical);
      this.Controls.Add(this.SubscriptionHash);
      this.Controls.Add(this.Subscription);
      this.MaximizeBox = false;
      this.Name = "GetTechnopediaAuthorizationDetails";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "GetTechnopediaAuthorizationDetails";
      this.Load += new System.EventHandler(this.GetTechnopediaAuthorizationDetails_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox Subscription;
    private System.Windows.Forms.TextBox SubscriptionHash;
    private System.Windows.Forms.TextBox Vertical;
  }
}