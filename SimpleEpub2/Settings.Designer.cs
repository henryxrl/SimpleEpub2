namespace SimpleEpub2
{
	partial class Settings
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
			this.settings_done_button = new System.Windows.Forms.Button();
			this.superTabStrip1 = new DevComponents.DotNetBar.SuperTabStrip();
			this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
			this.pageSlider1 = new DevComponents.DotNetBar.Controls.PageSlider();
			this.pageSliderPage1 = new DevComponents.DotNetBar.Controls.PageSliderPage();
			this.pageSliderPage2 = new DevComponents.DotNetBar.Controls.PageSliderPage();
			this.pageSliderPage3 = new DevComponents.DotNetBar.Controls.PageSliderPage();
			this.pageSliderPage4 = new DevComponents.DotNetBar.Controls.PageSliderPage();
			((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).BeginInit();
			this.pageSlider1.SuspendLayout();
			this.SuspendLayout();
			// 
			// settings_done_button
			// 
			this.settings_done_button.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.settings_done_button.Location = new System.Drawing.Point(0, 605);
			this.settings_done_button.Name = "settings_done_button";
			this.settings_done_button.Size = new System.Drawing.Size(950, 35);
			this.settings_done_button.TabIndex = 46;
			this.settings_done_button.Text = "OK";
			this.settings_done_button.UseVisualStyleBackColor = true;
			// 
			// superTabStrip1
			// 
			this.superTabStrip1.AutoSelectAttachedControl = false;
			this.superTabStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			// 
			// 
			// 
			this.superTabStrip1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.superTabStrip1.CloseButtonOnTabsAlwaysDisplayed = false;
			this.superTabStrip1.ContainerControlProcessDialogKey = true;
			// 
			// 
			// 
			// 
			// 
			// 
			this.superTabStrip1.ControlBox.CloseBox.Name = "";
			// 
			// 
			// 
			this.superTabStrip1.ControlBox.MenuBox.Name = "";
			this.superTabStrip1.ControlBox.Name = "";
			this.superTabStrip1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabStrip1.ControlBox.MenuBox,
            this.superTabStrip1.ControlBox.CloseBox});
			this.superTabStrip1.FixedTabSize = new System.Drawing.Size(200, 0);
			this.superTabStrip1.ForeColor = System.Drawing.Color.Black;
			this.superTabStrip1.Location = new System.Drawing.Point(3, 8);
			this.superTabStrip1.Name = "superTabStrip1";
			this.superTabStrip1.ReorderTabsEnabled = false;
			this.superTabStrip1.SelectedTabFont = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.superTabStrip1.SelectedTabIndex = 0;
			this.superTabStrip1.Size = new System.Drawing.Size(202, 592);
			this.superTabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left;
			this.superTabStrip1.TabCloseButtonHot = null;
			this.superTabStrip1.TabFont = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.superTabStrip1.TabIndex = 47;
			this.superTabStrip1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit;
			this.superTabStrip1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.superTabItem3,
            this.superTabItem4});
			this.superTabStrip1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
			this.superTabStrip1.TabVerticalSpacing = 40;
			this.superTabStrip1.Text = "superTabStrip1";
			this.superTabStrip1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
			// 
			// superTabItem1
			// 
			this.superTabItem1.GlobalItem = false;
			this.superTabItem1.Name = "superTabItem1";
			this.superTabItem1.Text = "电子书整体设置";
			// 
			// superTabItem2
			// 
			this.superTabItem2.GlobalItem = false;
			this.superTabItem2.Name = "superTabItem2";
			this.superTabItem2.Text = "页面设置";
			// 
			// superTabItem3
			// 
			this.superTabItem3.GlobalItem = false;
			this.superTabItem3.Name = "superTabItem3";
			this.superTabItem3.Text = "文字样式设置";
			// 
			// superTabItem4
			// 
			this.superTabItem4.GlobalItem = false;
			this.superTabItem4.Name = "superTabItem4";
			this.superTabItem4.Text = "其它设置";
			// 
			// pageSlider1
			// 
			this.pageSlider1.AnimationTime = 250;
			this.pageSlider1.Controls.Add(this.pageSliderPage1);
			this.pageSlider1.Controls.Add(this.pageSliderPage2);
			this.pageSlider1.Controls.Add(this.pageSliderPage3);
			this.pageSlider1.Controls.Add(this.pageSliderPage4);
			this.pageSlider1.IndicatorVisible = false;
			this.pageSlider1.Location = new System.Drawing.Point(207, 8);
			this.pageSlider1.Margin = new System.Windows.Forms.Padding(0);
			this.pageSlider1.MouseDragEnabled = false;
			this.pageSlider1.Name = "pageSlider1";
			this.pageSlider1.NextPageVisibleMargin = 0;
			this.pageSlider1.Orientation = DevComponents.DotNetBar.eOrientation.Vertical;
			this.pageSlider1.PageMouseDragEnabled = false;
			this.pageSlider1.ScrollBarVisibility = DevComponents.DotNetBar.Controls.eScrollBarVisibility.Hidden;
			this.pageSlider1.SelectedPage = this.pageSliderPage1;
			this.pageSlider1.Size = new System.Drawing.Size(743, 592);
			this.pageSlider1.TabIndex = 48;
			this.pageSlider1.Text = "pageSlider1";
			this.pageSlider1.TouchEnabled = DevComponents.DotNetBar.Controls.eTouchHandling.No;
			// 
			// pageSliderPage1
			// 
			this.pageSliderPage1.Location = new System.Drawing.Point(4, 4);
			this.pageSliderPage1.MaximumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage1.MinimumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage1.Name = "pageSliderPage1";
			this.pageSliderPage1.Size = new System.Drawing.Size(735, 585);
			this.pageSliderPage1.TabIndex = 3;
			// 
			// pageSliderPage2
			// 
			this.pageSliderPage2.Location = new System.Drawing.Point(4, 588);
			this.pageSliderPage2.MaximumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage2.MinimumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage2.Name = "pageSliderPage2";
			this.pageSliderPage2.Size = new System.Drawing.Size(735, 585);
			this.pageSliderPage2.TabIndex = 4;
			// 
			// pageSliderPage3
			// 
			this.pageSliderPage3.Location = new System.Drawing.Point(4, 1172);
			this.pageSliderPage3.MaximumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage3.MinimumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage3.Name = "pageSliderPage3";
			this.pageSliderPage3.Size = new System.Drawing.Size(735, 585);
			this.pageSliderPage3.TabIndex = 5;
			// 
			// pageSliderPage4
			// 
			this.pageSliderPage4.Location = new System.Drawing.Point(4, 1756);
			this.pageSliderPage4.MaximumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage4.MinimumSize = new System.Drawing.Size(735, 585);
			this.pageSliderPage4.Name = "pageSliderPage4";
			this.pageSliderPage4.Size = new System.Drawing.Size(735, 585);
			this.pageSliderPage4.TabIndex = 6;
			// 
			// Settings
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.pageSlider1);
			this.Controls.Add(this.superTabStrip1);
			this.Controls.Add(this.settings_done_button);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "Settings";
			this.Size = new System.Drawing.Size(950, 650);
			((System.ComponentModel.ISupportInitialize)(this.superTabStrip1)).EndInit();
			this.pageSlider1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button settings_done_button;
		private DevComponents.DotNetBar.SuperTabStrip superTabStrip1;
		private DevComponents.DotNetBar.SuperTabItem superTabItem1;
		private DevComponents.DotNetBar.SuperTabItem superTabItem2;
		private DevComponents.DotNetBar.SuperTabItem superTabItem3;
		private DevComponents.DotNetBar.SuperTabItem superTabItem4;
		private DevComponents.DotNetBar.Controls.PageSlider pageSlider1;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage1;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage2;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage3;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage4;




	}
}
