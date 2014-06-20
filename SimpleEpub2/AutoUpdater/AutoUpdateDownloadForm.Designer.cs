namespace SimpleEpub2.AutoUpdater
{
	partial class AutoUpdateDownloadForm
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
			this.lblProgress = new System.Windows.Forms.Label();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lblDownloading = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblProgress
			// 
			this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.lblProgress.Location = new System.Drawing.Point(34, 143);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(344, 13);
			this.lblProgress.TabIndex = 8;
			this.lblProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(34, 117);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(344, 23);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 7;
			// 
			// lblDownloading
			// 
			this.lblDownloading.AutoSize = true;
			this.lblDownloading.Font = new System.Drawing.Font("Segoe UI", 24F);
			this.lblDownloading.Location = new System.Drawing.Point(35, 41);
			this.lblDownloading.Name = "lblDownloading";
			this.lblDownloading.Size = new System.Drawing.Size(343, 45);
			this.lblDownloading.TabIndex = 6;
			this.lblDownloading.Text = "Downloading Update...";
			// 
			// AutoUpdateDownloadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(413, 196);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.lblDownloading);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AutoUpdateDownloadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Downloading Update";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoUpdateDownloadForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lblDownloading;
	}
}