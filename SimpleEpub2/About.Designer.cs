namespace SimpleEpub2
{
	partial class About
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.name = new System.Windows.Forms.Label();
			this.version_label = new System.Windows.Forms.Label();
			this.author_label = new System.Windows.Forms.Label();
			this.email_label = new System.Windows.Forms.Label();
			this.intro_label = new System.Windows.Forms.Label();
			this.intro = new DevComponents.DotNetBar.LabelX();
			this.email = new DevComponents.DotNetBar.LabelX();
			this.author = new DevComponents.DotNetBar.LabelX();
			this.version = new DevComponents.DotNetBar.LabelX();
			this.ok = new DevComponents.DotNetBar.ButtonX();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(150, 140);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(256, 256);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// name
			// 
			this.name.AutoSize = true;
			this.name.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.name.Location = new System.Drawing.Point(426, 144);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(173, 31);
			this.name.TabIndex = 1;
			this.name.Text = "SimpleEpub2";
			// 
			// version_label
			// 
			this.version_label.AutoSize = true;
			this.version_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.version_label.Location = new System.Drawing.Point(431, 194);
			this.version_label.Name = "version_label";
			this.version_label.Size = new System.Drawing.Size(54, 20);
			this.version_label.TabIndex = 2;
			this.version_label.Text = "版本：";
			// 
			// author_label
			// 
			this.author_label.AutoSize = true;
			this.author_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.author_label.Location = new System.Drawing.Point(431, 234);
			this.author_label.Name = "author_label";
			this.author_label.Size = new System.Drawing.Size(54, 20);
			this.author_label.TabIndex = 3;
			this.author_label.Text = "作者：";
			// 
			// email_label
			// 
			this.email_label.AutoSize = true;
			this.email_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.email_label.Location = new System.Drawing.Point(431, 274);
			this.email_label.Name = "email_label";
			this.email_label.Size = new System.Drawing.Size(54, 20);
			this.email_label.TabIndex = 4;
			this.email_label.Text = "邮箱：";
			// 
			// intro_label
			// 
			this.intro_label.AutoSize = true;
			this.intro_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.intro_label.Location = new System.Drawing.Point(431, 314);
			this.intro_label.Name = "intro_label";
			this.intro_label.Size = new System.Drawing.Size(54, 20);
			this.intro_label.TabIndex = 5;
			this.intro_label.Text = "简介：";
			// 
			// intro
			// 
			// 
			// 
			// 
			this.intro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.intro.Location = new System.Drawing.Point(509, 314);
			this.intro.Name = "intro";
			this.intro.Size = new System.Drawing.Size(272, 51);
			this.intro.TabIndex = 6;
			this.intro.Text = "SimpleEpub2是一款把TXT转换为EPUB的小工具。<br/>如果有任何建议或者意见请发Email联系。<br/>谢谢支持！";
			this.intro.WordWrap = true;
			// 
			// email
			// 
			this.email.AutoSize = true;
			// 
			// 
			// 
			this.email.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.email.Location = new System.Drawing.Point(509, 274);
			this.email.Name = "email";
			this.email.Size = new System.Drawing.Size(50, 19);
			this.email.TabIndex = 6;
			this.email.Text = "labelX1";
			// 
			// author
			// 
			this.author.AutoSize = true;
			// 
			// 
			// 
			this.author.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.author.Location = new System.Drawing.Point(509, 234);
			this.author.Name = "author";
			this.author.Size = new System.Drawing.Size(50, 19);
			this.author.TabIndex = 6;
			this.author.Text = "labelX1";
			// 
			// version
			// 
			this.version.AutoSize = true;
			// 
			// 
			// 
			this.version.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.version.Location = new System.Drawing.Point(509, 194);
			this.version.Name = "version";
			this.version.Size = new System.Drawing.Size(50, 19);
			this.version.TabIndex = 6;
			this.version.Text = "labelX1";
			// 
			// ok
			// 
			this.ok.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.ok.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.ok.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ok.Location = new System.Drawing.Point(647, 413);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(120, 45);
			this.ok.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.ok.TabIndex = 7;
			this.ok.Text = "OK";
			// 
			// About
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.ok);
			this.Controls.Add(this.version);
			this.Controls.Add(this.author);
			this.Controls.Add(this.email);
			this.Controls.Add(this.intro);
			this.Controls.Add(this.intro_label);
			this.Controls.Add(this.email_label);
			this.Controls.Add(this.author_label);
			this.Controls.Add(this.version_label);
			this.Controls.Add(this.name);
			this.Controls.Add(this.pictureBox);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "About";
			this.Size = new System.Drawing.Size(950, 650);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label name;
		private System.Windows.Forms.Label version_label;
		private System.Windows.Forms.Label author_label;
		private System.Windows.Forms.Label email_label;
		private System.Windows.Forms.Label intro_label;
		private DevComponents.DotNetBar.LabelX intro;
		private DevComponents.DotNetBar.LabelX email;
		private DevComponents.DotNetBar.LabelX author;
		private DevComponents.DotNetBar.LabelX version;
		private DevComponents.DotNetBar.ButtonX ok;
		protected internal System.Windows.Forms.PictureBox pictureBox;



	}
}
