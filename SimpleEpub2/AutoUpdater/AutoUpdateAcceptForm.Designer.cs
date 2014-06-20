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
			this.lblNewVersion = new System.Windows.Forms.Label();
			this.lblUpdateAvail = new System.Windows.Forms.Label();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnYes = new DevComponents.DotNetBar.ButtonX();
			this.btnNo = new DevComponents.DotNetBar.ButtonX();
			this.txtDescription = new System.Windows.Forms.RichTextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCurVersion
			// 
			this.lblCurVersion.BackColor = System.Drawing.Color.White;
			this.lblCurVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
			this.lblCurVersion.ForeColor = System.Drawing.Color.Black;
			this.lblCurVersion.Location = new System.Drawing.Point(254, 117);
			this.lblCurVersion.Name = "lblCurVersion";
			this.lblCurVersion.Size = new System.Drawing.Size(74, 19);
			this.lblCurVersion.TabIndex = 20;
			this.lblCurVersion.Text = "版本号";
			this.lblCurVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblNewVersion
			// 
			this.lblNewVersion.BackColor = System.Drawing.Color.White;
			this.lblNewVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
			this.lblNewVersion.ForeColor = System.Drawing.Color.Black;
			this.lblNewVersion.Location = new System.Drawing.Point(254, 89);
			this.lblNewVersion.Name = "lblNewVersion";
			this.lblNewVersion.Size = new System.Drawing.Size(74, 19);
			this.lblNewVersion.TabIndex = 16;
			this.lblNewVersion.Text = "版本号";
			this.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUpdateAvail
			// 
			this.lblUpdateAvail.BackColor = System.Drawing.Color.White;
			this.lblUpdateAvail.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.75F);
			this.lblUpdateAvail.ForeColor = System.Drawing.Color.Black;
			this.lblUpdateAvail.Location = new System.Drawing.Point(106, 10);
			this.lblUpdateAvail.Name = "lblUpdateAvail";
			this.lblUpdateAvail.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
			this.lblUpdateAvail.Size = new System.Drawing.Size(276, 80);
			this.lblUpdateAvail.TabIndex = 15;
			this.lblUpdateAvail.Text = "标题";
			this.lblUpdateAvail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.ForeColor = System.Drawing.Color.Black;
			this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
			this.pictureBox.Location = new System.Drawing.Point(12, 10);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(80, 80);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 14;
			this.pictureBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(143, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 19);
			this.label1.TabIndex = 16;
			this.label1.Text = "更新版本:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(143, 117);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 19);
			this.label2.TabIndex = 20;
			this.label2.Text = "当前版本:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnYes
			// 
			this.btnYes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnYes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnYes.Location = new System.Drawing.Point(147, 347);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 23);
			this.btnYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnYes.TabIndex = 23;
			this.btnYes.Text = "确定";
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnNo.Location = new System.Drawing.Point(258, 347);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 23);
			this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnNo.TabIndex = 24;
			this.btnNo.Text = "取消";
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.BackColor = System.Drawing.Color.White;
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDescription.Cursor = System.Windows.Forms.Cursors.Default;
			this.txtDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDescription.ForeColor = System.Drawing.Color.Black;
			this.txtDescription.Location = new System.Drawing.Point(111, 177);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(271, 152);
			this.txtDescription.TabIndex = 25;
			this.txtDescription.TabStop = false;
			this.txtDescription.Text = "更新";
			this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.BackColor = System.Drawing.Color.White;
			this.lblDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
			this.lblDescription.ForeColor = System.Drawing.Color.Black;
			this.lblDescription.Location = new System.Drawing.Point(108, 157);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(68, 17);
			this.lblDescription.TabIndex = 26;
			this.lblDescription.Text = "更新内容：";
			// 
			// AutoUpdateAcceptForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 391);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblCurVersion);
			this.Controls.Add(this.label1);
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
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCurVersion;
		private System.Windows.Forms.Label lblNewVersion;
		private System.Windows.Forms.Label lblUpdateAvail;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private DevComponents.DotNetBar.ButtonX btnYes;
		private DevComponents.DotNetBar.ButtonX btnNo;
		private System.Windows.Forms.RichTextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
	}
}