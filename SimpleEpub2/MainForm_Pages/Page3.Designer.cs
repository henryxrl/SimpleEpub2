namespace SimpleEpub2
{
	partial class Page3
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
            this.progressSteps = new DevComponents.DotNetBar.ProgressSteps();
            this.stepItem1 = new DevComponents.DotNetBar.StepItem();
            this.stepItem2 = new DevComponents.DotNetBar.StepItem();
            this.stepItem3 = new DevComponents.DotNetBar.StepItem();
            this.stepItem4 = new DevComponents.DotNetBar.StepItem();
            this.stepItem5 = new DevComponents.DotNetBar.StepItem();
            this.stepItem6 = new DevComponents.DotNetBar.StepItem();
            this.processing_label = new System.Windows.Forms.Label();
            this.circularProgress = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.cover = new System.Windows.Forms.PictureBox();
            this.bookinfo_tile = new System.Windows.Forms.PictureBox();
            this.bookname_label = new System.Windows.Forms.Label();
            this.bookauthor_label = new System.Windows.Forms.Label();
            this.bookwordcount_tile = new System.Windows.Forms.PictureBox();
            this.bookwordcount_label = new System.Windows.Forms.Label();
            this.bookwordcountnr_label = new System.Windows.Forms.Label();
            this.bookintro_tile = new System.Windows.Forms.PictureBox();
            this.bookintro_label = new System.Windows.Forms.Label();
            this.bookname = new DevComponents.DotNetBar.LabelX();
            this.bookwordcount = new DevComponents.DotNetBar.LabelX();
            this.bookauthor = new DevComponents.DotNetBar.LabelX();
            this.bookwordcountnr = new DevComponents.DotNetBar.LabelX();
            this.bookintro = new DevComponents.DotNetBar.LabelX();
            this.location_label = new DevComponents.DotNetBar.LabelX();
            this.FAILED = new System.Windows.Forms.Label();
            this.time_label = new DevComponents.DotNetBar.LabelX();
            this.newbook_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookinfo_tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookwordcount_tile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookintro_tile)).BeginInit();
            this.SuspendLayout();
            // 
            // progressSteps
            // 
            this.progressSteps.AutoSize = true;
            this.progressSteps.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.progressSteps.BackgroundStyle.Class = "ProgressSteps";
            this.progressSteps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressSteps.ContainerControlProcessDialogKey = true;
            this.progressSteps.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.stepItem1,
            this.stepItem2,
            this.stepItem3,
            this.stepItem4,
            this.stepItem5,
            this.stepItem6});
            this.progressSteps.Location = new System.Drawing.Point(69, 94);
            this.progressSteps.Name = "progressSteps";
            this.progressSteps.Size = new System.Drawing.Size(762, 58);
            this.progressSteps.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.progressSteps.TabIndex = 17;
            this.progressSteps.TabStop = false;
            // 
            // stepItem1
            // 
            this.stepItem1.HotTracking = false;
            this.stepItem1.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem1.Name = "stepItem1";
            this.stepItem1.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem1.Symbol = "";
            this.stepItem1.SymbolSize = 13F;
            this.stepItem1.Text = "<font size=\"+2\"><b>Sign In</b></font><br/><font size=\"-1\">Enter your<br/>credenti" +
    "als</font>";
            this.stepItem1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem2
            // 
            this.stepItem2.HotTracking = false;
            this.stepItem2.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem2.Name = "stepItem2";
            this.stepItem2.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem2.Symbol = "";
            this.stepItem2.SymbolSize = 13F;
            this.stepItem2.Text = "<font size=\"+2\"><b>Address</b></font><br/><font size=\"-1\">Select<br/>destination<" +
    "/font>";
            this.stepItem2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem3
            // 
            this.stepItem3.HotTracking = false;
            this.stepItem3.MinimumSize = new System.Drawing.Size(100, 0);
            this.stepItem3.Name = "stepItem3";
            this.stepItem3.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem3.Symbol = "";
            this.stepItem3.SymbolSize = 13F;
            this.stepItem3.Text = "<font size=\"+2\"><b>Options</b></font><br/><font size=\"-1\">Gift wrap<br/> </font>";
            this.stepItem3.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;
            // 
            // stepItem4
            // 
            this.stepItem4.HotTracking = false;
            this.stepItem4.Name = "stepItem4";
            this.stepItem4.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem4.Symbol = "";
            this.stepItem4.SymbolSize = 13F;
            this.stepItem4.Text = "<font size=\"+2\"><b>Payment</b></font><br/><font size=\"-1\">Choose payment<br/>meth" +
    "od</font>";
            // 
            // stepItem5
            // 
            this.stepItem5.HotTracking = false;
            this.stepItem5.Name = "stepItem5";
            this.stepItem5.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem5.Symbol = "";
            this.stepItem5.SymbolSize = 13F;
            this.stepItem5.Text = "<font size=\"+2\"><b>Confirm</b></font><br/><font size=\"-1\">Review your<br/>order</" +
    "font>";
            // 
            // stepItem6
            // 
            this.stepItem6.HotTracking = false;
            this.stepItem6.Name = "stepItem6";
            this.stepItem6.ProgressColors = new System.Drawing.Color[] {
        System.Drawing.Color.BlueViolet};
            this.stepItem6.Symbol = "";
            this.stepItem6.SymbolSize = 13F;
            this.stepItem6.Text = "<font size=\"+2\"><b>Confirm</b></font><br/><font size=\"-1\">Review your<br/>order</" +
    "font>";
            // 
            // processing_label
            // 
            this.processing_label.AutoSize = true;
            this.processing_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.processing_label.Location = new System.Drawing.Point(62, 5);
            this.processing_label.Name = "processing_label";
            this.processing_label.Size = new System.Drawing.Size(207, 50);
            this.processing_label.TabIndex = 18;
            this.processing_label.Text = "生成完毕！";
            // 
            // circularProgress
            // 
            this.circularProgress.AnimationSpeed = 125;
            this.circularProgress.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.circularProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.circularProgress.Location = new System.Drawing.Point(352, 275);
            this.circularProgress.Name = "circularProgress";
            this.circularProgress.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.circularProgress.ProgressColor = System.Drawing.Color.Purple;
            this.circularProgress.Size = new System.Drawing.Size(196, 196);
            this.circularProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.circularProgress.TabIndex = 20;
            this.circularProgress.TabStop = false;
            // 
            // cover
            // 
            this.cover.BackColor = System.Drawing.Color.Transparent;
            this.cover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cover.Location = new System.Drawing.Point(69, 173);
            this.cover.Name = "cover";
            this.cover.Size = new System.Drawing.Size(324, 432);
            this.cover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cover.TabIndex = 21;
            this.cover.TabStop = false;
            this.cover.Visible = false;
            // 
            // bookinfo_tile
            // 
            this.bookinfo_tile.BackColor = System.Drawing.Color.Transparent;
            this.bookinfo_tile.Location = new System.Drawing.Point(399, 173);
            this.bookinfo_tile.Name = "bookinfo_tile";
            this.bookinfo_tile.Size = new System.Drawing.Size(213, 213);
            this.bookinfo_tile.TabIndex = 21;
            this.bookinfo_tile.TabStop = false;
            this.bookinfo_tile.Visible = false;
            // 
            // bookname_label
            // 
            this.bookname_label.AutoSize = true;
            this.bookname_label.BackColor = System.Drawing.Color.Transparent;
            this.bookname_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookname_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookname_label.Location = new System.Drawing.Point(405, 183);
            this.bookname_label.Name = "bookname_label";
            this.bookname_label.Size = new System.Drawing.Size(50, 26);
            this.bookname_label.TabIndex = 18;
            this.bookname_label.Text = "书名";
            this.bookname_label.Visible = false;
            // 
            // bookauthor_label
            // 
            this.bookauthor_label.AutoSize = true;
            this.bookauthor_label.BackColor = System.Drawing.Color.Transparent;
            this.bookauthor_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookauthor_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookauthor_label.Location = new System.Drawing.Point(405, 279);
            this.bookauthor_label.Name = "bookauthor_label";
            this.bookauthor_label.Size = new System.Drawing.Size(50, 26);
            this.bookauthor_label.TabIndex = 18;
            this.bookauthor_label.Text = "作者";
            this.bookauthor_label.Visible = false;
            // 
            // bookwordcount_tile
            // 
            this.bookwordcount_tile.BackColor = System.Drawing.Color.Transparent;
            this.bookwordcount_tile.Location = new System.Drawing.Point(618, 173);
            this.bookwordcount_tile.Name = "bookwordcount_tile";
            this.bookwordcount_tile.Size = new System.Drawing.Size(213, 213);
            this.bookwordcount_tile.TabIndex = 21;
            this.bookwordcount_tile.TabStop = false;
            this.bookwordcount_tile.Visible = false;
            // 
            // bookwordcount_label
            // 
            this.bookwordcount_label.AutoSize = true;
            this.bookwordcount_label.BackColor = System.Drawing.Color.Transparent;
            this.bookwordcount_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookwordcount_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookwordcount_label.Location = new System.Drawing.Point(624, 183);
            this.bookwordcount_label.Name = "bookwordcount_label";
            this.bookwordcount_label.Size = new System.Drawing.Size(69, 26);
            this.bookwordcount_label.TabIndex = 18;
            this.bookwordcount_label.Text = "总字数";
            this.bookwordcount_label.Visible = false;
            // 
            // bookwordcountnr_label
            // 
            this.bookwordcountnr_label.AutoSize = true;
            this.bookwordcountnr_label.BackColor = System.Drawing.Color.Transparent;
            this.bookwordcountnr_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookwordcountnr_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookwordcountnr_label.Location = new System.Drawing.Point(624, 279);
            this.bookwordcountnr_label.Name = "bookwordcountnr_label";
            this.bookwordcountnr_label.Size = new System.Drawing.Size(107, 26);
            this.bookwordcountnr_label.TabIndex = 18;
            this.bookwordcountnr_label.Text = "不重复字数";
            this.bookwordcountnr_label.Visible = false;
            // 
            // bookintro_tile
            // 
            this.bookintro_tile.BackColor = System.Drawing.Color.Transparent;
            this.bookintro_tile.Location = new System.Drawing.Point(399, 392);
            this.bookintro_tile.Name = "bookintro_tile";
            this.bookintro_tile.Size = new System.Drawing.Size(432, 213);
            this.bookintro_tile.TabIndex = 21;
            this.bookintro_tile.TabStop = false;
            this.bookintro_tile.Visible = false;
            // 
            // bookintro_label
            // 
            this.bookintro_label.AutoSize = true;
            this.bookintro_label.BackColor = System.Drawing.Color.Transparent;
            this.bookintro_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookintro_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookintro_label.Location = new System.Drawing.Point(405, 402);
            this.bookintro_label.Name = "bookintro_label";
            this.bookintro_label.Size = new System.Drawing.Size(50, 26);
            this.bookintro_label.TabIndex = 18;
            this.bookintro_label.Text = "简介";
            this.bookintro_label.Visible = false;
            // 
            // bookname
            // 
            this.bookname.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bookname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bookname.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookname.Location = new System.Drawing.Point(409, 205);
            this.bookname.MaximumSize = new System.Drawing.Size(193, 71);
            this.bookname.MinimumSize = new System.Drawing.Size(193, 71);
            this.bookname.Name = "bookname";
            this.bookname.Size = new System.Drawing.Size(193, 71);
            this.bookname.TabIndex = 22;
            this.bookname.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bookname.Visible = false;
            this.bookname.WordWrap = true;
            // 
            // bookwordcount
            // 
            this.bookwordcount.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bookwordcount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bookwordcount.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookwordcount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookwordcount.Location = new System.Drawing.Point(628, 205);
            this.bookwordcount.MaximumSize = new System.Drawing.Size(193, 71);
            this.bookwordcount.MinimumSize = new System.Drawing.Size(193, 71);
            this.bookwordcount.Name = "bookwordcount";
            this.bookwordcount.Size = new System.Drawing.Size(193, 71);
            this.bookwordcount.TabIndex = 22;
            this.bookwordcount.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bookwordcount.Visible = false;
            this.bookwordcount.WordWrap = true;
            // 
            // bookauthor
            // 
            this.bookauthor.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bookauthor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bookauthor.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookauthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookauthor.Location = new System.Drawing.Point(409, 301);
            this.bookauthor.MaximumSize = new System.Drawing.Size(193, 71);
            this.bookauthor.MinimumSize = new System.Drawing.Size(193, 71);
            this.bookauthor.Name = "bookauthor";
            this.bookauthor.Size = new System.Drawing.Size(193, 71);
            this.bookauthor.TabIndex = 22;
            this.bookauthor.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bookauthor.Visible = false;
            this.bookauthor.WordWrap = true;
            // 
            // bookwordcountnr
            // 
            this.bookwordcountnr.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bookwordcountnr.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bookwordcountnr.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bookwordcountnr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookwordcountnr.Location = new System.Drawing.Point(628, 301);
            this.bookwordcountnr.MaximumSize = new System.Drawing.Size(193, 71);
            this.bookwordcountnr.MinimumSize = new System.Drawing.Size(193, 71);
            this.bookwordcountnr.Name = "bookwordcountnr";
            this.bookwordcountnr.Size = new System.Drawing.Size(193, 71);
            this.bookwordcountnr.TabIndex = 22;
            this.bookwordcountnr.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bookwordcountnr.Visible = false;
            this.bookwordcountnr.WordWrap = true;
            // 
            // bookintro
            // 
            this.bookintro.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.bookintro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bookintro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bookintro.Location = new System.Drawing.Point(409, 429);
            this.bookintro.MaximumSize = new System.Drawing.Size(412, 165);
            this.bookintro.MinimumSize = new System.Drawing.Size(412, 165);
            this.bookintro.Name = "bookintro";
            this.bookintro.Size = new System.Drawing.Size(412, 165);
            this.bookintro.TabIndex = 22;
            this.bookintro.TextLineAlignment = System.Drawing.StringAlignment.Near;
            this.bookintro.Visible = false;
            this.bookintro.WordWrap = true;
            // 
            // location_label
            // 
            this.location_label.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.location_label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.location_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.location_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.location_label.Location = new System.Drawing.Point(69, 51);
            this.location_label.Name = "location_label";
            this.location_label.Size = new System.Drawing.Size(1000, 26);
            this.location_label.TabIndex = 23;
            this.location_label.Text = "位置：";
            // 
            // FAILED
            // 
            this.FAILED.AutoSize = true;
            this.FAILED.Font = new System.Drawing.Font("Microsoft YaHei UI", 150F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FAILED.ForeColor = System.Drawing.Color.Firebrick;
            this.FAILED.Location = new System.Drawing.Point(334, 244);
            this.FAILED.MaximumSize = new System.Drawing.Size(250, 250);
            this.FAILED.MinimumSize = new System.Drawing.Size(250, 250);
            this.FAILED.Name = "FAILED";
            this.FAILED.Size = new System.Drawing.Size(250, 250);
            this.FAILED.TabIndex = 27;
            this.FAILED.Text = "⛒";
            this.FAILED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time_label
            // 
            // 
            // 
            // 
            this.time_label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.time_label.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time_label.Location = new System.Drawing.Point(69, 65);
            this.time_label.Name = "time_label";
            this.time_label.Size = new System.Drawing.Size(762, 23);
            this.time_label.TabIndex = 28;
            this.time_label.Text = "耗时：";
            // 
            // newbook_button
            // 
            this.newbook_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newbook_button.FlatAppearance.BorderSize = 0;
            this.newbook_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbook_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.newbook_button.Location = new System.Drawing.Point(885, 0);
            this.newbook_button.Name = "newbook_button";
            this.newbook_button.Size = new System.Drawing.Size(40, 605);
            this.newbook_button.TabIndex = 30;
            this.newbook_button.Text = "OK";
            this.newbook_button.UseVisualStyleBackColor = true;
            // 
            // Page3
            // 
            this.AllowDrop = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.newbook_button);
            this.Controls.Add(this.time_label);
            this.Controls.Add(this.location_label);
            this.Controls.Add(this.bookwordcountnr);
            this.Controls.Add(this.bookintro);
            this.Controls.Add(this.bookauthor);
            this.Controls.Add(this.bookwordcount);
            this.Controls.Add(this.bookname);
            this.Controls.Add(this.processing_label);
            this.Controls.Add(this.bookwordcountnr_label);
            this.Controls.Add(this.bookauthor_label);
            this.Controls.Add(this.bookintro_label);
            this.Controls.Add(this.bookwordcount_label);
            this.Controls.Add(this.bookname_label);
            this.Controls.Add(this.bookintro_tile);
            this.Controls.Add(this.bookwordcount_tile);
            this.Controls.Add(this.bookinfo_tile);
            this.Controls.Add(this.cover);
            this.Controls.Add(this.progressSteps);
            this.Controls.Add(this.circularProgress);
            this.Controls.Add(this.FAILED);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Page3";
            this.Size = new System.Drawing.Size(940, 605);
            ((System.ComponentModel.ISupportInitialize)(this.cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookinfo_tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookwordcount_tile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookintro_tile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		protected internal DevComponents.DotNetBar.StepItem stepItem1;
		protected internal DevComponents.DotNetBar.StepItem stepItem3;
		protected internal DevComponents.DotNetBar.StepItem stepItem5;
		protected internal DevComponents.DotNetBar.StepItem stepItem4;
		protected internal DevComponents.DotNetBar.StepItem stepItem2;
        protected internal System.Windows.Forms.Label processing_label;
		protected internal DevComponents.DotNetBar.Controls.CircularProgress circularProgress;
		protected internal System.Windows.Forms.Label bookname_label;
		protected internal System.Windows.Forms.Label bookauthor_label;
		protected internal System.Windows.Forms.Label bookwordcount_label;
		protected internal System.Windows.Forms.Label bookwordcountnr_label;
		protected internal System.Windows.Forms.Label bookintro_label;
		protected internal System.Windows.Forms.PictureBox cover;
		protected internal System.Windows.Forms.PictureBox bookwordcount_tile;
		protected internal System.Windows.Forms.PictureBox bookintro_tile;
		protected internal System.Windows.Forms.PictureBox bookinfo_tile;
        protected internal System.Windows.Forms.Label FAILED;
        protected internal System.Windows.Forms.Button newbook_button;
        protected internal DevComponents.DotNetBar.StepItem stepItem6;
        protected internal DevComponents.DotNetBar.ProgressSteps progressSteps;
        protected internal DevComponents.DotNetBar.LabelX bookname;
        protected internal DevComponents.DotNetBar.LabelX bookwordcount;
        protected internal DevComponents.DotNetBar.LabelX bookauthor;
        protected internal DevComponents.DotNetBar.LabelX bookwordcountnr;
        protected internal DevComponents.DotNetBar.LabelX bookintro;
        protected internal DevComponents.DotNetBar.LabelX location_label;
        protected internal DevComponents.DotNetBar.LabelX time_label;
    }
}
