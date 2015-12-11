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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblNewVersion_label = new System.Windows.Forms.Label();
            this.lblCurVersion_label = new System.Windows.Forms.Label();
            this.btnYes = new DevComponents.DotNetBar.ButtonX();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.lblAppName = new DevComponents.DotNetBar.LabelX();
            this.lblUpdateAvail = new DevComponents.DotNetBar.LabelX();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCurVersion
            // 
            this.lblCurVersion.BackColor = System.Drawing.Color.White;
            this.lblCurVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.lblCurVersion.ForeColor = System.Drawing.Color.Black;
            this.lblCurVersion.Location = new System.Drawing.Point(305, 126);
            this.lblCurVersion.Name = "lblCurVersion";
            this.lblCurVersion.Size = new System.Drawing.Size(74, 19);
            this.lblCurVersion.TabIndex = 20;
            this.lblCurVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNewVersion
            // 
            this.lblNewVersion.BackColor = System.Drawing.Color.White;
            this.lblNewVersion.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.lblNewVersion.ForeColor = System.Drawing.Color.Black;
            this.lblNewVersion.Location = new System.Drawing.Point(305, 98);
            this.lblNewVersion.Name = "lblNewVersion";
            this.lblNewVersion.Size = new System.Drawing.Size(74, 19);
            this.lblNewVersion.TabIndex = 16;
            this.lblNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.ForeColor = System.Drawing.Color.Black;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(12, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(150, 150);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 14;
            this.pictureBox.TabStop = false;
            // 
            // lblNewVersion_label
            // 
            this.lblNewVersion_label.BackColor = System.Drawing.Color.White;
            this.lblNewVersion_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.lblNewVersion_label.ForeColor = System.Drawing.Color.Black;
            this.lblNewVersion_label.Location = new System.Drawing.Point(168, 98);
            this.lblNewVersion_label.Name = "lblNewVersion_label";
            this.lblNewVersion_label.Size = new System.Drawing.Size(100, 19);
            this.lblNewVersion_label.TabIndex = 16;
            this.lblNewVersion_label.Text = "更新版本:";
            this.lblNewVersion_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurVersion_label
            // 
            this.lblCurVersion_label.BackColor = System.Drawing.Color.White;
            this.lblCurVersion_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.25F);
            this.lblCurVersion_label.ForeColor = System.Drawing.Color.Black;
            this.lblCurVersion_label.Location = new System.Drawing.Point(168, 126);
            this.lblCurVersion_label.Name = "lblCurVersion_label";
            this.lblCurVersion_label.Size = new System.Drawing.Size(100, 19);
            this.lblCurVersion_label.TabIndex = 20;
            this.lblCurVersion_label.Text = "当前版本:";
            this.lblCurVersion_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnYes
            // 
            this.btnYes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnYes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnYes.Location = new System.Drawing.Point(90, 350);
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
            this.btnNo.Location = new System.Drawing.Point(230, 350);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 24;
            this.btnNo.Text = "取消";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.lblDescription.ForeColor = System.Drawing.Color.Black;
            this.lblDescription.Location = new System.Drawing.Point(9, 178);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(68, 17);
            this.lblDescription.TabIndex = 26;
            this.lblDescription.Text = "更新内容：";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BackColorRichTextBox = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtDescription.BackgroundStyle.Class = "RichTextBoxBorder";
            this.txtDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.Location = new System.Drawing.Point(12, 205);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 Microsoft YaHei UI;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            this.txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(370, 125);
            this.txtDescription.TabIndex = 30;
            this.txtDescription.TabStop = false;
            // 
            // lblAppName
            // 
            this.lblAppName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblAppName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAppName.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAppName.ForeColor = System.Drawing.Color.Black;
            this.lblAppName.Location = new System.Drawing.Point(168, 12);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(214, 35);
            this.lblAppName.TabIndex = 32;
            this.lblAppName.Text = "labelX1";
            this.lblAppName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblUpdateAvail
            // 
            this.lblUpdateAvail.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblUpdateAvail.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUpdateAvail.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.75F);
            this.lblUpdateAvail.ForeColor = System.Drawing.Color.Black;
            this.lblUpdateAvail.Location = new System.Drawing.Point(168, 51);
            this.lblUpdateAvail.Name = "lblUpdateAvail";
            this.lblUpdateAvail.Size = new System.Drawing.Size(214, 35);
            this.lblUpdateAvail.TabIndex = 31;
            this.lblUpdateAvail.Text = "labelX1";
            this.lblUpdateAvail.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(12, 205);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(370, 125);
            this.richTextBox1.TabIndex = 33;
            this.richTextBox1.Text = "";
            // 
            // AutoUpdateAcceptForm
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(394, 391);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblAppName);
            this.Controls.Add(this.lblUpdateAvail);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblCurVersion_label);
            this.Controls.Add(this.lblCurVersion);
            this.Controls.Add(this.lblNewVersion_label);
            this.Controls.Add(this.lblNewVersion);
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
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label lblNewVersion_label;
		private System.Windows.Forms.Label lblCurVersion_label;
		private DevComponents.DotNetBar.ButtonX btnYes;
        private DevComponents.DotNetBar.ButtonX btnNo;
        private System.Windows.Forms.Label lblDescription;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx txtDescription;
        private DevComponents.DotNetBar.LabelX lblAppName;
        private DevComponents.DotNetBar.LabelX lblUpdateAvail;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}