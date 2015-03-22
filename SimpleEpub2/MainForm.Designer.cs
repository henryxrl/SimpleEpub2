namespace SimpleEpub2
{
	partial class MainForm
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
            this.radialMenu = new DevComponents.DotNetBar.RadialMenu();
            this.Item1 = new DevComponents.DotNetBar.RadialMenuItem();
            this.Space1 = new DevComponents.DotNetBar.RadialMenuItem();
            this.Item3 = new DevComponents.DotNetBar.RadialMenuItem();
            this.Space2 = new DevComponents.DotNetBar.RadialMenuItem();
            this.Item2 = new DevComponents.DotNetBar.RadialMenuItem();
            this.Space3 = new DevComponents.DotNetBar.RadialMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toostripmenu1_show = new System.Windows.Forms.ToolStripMenuItem();
            this.toostripmenu2_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationBar1 = new DevComponents.DotNetBar.NavigationBar();
            this.previous_button = new DevComponents.DotNetBar.ButtonItem();
            this.next_button = new DevComponents.DotNetBar.ButtonItem();
            this.processTXTWorker = new System.ComponentModel.BackgroundWorker();
            this.epubWorker = new System.ComponentModel.BackgroundWorker();
            this.pageSlider1 = new DevComponents.DotNetBar.Controls.PageSlider();
            this.pageSliderPage1 = new DevComponents.DotNetBar.Controls.PageSliderPage();
            this.pageSliderPage2 = new DevComponents.DotNetBar.Controls.PageSliderPage();
            this.pageSliderPage3 = new DevComponents.DotNetBar.Controls.PageSliderPage();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationBar1)).BeginInit();
            this.pageSlider1.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager
            // 
            this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013;
            this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(56)))), ((int)(((byte)(137))))));
            // 
            // radialMenu
            // 
            this.radialMenu.Diameter = 200;
            this.radialMenu.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.Item1,
            this.Space1,
            this.Item3,
            this.Space2,
            this.Item2,
            this.Space3});
            this.radialMenu.Location = new System.Drawing.Point(-100, -100);
            this.radialMenu.Name = "radialMenu";
            this.radialMenu.Size = new System.Drawing.Size(28, 28);
            this.radialMenu.Symbol = "";
            this.radialMenu.SymbolSize = 13F;
            this.radialMenu.TabIndex = 23;
            this.radialMenu.Text = "radialMenu";
            // 
            // Item1
            // 
            this.Item1.Name = "Item1";
            this.Item1.Symbol = "";
            this.Item1.Text = "窗口置顶";
            // 
            // Space1
            // 
            this.Space1.Name = "Space1";
            // 
            // Item3
            // 
            this.Item3.Name = "Item3";
            this.Item3.Symbol = "";
            this.Item3.Text = "关闭";
            // 
            // Space2
            // 
            this.Space2.Name = "Space2";
            // 
            // Item2
            // 
            this.Item2.Name = "Item2";
            this.Item2.Symbol = "";
            this.Item2.Text = "最小化";
            // 
            // Space3
            // 
            this.Space3.Name = "Space3";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SimpleEpub";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toostripmenu1_show,
            this.toostripmenu2_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 48);
            // 
            // toostripmenu1_show
            // 
            this.toostripmenu1_show.Name = "toostripmenu1_show";
            this.toostripmenu1_show.Size = new System.Drawing.Size(166, 22);
            this.toostripmenu1_show.Text = "显示 SimpleEpub";
            this.toostripmenu1_show.Click += new System.EventHandler(this.toostripmenu1_show_Click);
            // 
            // toostripmenu2_exit
            // 
            this.toostripmenu2_exit.Name = "toostripmenu2_exit";
            this.toostripmenu2_exit.Size = new System.Drawing.Size(166, 22);
            this.toostripmenu2_exit.Text = "退出";
            this.toostripmenu2_exit.Click += new System.EventHandler(this.toostripmenu2_exit_Click);
            // 
            // navigationBar1
            // 
            this.navigationBar1.BackgroundStyle.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.navigationBar1.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationBar1.BackgroundStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationBar1.ConfigureAddRemoveVisible = false;
            this.navigationBar1.ConfigureItemVisible = false;
            this.navigationBar1.ConfigureNavOptionsVisible = false;
            this.navigationBar1.ConfigureShowHideVisible = false;
            this.navigationBar1.ItemPaddingBottom = 2;
            this.navigationBar1.ItemPaddingTop = 2;
            this.navigationBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.previous_button,
            this.next_button});
            this.navigationBar1.Location = new System.Drawing.Point(4, 615);
            this.navigationBar1.Name = "navigationBar1";
            this.navigationBar1.Size = new System.Drawing.Size(927, 34);
            this.navigationBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationBar1.TabIndex = 24;
            this.navigationBar1.Text = "navigationBar1";
            // 
            // previous_button
            // 
            this.previous_button.CanCustomize = false;
            this.previous_button.Checked = true;
            this.previous_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_button.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.previous_button.Name = "previous_button";
            this.previous_button.OptionGroup = "navBar";
            this.previous_button.Symbol = "";
            this.previous_button.Text = "buttonItem1";
            this.previous_button.Click += new System.EventHandler(this.previous_button_Click);
            // 
            // next_button
            // 
            this.next_button.CanCustomize = false;
            this.next_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_button.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.next_button.Name = "next_button";
            this.next_button.OptionGroup = "navBar";
            this.next_button.Symbol = "";
            this.next_button.Text = "buttonItem2";
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // processTXTWorker
            // 
            this.processTXTWorker.WorkerReportsProgress = true;
            this.processTXTWorker.WorkerSupportsCancellation = true;
            this.processTXTWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.processTXTWorker_DoWork);
            this.processTXTWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.processTXTWorker_ProgressChanged);
            this.processTXTWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.processTXTWorker_RunWorkerCompleted);
            // 
            // epubWorker
            // 
            this.epubWorker.WorkerReportsProgress = true;
            this.epubWorker.WorkerSupportsCancellation = true;
            this.epubWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.epubWorker_DoWork);
            this.epubWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.epubWorker_ProgressChanged);
            this.epubWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.epubWorker_RunWorkerCompleted);
            // 
            // pageSlider1
            // 
            this.pageSlider1.AnimationTime = 250;
            this.pageSlider1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pageSlider1.Controls.Add(this.pageSliderPage1);
            this.pageSlider1.Controls.Add(this.pageSliderPage2);
            this.pageSlider1.Controls.Add(this.pageSliderPage3);
            this.pageSlider1.IndicatorVisible = false;
            this.pageSlider1.Location = new System.Drawing.Point(0, 0);
            this.pageSlider1.MouseDragEnabled = false;
            this.pageSlider1.Name = "pageSlider1";
            this.pageSlider1.NextPageVisibleMargin = 0;
            this.pageSlider1.PageSpacing = -50;
            this.pageSlider1.ScrollBarVisibility = DevComponents.DotNetBar.Controls.eScrollBarVisibility.Hidden;
            this.pageSlider1.SelectedPage = this.pageSliderPage1;
            this.pageSlider1.Size = new System.Drawing.Size(936, 618);
            this.pageSlider1.TabIndex = 25;
            this.pageSlider1.Text = "pageSlider1";
            this.pageSlider1.TouchEnabled = DevComponents.DotNetBar.Controls.eTouchHandling.No;
            // 
            // pageSliderPage1
            // 
            this.pageSliderPage1.Location = new System.Drawing.Point(4, 4);
            this.pageSliderPage1.MaximumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage1.MinimumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage1.Name = "pageSliderPage1";
            this.pageSliderPage1.Size = new System.Drawing.Size(932, 610);
            this.pageSliderPage1.TabIndex = 3;
            // 
            // pageSliderPage2
            // 
            this.pageSliderPage2.Location = new System.Drawing.Point(932, 4);
            this.pageSliderPage2.MaximumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage2.MinimumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage2.Name = "pageSliderPage2";
            this.pageSliderPage2.Size = new System.Drawing.Size(932, 610);
            this.pageSliderPage2.TabIndex = 4;
            // 
            // pageSliderPage3
            // 
            this.pageSliderPage3.Location = new System.Drawing.Point(1860, 4);
            this.pageSliderPage3.MaximumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage3.MinimumSize = new System.Drawing.Size(932, 610);
            this.pageSliderPage3.Name = "pageSliderPage3";
            this.pageSliderPage3.Size = new System.Drawing.Size(932, 610);
            this.pageSliderPage3.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(936, 651);
            this.Controls.Add(this.radialMenu);
            this.Controls.Add(this.pageSlider1);
            this.Controls.Add(this.navigationBar1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButtonText = "Help";
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 5, 5);
            this.Text = "SimpleEpub";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationBar1)).EndInit();
            this.pageSlider1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.StyleManager styleManager;
		private DevComponents.DotNetBar.RadialMenu radialMenu;
		private DevComponents.DotNetBar.RadialMenuItem Space1;
		private DevComponents.DotNetBar.RadialMenuItem Space2;
        private DevComponents.DotNetBar.RadialMenuItem Space3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toostripmenu1_show;
        private System.Windows.Forms.ToolStripMenuItem toostripmenu2_exit;
		protected internal DevComponents.DotNetBar.RadialMenuItem Item1;
		protected internal DevComponents.DotNetBar.RadialMenuItem Item2;
		protected internal DevComponents.DotNetBar.RadialMenuItem Item3;
		private DevComponents.DotNetBar.NavigationBar navigationBar1;
		private DevComponents.DotNetBar.ButtonItem next_button;
		protected internal DevComponents.DotNetBar.ButtonItem previous_button;
		private System.ComponentModel.BackgroundWorker processTXTWorker;
		private System.ComponentModel.BackgroundWorker epubWorker;
		private DevComponents.DotNetBar.Controls.PageSlider pageSlider1;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage1;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage2;
		private DevComponents.DotNetBar.Controls.PageSliderPage pageSliderPage3;
	}
}

