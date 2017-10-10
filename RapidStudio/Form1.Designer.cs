namespace RapidStudio
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
      this.txtAlbumDirectory = new System.Windows.Forms.TextBox();
      this.fbdAlbumDirectory = new System.Windows.Forms.FolderBrowserDialog();
      this.cmdBrowseAlbumDirectory = new System.Windows.Forms.Button();
      this.cmdRemoveCaptions = new System.Windows.Forms.Button();
      this.prg = new System.Windows.Forms.ProgressBar();
      this.txtLog = new System.Windows.Forms.TextBox();
      this.cmdAddCaptions = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(81, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Album Directory";
      // 
      // txtAlbumDirectory
      // 
      this.txtAlbumDirectory.Location = new System.Drawing.Point(99, 6);
      this.txtAlbumDirectory.Name = "txtAlbumDirectory";
      this.txtAlbumDirectory.Size = new System.Drawing.Size(503, 20);
      this.txtAlbumDirectory.TabIndex = 1;
      this.txtAlbumDirectory.Text = "C:\\Temp\\Album";
      // 
      // cmdBrowseAlbumDirectory
      // 
      this.cmdBrowseAlbumDirectory.Location = new System.Drawing.Point(608, 6);
      this.cmdBrowseAlbumDirectory.Name = "cmdBrowseAlbumDirectory";
      this.cmdBrowseAlbumDirectory.Size = new System.Drawing.Size(75, 23);
      this.cmdBrowseAlbumDirectory.TabIndex = 2;
      this.cmdBrowseAlbumDirectory.Text = "Browse";
      this.cmdBrowseAlbumDirectory.UseVisualStyleBackColor = true;
      this.cmdBrowseAlbumDirectory.Click += new System.EventHandler(this.cmdBrowseAlbumDirectory_Click);
      // 
      // cmdRemoveCaptions
      // 
      this.cmdRemoveCaptions.Location = new System.Drawing.Point(99, 32);
      this.cmdRemoveCaptions.Name = "cmdRemoveCaptions";
      this.cmdRemoveCaptions.Size = new System.Drawing.Size(136, 23);
      this.cmdRemoveCaptions.TabIndex = 3;
      this.cmdRemoveCaptions.Text = "Remove Captions";
      this.cmdRemoveCaptions.UseVisualStyleBackColor = true;
      this.cmdRemoveCaptions.Click += new System.EventHandler(this.cmdRemoveCaptions_Click);
      // 
      // prg
      // 
      this.prg.Location = new System.Drawing.Point(12, 226);
      this.prg.Name = "prg";
      this.prg.Size = new System.Drawing.Size(719, 23);
      this.prg.TabIndex = 4;
      // 
      // txtLog
      // 
      this.txtLog.Location = new System.Drawing.Point(12, 61);
      this.txtLog.Multiline = true;
      this.txtLog.Name = "txtLog";
      this.txtLog.ReadOnly = true;
      this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtLog.Size = new System.Drawing.Size(719, 159);
      this.txtLog.TabIndex = 5;
      // 
      // cmdAddCaptions
      // 
      this.cmdAddCaptions.Location = new System.Drawing.Point(241, 32);
      this.cmdAddCaptions.Name = "cmdAddCaptions";
      this.cmdAddCaptions.Size = new System.Drawing.Size(136, 23);
      this.cmdAddCaptions.TabIndex = 6;
      this.cmdAddCaptions.Text = "Add Captions";
      this.cmdAddCaptions.UseVisualStyleBackColor = true;
      this.cmdAddCaptions.Click += new System.EventHandler(this.cmdAddCaptions_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(743, 261);
      this.Controls.Add(this.cmdAddCaptions);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.prg);
      this.Controls.Add(this.cmdRemoveCaptions);
      this.Controls.Add(this.cmdBrowseAlbumDirectory);
      this.Controls.Add(this.txtAlbumDirectory);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtAlbumDirectory;
    private System.Windows.Forms.FolderBrowserDialog fbdAlbumDirectory;
    private System.Windows.Forms.Button cmdBrowseAlbumDirectory;
    private System.Windows.Forms.Button cmdRemoveCaptions;
    private System.Windows.Forms.ProgressBar prg;
    private System.Windows.Forms.TextBox txtLog;
    private System.Windows.Forms.Button cmdAddCaptions;
  }
}

