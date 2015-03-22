namespace SimpleEpub2
{
	partial class Page1
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
            this.txt_picturebox = new System.Windows.Forms.PictureBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.overlay_cover = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cover_intro_textbox = new System.Windows.Forms.TextBox();
            this.cover_author_tile = new System.Windows.Forms.PictureBox();
            this.cover_bookname_tile = new System.Windows.Forms.PictureBox();
            this.cover_intro_tile = new System.Windows.Forms.PictureBox();
            this.cover_bookname_label = new DevComponents.DotNetBar.LabelX();
            this.cover_author_label = new DevComponents.DotNetBar.LabelX();
            this.cover_bookname_textbox = new System.Windows.Forms.TextBox();
            this.cover_author_textbox = new System.Windows.Forms.TextBox();
            this.highlighter = new DevComponents.DotNetBar.Validator.Highlighter();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cover_intro_label = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.txt_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlay_cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_author_tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_bookname_tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_intro_tile)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_picturebox
            // 
            this.txt_picturebox.Location = new System.Drawing.Point(0, 0);
            this.txt_picturebox.Name = "txt_picturebox";
            this.txt_picturebox.Size = new System.Drawing.Size(600, 600);
            this.txt_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.txt_picturebox.TabIndex = 14;
            this.txt_picturebox.TabStop = false;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.White;
            this.line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.line1.ForeColor = System.Drawing.Color.Silver;
            this.line1.Location = new System.Drawing.Point(605, 0);
            this.line1.Margin = new System.Windows.Forms.Padding(0);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(10, 600);
            this.line1.TabIndex = 15;
            this.line1.TabStop = false;
            this.line1.Text = "line1";
            this.line1.VerticalLine = true;
            // 
            // overlay_cover
            // 
            this.overlay_cover.Location = new System.Drawing.Point(0, 0);
            this.overlay_cover.Name = "overlay_cover";
            this.overlay_cover.Size = new System.Drawing.Size(27, 22);
            this.overlay_cover.TabIndex = 16;
            this.overlay_cover.TabStop = false;
            this.overlay_cover.Visible = false;
            // 
            // cover_intro_textbox
            // 
            this.cover_intro_textbox.AcceptsReturn = true;
            this.highlighter.SetHighlightOnFocus(this.cover_intro_textbox, true);
            this.cover_intro_textbox.Location = new System.Drawing.Point(640, 375);
            this.cover_intro_textbox.Multiline = true;
            this.cover_intro_textbox.Name = "cover_intro_textbox";
            this.cover_intro_textbox.Size = new System.Drawing.Size(257, 165);
            this.cover_intro_textbox.TabIndex = 3;
            // 
            // cover_author_tile
            // 
            this.cover_author_tile.Location = new System.Drawing.Point(621, 151);
            this.cover_author_tile.Name = "cover_author_tile";
            this.cover_author_tile.Size = new System.Drawing.Size(297, 144);
            this.cover_author_tile.TabIndex = 23;
            this.cover_author_tile.TabStop = false;
            // 
            // cover_bookname_tile
            // 
            this.cover_bookname_tile.Location = new System.Drawing.Point(621, 0);
            this.cover_bookname_tile.Name = "cover_bookname_tile";
            this.cover_bookname_tile.Size = new System.Drawing.Size(297, 144);
            this.cover_bookname_tile.TabIndex = 23;
            this.cover_bookname_tile.TabStop = false;
            // 
            // cover_intro_tile
            // 
            this.cover_intro_tile.Location = new System.Drawing.Point(621, 303);
            this.cover_intro_tile.Name = "cover_intro_tile";
            this.cover_intro_tile.Size = new System.Drawing.Size(297, 297);
            this.cover_intro_tile.TabIndex = 23;
            this.cover_intro_tile.TabStop = false;
            // 
            // cover_bookname_label
            // 
            // 
            // 
            // 
            this.cover_bookname_label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cover_bookname_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cover_bookname_label.Location = new System.Drawing.Point(641, 14);
            this.cover_bookname_label.Name = "cover_bookname_label";
            this.cover_bookname_label.Size = new System.Drawing.Size(96, 23);
            this.cover_bookname_label.TabIndex = 24;
            this.cover_bookname_label.Text = "labelX1";
            // 
            // cover_author_label
            // 
            // 
            // 
            // 
            this.cover_author_label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cover_author_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cover_author_label.Location = new System.Drawing.Point(639, 180);
            this.cover_author_label.Name = "cover_author_label";
            this.cover_author_label.Size = new System.Drawing.Size(173, 23);
            this.cover_author_label.TabIndex = 26;
            this.cover_author_label.Text = "labelX1";
            // 
            // cover_bookname_textbox
            // 
            this.cover_bookname_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highlighter.SetHighlightOnFocus(this.cover_bookname_textbox, true);
            this.cover_bookname_textbox.Location = new System.Drawing.Point(641, 59);
            this.cover_bookname_textbox.Name = "cover_bookname_textbox";
            this.cover_bookname_textbox.Size = new System.Drawing.Size(191, 23);
            this.cover_bookname_textbox.TabIndex = 1;
            this.cover_bookname_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cover_author_textbox
            // 
            this.cover_author_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highlighter.SetHighlightOnFocus(this.cover_author_textbox, true);
            this.cover_author_textbox.Location = new System.Drawing.Point(641, 231);
            this.cover_author_textbox.Name = "cover_author_textbox";
            this.cover_author_textbox.Size = new System.Drawing.Size(191, 23);
            this.cover_author_textbox.TabIndex = 2;
            this.cover_author_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // highlighter
            // 
            this.highlighter.ContainerControl = this;
            this.highlighter.CustomHighlightColors = new System.Drawing.Color[0];
            // 
            // circularProgress
            // 
            this.circularProgress.AnimationSpeed = 125;
            this.circularProgress.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.Location = new System.Drawing.Point(202, 257);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgress.ProgressColor = System.Drawing.Color.Purple;
            this.circularProgress.Size = new System.Drawing.Size(196, 196);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 28;
            this.circularProgress.TabStop = false;
            // 
            // cover_intro_label
            // 
            // 
            // 
            // 
            this.cover_intro_label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cover_intro_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cover_intro_label.Location = new System.Drawing.Point(640, 328);
            this.cover_intro_label.Name = "cover_intro_label";
            this.cover_intro_label.Size = new System.Drawing.Size(173, 23);
            this.cover_intro_label.TabIndex = 27;
            this.cover_intro_label.Text = "labelX1";
            // 
            // Page1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cover_intro_label);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.cover_author_textbox);
            this.Controls.Add(this.cover_bookname_textbox);
            this.Controls.Add(this.cover_author_label);
            this.Controls.Add(this.cover_bookname_label);
            this.Controls.Add(this.cover_intro_textbox);
            this.Controls.Add(this.cover_intro_tile);
            this.Controls.Add(this.cover_bookname_tile);
            this.Controls.Add(this.cover_author_tile);
            this.Controls.Add(this.overlay_cover);
            this.Controls.Add(this.txt_picturebox);
            this.Controls.Add(this.line1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(918, 600);
            ((System.ComponentModel.ISupportInitialize)(this.txt_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlay_cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_author_tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_bookname_tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_intro_tile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        protected internal System.Windows.Forms.PictureBox txt_picturebox;
        protected internal DevComponents.DotNetBar.Controls.Line line1;
        protected internal System.Windows.Forms.PictureBox overlay_cover;
		protected internal System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.PictureBox cover_author_tile;
		private System.Windows.Forms.PictureBox cover_bookname_tile;
		private System.Windows.Forms.PictureBox cover_intro_tile;
		private DevComponents.DotNetBar.LabelX cover_bookname_label;
        private DevComponents.DotNetBar.LabelX cover_author_label;
		protected internal System.Windows.Forms.TextBox cover_intro_textbox;
		protected internal System.Windows.Forms.TextBox cover_bookname_textbox;
		protected internal System.Windows.Forms.TextBox cover_author_textbox;
		private DevComponents.DotNetBar.Validator.Highlighter highlighter;
		protected internal DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
        private DevComponents.DotNetBar.LabelX cover_intro_label;


	}
}
