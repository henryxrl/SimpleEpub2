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
            this.lblDownloading = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.SuspendLayout();
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(215, 125);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(195, 22);
            this.lblProgress.TabIndex = 8;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDownloading
            // 
            this.lblDownloading.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDownloading.Location = new System.Drawing.Point(35, 21);
            this.lblDownloading.Name = "lblDownloading";
            this.lblDownloading.Size = new System.Drawing.Size(375, 45);
            this.lblDownloading.TabIndex = 6;
            this.lblDownloading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercentage
            // 
            this.lblPercentage.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(31, 125);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(164, 22);
            this.lblPercentage.TabIndex = 9;
            this.lblPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            // 
            // 
            // 
            this.progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBar.Location = new System.Drawing.Point(34, 85);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(375, 23);
            this.progressBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Metro;
            this.progressBar.TabIndex = 10;
            this.progressBar.Text = "progressBarX1";
            // 
            // AutoUpdateDownloadForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(444, 176);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblDownloading);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoUpdateDownloadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AutoUpdateDownloadForm_FormClosed);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Label lblDownloading;
        private System.Windows.Forms.Label lblPercentage;
        protected internal DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
	}
}