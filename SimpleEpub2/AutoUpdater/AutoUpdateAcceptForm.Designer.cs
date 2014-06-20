namespace SimpleEpub2.AutoUpdater
{
	partial class AutoUpdateAcceptForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoUpdateAcceptForm));
			this.lblCurVersion = new System.Windows.Forms.Label();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.btnDetails = new System.Windows.Forms.Button();
			this.lblNewVersion = new System.Windows.Forms.Label();
			this.lblUpdateAvail = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCurVersion
			// 
			this.lblCurVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblCurVersion.Location = new System.Drawing.Point(143, 101);
			this.lblCurVersion.Name = "lblCurVersion";
			this.lblCurVersion.Size = new System.Drawing.Size(154, 19);
			this.lblCurVersion.TabIndex = 20;
			this.lblCurVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnYes
			// 
			this.btnYes.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.btnYes.Location = new System.Drawing.Point(97, 140);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.TabIndex = 19;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.btnNo.Location = new System.Drawing.Point(175, 140);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 23);
			this.btnNo.TabIndex = 18;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnDetails
			// 
			this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.btnDetails.Location = new System.Drawing.Point(256, 140);
			this.btnDetails.Name = "btnDetails";
			this.btnDetails.Size = new System.Drawing.Size(75, 23);
			this.btnDetails.TabIndex = 17;
			this.btnDetails.Text = "Details";
			this.btnDetails.UseVisualStyleBackColor = true;
			this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
			// 
			// lblNewVersion
			// 
			this.lblNewVersion.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.lblNewVersion.Location = new System.Drawing.Point(143, 71);
			this.lblNewVersion.Name = "lblNewVersion";
			this.lblNewVersion.Size = new System.Drawing.Size(154, 19);
			this.lblNewVersion.TabIndex = 16;
			this.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblUpdateAvail
			// 
			this.lblUpdateAvail.Font = new System.Drawing.Font("Segoe UI", 13F);
			this.lblUpdateAvail.Location = new System.Drawing.Point(106, 10);
			this.lblUpdateAvail.Name = "lblUpdateAvail";
			this.lblUpdateAvail.Size = new System.Drawing.Size(228, 56);
			this.lblUpdateAvail.TabIndex = 15;
			this.lblUpdateAvail.Text = "An update is available!\r\nWould you like to update?";
			this.lblUpdateAvail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox
			// 
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(12, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(80, 80);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 14;
			this.pictureBox.TabStop = false;
			// 
			// AutoUpdateAcceptForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(346, 173);
			this.Controls.Add(this.lblCurVersion);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnDetails);
			this.Controls.Add(this.lblNewVersion);
			this.Controls.Add(this.lblUpdateAvail);
			this.Controls.Add(this.pictureBox);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AutoUpdateAcceptForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblCurVersion;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnDetails;
		private System.Windows.Forms.Label lblNewVersion;
		private System.Windows.Forms.Label lblUpdateAvail;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}