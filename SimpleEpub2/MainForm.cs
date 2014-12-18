using DevComponents.DotNetBar;
using Ionic.Zip;
using SimpleEpub2.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using VB = Microsoft.VisualBasic;

namespace SimpleEpub2
{
	public partial class MainForm : DevComponents.DotNetBar.Metro.MetroForm, AutoUpdater.AutoUpdatable
	{
		// 无法将DotNetBar2.dll设为嵌入资源并通过Assembly调用
		// 将其生成操作设为无以减小程序体积
		// 在引用文件夹里，将其复制本地设为True
		// 【更新】把Ionic.Zip.dll也设为复制本地，然后用ILMerge打包成一个exe文件！
		// 在Build的时候用ILMerge自动生成单文件EXE！
		

		#region Variables
		private AutoUpdater.AutoUpdater updater;

		#region AutoUpdate
		public string ApplicationName
		{
			get { return "SimpleEpub2"; }
		}

		public string ApplicationID
		{
			get { return "SimpleEpub2"; }
		}

		public Assembly ApplicationAssembly
		{
			get { return Assembly.GetExecutingAssembly(); }
		}

		public Icon ApplicationIcon
		{
			get { return this.Icon; }
		}

		public Uri UpdateXmlLocation
		{
			get { return new Uri("https://raw.githubusercontent.com/henryxrl/SimpleEpub2/master/SimpleEpub2_Update.xml"); }
		}

		public Form Context
		{
			get { return this; }
		}
		#endregion

		private Page1 pg1 = null;
		private Page2 pg2 = null;
		private Page3 pg3 = null;
		private About abt = null;
		private Settings sts = null;
		
		private SettingsObject stsObj = null;

		//private DevComponents.DotNetBar.Controls.SlidePanel[] cq = null;
		private Int32 cqIDX = 0;

		private System.Drawing.Color themeColor = System.Drawing.Color.FromArgb(255, 90, 35, 120);


		/*private static String tempPath = Path.Combine(Path.GetTempPath(), "SimpleEpub2");
		private static String resourcesPath = Path.Combine(Path.GetTempPath(), "SimpleEpub2") + "\\Resources";*/
		private static String tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SimpleEpub2");
		private static String resourcesPath = tempPath + "\\Resources";
		private static String settingsPath = resourcesPath + "\\settings.ini";


		private static String regex = "^(\\s*([【])?(正文\\s*)?[第序终終【]\\s*([——-——一二两三四五六七八九十○零百千壹贰叁肆伍陆柒捌玖拾佰仟0-9０-９\\s/\\、、]*)\\s*[章节節回集卷部】]\\s*.{0,30}?$)|^(\\s*(内容简介|內容簡介|内容介绍|內容介紹|内容梗概|内容大意|小说简介|小說簡介|小说介绍|小說介紹|小说大意|小說大意|书籍简介|書籍簡介|书籍介绍|書籍介紹|书籍大意|書籍大意|作品简介|作品簡介|作品介绍|作品介紹|作品大意|作者简介|作者簡介|作者介绍|作者介紹|序|序言|序章|前言|楔子|终章|終章|尾声|尾聲|后记|後記|完本感言|出版后记|出版後記|谢辞|謝辭)\\s*.{0,40}?$)|^(\\s*((?i)chapter)\\s*.{0,40}?$)|^(\\s*((?i)appendix)\\s*.{0,40}?$)";
		private static String emptyLineRegex = "^\\s*$";

		private List<String> bookAndAuthor = new List<String>();
		private List<Tuple<Int32, String>> TOC = new List<Tuple<Int32, String>>();
		private Int32 FSLinesScanned = 0;
		private Boolean extraLinesInBeginning = false;
		private Boolean extraLinesNotEmpty = false;
		private List<Int32> titleLineNumbers = new List<Int32>();
		private List<Tuple<String, String>> pictureHTMLs = new List<Tuple<String, String>>();
		private String TXTPath;
		private String CoverPath;
		private String CoverPathSlim;
		private Bitmap[] covers = { null, null };
		private Boolean reCovers = false;
		private Boolean isPicCover = false;
		private String origCover;
		private Boolean coverChanged = true;
		private String DocName;
		private String Intro;
		private Int32 chapterNumber = 1;
		private Boolean parchmentNeeded = false;
		private List<String> embedFontPaths = new List<String>();
		private HashSet<Char> ALLTITLETEXT = new HashSet<Char>();
		private HashSet<Char> ALLBODYTEXT = new HashSet<Char>();
		private ICollection<UInt16> IndexT = new List<UInt16>();
		private ICollection<UInt16> IndexB = new List<UInt16>();
		private String titleFontPath;
		private String bodyFontPath;
		private GlyphTypeface glyphTypefaceT;
		private GlyphTypeface glyphTypefaceB;
		private Uri URIT;
		private Uri URIB;
		private Int64 wordcount;
		private Int64 wordcountnr;
		private Boolean noNeedEmbed = false;

		private Boolean hasFootNote = false;

		private String mimetype;
		private String container;
		private StringBuilder css = new StringBuilder();
		private StringBuilder opf = new StringBuilder();
		private StringBuilder ncx = new StringBuilder();
		private StringBuilder coverHtml = new StringBuilder();
		private List<String> picHtmlList = new List<String>();
		private List<String> txtHtmlList = new List<String>();

		private String zipPath;
		private String processedIntro;

		private Stopwatch stopWatch;

		private Boolean broken = false;
		private Boolean DONE = false;

		#endregion

		
		#region Form Preset
		public MainForm()
		{
			#region Obsolete Code: Loading dll's from Assembly
			/*AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
			{
				String resourceName = new AssemblyName(args.Name).Name + ".dll";
				String resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

				using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
				{
					Byte[] assemblyData = new Byte[stream.Length];
					stream.Read(assemblyData, 0, assemblyData.Length);
					return Assembly.Load(assemblyData);
				}
			};*/
			#endregion

			Directory.CreateDirectory(tempPath);
			Directory.CreateDirectory(resourcesPath);

			#region Set Form
			InitializeComponent();

			updater = new AutoUpdater.AutoUpdater(this);

			//this.FormClosing += MainForm_FormClosing;

			TitleText = "<div align=\"left\">  SimpleEpub2</div>";
			MaximizeBox = false;
			SettingsButtonText = "<b>SETTINGS</b>";
			SettingsButtonVisible = true;
			SettingsButtonClick += FormSettingsButtonClick;
			HelpButtonText = "<b>ABOUT</b>";
			HelpButtonVisible = true;
			HelpButtonClick += FormHelpButtonClick;
			HelpButton = true;
			HelpButtonClicked += FormHelpButtonClicked;

			radialMenu.Symbol = "";
			radialMenu.SubMenuEdgeWidth = 8;
			radialMenu.CenterButtonDiameter = 20;
			radialMenu.Diameter = 150;
			radialMenu.ItemClick += RadialMenuItemClick;
			radialMenu.SendToBack();

			next_button.ForeColor = themeColor;
			previous_button.ForeColor = themeColor;
			next_button.Enabled = false;
			previous_button.Enabled = false;

			#endregion

		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			// 设置为中文环境
			Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("zh-CN");

			#region Set Subpages
			Extract("SimpleEpub2", resourcesPath, "Resources", "About.png");
			setSubPages(true);
			#endregion

			#region Settings Preparation
			stsObj = new SettingsObject(settingsPath);

			// Create SettingsObject and load settings to form
			if (!File.Exists(stsObj.iniPath))
			{
				stsObj.writeToIni();
			}
			else
			{
				try
				{
					stsObj.loadFromIni();
				}
				catch
				{
					MessageBoxEx.Show(this, "加载设置文件出错，即将导入默认设置！");
					stsObj = null;
					stsObj = new SettingsObject(settingsPath);
					stsObj.writeToIni();
				}
			}
			stsObj.writeToSettings(sts);

			if (sts.pg4.settings4_4_chkupd.Value)
				updater.DoUpdate(true);

			#endregion
		}

		#region Set Subpages Helper Functions

		private void setSubPages(Boolean firstTime)
		{
			//Size = new Size(946, 650 + navigationBar1.Height);

			pageSlider1.SelectedPageIndex = 0;

			setPage1();
			if (firstTime)
				setSettings(false);

			previous_button.Enabled = false;
			next_button.Enabled = false;
		}

		private void setPage1()
		{
			SuspendLayout();
			pg1 = new Page1(themeColor);
			pg1.IsOpen = true;
			pg1.SetBounds(4, 8, 918, 600);
			pg1.Parent = this;
			pageSliderPage1.Controls.Add(pg1);
			pg1.txt_picturebox.DragDrop += txt_picturebox_DragDrop;
			pg1.txt_picturebox.DoubleClick += txt_picturebox_DoubleClick;
			pg1.cover_bookname_textbox.TextChanged += cover_bookname_textbox_TextChanged;
			pg1.cover_author_textbox.TextChanged += cover_author_textbox_TextChanged;
			pg1.preProcessMode();
			ResumeLayout(false);
		}

		private void setPage2()
		{
			SuspendLayout();
			pg2 = new Page2(themeColor);
			pg2.IsOpen = true;
			pg2.SetBounds(3, 8, 920, 600);
			pg2.Parent = this;
			pageSliderPage2.Controls.Add(pg2);
			pg2.cover_picturebox.DragDrop += cover_picturebox_DragDrop;
			pg2.cover_picturebox.DoubleClick += cover_picturebox_DoubleClick;
			pg2.cover_picturebox.MouseClick += cover_picturebox_MouseClick;
			pg2.TOC_export.Click += TOC_export_Click;
			pg2.TOC_import.Click += TOC_import_Click;
			pg2.TOC_clear.Click += TOC_clear_Click;
			pg2.TOC_list.DragDrop += TOC_list_DragDrop;
			pg2.radialMenu1.ItemClick += TOCRadialMenu1ItemClick;
			pg2.radialMenu2.ItemClick += TOCRadialMenu2ItemClick;
			pg2.radialMenu3.ItemClick += TOCRadialMenu3ItemClick;
			ResumeLayout(false);
		}

		private void setPage3()
		{
			SuspendLayout();
			pg3 = new Page3(themeColor);
			pg3.IsOpen = true;
			pg3.SetBounds(3, 3, 940, 605);
			pg3.Parent = this;
			pageSliderPage3.Controls.Add(pg3);
			pg3.newbook_button.Click += newbook_button_Click;
			ResumeLayout(false);
		}

		private void setAbout(Boolean show)
		{
			SuspendLayout();
			abt = new About(themeColor);
			abt.IsOpen = true;
			abt.SetBounds(8, 8, 950, 650);
			if (!show)
				abt.IsOpen = false;
			Controls.Add(abt);
			if (!show)
				abt.SendToBack();
			else
				abt.BringToFront();
			abt.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Top;
			abt.Parent = this;
			abt.pictureBox.Image = Image.FromFile(resourcesPath + "\\About.png");
			ResumeLayout(false);
		}

		private void setSettings(Boolean show)
		{
			SuspendLayout();
			sts = new Settings(themeColor);
			sts.IsOpen = true;
			sts.SetBounds(8, 8, 950, 650);
			if (!show)
				sts.IsOpen = false;
			Controls.Add(sts);
			if (!show)
				sts.SendToBack();
			else
				sts.BringToFront();
			sts.SlideSide = DevComponents.DotNetBar.Controls.eSlideSide.Top;
			sts.Parent = this;
			sts.IsOpenChanged += sts_IsOpenChanged;
			sts.pg1.settings1_3_vertical.ValueChanged += sts_pg1_settings1_3_vertical_ValueChanged;
			sts.pg2.settings2_3_booknamefont.TextChanged += sts_pg2_settings2_3_booknamefont_TextChanged;
			sts.pg2.settings2_3_authornamefont.TextChanged += sts_pg2_settings2_3_authornamefont_TextChanged;
			sts.pg4.settings4_4_chkupd_button.Click += sts_pg4_settings4_4_chkupd_button_Click;
			sts.pg4.settings4_3_reset_button.Click += sts_pg4_settings4_3_reset_button_Click;
			ResumeLayout(false);
		}

		#endregion

		#endregion


		#region Event Handlers

		private void newbook_button_Click(object sender, EventArgs e)
		{
			previous_button.Enabled = false;
			next_button.Enabled = false;

			pg1.preProcessMode();
			pg1.cover_bookname_textbox.Text = "";
			pg1.cover_author_textbox.Text = "";
			pg1.cover_intro_textbox.Text = "";
			cqIDX = 0;
			//pageSlider1.SelectedPageIndex = cqIDX;
			
			// clear everything!
			resetPages();

			pageSlider1.SelectedPageIndex = cqIDX;
		}

		private void FormHelpButtonClick(object sender, EventArgs e)
		{
			if (abt == null)
				setAbout(false);
			abt.BringToFront();
			abt.IsOpen = true;
		}

		private void FormSettingsButtonClick(object sender, EventArgs e)
		{
			sts.BringToFront();
			sts.IsOpen = true;
		}

		private void FormHelpButtonClicked(object sender, EventArgs e)
		{
			Extract("SimpleEpub2", resourcesPath, "Resources", "help.pdf");
			try
			{
				System.Diagnostics.Process.Start(resourcesPath + "\\help.pdf");
			}
			catch
			{
				notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
				showBalloonTip("错误！", "帮助文件不存在！");
			}
		}

		private void next_button_Click(object sender, EventArgs e)
		{
			next_button.Checked = false;

			cqIDX++;
			if (cqIDX == 1)
			{
				if (pg2 == null)
				{
					setPage2();
				}
				pageSlider1.SelectedPageIndex = cqIDX;
				if (reCovers && !isPicCover)
				{
					generateTempCovers();
					pg2.cover_picturebox.Image = covers[0];
					reCovers = false;
				}
			}
			else //if (cqIDX == 2)
			{
				if (pg3 == null)
				{
					setPage3();
					pg3.ProcessingMode();
					if (!stsObj.embedFontSubset)
					{
						pg3.stepItem3.Enabled = false;
						pg3.stepItem3.Visible = false;
					}
				}
				pageSlider1.SelectedPageIndex = cqIDX;
				next_button.Enabled = false;
				previous_button.Enabled = false;

				epubWorker.RunWorkerAsync();

				return;
			}

			previous_button.Enabled = true;
		}

		private void previous_button_Click(object sender, EventArgs e)
		{
			previous_button.Checked = false;

			cqIDX--;
			if (cqIDX == 1)		// this case doesn't exist since cannot go back from pg3 to pg2.
			{
				pageSlider1.SelectedPageIndex = cqIDX;
			}
			else //if (cqIDX == 0)
			{
				pageSlider1.SelectedPageIndex = cqIDX;
				previous_button.Enabled = false;
			}

			next_button.Enabled = true;
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0xa4)  // Trap WM_NCRBUTTONDOWN
			{
				Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
				OnTitlebarClick(pos);
				return;
			}
			base.WndProc(ref m);
		}

		protected void OnTitlebarClick(Point pos)
		{
			radialMenu.MenuLocation = new Point(Control.MousePosition.X - radialMenu.Diameter / 2, Control.MousePosition.Y - radialMenu.Diameter / 2);
			radialMenu.IsOpen = true;
		}

		private void RadialMenuItemClick(object sender, EventArgs e)
		{
			RadialMenuItem item = sender as RadialMenuItem;
			if (item != null && !String.IsNullOrEmpty(item.Text))
			{
				switch (item.Text.Substring(item.Text.Length - 2))
				{
					case "置顶":
						switchAOT();
						break;
					case "小化":
						this.WindowState = FormWindowState.Minimized;
						break;
					case "关闭":
						Application.Exit();
						break;
					default:
						MessageBoxEx.Show(this, item.Text);
						break;
				}
			}
		}

		private void toostripmenu1_show_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		private void toostripmenu2_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void notifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
				this.WindowState = FormWindowState.Normal;
			if (this.WindowState == FormWindowState.Normal)
				this.WindowState = FormWindowState.Minimized;
		}

		private void sts_IsOpenChanged(object sender, EventArgs e)
		{
			if (sts.IsOpen == false)
			{
				// Redraw?
				Boolean redraw = false;
				if (cqIDX == 1)
				{
					if (sts.pg2.settings2_3_booknamefont.SelectedItem.ToString().CompareTo(stsObj.bookNameFont) != 0 || sts.pg2.settings2_3_authornamefont.SelectedItem.ToString().CompareTo(stsObj.authorNameFont) != 0 || sts.pg1.settings1_3_vertical.Value != stsObj.verticalText)
					{
						if (!isPicCover)
						{
							redraw = true;
						}
					}
				}

				// Save settigngs
				try
				{
					stsObj.loadFromSettings(sts);
					stsObj.writeToIni();
				}
				catch
				{
					MessageBoxEx.Show(this, "加载设置文件出错，即将导入默认设置！");
					stsObj = null;
					stsObj = new SettingsObject(settingsPath);
					stsObj.writeToSettings(sts);
					redraw = false;
					reCovers = false;
				}

				// Redraw cover if necessary
				if (redraw)
				{
					generateTempCovers();
					pg2.cover_picturebox.Image = covers[0];
					reCovers = false;
				}
			}
			else
			{
				stsObj.writeToSettings(sts);
				stsObj.writeToIni();
			}
		}

		private void sts_pg4_settings4_4_chkupd_button_Click(object sender, EventArgs e)
		{
			updater.DoUpdate(false);
		}

		private void sts_pg4_settings4_3_reset_button_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBoxEx.Show(this, "是否要还原默认设置？", "确认", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				stsObj = null;
				stsObj = new SettingsObject(settingsPath);
				stsObj.writeToSettings(sts);
			}
		}

		private void cover_bookname_textbox_TextChanged(object sender, EventArgs e)
		{
			eventToRedrawCover(0);
		}

		private void cover_author_textbox_TextChanged(object sender, EventArgs e)
		{
			eventToRedrawCover(1);
		}

		private void sts_pg1_settings1_3_vertical_ValueChanged(object sender, EventArgs e)
		{
			eventToRedrawCover(1);
		}

		private void sts_pg2_settings2_3_booknamefont_TextChanged(object sender, EventArgs e)
		{
			eventToRedrawCover(1);
		}

		private void sts_pg2_settings2_3_authornamefont_TextChanged(object sender, EventArgs e)
		{
			eventToRedrawCover(1);
		}

		private void eventToRedrawCover(Int32 flag)
		{
			if (flag == 0)
			{
				if (bookAndAuthor.Count >= 1)
				{
					bookAndAuthor[0] = pg1.cover_bookname_textbox.Text;
				}
			}
			else if (flag == 1)
			{
				if (bookAndAuthor.Count == 2)
				{
					bookAndAuthor[1] = pg1.cover_author_textbox.Text;
				}
			}
			if (bookAndAuthor.Count == 2 && CoverPath != null && CoverPathSlim != null && bookAndAuthor[0] != null && bookAndAuthor[1] != null)
			{
				reCovers = true;
			}
		}

		#endregion


		#region Main Functions

		#region Page1 Functions

		private void txt_picturebox_DragDrop(object sender, DragEventArgs e)
		{
			String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBoxEx.Show(this, "只能拖入一个文件！");
				pg1.overlay_cover.Hide();
				return;
			}
			if (!files[0].ToLower().EndsWith(".txt"))
			{
				MessageBoxEx.Show(this, "只能拖入TXT文件！");
				pg1.overlay_cover.Hide();
			}
			else
			{
				pg1.overlay_cover.Hide();
				next_button.Enabled = false;
				pg1.processingMode();

				clearTOC();

				processTXTWorker.RunWorkerAsync(files[0]);
			}
			coverChanged = true;
		}

		private void txt_picturebox_DoubleClick(object sender, EventArgs e)
		{
			pg1.overlay_cover.Show();

			pg1.openFileDialog.Title = "请选择TXT文件";
			pg1.openFileDialog.Filter = "Text Files|*.txt";
			if (pg1.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				pg1.overlay_cover.Hide();
				next_button.Enabled = false;
				pg1.processingMode();

				clearTOC();

				processTXTWorker.RunWorkerAsync(pg1.openFileDialog.FileName);
			}
			else
			{
				pg1.overlay_cover.Hide();
				if (CoverPath == null || CoverPathSlim == null)
					next_button.Enabled = false;
			}
			coverChanged = true;
		}

		private void processTXT(String file)
		{
			// Clear TOC_list
			TOC.Clear();
			processTXTWorker.ReportProgress(10);

			// Save txt file path
			TXTPath = file;

			// Get file name
			String filename = Path.GetFileNameWithoutExtension(TXTPath);

			// Get book name and author info to fill the first two rows of TOC_list
			bookAndAuthor = getBookNameAndAuthorInfo(TXTPath, filename);

			// Fill author and bookname textboxes on the right side
			processTXTWorker.ReportProgress(20);
			
			// Fill intro textbox on the right side
			Intro = getIntroInfo(TXTPath);
			if (Intro.Contains("\n"))
				Intro = Intro.Replace("\n", "\r\n");

			processTXTWorker.ReportProgress(40);

			// Prepare a list of title line numbers
			using (FileStream fs = File.Open(TXTPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (BufferedStream bs = new BufferedStream(fs))
			using (StreamReader sr = new StreamReader(TXTPath, Encoding.GetEncoding("GB2312")))
			{
				String nextLine;
				Int32 lineNumber = 1;
				Int32 rowNumber = 0;
				while ((nextLine = sr.ReadLine()) != null)
				{
					Match title = Regex.Match(nextLine, regex);

					// Chapter title (with its line number) found!
					if (title.Success)
					{
						Regex rgx = new Regex("[\u2460-\u2473\u3251-\u325F\u32B1-\u32BF]");
						String chapterTitle = rgx.Replace(title.ToString().Trim(), "");
						TOC.Add(new Tuple<Int32, String>(lineNumber, chapterTitle));

						rowNumber++;

						titleLineNumbers.Add(lineNumber);
					}
					lineNumber++;
				}
			}

			processTXTWorker.ReportProgress(60);
			
			// clear CoverPath
			CoverPath = null;

			// generate temp cover
			CoverPath = tempPath + "\\cover.jpg";
			CoverPathSlim = tempPath + "\\cover~slim.jpg";

			//generateTempCovers();

			processTXTWorker.ReportProgress(80);
		}

		#endregion

		#region Page2 Functions

		private void cover_picturebox_DragDrop(object sender, DragEventArgs e)
		{
			coverChanged = true;

			String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBoxEx.Show(this, "只能拖入一个文件！");
				pg2.overlay_cover.Hide();
				return;
			}
			if (!files[0].ToLower().EndsWith(".jpg") && !files[0].ToLower().EndsWith(".jpeg") && !files[0].ToLower().EndsWith(".png") && !files[0].ToLower().EndsWith(".bmp"))
			{
				MessageBoxEx.Show(this, "只能拖入图片文件！");
				pg2.overlay_cover.Hide();
			}
			else
			{
				pg2.overlay_cover.Hide();
				pg2.cover_picturebox.BackgroundImage = null;
				processCover(files[0]);

				isPicCover = true;
			}
		}

		private void cover_picturebox_DoubleClick(object sender, EventArgs e)
		{
			coverChanged = true;

			pg2.overlay_cover.Show();

			pg2.openFileDialog.Title = "请选择封面图片";
			pg2.openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.bmp;*.png";
			if (pg2.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				//MessageBoxEx.Show(this, pg2.openFileDialog.FileName);
				processCover(pg2.openFileDialog.FileName);

				isPicCover = true;
			}

			pg2.overlay_cover.Hide();
			pg2.cover_picturebox.BackgroundImage = null;
		}

		private void cover_picturebox_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				pg2.overlay_cover.Show();

				pg2.radialMenu3.MenuLocation = new Point(Control.MousePosition.X - pg2.radialMenu3.Diameter / 2, Control.MousePosition.Y - pg2.radialMenu3.Diameter / 2);
				pg2.radialMenu3.IsOpen = true;
			}
		}

		private void TOCRadialMenu3ItemClick(object sender, EventArgs e)
		{
			RadialMenuItem item = sender as RadialMenuItem;
			if (item != null && !String.IsNullOrEmpty(item.Text))
			{
				switch (item.Text)
				{
					case "使用自动生成封面":
						generateTempCovers();
						pg2.cover_picturebox.Image = covers[0];
						reCovers = false;
						isPicCover = false;
						pg2.overlay_cover.Hide();
						break;
					case "选择封面图片":
						cover_picturebox_DoubleClick(sender, e);
						break;
					default:
						MessageBoxEx.Show(this, item.Text);
						break;
				}
			}
		}

		private void processCover(String file)
		{
			// clear CoverPath
			CoverPath = null;
			pg2.cover_picturebox.Image = null;
			if (covers[0] != null)
				covers[0].Dispose();
			if (covers[1] != null)
				covers[1].Dispose();
			if (File.Exists(CoverPath))
			{
				try
				{
					File.Delete(CoverPath);
				}
				catch
				{
					if (File.Exists(CoverPath))
						MessageBoxEx.Show(this, "删除原封面文件失败！");
				}
			}
			if (File.Exists(CoverPathSlim))
			{
				try
				{
					File.Delete(CoverPathSlim);
				}
				catch
				{
					if (File.Exists(CoverPathSlim))
						MessageBoxEx.Show(this, "删除原封面文件失败！");
				}
			}

			// generate cover.jpg and cover~slim.jpg
			origCover = file;
			generateCoverFromFilePath();
		}

		private void TOCRadialMenu1ItemClick(object sender, EventArgs e)
		{
			RadialMenuItem item = sender as RadialMenuItem;
			if (item != null && !String.IsNullOrEmpty(item.Text))
			{
				switch (item.Text)
				{
					case "导出目录":
						TOC_export_Click(sender, e);
						break;
					case "导入目录":
						TOC_import_Click(sender, e);
						break;
					case "清空目录":
						TOC_clear_Click(sender, e);
						break;
					default:
						MessageBoxEx.Show(this, item.Text);
						break;
				}
			}
		}

		private void TOC_import_Click(object sender, EventArgs e)
		{
			pg2.openFileDialog.Title = "请选择目录文件";
			pg2.openFileDialog.Filter = "Text Files|*.txt";
			if (pg2.openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				//MessageBoxEx.Show(this, pg2.openFileDialog.FileName);
				importTOC(pg2.openFileDialog.FileName);
			}

			pg2.overlay_TOC_buttons.Hide();
			pg2.TOC_import.Hide();
			pg2.TOC_export.Hide();
		}

		private void TOC_list_DragDrop(object sender, DragEventArgs e)
		{
			String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBoxEx.Show(this, "只能拖入一个文件！");
				pg2.overlay_TOC.Hide();
				return;
			}
			if (!files[0].ToLower().EndsWith(".txt"))
			{
				MessageBoxEx.Show(this, "只能拖入TXT文件！");
				pg2.overlay_TOC.Hide();
			}
			else
			{
				pg2.overlay_TOC.Hide();
				//MessageBoxEx.Show(this, "读取目录");

				importTOC(files[0]);
			}
		}

		private void importTOC(String TOCPath)
		{
			//String TOCPath = getTOCPath();

			Boolean broken = false;

			using (FileStream fs = File.Open(TOCPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (BufferedStream bs = new BufferedStream(fs))
			using (StreamReader sr = new StreamReader(TOCPath, Encoding.GetEncoding("GB2312")))
			{
				// Set cell font colors
				//setCellFontColor(System.Drawing.Color.Black, System.Drawing.Color.RoyalBlue);

				List<DataGridViewRow> test = new List<DataGridViewRow>();
				String nextLine;
				String[] separators = { ">" };
				while ((nextLine = sr.ReadLine()) != null)
				{
					String[] data = nextLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
					if (data.Length != 2)
					{
						broken = true;
						break;
					}
					DataGridViewRow row = (DataGridViewRow)pg2.TOC_list.Rows[0].Clone();
					row.Cells[0].Value = data[0];
					row.Cells[1].Value = data[1];
					test.Add(row);
				}
				if (!broken)
				{
					if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[0].Cells[1].Value != null)
					{
						pg2.TOC_list.Rows.Clear();
					}
					foreach (DataGridViewRow row in test)
					{
						pg2.TOC_list.Rows.Add(row);
					}
				}
			}

			if (broken)
			{
				MessageBoxEx.Show(this, "无效的目录文件！");
				clearOverLay();
				return;
			}
			notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
			showBalloonTip("温馨提示", "目录导入完毕！");
		}

		private void TOC_export_Click(object sender, EventArgs e)
		{
			//MessageBoxEx.Show(this, "导出目录");
			exportTOC();

			pg2.overlay_TOC_buttons.Hide();
			pg2.TOC_import.Hide();
			pg2.TOC_export.Hide();
		}

		private void exportTOC()
		{
			if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[0].Cells[1].Value != null)
			{
				String TOCPath = getTOCPath();
				StreamWriter sw = new StreamWriter(TOCPath, false, Encoding.GetEncoding("GB2312"));

				foreach (DataGridViewRow row in pg2.TOC_list.Rows)
				{
					if (row.Cells[0].Value != null && row.Cells[1].Value != null)
					{
						String toPrint = row.Cells[0].Value.ToString() + ">" + row.Cells[1].Value.ToString();
						sw.WriteLine(toPrint);
					}
				}
				sw.Close();

				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				showBalloonTip("温馨提示", "目录导出完毕！\n目录位置：" + TOCPath);
			}
			else
			{
				MessageBoxEx.Show(this, "目录是空的，无法导出！");
				clearOverLay();
			}
		}

		private void TOC_clear_Click(object sender, EventArgs e)
		{
			//MessageBoxEx.Show(this, "清空目录");
			clear_TOC();

			pg2.overlay_TOC_buttons.Hide();
			pg2.TOC_import.Hide();
			pg2.TOC_export.Hide();
		}

		private void clear_TOC()
		{
			if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[0].Cells[1].Value != null)
			{
				DialogResult dialogResult = MessageBoxEx.Show(this, "建议你按导出目录菜单以保存列表框中的数据\n你确定要清空列表框中的数据？", "确认", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					pg2.TOC_list.Rows.Clear();

					notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
					showBalloonTip("温馨提示", "目录清空完毕！");
				}
			}
			else
			{
				MessageBoxEx.Show(this, "目录是空的，无法清空！");
				clearOverLay();
			}
		}

		private void TOCRadialMenu2ItemClick(object sender, EventArgs e)
		{
			RadialMenuItem item = sender as RadialMenuItem;
			if (item != null && !String.IsNullOrEmpty(item.Text))
			{
				switch (item.Text)
				{
					case "选中章节升一级":
						TOC_button1_Click(sender, e);
						break;
					case "选中章节降一级":
						TOC_button2_Click(sender, e);
						break;
					default:
						MessageBoxEx.Show(this, item.Text);
						break;
				}
			}
		}

		private void TOC_button1_Click(object sender, EventArgs e)
		{
			Int32 selectedRowsCount = pg2.TOC_list.SelectedRows.Count;

			Boolean selectedValid = true;
			if (selectedRowsCount > 0)
			{
				for (Int32 i = 0; i < selectedRowsCount; i++)
				{
					if (pg2.TOC_list.SelectedRows[i].Cells[0].Value == null || pg2.TOC_list.SelectedRows[i].Cells[1].Value == null)
					{
						MessageBoxEx.Show(this, "操作无效！");
						selectedValid = false;
						break;
					}
				}
				if (selectedValid)
				{
					for (Int32 i = 0; i < selectedRowsCount; i++)
					{
						if (pg2.TOC_list.SelectedRows[i].Cells[0].Value.ToString().StartsWith(" *** "))
						{
							String temp = pg2.TOC_list.SelectedRows[i].Cells[0].Value.ToString();
							temp = temp.Substring(5);
							pg2.TOC_list.SelectedRows[i].Cells[0].Value = temp;
						}
						else
						{
							MessageBoxEx.Show(this, "操作无效！");
							clearOverLay();
							return;
						}
					}
					clearOverLay();
				}
				else
				{
					clearOverLay();
					return;
				}
			}
			else
			{
				MessageBoxEx.Show(this, "操作无效！");
				clearOverLay();
				return;
			}
		}

		private void TOC_button2_Click(object sender, EventArgs e)
		{
			Int32 selectedRowsCount = pg2.TOC_list.SelectedRows.Count;

			Boolean selectedValid = true;
			if (selectedRowsCount > 0)
			{
				for (Int32 i = 0; i < selectedRowsCount; i++)
				{
					if (pg2.TOC_list.SelectedRows[i].Cells[0].Value == null || pg2.TOC_list.SelectedRows[i].Cells[1].Value == null)
					{
						MessageBoxEx.Show(this, "操作无效！");
						selectedValid = false;
						break;
					}
				}
				if (selectedValid)
				{
					if (String.Compare(pg2.TOC_list.SelectedRows[0].Cells[0].Value.ToString(), pg2.TOC_list.Rows[0].Cells[0].Value.ToString()) == 0 && String.Compare(pg2.TOC_list.SelectedRows[0].Cells[1].Value.ToString(), pg2.TOC_list.Rows[0].Cells[1].Value.ToString()) == 0)
					{
						MessageBoxEx.Show(this, "操作无效！");
						clearOverLay();
						return;
					}
					for (Int32 i = 0; i < selectedRowsCount; i++)
					{
						if (pg2.TOC_list.SelectedRows[i].Cells[0].Value.ToString().StartsWith(" ***  ***  *** "))
						{
							MessageBoxEx.Show(this, "操作无效！");
							clearOverLay();
							return;
						}
						else
						{
							String temp = pg2.TOC_list.SelectedRows[i].Cells[0].Value.ToString();
							temp = " *** " + temp;
							pg2.TOC_list.SelectedRows[i].Cells[0].Value = temp;
						}
					}
					clearOverLay();
				}
				else
				{
					clearOverLay();
					return;
				}
			}
			else
			{
				MessageBoxEx.Show(this, "操作无效！");
				clearOverLay();
				return;
			}
		}

		#endregion

		#region Page3 Functions

		private void generateEpub()
		{
			picHtmlList.Clear();
			txtHtmlList.Clear();
			embedFontPaths.Clear();
			ALLBODYTEXT.Clear();
			ALLTITLETEXT.Clear();
			IndexT.Clear();
			IndexB.Clear();
			glyphTypefaceT = new GlyphTypeface();
			glyphTypefaceB = new GlyphTypeface();
			coverHtml.Clear();
			css.Clear();
			opf.Clear();
			ncx.Clear();

			if (TXTPath == null)
			{
				MessageBoxEx.Show("没有源文件！请拖入TXT文件后重试！");
				return;
			}

			stopWatch = new Stopwatch();
			stopWatch.Start();

			if (DONE)
			{
				if (!coverChanged)
				{
					deleteAllTempFiles();
				}
				DONE = false;
			}
			if (origCover != null && !File.Exists(CoverPath) && !File.Exists(CoverPathSlim))
			{
				generateCoverFromFilePath();
			}

			/*** Load new TOC ***/
			Boolean validTOC = loadNewTOC();
			if (!validTOC) return;

			/*** Load new Intro ***/
			Intro = pg1.cover_intro_textbox.Text;
			if (Intro != "")
			{
				Intro = "&lt;span class=\"Apple-style-span\"&gt;" + Intro + "&lt;/span&gt;";
				if (Intro.Contains("\r\n"))
				{
					Intro = Intro.Replace("\r\n", "&lt;/span&gt;&lt;br/&gt;&lt;span class=\"Apple-style-span\"&gt;");
				}
			}

			/*** Load settings ***/
			Int32 translation = translationState(stsObj.StT, stsObj.TtS);
			String temp1 = bookAndAuthor[0];
			String temp2 = bookAndAuthor[1];
			bookAndAuthor.Clear();
			bookAndAuthor.Add(translate(temp1, translation));
			bookAndAuthor.Add(translate(temp2, translation));

			if (stsObj.embedFontSubset)
			{
				titleFontPath = FontNameFile.getFontFileName(stsObj.titleFont);
				if (titleFontPath.CompareTo("") == 0)
					MessageBoxEx.Show("指定的标题字体不是TTF字体，无法嵌入！");
				else
				{
					URIT = new Uri(titleFontPath);
					glyphTypefaceT = new GlyphTypeface(URIT);
				}
				bodyFontPath = FontNameFile.getFontFileName(stsObj.bodyFont);
				if (bodyFontPath.CompareTo("") == 0)
					MessageBoxEx.Show("指定的正文字体不是TTF字体，无法嵌入！");
				else
				{
					URIB = new Uri(bodyFontPath);
					glyphTypefaceB = new GlyphTypeface(URIB);
				}
			}
			epubWorker.ReportProgress(20);

			/*** Generate temp HTML ***/
			Boolean HTML = generateHTML(stsObj.coverFirstPage, translation, stsObj.verticalText, stsObj.replaceNumByHan, stsObj.embedFontSubset);
			if (!HTML) { broken = true; return; }
			epubWorker.ReportProgress(60);

			/*** Generate CSS ***/
			generateCSS(stsObj.verticalText, stsObj.marginL, stsObj.marginR, stsObj.marginT, stsObj.marginB, stsObj.lineSpacing, stsObj.addParagraphSpacing, stsObj.titleFont, stsObj.titleColor, stsObj.bodyFont, stsObj.bodyColor, stsObj.pageColor, stsObj.embedFontSubset);

			/*** Image File ***/
			Boolean IMG = copyImageFile(stsObj.verticalText, stsObj.bookNameFont, stsObj.authorNameFont);
			if (!IMG) { broken = true; return; }
			/*if (!coverFirstPage)
				if (File.Exists(getIMGFolderPath() + "\\cover~slim.jpg"))
					File.Delete(getIMGFolderPath() + "\\cover~slim.jpg");*/

			/*** Generate OPF ***/
			generateOPF(stsObj.coverFirstPage, translation, stsObj.verticalText, stsObj.embedFontSubset);

			/*** Generate NCX ***/
			generateNCX(stsObj.coverFirstPage, stsObj.coverNoTOC, translation);

			/*** Generate other files ***/
			mimetype = "application/epub+zip";
			container = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n<container version=\"1.0\" xmlns=\"urn:oasis:names:tc:opendocument:xmlns:container\">\n\t<rootfiles>\n\t\t<rootfile full-path=\"OEBPS/content.opf\" media-type=\"application/oebps-package+xml\" />\n\t</rootfiles>\n</container>";
			epubWorker.ReportProgress(80);

			/*** ZIP ***/
			DocName = "《" + bookAndAuthor[0] + "》作者：" + bookAndAuthor[1];
			zipPath = stsObj.fileLocation + "\\" + DocName + ".epub";

			using (ZipFile zip = new ZipFile())
			{
				zip.EmitTimesInWindowsFormatWhenSaving = false;					// Exclude extra attribute (timestamp); same as -X command
				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;		// Ensure mimetype file is NOT compressed
				zip.Encryption = EncryptionAlgorithm.None;						// Ensure mimetype file is NOT encryped
				zip.AddEntry("mimetype", mimetype, Encoding.ASCII);		// yet another way to generate flawless mimetype file
				zip.Save(zipPath);

				zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
				zip.AddDirectoryByName("META-INF");
				zip.AddEntry("META-INF\\container.xml", container, Encoding.UTF8);
				zip.AddDirectoryByName("OEBPS");
				zip.AddDirectoryByName("OEBPS\\Images");
				zip.AddDirectoryByName("OEBPS\\Styles");
				zip.AddDirectoryByName("OEBPS\\Text");
				zip.AddEntry("OEBPS\\Styles\\main.css", css.ToString(), Encoding.UTF8);
				zip.AddEntry("OEBPS\\content.opf", opf.ToString(), Encoding.UTF8);
				zip.AddEntry("OEBPS\\toc.ncx", ncx.ToString(), Encoding.UTF8);
				if (stsObj.coverFirstPage) zip.AddEntry("OEBPS\\Text\\coverpage.html", coverHtml.ToString(), Encoding.UTF8);
				for (Int32 i = 1; i <= txtHtmlList.Count; i++) zip.AddEntry("OEBPS\\Text\\chapter" + i + ".html", txtHtmlList[i - 1], Encoding.UTF8);
				for (Int32 i = 0; i < picHtmlList.Count; i++) zip.AddEntry("OEBPS\\Text\\picture" + i + ".html", picHtmlList[i], Encoding.UTF8);
				zip.AddFile(CoverPath, "OEBPS\\Images\\");
				zip.AddFile(CoverPathSlim, "OEBPS\\Images\\");
				for (Int32 i = 0; i < pictureHTMLs.Count; i++)
				{
					String origPic = tempPath + "\\picture" + i + ".jpg";
					String origPicSlim = tempPath + "\\picture" + i + "~slim.jpg";
					zip.AddFile(origPic, "OEBPS\\Images\\");
					zip.AddFile(origPicSlim, "OEBPS\\Images\\");
				}
				if (parchmentNeeded) zip.AddFile(tempPath + "\\parchment.jpg", "OEBPS\\Images\\");
				if (hasFootNote)
				{
					// Use the note.png from resourses
					//Extract("SimpleEpub2", resourcesPath, "Resources", "note.png");
					//zip.AddFile(resourcesPath + "\\note.png", "OEBPS\\Images\\");
					
					// Use auto-generated note.png
					generateNotePic();
					zip.AddFile(tempPath + "\\note.png", "OEBPS\\Images\\");
				}
				if (stsObj.embedFontSubset)
				{
					for (Int32 i = 0; i < embedFontPaths.Count; i++)
					{
						zip.AddFile(embedFontPaths[i], "OEBPS\\Fonts\\");
					}
				}
				zip.Save(zipPath);
			}

			processedIntro = Intro;
			if (processedIntro != "")
			{
				if (processedIntro.Contains("&lt;/span&gt;&lt;br/&gt;&lt;span class=\"Apple-style-span\"&gt;"))
				{
					processedIntro = processedIntro.Replace("&lt;/span&gt;&lt;br/&gt;&lt;span class=\"Apple-style-span\"&gt;", "\r\n");
				}
				processedIntro = processedIntro.Replace("&lt;span class=\"Apple-style-span\"&gt;", "");
				processedIntro = processedIntro.Replace("&lt;/span&gt;", "");
			}

			epubWorker.ReportProgress(100);

		}

		private Boolean generateHTML(Boolean coverFirstPage, Int32 translation, Boolean vertical, Boolean replace, Boolean embedFontSubset)
		{
			if (!File.Exists(TXTPath))
			{
				MessageBoxEx.Show("找不到" + TXTPath + "文件！\n无法继续生成！");
				return false;
			}

			using (FileStream fs = File.Open(TXTPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (BufferedStream bs = new BufferedStream(fs))
			using (StreamReader sr = new StreamReader(bs, Encoding.GetEncoding("GB2312")))
			{
				String nextLine;
				Int32 TXTlineNumber = 1;
				Int32 TLN_idx = 0;
				Int32 TLN_size = titleLineNumbers.Count;

				Boolean sameChapter = false;
				String toPrint = "";
				chapterNumber = 1;
				// 制作第一页封面
				if (coverFirstPage)
				{
					String title = "封面";
					title = translate(title, translation);		// 简繁转换

					coverHtml.Append(HTMLHead(title, "", 0));
					coverHtml.Append("\n<img src=\"../Images/cover.jpg\" alt=\"Cover\" />\n</div>\n</body>\n</html>");

					//chapterNumber++;
				}

				// 制作其他图片页
				for (Int32 i = 0; i < pictureHTMLs.Count; i++)
				{
					String title = pictureHTMLs[i].Item1;
					title = title.Trim();

					if (title.StartsWith("D") || title.StartsWith("U") || title.StartsWith("d") || title.StartsWith("u"))
					{
						title = title.Substring(1, title.Length - 1);
						title = title.Trim();
					}

					title = translate(title, translation);		// 简繁转换

					String tempToPrint = HTMLHead(title, "picture" + i, 2) + "\n<img src=\"../Images/" + "picture" + i + ".jpg\" alt=\"Cover\" />\n</div>\n</body>\n</html>";
					picHtmlList.Add(tempToPrint);
				}


				if (FSLinesScanned != 0)
				{
					//FSLinesScanned = 0;
					TXTlineNumber += 2;
				}


				Boolean titleHasFootNote = false;
				Queue<Tuple<String, Int32>> footNoteQueuePre = new Queue<Tuple<String, Int32>>();
				Queue<Tuple<Int32, String>> footNoteQueuePost = new Queue<Tuple<Int32, String>>();
				Int32 chapterFootNoteCount = 0;

				// Read from the first line to the first chapter title defined!
				if (TLN_size != 0 && titleLineNumbers[0] > TXTlineNumber)
				{
					extraLinesInBeginning = true;
					StringBuilder html = new StringBuilder();
					Boolean firstTime = true;

					while (titleLineNumbers[0] > TXTlineNumber && (nextLine = sr.ReadLine()) != null)
					{
						if (FSLinesScanned != 0)
						{
							FSLinesScanned--;
							continue;
						}

						// Remove empty lines
						if (!Regex.IsMatch(nextLine, emptyLineRegex))
						{
							extraLinesNotEmpty = true;

							nextLine = nextLine.Trim();
							nextLine = translate(nextLine, translation);		// 简繁转换

							// 删除" *** "标识
							if (nextLine.Contains(" *** "))
							{
								nextLine = nextLine.Replace(" *** ", "");
							}

							if (vertical)		// 半角字符转全角
							{
								nextLine = ToSBC(nextLine);
							}
							if (embedFontSubset && URIB != null) addStringToUInt16CollectionB(nextLine);



							// ① - ⑳: FootNote content!
							if (Regex.IsMatch(nextLine[0].ToString(), "[\u2460-\u2473\u3251-\u325F\u32B1-\u32BF]"))
							{
								hasFootNote = true;

								linkFootNote(nextLine, footNoteQueuePre, footNoteQueuePost);
							}
							else
							{
								storeFootNoteLocation(ref nextLine, footNoteQueuePre, ref chapterFootNoteCount, 1, ref titleHasFootNote);

								if (firstTime)
								{
									html.Append(HTMLHead(nextLine, "", 1) + "\n");
									firstTime = false;
								}
								else
									html.Append("<p>" + nextLine + "</p>\n");
							}

						}
						TXTlineNumber++;
					}
					//extraLinesInBeginning = false;

					appendFootNotes(footNoteQueuePost, html);

					html.Append("</div>\n</body>\n</html>\n");
					if (extraLinesNotEmpty)
						txtHtmlList.Add(html.ToString());
					chapterNumber++;
				}

				while (true)
				{
					StringBuilder html = new StringBuilder();

					chapterFootNoteCount = 0;
					if (!titleHasFootNote)
						footNoteQueuePre.Clear();
					footNoteQueuePost.Clear();

					if (toPrint != "")
					{
						html.Append(toPrint + "\n");
						sameChapter = true;
						toPrint = "";
						if (titleHasFootNote)
						{
							chapterFootNoteCount = 1;
							titleHasFootNote = false;
						}
					}

					if (TLN_size == 0)
					{
						html.Append(HTMLHead(bookAndAuthor[0], "", 1) + "\n");
					}
					while ((nextLine = sr.ReadLine()) != null)
					{
						// Remove empty lines
						if (!Regex.IsMatch(nextLine, emptyLineRegex))
						{
							nextLine = nextLine.Trim();
							nextLine = translate(nextLine, translation);		// 简繁转换

							// 删除" *** "标识
							if (nextLine.Contains(" *** "))
							{
								nextLine = nextLine.Replace(" *** ", "");
							}

							if (vertical)		// 半角字符转全角
							{
								nextLine = ToSBC(nextLine);
								//nextLine = VB.Strings.StrConv(nextLine, VB.VbStrConv.Wide);
								//nextLine = nextLine.Replace("—", "<span lang=EN-US style='font-family:\"Times New Roman\"'>—</span>");
							}

							if (TLN_idx < TLN_size && TXTlineNumber == titleLineNumbers[TLN_idx])		// Chapter titles!
							{
								if (replace)		// 替换标题中的数字为汉字
								{
									nextLine = numberToHan(nextLine);
								}
								if (embedFontSubset && URIT != null) addStringToUInt16CollectionT(nextLine);

								storeFootNoteLocation(ref nextLine, footNoteQueuePre, ref chapterFootNoteCount, 0, ref titleHasFootNote);

								if (sameChapter)
								{
									sameChapter = false;
									toPrint = HTMLHead(nextLine, "", 1);
									TLN_idx++;
									TXTlineNumber++;
									break;
								}
								else
								{
									html.Append(HTMLHead(nextLine, "", 1) + "\n");
									sameChapter = true;
									TLN_idx++;
								}
							}
							else
							{
								if (embedFontSubset && URIB != null) addStringToUInt16CollectionB(nextLine);

								// ① - ⑳: FootNote content!
								if (Regex.IsMatch(nextLine[0].ToString(), "[\u2460-\u2473\u3251-\u325F\u32B1-\u32BF]"))
								{
									hasFootNote = true;

									linkFootNote(nextLine, footNoteQueuePre, footNoteQueuePost);
								}
								else
								{
									storeFootNoteLocation(ref nextLine, footNoteQueuePre, ref chapterFootNoteCount, 1, ref titleHasFootNote);

									html.Append("<p>" + nextLine + "</p>\n");
								}
							}
						}
						TXTlineNumber++;
					}

					if (nextLine != null)
					{
						appendFootNotes(footNoteQueuePost, html);

						html.Append("</div>\n</body>\n</html>\n");
						txtHtmlList.Add(html.ToString());
						chapterNumber++;
					}
					else
					{
						appendFootNotes(footNoteQueuePost, html);

						html.Append("</div>\n</body>\n</html>\n");
						txtHtmlList.Add(html.ToString());
						break;
					}
				}
			}

			return true;
		}

		private void storeFootNoteLocation(ref String nextLine, Queue<Tuple<String, Int32>> footNoteQueuePre, ref Int32 chapterFootNoteCount, Int32 flag, ref Boolean titleHasFootNote)
		{
			// ① - ⑳: FootNote position!
			MatchCollection footnotesPos = Regex.Matches(nextLine, "[\u2460-\u2473\u3251-\u325F\u32B1-\u32BF]");
			if (footnotesPos.Count > 0)
			{
				if (flag == 0)
				{
					titleHasFootNote = true;
					chapterFootNoteCount = 0;
				}
				hasFootNote = true;
				foreach (Match footnote in footnotesPos)
				{
					// the following code replace ALL occurances, which is INCORRECT
					//nextLine = nextLine.Replace(footnote.Value, "<a class=\"duokan-footnote\" href=\"#note" + chapterFootNoteCount + "\"><img src=\"../Images/note.png\" width=\"10\" height=\"10\"/></a>");

					nextLine = ReplaceFirst(nextLine, footnote.Value, "<a class=\"duokan-footnote\" href=\"#note" + chapterFootNoteCount + "\"><img src=\"../Images/note.png\" width=\"10\" height=\"10\"/></a>");
					footNoteQueuePre.Enqueue(new Tuple<String, Int32>(footnote.Value, chapterFootNoteCount));
					chapterFootNoteCount++;
				}
			}
		}

		private static void linkFootNote(String nextLine, Queue<Tuple<String, Int32>> footNoteQueuePre, Queue<Tuple<Int32, String>> footNoteQueuePost)
		{
			try
			{
				if (footNoteQueuePre.Peek().Item1.CompareTo(nextLine[0].ToString()) == 0)
					footNoteQueuePost.Enqueue(new Tuple<Int32, String>(footNoteQueuePre.Dequeue().Item2, nextLine.Substring(1)));
				else if (footNoteQueuePre.Peek().Item1.CompareTo(nextLine[0].ToString()) < 0)
				{
					while (footNoteQueuePre.Peek().Item1.CompareTo(nextLine[0].ToString()) < 0)
					{
						footNoteQueuePre.Dequeue();
					}
				}
				else	// if (footNoteQueuePre.Peek().Item1.CompareTo(nextLine[0].ToString()) > 0)
				{
					// do nothing
				}

			}
			catch { }
		}

		private void appendFootNotes(Queue<Tuple<Int32, String>> footNoteQueuePost, StringBuilder html)
		{
			if (hasFootNote)
			{
				html.Append("\n<ol class=\"duokan-footnote-content\">\n");

				while (footNoteQueuePost.Count > 0)
				{
					html.Append("<li class=\"duokan-footnote-item\" id=\"note" + footNoteQueuePost.Peek().Item1 + "\">" + footNoteQueuePost.Peek().Item2 + "</li>\n");
					footNoteQueuePost.Dequeue();
				}

				html.Append("</ol>\n");
			}
		}

		private void generateCSS(Boolean vertical, Single marginL, Single marginR, Single marginT, Single marginB, Single lineHeight, Boolean addParagraphSpacing, String titleFont, System.Drawing.Color titleColorC, String bodyFont, System.Drawing.Color bodyColorC, System.Drawing.Color pageColor, Boolean embedFontSubset)
		{
			String bodyColor = (bodyColorC == System.Drawing.Color.Transparent || bodyColorC == System.Drawing.Color.Empty) ? "" : ColorTranslator.ToHtml(bodyColorC);
			String titleColor = (titleColorC == System.Drawing.Color.Transparent || titleColorC == System.Drawing.Color.Empty) ? "" : ColorTranslator.ToHtml(titleColorC);

			String background = "";
			background = "\n\tbackground-color:" + ColorTranslator.ToHtml(pageColor) + ";";
			if (pageColor == System.Drawing.Color.Transparent || pageColor == System.Drawing.Color.Empty)
				background = "";

			StringBuilder font1 = new StringBuilder();
			font1.Append("@font-face {\n\tfont-family:\"" + titleFont + "\";\n\tsrc:local(\"" + titleFont + "\"),\n\turl(res:///opt/sony/ebook/FONT/" + titleFont + ".ttf),\n\turl(res:///Data/FONT/" + titleFont + ".ttf),\n\turl(res:///opt/sony/ebook/FONT/" + titleFont + ".ttf),\n\turl(res:///fonts/ttf/" + titleFont + ".ttf),\n\turl(res:///../../media/mmcblk0p1/fonts/" + titleFont + ".ttf),\n\turl(res:///DK_System/system/font/" + titleFont + ".ttf),\n\turl(res:///abook/fonts/" + titleFont + ".ttf),\n\turl(res:///system/fonts/" + titleFont + ".ttf),\n\turl(res:///system/media/sdcard/fonts/" + titleFont + ".ttf),\n\turl(res:///media/fonts/" + titleFont + ".ttf),\n\turl(res:///sdcard/fonts/" + titleFont + ".ttf),\n\turl(res:///system/fonts/" + titleFont + ".ttf),\n\turl(res:///mnt/MOVIFAT/font/" + titleFont + ".ttf)");
			if (embedFontSubset && titleFontPath.CompareTo("") != 0 && URIT != null)
			{
				CreateFontSubSetT();
				if (embedFontPaths.Count > 0)
				{
					String font1Name = embedFontPaths[0].Substring(embedFontPaths[0].LastIndexOf("\\") + 1);
					font1.Append(",\n\turl(../Fonts/" + font1Name + ")");
				}
			}
			font1.Append(";\n}\n");

			StringBuilder font2 = new StringBuilder();
			font2.Append("@font-face {\n\tfont-family:\"" + bodyFont + "\";\n\tsrc:local(\"" + bodyFont + "\"),\n\turl(res:///opt/sony/ebook/FONT/" + bodyFont + ".ttf),\n\turl(res:///Data/FONT/" + bodyFont + ".ttf),\n\turl(res:///opt/sony/ebook/FONT/" + bodyFont + ".ttf),\n\turl(res:///fonts/ttf/" + bodyFont + ".ttf),\n\turl(res:///../../media/mmcblk0p1/fonts/" + bodyFont + ".ttf),\n\turl(res:///DK_System/system/font/" + bodyFont + ".ttf),\n\turl(res:///abook/fonts/" + bodyFont + ".ttf),\n\turl(res:///system/fonts/" + bodyFont + ".ttf),\n\turl(res:///system/media/sdcard/fonts/" + bodyFont + ".ttf),\n\turl(res:///media/fonts/" + bodyFont + ".ttf),\n\turl(res:///sdcard/fonts/" + bodyFont + ".ttf),\n\turl(res:///system/fonts/" + bodyFont + ".ttf),\n\turl(res:///mnt/MOVIFAT/font/" + bodyFont + ".ttf)");
			if (embedFontSubset && bodyFontPath.CompareTo("") != 0 && URIB != null)
			{
				CreateFontSubSetB();
				if (embedFontPaths.Count > 0)
				{
					Int32 idx = (URIT == null || embedFontPaths.Count == 1) ? 0 : 1;
					String font2Name = embedFontPaths[idx].Substring(embedFontPaths[idx].LastIndexOf("\\") + 1);
					font2.Append(",\n\turl(../Fonts/" + font2Name + ")");
				}
			}
			font2.Append(";\n}\n");

			String html = (vertical ? "html {\n\twriting-mode:vertical-rl;\n\t-webkit-writing-mode:vertical-rl;\n\t-epub-writing-mode:vertical-rl;\n\t-epub-line-break:strict;\n\tline-break:strict;\n\t-epub-word-break:normal;\n\tword-break:normal;\n\tmargin:0;\n\tpadding:0;\n}\n" : "");

			String body = "body {\n\tmargin-top:" + marginT + "%;\n\tmargin-bottom:" + marginB + "%;\n\tmargin-left:" + marginL + "%;\n\tmargin-right:" + marginR + "%;\n\tline-height:" + lineHeight + "%;\n\ttext-align:justify;\n\tfont-family:" + bodyFont + ";\n\tcolor:" + bodyColor + ";" + background + "\n}\n";

			String div = "div {\n\tmargin:0px;\n\tline-height:" + lineHeight + "%;\n\ttext-align:justify;\n\tfont-family:" + bodyFont + ";\n\tcolor:" + bodyColor + ";\n}\n";

			String img = "img {\n\tmax-width:100%;\n\tmax-height:100%;\n\tbottom:0;\n\tleft:0;\n\tmargin:auto;\n\toverflow:auto;\n\tposition:fixed;\n\tright:0;\n\ttop:0;\n}\n";
			//String img = "img {\n\tbottom:0;\n\tleft:0;\n\tmargin:auto;\n\toverflow:auto;\n\tposition:fixed;\n\tright:0;\n\ttop:0;\n}\n";
			//String img = "";

			Int32 pMargin = (addParagraphSpacing ? 5 : 0);
			String p = "p {\n\ttext-align:justify;\n\ttext-indent:2em;\n\tline-height:" + lineHeight + "%;\n\tmargin-top:" + pMargin + "pt;\n\tmargin-bottom:" + pMargin + "pt;\n}\n";

			String others = ".cover {\n\twidth:100%;\n}\n.center {\n\ttext-align:center;\n\tmargin-left:0%;\n\tmargin-right:0%;\n}\n.left {\n\ttext-align:left;\n\tmargin-left:0%;\n\tmargin-right:0%;\n}\n.right {\n\ttext-align:right;\n\tmargin-left:0%;\n\tmargin-right:0%;\n}\n.quote {\n\tmargin-top:0%;\n\tmargin-bottom:0%;\n\tmargin-left:1em;\n\tmargin-right:1em;\n\ttext-align:justify;\n\tfont-family:" + bodyFont + ";\n\tcolor:" + bodyColor + ";\n}\n";

			String headers = "h1 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:xx-large;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\nh2 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:x-large;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\nh3 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:large;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\nh4 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:medium;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\nh5 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:small;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\nh6 {\n\tline-height:" + lineHeight + "%;\n\ttext-align:center;\n\tfont-weight:bold;\n\tfont-size:x-small;\n\tfont-family:" + titleFont + ";\n\tcolor:" + titleColor + ";\n}\n";

			css.Append(font1);
			css.Append(font2);
			css.Append(html);
			css.Append(body);
			css.Append(div);
			css.Append(img);
			css.Append(p);
			css.Append(others);
			css.Append(headers);
		}

		private Boolean copyImageFile(Boolean vertical, String bookfont, String authorfont)
		{
			if (CoverPath == null || !File.Exists(CoverPath))
			{
				//toBeShown.Dispose();
				covers[0].Dispose();

				using (Image cover = DrawText(1536, 2048, vertical, bookfont, authorfont))
				{
					try
					{
						covers[0] = new Bitmap(cover);
						CoverPath = tempPath + "\\cover.jpg";
						//cover.Save(CoverPath, System.Drawing.Imaging.ImageFormat.Jpeg);
						SaveJpeg(CoverPath, cover, 100);
					}
					catch
					{
						MessageBoxEx.Show("coverpath: " + CoverPath);
					}
				}

				pg3.cover.SizeMode = PictureBoxSizeMode.Zoom;
				//toBeShown = new Bitmap(CoverPath);
				/*toBeShown = Image.FromFile(CoverPath);
				pg3.cover.Image = toBeShown;*/
				pg3.cover.Image = covers[0];
			}
			else
			{
				if (!File.Exists(CoverPath))
				{
					MessageBoxEx.Show("找不到" + CoverPath + "文件！\n无法继续生成！");
					return false;
				}
			}

			if (CoverPathSlim == null || !File.Exists(CoverPathSlim))
			{
				covers[1].Dispose();

				using (Image coverSlim = DrawText(1080, 1920, vertical, bookfont, authorfont))
				{
					try
					{
						covers[1] = new Bitmap(coverSlim);
						CoverPathSlim = tempPath + "\\cover~slim.jpg";
						//coverSlim.Save(CoverPathSlim, System.Drawing.Imaging.ImageFormat.Jpeg);
						SaveJpeg(CoverPathSlim, coverSlim, 100);
					}
					catch
					{
						MessageBoxEx.Show("coverpathslim: " + CoverPathSlim);
					}
				}
			}
			else
			{
				if (!File.Exists(CoverPathSlim))
				{
					MessageBoxEx.Show("找不到" + CoverPathSlim + "文件！\n无法继续生成！");
					return false;
				}
			}

			for (Int32 i = 0; i < pictureHTMLs.Count; i++)
			{
				String origPic = tempPath + "\\picture" + i + ".jpg";
				String origPicSlim = tempPath + "\\picture" + i + "~slim.jpg";

				if (!File.Exists(origPic))
				{
					MessageBoxEx.Show("找不到" + origPic + "文件！\n无法继续生成！");
					return false;
				}
				if (!File.Exists(origPicSlim))
				{
					MessageBoxEx.Show("找不到" + origPicSlim + "文件！\n无法继续生成！");
					return false;
				}
			}
			return true;
		}

		private void generateOPF(Boolean coverFirstPage, Int32 translation, Boolean vertical, Boolean embedFontSubset)
		{
			Intro = translate(Intro, translation);

			String head = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n<package version=\"2.0\" unique-identifier=\"BookID\" xmlns=\"http://www.idpf.org/2007/opf\">\n<metadata xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:opf=\"http://www.idpf.org/2007/opf\">\n<dc:title>" + bookAndAuthor[0] + "</dc:title>\n<dc:identifier id=\"BookID\">urn:uuid:henryxrl@gmail.com</dc:identifier>\n<dc:language>zh-CN</dc:language>\n<dc:creator opf:role=\"aut\">" + bookAndAuthor[1] + "</dc:creator>\n<dc:description>" + Intro + "</dc:description>\n<meta name=\"cover\" content=\"cover-image\" />\n</metadata>\n<manifest>\n<!-- Content Documents -->\n";

			StringBuilder body1 = new StringBuilder();
			if (coverFirstPage)
			{
				body1.Append("<item id=\"coverpage\" href=\"Text/coverpage.html\"  media-type=\"application/xhtml+xml\" />\n");
			}

			Int32 chapterID = 1;
			Int32 picID = 0;
			Int32 iVal = (extraLinesInBeginning ? (chapterNumber + pictureHTMLs.Count - 1) : (chapterNumber + pictureHTMLs.Count));
			if (extraLinesInBeginning)
			{
				if (extraLinesNotEmpty)
				{
					body1.Append("<item id=\"chapter" + chapterID + "\"  href=\"Text/chapter" + chapterID + ".html\"  media-type=\"application/xhtml+xml\" />\n");
					chapterID++;
				}
			}

			// no toc found
			if (pg2.TOC_list.Rows[0].Cells[0].Value == null)
			{
				body1.Append("<item id=\"chapter" + chapterID + "\"  href=\"Text/chapter" + chapterID + ".html\"  media-type=\"application/xhtml+xml\" />\n");
			}
			else
			{
				for (Int32 i = 1; i <= iVal; i++)
				{
					String tempTitle = pg2.TOC_list.Rows[i - 1].Cells[0].Value.ToString();

					String tempTitleProcessed = "";
					if (tempTitle.Contains(" *** "))
					{
						tempTitleProcessed = tempTitle.Replace(" *** ", "");
					}
					else
					{
						tempTitleProcessed = tempTitle;
					}

					// 加图片页
					if (tempTitle.StartsWith("<"))
					{
						body1.Append("<item id=\"picture" + picID + "\"  href=\"Text/picture" + picID + ".html\"  media-type=\"application/xhtml+xml\" />\n");
						picID++;
					}

					else	// 加文字页
					{
						body1.Append("<item id=\"chapter" + chapterID + "\"  href=\"Text/chapter" + chapterID + ".html\"  media-type=\"application/xhtml+xml\" />\n");
						chapterID++;
					}
				}
			}

			String spine = "";
			if (vertical)
			{
				spine = "<spine toc=\"ncx\" page-progression-direction=\"rtl\">";
			}
			else
			{
				spine = "<spine toc=\"ncx\">";
			}

			StringBuilder otherImages = new StringBuilder();
			for (Int32 i = 0; i < picHtmlList.Count; i++)
			{
				otherImages.Append("\n<item id=\"picture" + i + "-image\" href=\"Images/picture" + i + ".jpg\" media-type=\"image/jpeg\" />\n<item id=\"picture" + i + "-image-slim\" href=\"Images/picture" + i + "~slim.jpg\" media-type=\"image/jpeg\" />");
			}

			StringBuilder embedFonts = new StringBuilder();
			if (embedFontSubset)
			{
				for (Int32 i = 0; i < embedFontPaths.Count; i++)
				{
					String fontPath = embedFontPaths[i];
					String fontName = fontPath.Substring(fontPath.LastIndexOf("\\") + 1);
					embedFonts.Append("\n<item id=\"" + fontName + "\" href=\"Fonts/" + fontName + "\" media-type=\"application/vnd.ms-opentype\" />");
				}
			}

			String body2 = "\n<item id=\"ncx\" href=\"toc.ncx\" media-type=\"application/x-dtbncx+xml\" />\n<item id=\"css\" href=\"Styles/main.css\" media-type=\"text/css\" />\n<item id=\"cover-image\" href=\"Images/cover.jpg\" media-type=\"image/jpeg\" />\n<item id=\"cover-image-slim\" href=\"Images/cover~slim.jpg\" media-type=\"image/jpeg\" />" + otherImages.ToString() + embedFonts.ToString() + "\n</manifest>\n\n" + spine + "\n";

			StringBuilder body3 = new StringBuilder();
			if (coverFirstPage)
			{
				body3.Append("<itemref idref=\"coverpage\" properties=\"duokan-page-fullscreen\" />\n");
			}

			chapterID = 1;
			picID = 0;
			if (extraLinesInBeginning)
			{
				if (extraLinesNotEmpty)
				{
					body3.Append("<itemref idref=\"chapter" + chapterID + "\" />\n");
					chapterID++;
				}
			}

			if (pg2.TOC_list.Rows[0].Cells[0].Value == null)
			{
				body3.Append("<itemref idref=\"chapter" + chapterID + "\" />\n");
			}
			else
			{
				for (Int32 i = 1; i <= iVal; i++)
				{
					String tempTitle = pg2.TOC_list.Rows[i - 1].Cells[0].Value.ToString();

					String tempTitleProcessed = "";
					if (tempTitle.Contains(" *** "))
					{
						tempTitleProcessed = tempTitle.Replace(" *** ", "");
					}
					else
					{
						tempTitleProcessed = tempTitle;
					}

					// 加图片页
					if (tempTitle.StartsWith("<"))
					{
						body3.Append("<itemref idref=\"picture" + picID + "\" properties=\"duokan-page-fullscreen\" />\n");
						picID++;
					}

					else	// 加文字页
					{
						body3.Append("<itemref idref=\"chapter" + chapterID + "\" />\n");
						chapterID++;
					}
				}
			}

			String foot = "\n</spine>\n<guide>\n\n</guide>\n</package>";

			opf.Append(head);
			opf.Append(body1);
			opf.Append(body2);
			opf.Append(body3);
			opf.Append(foot);
		}

		private void generateNCX(Boolean coverFirstPage, Boolean coverNoTOC, Int32 translation)
		{
			/*** head ***/
			String head = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n<!DOCTYPE ncx PUBLIC \"-//NISO//DTD ncx 2005-1//EN\" \"http://www.daisy.org/z3986/2005/ncx-2005-1.dtd\">\n<ncx version=\"2005-1\" xml:lang=\"zh-CN\" xmlns=\"http://www.daisy.org/z3986/2005/ncx/\">\n<head>\n\t<!-- The following four metadata items are required for all NCX documents, including those conforming to the relaxed constraints of OPS 2.0 -->\n\t<meta name=\"dtb:uid\" content=\"urn:uuid:henryxrl@gmail.com\" />\n\t<meta name=\"dtb:depth\" content=\"1\" />\n\t<meta name=\"dtb:totalPageCount\" content=\"0\" />\n\t<meta name=\"dtb:maxPageNumber\" content=\"0\" />\n</head>\n<docTitle><text>" + bookAndAuthor[0] + "</text></docTitle>\n<docAuthor><text>" + bookAndAuthor[1] + "</text></docAuthor>\n";

			/*** navMap ***/
			Int32 maxCount = 0;

			List<Tuple<Int32, NavPoint>> TOCTree = new List<Tuple<Int32, NavPoint>>();

			Boolean addFirstChapter = true;
			Int32 j = 1;
			Int32 picIDX = 0;
			Boolean fromD = false;
			Int32 iVal = (extraLinesInBeginning ? (chapterNumber + pictureHTMLs.Count - 1) : (chapterNumber + pictureHTMLs.Count));

			if (coverFirstPage && addFirstChapter)
			{
				String title = "封面";
				title = translate(title, translation);		// 简繁转换

				if (!coverNoTOC)
				{
					TOCTree.Add(new Tuple<Int32, NavPoint>(0, new NavPoint("coverpage", 1, title, "Text/coverpage.html", null, null)));
				}

				addFirstChapter = false;
			}

			if (extraLinesInBeginning)
			{
				Int32 start = (txtHtmlList[0].IndexOf("<title>") + "<title>".Length);
				Int32 end = (txtHtmlList[0].IndexOf("</title>"));
				Int32 length = end - start;
				String title = txtHtmlList[0].Substring(start, length);
				if (extraLinesNotEmpty)
				{
					if (!coverNoTOC)
						TOCTree.Add(new Tuple<Int32, NavPoint>(0, new NavPoint("chapter" + j, (j + 1), title, "Text/chapter" + j + ".html", null, null)));
					else
						TOCTree.Add(new Tuple<Int32, NavPoint>(0, new NavPoint("chapter" + j, j, title, "Text/chapter" + j + ".html", null, null)));
					j++;
				}
				extraLinesInBeginning = false;
				extraLinesNotEmpty = false;
			}

			if (pg2.TOC_list.Rows[0].Cells[0].Value == null)
			{
				if (!coverNoTOC)
					TOCTree.Add(new Tuple<Int32, NavPoint>(0, new NavPoint("chapter" + j, (j + 1), bookAndAuthor[0], "Text/chapter" + j + ".html", null, null)));
				else
					TOCTree.Add(new Tuple<Int32, NavPoint>(0, new NavPoint("chapter" + j, j, bookAndAuthor[0], "Text/chapter" + j + ".html", null, null)));
			}
			else
			{
				for (Int32 i = 1; i <= iVal; i++)
				{
					// 删除" *** "标识
					//MessageBoxEx.Show("i: " + i + "\nj: " + j + "\n(i-j): " + (i - j));
					String tempTitle = pg2.TOC_list.Rows[i - 1].Cells[0].Value.ToString();

					String tempTitleProcessed = "";
					if (tempTitle.Contains(" *** "))
					{
						tempTitleProcessed = tempTitle.Replace(" *** ", "");
					}
					else
					{
						tempTitleProcessed = tempTitle;
					}
					tempTitleProcessed = tempTitleProcessed.Trim();

					// 目录分级
					Int32 occurCount = CountStringOccurrences(tempTitle, " *** ");
					maxCount = (occurCount >= maxCount) ? occurCount : maxCount;

					// 加页
					if (!tempTitleProcessed.StartsWith("<"))
					{
						if (!fromD)
						{
							tempTitleProcessed = translate(tempTitleProcessed, translation);
							if (!coverNoTOC)
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("chapter" + j, (j + 1), tempTitleProcessed, "Text/chapter" + j + ".html", null, null)));
							else
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("chapter" + j, j, tempTitleProcessed, "Text/chapter" + j + ".html", null, null)));
							j++;
						}
						else
						{
							fromD = false;
						}
					}
					else
					{
						String temp = pictureHTMLs[picIDX].Item1;
						if (temp.StartsWith("U") || temp.StartsWith("u"))
						{
							picIDX++;
						}
						else if (temp.StartsWith("D") || temp.StartsWith("d"))
						{
							temp = temp.Substring(1, temp.Length - 1);
							temp = temp.Trim();

							if (!coverNoTOC)
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("picture" + picIDX, (j + 1), temp, "Text/picture" + picIDX + ".html", null, null)));
							else
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("picture" + picIDX, j, temp, "Text/picture" + picIDX + ".html", null, null)));
							picIDX++;
							j++;

							fromD = true;
						}
						else
						{
							temp = temp.Trim();

							if (!coverNoTOC)
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("picture" + picIDX, (j + 1), temp, "Text/picture" + picIDX + ".html", null, null)));
							else
								TOCTree.Add(new Tuple<Int32, NavPoint>(occurCount, new NavPoint("picture" + picIDX, j, temp, "Text/picture" + picIDX + ".html", null, null)));
							picIDX++;
							j++;

						}
					}
				}
			}

			NavMap nm = new NavMap(TOCTree, maxCount);


			ncx.Append(head);
			ncx.Append(nm.printNM());
			ncx.Append("</ncx>");
		}

		#endregion

		#endregion


		#region Helper Functions

		#region Page1 Helper Functions

		private void clearTOC()
		{
			if (pg2 == null)
			{
				setPage2();
			}
			else
			{
				// Clear TOC_list
				if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[0].Cells[1].Value != null)
				{
					pg2.TOC_list.Rows.Clear();
				}
			}
		}

		private List<String> getBookNameAndAuthorInfo(String path, String filename)
		{
			List<String> result = new List<String>();

			filename = filename.Trim();

			//Match m = Regex.Match(filename, "^[a-zA-Z0-9?><;,{}[\\]\\-_+=!@#$%\\^&*|'\\s]*$");
			//Match m = Regex.Match(filename, "^[\\p{L}\\p{P}\\s\\p{N}]*$");	Doesn't work since \p{L} includes Eastern characters as well!
			Match m = Regex.Match(filename, "^[a-zA-ZÀ-ÿ\\p{P}\\s\\p{N}]*$");
			if (m.Success)		// is English book name
			{
				//Match m1 = Regex.Match(filename, "^[a-zA-Z0-9?><;,{}[\\]\\-_+=!@#$%\\^&*|'\\s]*(\\s(?i)by\\s)[a-zA-Z0-9?><;,{}[\\]\\-_+=!@#$%\\^&*|'\\s]*$");
				// 1. get info from file name
				Int32 pos = filename.ToLower().IndexOf(" by ");
				if (pos != -1)
				{
					String bookname = filename.Substring(0, pos);
					bookname = bookname.Trim();
					String author = filename.Substring(filename.ToLower().IndexOf(" by ") + 4, filename.Length - filename.ToLower().IndexOf(" by ") - 4);
					author = author.Trim();

					result.Add(bookname);
					result.Add(author);

					return result;
				}
				else
				{
					FSLinesScanned = 2;

					// No complete book name and author info
					notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
					showBalloonTip("文件名中无完整英文书名和作者信息！", "完整信息范例：“BookName By Author”\n（文件名中一定要有“By”这个词，大小写不限）\n\n开始检测文件第一、二行……\n其中第一行为书名，第二行为作者名！");

					// Treat first line as book name and second line as author
					using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("GB2312")))
					{
						String bookname = sr.ReadLine();
						if (bookname == null || bookname.Trim() == "") bookname = filename;
						else
						{
							bookname = bookname.Trim();
						}

						String author = sr.ReadLine();
						if (author == null || author.Trim() == "") author = "SimpleEpub2";
						else
						{
							author = author.Trim();
						}

						result.Add(bookname);
						result.Add(author);
					}
					return result;
				}
			}
			else
			{
				// 1. get info from file name
				Int32 pos = filename.IndexOf("作者：");
				if (pos == -1)
					pos = filename.IndexOf("作者:");
				if (pos != -1)
				{
					String bookname = filename.Substring(0, pos);
					char[] charsToTrim = { '《', '》' };
					bookname = bookname.Trim(charsToTrim);
					bookname = bookname.Replace("书名：", "");
					bookname = bookname.Replace("书名:", "");
					bookname = bookname.Trim();
					String author = filename.Substring(filename.IndexOf("作者：") + 3, filename.Length - filename.IndexOf("作者：") - 3);
					author = author.Trim();

					result.Add(bookname);
					result.Add(author);

					return result;
				}
				else
				{
					FSLinesScanned = 2;

					// No complete book name and author info
					notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
					showBalloonTip("文件名中无完整书名和作者信息！", "完整信息范例：“《书名》作者：作者名”\n（文件名中一定要有“作者”二字，书名号可以省略）\n\n开始检测文件第一、二行……\n其中第一行为书名，第二行为作者名！");

					// Treat first line as book name and second line as author
					using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("GB2312")))
					{
						String bookname = sr.ReadLine();
						if (bookname == null || bookname.Trim() == "") bookname = filename;
						else
						{
							char[] charsToTrim = { '《', '》' };
							bookname = bookname.Trim(charsToTrim);
							bookname = bookname.Replace("书名：", "");
							bookname = bookname.Replace("书名:", "");
							bookname = bookname.Trim();
						}

						String author = sr.ReadLine();
						if (author == null || author.Trim() == "") author = "SimpleEpub2";
						else
						{
							author = author.Replace("作者：", "");
							author = author.Replace("作者:", "");
							author = author.Trim();
						}

						result.Add(bookname);
						result.Add(author);
					}
					return result;
				}
			}
		}

		private static String getIntroInfo(String path)
		{
			StringBuilder result = new StringBuilder();

			using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (BufferedStream bs = new BufferedStream(fs))
			using (StreamReader sr = new StreamReader(path, Encoding.GetEncoding("GB2312")))
			{
				String line = "";
				Boolean titleFirstLine = false;

				// Find first title line number
				Int32 firstTitleLineNumber = 1;
				while ((line = sr.ReadLine()) != null)
				{
					Match title = Regex.Match(line, regex);
					
					// First chapter title found!
					if (title.Success)
					{
						if (firstTitleLineNumber == 1) titleFirstLine = true;
						else break;
					}
					firstTitleLineNumber++;
				}
				// exclude the title itself
				firstTitleLineNumber -= 1;

				sr.DiscardBufferedData();
				sr.BaseStream.Seek(0, SeekOrigin.Begin);
				sr.BaseStream.Position = 0;

				Int32 startLineNumber = (titleFirstLine ? 1 : 0);
				line = (titleFirstLine ? sr.ReadLine() : "");
				for (Int32 i = startLineNumber; i < firstTitleLineNumber; i++)
				{
					line = sr.ReadLine();
					// Remove empty lines
					if (!Regex.IsMatch(line, emptyLineRegex))
					{
						result.Append(line.Trim() + "\n");
					}
				}
			}

			return result.ToString().Trim();
		}

		private static String ToSBC(String input)
		{
			// 半角转全角：
			char[] c = input.ToCharArray();
			for (Int32 i = 0; i < c.Length; i++)
			{
				if (c[i] == 32)
				{
					c[i] = (char)12288;
					continue;
				}
				if (c[i] < 127)
					c[i] = (char)(c[i] + 65248);
			}
			return new String(c);
		}

		#endregion

		#region Page2 Helper Functions

		private void generateTempCovers()
		{
			if (File.Exists(CoverPath))
			{
				try
				{
					File.Delete(CoverPath);
				}
				catch
				{
					if (File.Exists(CoverPath))
						MessageBoxEx.Show(this, "删除原封面文件失败！");
				}
			}
			if (File.Exists(CoverPathSlim))
			{
				try
				{
					File.Delete(CoverPathSlim);
				}
				catch
				{
					if (File.Exists(CoverPathSlim))
						MessageBoxEx.Show(this, "删除原封面文件失败！");
				}
			}

			covers[0] = null;
			covers[1] = null;
			using (Image cover = DrawText(1536, 2048, stsObj.verticalText, stsObj.bookNameFont, stsObj.authorNameFont))
			{
				try
				{
					covers[0] = new Bitmap(cover);
					//covers.Add(new Bitmap(cover));

					//cover.Save(CoverPath, System.Drawing.Imaging.ImageFormat.Jpeg);
					SaveJpeg(CoverPath, cover, 100);
				}
				catch
				{
					MessageBoxEx.Show("coverpath: " + CoverPath);
				}
			}
			using (Image coverSlim = DrawText(1080, 1920, stsObj.verticalText, stsObj.bookNameFont, stsObj.authorNameFont))
			{
				try
				{
					covers[1] = new Bitmap(coverSlim);
					//covers.Add(new Bitmap(coverSlim));

					//coverSlim.Save(CoverPathSlim, System.Drawing.Imaging.ImageFormat.Jpeg);
					SaveJpeg(CoverPathSlim, coverSlim, 100);
				}
				catch
				{
					MessageBoxEx.Show("coverpathslim: " + CoverPathSlim);
				}
			}
		}

		private void generateNotePic()
		{
			String NotePath = tempPath + "\\note.png";
			if (File.Exists(NotePath))
			{
				try
				{
					File.Delete(NotePath);
				}
				catch
				{
					if (File.Exists(NotePath))
						MessageBoxEx.Show("Deletion failed");
				}
			}

			using (Image note = DrawNotePic(64, 64, "注", stsObj.bodyFont))
			{
				try
				{
					//note.Save(NotePath, System.Drawing.Imaging.ImageFormat.Png);
					SavePng(NotePath, note, 100);
				}
				catch
				{
					MessageBoxEx.Show("notepath: " + NotePath);
				}
			}
		}

		private void generateCoverFromFilePath()
		{
			String coverTemp = tempPath + "\\covertemp.jpg";
			System.IO.File.Copy(origCover, coverTemp, true);
			crop("cover");
			CoverPath = tempPath + "\\cover.jpg";
			CoverPathSlim = tempPath + "\\cover~slim.jpg";
			if (covers[0] != null)
				covers[0].Dispose();
			if (covers[1] != null)
				covers[1].Dispose();
			Image img1 = Image.FromFile(CoverPath);
			Image img2 = Image.FromFile(CoverPathSlim);
			Bitmap cover = new Bitmap(img1);
			Bitmap coverSlim = new Bitmap(img2);
			covers[0] = cover;
			covers[1] = coverSlim;
			img1.Dispose();
			img2.Dispose();

			pg2.cover_picturebox.SizeMode = PictureBoxSizeMode.Zoom;
			//toBeShown = new Bitmap(CoverPath);
			/*toBeShown = Image.FromFile(CoverPath);
			pg2.cover_picturebox.Image = toBeShown;*/
			pg2.cover_picturebox.Image = covers[0];
		}
		
		private Image DrawText(Int32 width, Int32 height, Boolean vertical, String bookfont, String authorfont)
		{
			//String bookname = VB.Strings.StrConv(bookAndAuthor[0], VB.VbStrConv.SimplifiedChinese, 0);
			//String author = VB.Strings.StrConv(bookAndAuthor[1], VB.VbStrConv.SimplifiedChinese, 0);
			String bookname = bookAndAuthor[0];
			String author = bookAndAuthor[1];

			Image img = new Bitmap(width, height);
			Graphics drawing = Graphics.FromImage(img);

			//paint the background
			drawing.Clear(System.Drawing.Color.FromArgb(50, 70, 110));
			drawing.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			drawing.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			drawing.InterpolationMode = InterpolationMode.HighQualityBicubic;
			drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
			drawing.CompositingQuality = CompositingQuality.HighQuality;
			drawing.CompositingMode = CompositingMode.SourceOver;

			System.Drawing.Brush whiteBrush = new SolidBrush(System.Drawing.Color.White);
			System.Drawing.Brush orangeBrush = new SolidBrush(System.Drawing.Color.FromArgb(228, 89, 23));
			System.Drawing.Brush yellowBrush = new SolidBrush(System.Drawing.Color.Yellow);
			System.Drawing.Brush blackBrush = new SolidBrush(System.Drawing.Color.Black);

			System.Drawing.Pen whitePen = new System.Drawing.Pen(whiteBrush, width / 1000 * 5);

			Rectangle bookNameRec;
			Rectangle authorRec1;
			Rectangle authorRec2;

			if (!vertical)		// 横排书封面
			{
				drawing.DrawLine(whitePen, new Point(width / 15, 0), new Point(width / 15, height));
				drawing.DrawLine(whitePen, new Point(0, height / 10), new Point(width / 15, height / 10));
				drawing.DrawLine(whitePen, new Point(0, height / 10 + height / 3), new Point(width / 15, height / 10 + height / 3));
				drawing.DrawLine(whitePen, new Point(0, height - height / 10 - height / 3), new Point(width / 15, height - height / 10 - height / 3));
				drawing.DrawLine(whitePen, new Point(0, height - height / 10), new Point(width / 15, height - height / 10));

				bookNameRec = Rectangle.FromLTRB(width / 2 + width / 10, height / 10, width - width / 10, height / 2 + height / 10);
				drawing.FillRectangle(whiteBrush, bookNameRec);
				authorRec1 = Rectangle.FromLTRB(width / 2 + width / 10 - width / 20, height / 10, width / 2 + width / 10, height / 2 + height / 10 - height / 40);
				drawing.FillRectangle(orangeBrush, authorRec1);
				authorRec2 = Rectangle.FromLTRB(width / 2 + width / 10 - width / 20, height / 10 + authorRec1.Height, width / 2 + width / 10, height / 2 + height / 10);
				drawing.FillRectangle(orangeBrush, authorRec2);
			}
			else		// 竖排书封面
			{
				drawing.DrawLine(whitePen, new Point(width - width / 15, 0), new Point(width - width / 15, height));
				drawing.DrawLine(whitePen, new Point(width - width / 15, height / 10), new Point(width, height / 10));
				drawing.DrawLine(whitePen, new Point(width - width / 15, height / 10 + height / 3), new Point(width, height / 10 + height / 3));
				drawing.DrawLine(whitePen, new Point(width - width / 15, height - height / 10 - height / 3), new Point(width, height - height / 10 - height / 3));
				drawing.DrawLine(whitePen, new Point(width - width / 15, height - height / 10), new Point(width, height - height / 10));

				bookNameRec = Rectangle.FromLTRB(width / 10, height / 10, width / 2 - width / 10, height / 2 + height / 10);
				drawing.FillRectangle(whiteBrush, bookNameRec);
				authorRec1 = Rectangle.FromLTRB(width / 2 - width / 10, height / 10, width / 2 - width / 10 + width / 20, height / 2 + height / 10 - height / 40);
				drawing.FillRectangle(orangeBrush, authorRec1);
				authorRec2 = Rectangle.FromLTRB(width / 2 - width / 10, height / 10 + authorRec1.Height, width / 2 - width / 10 + width / 20, height / 2 + height / 10);
				drawing.FillRectangle(orangeBrush, authorRec2);
			}

			StringFormat bookDrawFormat = new StringFormat();
			bookDrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
			//bookDrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			bookDrawFormat.Alignment = StringAlignment.Center;
			bookDrawFormat.LineAlignment = StringAlignment.Center;
			bookname = ToSBC(bookname);
			Tuple<String, Int32> settings = setTitleFontSize(bookname.Length, bookNameRec.Width, bookname, vertical);
			//Font bookFont = new Font(privateFontFamilies[1], settings.Item2, FontStyle.Bold);
			Font bookFont = new Font(bookfont, settings.Item2, FontStyle.Bold);
			drawing.DrawString(settings.Item1, bookFont, blackBrush, bookNameRec, bookDrawFormat);

			StringFormat authorDrawFormat = new StringFormat();
			authorDrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
			//authorDrawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			authorDrawFormat.Alignment = StringAlignment.Far;
			authorDrawFormat.LineAlignment = StringAlignment.Center;
			author = ToSBC(author);
			//Font authorFont = new Font(privateFontFamilies[0], authorRec1.Width / 2, FontStyle.Bold);
			Font authorFont = new Font(authorfont, authorRec1.Width / 2, FontStyle.Bold);
			drawing.DrawString(author + " ◆ 著", authorFont, whiteBrush, authorRec1, authorDrawFormat);
			drawing.DrawString(" ◆ 著", authorFont, yellowBrush, authorRec1, authorDrawFormat);
			drawing.DrawString("著", authorFont, whiteBrush, authorRec1, authorDrawFormat);

			whiteBrush.Dispose();
			orangeBrush.Dispose();
			yellowBrush.Dispose();
			blackBrush.Dispose();
			whitePen.Dispose();
			bookFont.Dispose();
			authorFont.Dispose();
			bookDrawFormat.Dispose();
			authorDrawFormat.Dispose();

			drawing.Save();
			drawing.Dispose();

			return img;
		}

		private Image DrawNotePic(Int32 width, Int32 height, String word, String bodyfont)
		{
			Bitmap img = new Bitmap(width, height);
			Graphics drawing = Graphics.FromImage(img);

			//paint the background
			drawing.Clear(System.Drawing.Color.Transparent);
			drawing.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			drawing.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

			Rectangle bound = new Rectangle(0, 0, width-1, height-1);

			System.Drawing.Brush brownBrush = new SolidBrush(System.Drawing.Color.FromArgb(165, 70, 15));
			drawing.FillEllipse(brownBrush, bound);			

			// Draw word overlay
			Bitmap overLay = new Bitmap(width, height);
			Graphics drawingOverLay = Graphics.FromImage(overLay);
			drawingOverLay.Clear(System.Drawing.Color.Black);
			drawingOverLay.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			drawingOverLay.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
			drawingOverLay.InterpolationMode = InterpolationMode.HighQualityBicubic;
			drawingOverLay.PixelOffsetMode = PixelOffsetMode.HighQuality;
			drawingOverLay.CompositingQuality = CompositingQuality.HighQuality;
			drawingOverLay.CompositingMode = CompositingMode.SourceOver;
			
			System.Drawing.Brush transparentBrush = new SolidBrush(System.Drawing.Color.White);
			StringFormat noteDrawFormat = new StringFormat();
			noteDrawFormat.Alignment = StringAlignment.Center;
			/*noteDrawFormat.LineAlignment = StringAlignment.Center;
			noteDrawFormat.FormatFlags = StringFormatFlags.DirectionVertical;*/

			Font noteFont = new Font(bodyfont, 1, FontStyle.Regular);
			/*TextFormatFlags flags = TextFormatFlags.NoPadding;
			TextRenderer.DrawText(drawingOverLay, word, noteFont, new Point(0, 0), System.Drawing.Color.White, flags);*/
			//TextRenderer.DrawText(drawingOverLay, word, noteFont, new Point(0, 0), System.Drawing.Color.FromArgb(165, 70, 15), System.Drawing.Color.White, TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter);
			drawingOverLay.DrawString(word, scaleFont(drawing, word, noteFont, bound, noteDrawFormat), transparentBrush, bound, noteDrawFormat);

			//drawingOverLay.Save();

			ApplyAlphaMask(img, overLay);

			overLay.Dispose();
			drawingOverLay.Dispose();

			brownBrush.Dispose();
			noteFont.Dispose();
			noteDrawFormat.Dispose();

			drawing.Save();
			drawing.Dispose();

			return img;
		}

		private static void ApplyAlphaMask(Bitmap bmp, Bitmap alphaMaskImage)
		{
			Int32 width = bmp.Width;
			Int32 height = bmp.Height;

			BitmapData dataAlphaMask = alphaMaskImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			try
			{
				BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
				try
				{
					unsafe //using pointer requires the unsafe keyword
					{
						Byte* pData0Mask = (Byte*)dataAlphaMask.Scan0;
						Byte* pData0 = (Byte*)data.Scan0;

						for (Int32 x = 0; x < width; x++)
						{
							for (Int32 y = 0; y < height; y++)
							{
								Byte* pData = pData0 + (y * data.Stride) + (x * 4);
								Byte* pDataMask = pData0Mask + (y * dataAlphaMask.Stride) + (x * 4);

								Byte maskBlue = pDataMask[0];
								Byte maskGreen = pDataMask[1];
								Byte maskRed = pDataMask[2];

								//the closer the color is to black the more opaque it will be.
								Byte alpha = (Byte)(255 - (maskRed + maskBlue + maskGreen) / 3);

								//respect the original alpha value
								Byte originalAlpha = pData[3];
								pData[3] = (Byte)(((Single)(alpha * originalAlpha)) / 255f);
							}
						}
					}
				}
				finally
				{
					bmp.UnlockBits(data);
				}
			}
			finally
			{
				alphaMaskImage.UnlockBits(dataAlphaMask);
			}
		}

		private Font scaleFont(Graphics g, String s, Font f, RectangleF r, StringFormat fm)
		{
			Single width = g.MeasureString(s, f, new SizeF(r.Width, r.Height), fm).Width;
			Single height = g.MeasureString(s, f, new SizeF(r.Width, r.Height), fm).Height;

			/*Single width = TextRenderer.MeasureText(s, f).Width;
			Single height = TextRenderer.MeasureText(s, f).Height;*/

			Single fontSize = (Convert.ToSingle((Math.Max(r.Width, r.Height) * 1.1) / Math.Min(width, height)) * f.Size);
			//MessageBoxEx.Show("width: " + g.MeasureString(s, f).Width + "\nheight: " + g.MeasureString(s, f).Height + "\nsize: " + fontSize.ToString());
			return new Font(f.FontFamily, fontSize, f.Style);
		}

		private static Tuple<String, Int32> setTitleFontSize(Int32 len, Int32 width, String s, Boolean vertical)
		{
			if (len == 1) return new Tuple<String, Int32>(s, width / 50 * 33);
			else if (len == 2) return new Tuple<String, Int32>(s, width / 50 * 27);
			else if (len == 3) return new Tuple<String, Int32>(s, width / 50 * 22);
			else if (len == 4) return new Tuple<String, Int32>(manualTextWrap(s, 4, vertical), width / 50 * 17);
			else if (len == 5) return new Tuple<String, Int32>(manualTextWrap(s, 5, vertical), width / 50 * 15);
			else if (len == 6) return new Tuple<String, Int32>(manualTextWrap(s, 6, vertical), width / 50 * 12);
			else if (len == 7) return new Tuple<String, Int32>(manualTextWrap(s, 7, vertical), width / 50 * 11);
			else return setTitleFontSize((Int32)Math.Ceiling((Double)len / 2), width, s, vertical);
		}

		private static String manualTextWrap(String s, Int32 length, Boolean vertical)
		{
			List<String> wordList = new List<String>();
			for (Int32 i = 0; i < s.Length; i += length)
			{
				if ((i + length) > s.Length)
				{
					wordList.Add(s.Substring(i, s.Length - i));
				}
				else
				{
					wordList.Add(s.Substring(i, length));
				}
			}

			if (!vertical)
				wordList.Reverse();

			StringBuilder result = new StringBuilder();
			for (Int32 i = 0; i < wordList.Count; i++)
			{
				result.Append(wordList[i] + "\n");
			}
			return result.ToString().Trim();
		}

		private static void crop(String tempIMGNamePart1)
		{
			String tempIMGPath = tempPath + "\\" + tempIMGNamePart1 + "temp.jpg";

			Image newImage = Image.FromFile(tempIMGPath);
			String pic = "";
			String picSlim = "";
			if (((Single)(newImage.Height) / (Single)(newImage.Width)) <= ((Single)4 / (Single)3))
			{
				// create cover
				pic = tempPath + "\\" + tempIMGNamePart1 + ".jpg";
				Int32 newWidth = 3 * newImage.Height / 4;
				Bitmap croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle((newImage.Width / 2 - newWidth / 2), 0, newWidth, newImage.Height), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(pic, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(pic, croppedBitmap, 100);
				croppedBitmap.Dispose();

				// create cover~slim
				picSlim = tempPath + "\\" + tempIMGNamePart1 + "~slim.jpg";
				newWidth = 9 * newImage.Height / 16;
				croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle((newImage.Width / 2 - newWidth / 2), 0, newWidth, newImage.Height), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(picSlim, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(picSlim, croppedBitmap, 100);
				croppedBitmap.Dispose();
				newImage.Dispose();

				// delete covertemp.jpg
				if (File.Exists(tempIMGPath))
					File.Delete(tempIMGPath);
			}
			else if ((((Single)(newImage.Height) / (Single)(newImage.Width)) > ((Single)4 / (Single)3)) && (((Single)(newImage.Height) / (Single)(newImage.Width)) < ((Single)16 / (Single)9)))
			{
				// create cover
				pic = tempPath + "\\" + tempIMGNamePart1 + ".jpg";
				Int32 newHeight = 4 * newImage.Width / 3;
				Bitmap croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle(0, (newImage.Height / 2 - newHeight / 2), newImage.Width, newHeight), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(pic, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(pic, croppedBitmap, 100);
				croppedBitmap.Dispose();

				// create cover~slim
				picSlim = tempPath + "\\" + tempIMGNamePart1 + "~slim.jpg";
				Int32 newWidth = 9 * newImage.Height / 16;
				croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle((newImage.Width / 2 - newWidth / 2), 0, newWidth, newImage.Height), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(picSlim, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(picSlim, croppedBitmap, 100);
				croppedBitmap.Dispose();
				newImage.Dispose();

				// delete covertemp.jpg
				if (File.Exists(tempIMGPath))
					File.Delete(tempIMGPath);
			}
			else		// ((Single)(newImage.Height) / (Single)(newImage.Width)) >= ((Single)16 / (Single)9)
			{
				// create cover
				pic = tempPath + "\\" + tempIMGNamePart1 + ".jpg";
				Int32 newHeight = 4 * newImage.Width / 3;
				Bitmap croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle(0, (newImage.Height / 2 - newHeight / 2), newImage.Width, newHeight), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(pic, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(pic, croppedBitmap, 100);
				croppedBitmap.Dispose();

				// create cover~slim
				picSlim = tempPath + "\\" + tempIMGNamePart1 + "~slim.jpg";
				newHeight = 16 * newImage.Width / 9;
				croppedBitmap = new Bitmap(newImage);
				croppedBitmap = croppedBitmap.Clone(new Rectangle(0, (newImage.Height / 2 - newHeight / 2), newImage.Width, newHeight), System.Drawing.Imaging.PixelFormat.DontCare);
				//croppedBitmap.Save(picSlim, System.Drawing.Imaging.ImageFormat.Jpeg);
				SaveJpeg(picSlim, croppedBitmap, 100);
				croppedBitmap.Dispose();
				newImage.Dispose();

				// delete covertemp.jpg
				if (File.Exists(tempIMGPath))
					File.Delete(tempIMGPath);
			}
		}
		
		private static void SaveJpeg(String path, Image img, Int32 quality)
		{
			if (quality < 0 || quality > 100)
				throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");


			// Encoder parameter for image quality 
			EncoderParameter qualityParam =
				new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
			// Jpeg image codec 
			ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			img.Save(path, jpegCodec, encoderParams);
		}

		private static void SavePng(String path, Image img, Int32 quality)
		{
			if (quality < 0 || quality > 100)
				throw new ArgumentOutOfRangeException("quality must be between 0 and 100.");


			// Encoder parameter for image quality 
			EncoderParameter qualityParam =
				new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
			// Jpeg image codec 
			ImageCodecInfo jpegCodec = GetEncoderInfo("image/png");

			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			img.Save(path, jpegCodec, encoderParams);
		}

		private static ImageCodecInfo GetEncoderInfo(String mimeType)
		{
			Int32 j;
			ImageCodecInfo[] encoders;
			encoders = ImageCodecInfo.GetImageEncoders();
			for (j = 0; j < encoders.Length; j++)
			{
				if (encoders[j].MimeType == mimeType)
					return encoders[j];
			}
			return null;
		}

		private String getROOTPath()
		{
			return stsObj.fileLocation;
		}

		private String getTOCPath()
		{
			return getROOTPath() + "\\目录.txt";
		}

		private void clearOverLay()
		{
			pg2.overlay_TOC_buttons.Hide();
			pg2.radialMenu1.IsOpen = false;
			pg2.radialMenu3.IsOpen = false;
		}

		#endregion

		#region Page3 Helper Functions

		private void deleteAllTempFiles()
		{
			/*if (File.Exists(getTOCPath()))
			{
				File.Delete(getTOCPath());
			}*/
			Array.ForEach(Directory.GetFiles(tempPath), File.Delete);
		}

		private Boolean loadNewTOC()
		{
			Boolean validTOC = true;
			Int32 tempIDX = 0;
			Int32 picIDX = 0;
			while (pg2.TOC_list.Rows[tempIDX].Cells[1].Value != null)
			{
				Match validValue = Regex.Match(pg2.TOC_list.Rows[tempIDX].Cells[1].Value.ToString(), "^[0-9]+$");
				if (!validValue.Success)
				{
					if (pg2.TOC_list.Rows[tempIDX].Cells[0].Value.ToString().StartsWith("<"))		// insert picture chapter
					{
						String picPath = pg2.TOC_list.Rows[tempIDX].Cells[1].Value.ToString();
						if (File.Exists(picPath))
						{
							String newPicPath = tempPath + "\\picture" + picIDX + "temp.jpg";
							File.Copy(picPath, newPicPath, true);
							crop("picture" + picIDX);
							tempIDX++;
							picIDX++;
							continue;
						}
						try
						{
							picPath = Path.Combine(getROOTPath(), picPath);
							if (File.Exists(picPath))
							{
								String newPicPath = tempPath + "\\picture" + picIDX + "temp.jpg";
								File.Copy(picPath, newPicPath, true);
								crop("picture" + picIDX);
								picIDX++;
								tempIDX++;
								continue;
							}
						}
						catch
						{
							MessageBoxEx.Show("无效的目录！行号只能是数字！\n无法继续生成Epub！");
							validTOC = false;
							break;
						}
					}
					else
					{
						MessageBoxEx.Show("无效的目录！行号只能是数字！\n无法继续生成Epub！");
						validTOC = false;
						break;
					}
				}
				tempIDX++;
			}
			if (!validTOC) return false;

			if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[1].Cells[0].Value != null)
			{
				// load new book name and author
				bookAndAuthor.Clear();
				bookAndAuthor.Add(pg1.cover_bookname_textbox.Text);
				bookAndAuthor.Add(pg1.cover_author_textbox.Text);

				// load new title line number
				if (pg2.TOC_list.Rows[0].Cells[0].Value != null && pg2.TOC_list.Rows[0].Cells[0].Value != null)
				{
					titleLineNumbers.Clear();
					pictureHTMLs.Clear();
					for (Int32 i = 0; i < pg2.TOC_list.Rows.Count; i++)
					{
						if (pg2.TOC_list.Rows[i].Cells[0].Value != null && pg2.TOC_list.Rows[i].Cells[1].Value != null)
						{
							Match isLineNumber = Regex.Match(pg2.TOC_list.Rows[i].Cells[1].Value.ToString(), "^[0-9]+$");
							if (isLineNumber.Success)
							{
								titleLineNumbers.Add(Convert.ToInt32(pg2.TOC_list.Rows[i].Cells[1].Value));
							}
							else
							{
								String pictureHTMLTitle = pg2.TOC_list.Rows[i].Cells[0].Value.ToString();
								if (pictureHTMLTitle.StartsWith("<"))
								{
									pictureHTMLTitle = pictureHTMLTitle.Trim();
									pictureHTMLTitle = pictureHTMLTitle.Substring(1, pictureHTMLTitle.Length - 1);
									pictureHTMLTitle = pictureHTMLTitle.Trim();

									pictureHTMLs.Add(new Tuple<String, String>(pictureHTMLTitle, pg2.TOC_list.Rows[i].Cells[1].Value.ToString().Trim()));
								}
							}
						}
					}
				}
			}

			return true;
		}

		private static String HTMLHead(String chapterTitle, String picName, Int32 flag)		// flag == 0: cover page; flag == 1: chapter page; flag == 2: else
		{
			if (flag == 0)
			{
				return "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"zh-CN\">\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n<link rel=\"stylesheet\" type=\"text/css\" href=\"../Styles/main.css\" />\n<script type=\"text/javascript\">\n$(function() {\n\tif(($(window).height() / $(window).width()) >= 1.5) {\n\t\t$(\"img\").each(function() {\n\t\t\t$(this).attr(\"src\", $(this).attr(\"src\").replace(\"../Images/cover.jpg\", \"../Images/cover~slim.jpg\"));\n\t\t});\n\t}\n});\n</script>\n<title>" + chapterTitle + "</title>\n</head>\n<body>\n<div>";
			}
			else if (flag == 1)
			{
				Int32 footNoteIdx = chapterTitle.IndexOf("<a class=\"duokan-footnote\"");
				String title = (footNoteIdx > 0) ? chapterTitle.Substring(0, footNoteIdx) : chapterTitle;
				return "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"zh-CN\">\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n<link rel=\"stylesheet\" type=\"text/css\" href=\"../Styles/main.css\" />\n<title>" + title + "</title>\n</head>\n<body>\n<div>\n<h2>" + chapterTitle + "</h2>";
			}
			else
			{
				return "<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"zh-CN\">\n<head>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\n<link rel=\"stylesheet\" type=\"text/css\" href=\"../Styles/main.css\" />\n<script type=\"text/javascript\">\n$(function() {\n\tif(($(window).height() / $(window).width()) >= 1.5) {\n\t\t$(\"img\").each(function() {\n\t\t\t$(this).attr(\"src\", $(this).attr(\"src\").replace(\"../Images/" + picName + ".jpg\", \"../Images/" + picName + "~slim.jpg\"));\n\t\t});\n\t}\n});\n</script>\n<title>" + chapterTitle + "</title>\n</head>\n<body>\n<div>";
			}
		}

		private static String ReplaceFirst(String text, String search, String replace)
		{
			Int32 pos = text.IndexOf(search);
			if (pos < 0)
			{
				return text;
			}
			return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
		}

		private Double getProcessTime()
		{
			stopWatch.Stop();
			Int64 duration = stopWatch.ElapsedMilliseconds;
			return (duration / 1000d);
		}

		private static Int32 CountStringOccurrences(String text, String pattern)
		{
			Int32 count = 0;
			Int32 i = 0;
			while ((i = text.IndexOf(pattern, i)) != -1)
			{
				i += pattern.Length;
				count++;
			}
			return count;
		}

		private static Int32 translationState(Boolean StT, Boolean TtS)
		{
			// return 0: 不转; 1: 简转繁; 2: 繁转简
			if (StT && TtS)
			{
				return 0;
			}
			else if (StT && !TtS)
			{
				return 1;
			}
			else if (!StT && TtS)
			{
				return 2;
			}
			else return 0;
		}

		private static String translate(String s, Int32 translation)
		{
			VB.VbStrConv vbTranslation = VB.VbStrConv.None;
			switch (translation)
			{
				case 0:
					vbTranslation = VB.VbStrConv.None;
					break;
				case 1:
					vbTranslation = VB.VbStrConv.TraditionalChinese;
					break;
				case 2:
					vbTranslation = VB.VbStrConv.SimplifiedChinese;
					break;
				default:
					vbTranslation = VB.VbStrConv.None;
					break;
			}
			return VB.Strings.StrConv(s, vbTranslation, 0);
		}

		private static String numberToHan(String nextLine)
		{
			nextLine = nextLine.Replace("0", "零");
			nextLine = nextLine.Replace("1", "一");
			nextLine = nextLine.Replace("2", "二");
			nextLine = nextLine.Replace("3", "三");
			nextLine = nextLine.Replace("4", "四");
			nextLine = nextLine.Replace("5", "五");
			nextLine = nextLine.Replace("6", "六");
			nextLine = nextLine.Replace("7", "七");
			nextLine = nextLine.Replace("8", "八");
			nextLine = nextLine.Replace("9", "九");
			nextLine = nextLine.Replace("０", "零");
			nextLine = nextLine.Replace("１", "一");
			nextLine = nextLine.Replace("２", "二");
			nextLine = nextLine.Replace("３", "三");
			nextLine = nextLine.Replace("４", "四");
			nextLine = nextLine.Replace("５", "五");
			nextLine = nextLine.Replace("６", "六");
			nextLine = nextLine.Replace("７", "七");
			nextLine = nextLine.Replace("８", "八");
			nextLine = nextLine.Replace("９", "九");
			return nextLine;
		}

		private void CreateFontSubSetT()
		{
			if (titleFontPath.CompareTo("") != 0 && URIT != null)
			{
				Int32 wordCount = IndexT.Count;
				if (wordCount <= 0)
				{
					MessageBoxEx.Show("不需要内嵌标题字体！");
					noNeedEmbed = true;
					return;
				}
				else if (wordCount > 65535)
				{
					MessageBoxEx.Show("字符太多！将用字体全集！");
					File.Copy(URIT.AbsolutePath, (tempPath + "\\title.ttf"));
					return;
				}
				else
				{
					Byte[] filebytes = glyphTypefaceT.ComputeSubset(IndexT);
					String newFontPath = tempPath + "\\title.ttf";
					embedFontPaths.Add(newFontPath);
					using (FileStream fileStream = new FileStream(newFontPath, FileMode.Create))
					{
						fileStream.Write(filebytes, 0, filebytes.Length);
					}
				}
			}
		}

		private void CreateFontSubSetB()
		{
			if (bodyFontPath.CompareTo("") != 0 && URIB != null)
			{
				wordcountnr = IndexB.Count;
				if (wordcountnr <= 0)
				{
					MessageBoxEx.Show("不需要内嵌正文字体！");
					noNeedEmbed = true;
					return;
				}
				else if (wordcountnr > 65535)
				{
					MessageBoxEx.Show("字符太多！将用字体全集！");
					File.Copy(URIB.AbsolutePath, (tempPath + "\\body.ttf"));
					return;
				}
				else
				{
					Byte[] filebytes = glyphTypefaceB.ComputeSubset(IndexB);
					String newFontPath = tempPath + "\\body.ttf";
					embedFontPaths.Add(newFontPath);
					using (FileStream fileStream = new FileStream(newFontPath, FileMode.Create))
					{
						fileStream.Write(filebytes, 0, filebytes.Length);
					}
				}
			}
		}

		private void addStringToUInt16CollectionT(String s)
		{
			Char[] temp = s.ToCharArray();
			// Remove duplicated chars
			// Only add unique chars to Index
			for (Int32 i = 0; i < temp.Length; i++)
			{
				if (ALLTITLETEXT.Add(temp[i]))
				{
					try { IndexT.Add((UInt16)(glyphTypefaceT.CharacterToGlyphMap[Convert.ToInt32(temp[i])])); }
					catch { /* character not in CharacterToGlyphMap! */ }
				}
			}
		}

		private void addStringToUInt16CollectionB(String s)
		{
			Char[] temp = s.ToCharArray();
			wordcount += temp.Length;
			// Remove duplicated chars
			// Only add unique chars to Index
			for (Int32 i = 0; i < temp.Length; i++)
			{
				if (ALLBODYTEXT.Add(temp[i]))
				{
					try { IndexB.Add((UInt16)(glyphTypefaceB.CharacterToGlyphMap[Convert.ToInt32(temp[i])])); }
					catch { /* character not in CharacterToGlyphMap! */ }
				}
			}
		}

		#endregion

		#region Other Helper Functions

		private static void Extract(String nameSpace, String outDirectory, String internalFilePath, String resourceName)
		{
			Assembly assembly = Assembly.GetCallingAssembly();

			using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
			using (BinaryReader r = new BinaryReader(s))
			using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
			using (BinaryWriter w = new BinaryWriter(fs))
				w.Write(r.ReadBytes((Int32)s.Length));
		}

		private void switchAOT()
		{
			if (this.TopMost)
			{
				this.TopMost = false;
				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				showBalloonTip("温馨提示", "已取消置顶");
				Item1.Text = "窗口置顶";
			}
			else
			{
				this.TopMost = true;
				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				showBalloonTip("温馨提示", "已置顶");
				Item1.Text = "取消置顶";
			}
		}

		private void showBalloonTip(String title, String text)
		{
			notifyIcon1.BalloonTipTitle = title;
			notifyIcon1.BalloonTipText = text;
			notifyIcon1.ShowBalloonTip(1000);
		}

		private void resetPages()
		{
			pg2.Dispose();
			pg2 = null;		// Need to set it back to null!
			pg3.Dispose();
			pg3 = null;

			cqIDX = 0;
			bookAndAuthor.Clear();
			TOC.Clear();
			FSLinesScanned = 0;
			extraLinesInBeginning = false;
			extraLinesNotEmpty = false;
			titleLineNumbers.Clear();
			pictureHTMLs.Clear();
			TXTPath = null;
			CoverPath = null;
			CoverPathSlim = null;
			covers[0].Dispose();
			covers[1].Dispose();
			origCover = null;
			coverChanged = true;
			DocName = null;
			Intro = null;
			chapterNumber = 1;
			parchmentNeeded = false;
			embedFontPaths.Clear();
			ALLTITLETEXT.Clear();
			ALLBODYTEXT = new HashSet<Char>();
			IndexT = new List<UInt16>();
			IndexB = new List<UInt16>();
			titleFontPath = null;
			bodyFontPath = null;
			glyphTypefaceT = null;
			glyphTypefaceB = null;
			URIT = null;
			URIB = null;
			wordcount = 0;
			wordcountnr = 0;
			noNeedEmbed = false;
			mimetype = null;
			container = null;
			css.Clear();
			opf.Clear();
			ncx.Clear();
			coverHtml.Clear();
			picHtmlList.Clear();
			txtHtmlList.Clear();
			zipPath = null;
			processedIntro = null;
			stopWatch = null;
			DONE = false;
		}

		#endregion

		#endregion


		#region Multithreading

		private void processTXTWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			processTXT(e.Argument.ToString());
		}

		private void processTXTWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 10)
			{
				clearTOC();
			}
			else if (e.ProgressPercentage == 20)
			{
				pg1.cover_bookname_textbox.Text = bookAndAuthor[0];
				pg1.cover_author_textbox.Text = bookAndAuthor[1];
			}
			else if (e.ProgressPercentage == 40)
			{
				pg1.cover_intro_textbox.Text = Intro;
			}
			else if (e.ProgressPercentage == 60)
			{
				pg1.processedMode();

				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				showBalloonTip("温馨提示", "目录提取完毕！");

				next_button.Enabled = true;
			}
			else if (e.ProgressPercentage == 80)
			{
				//pg2.cover_picturebox.Image = covers[0];

				for (Int32 i = 0; i < TOC.Count; i++)
				{
					DataGridViewRow row = (DataGridViewRow)pg2.TOC_list.Rows[0].Clone();
					row.Cells[0].Value = TOC[i].Item2;
					row.Cells[1].Value = TOC[i].Item1;
					pg2.TOC_list.Rows.Add(row);
				}
			}
		}

		private void processTXTWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			/*for (Int32 i = 0; i < TOC.Count; i++)
			{
				DataGridViewRow row = (DataGridViewRow)pg2.TOC_list.Rows[0].Clone();
				row.Cells[0].Value = TOC[i].Item2;
				row.Cells[1].Value = TOC[i].Item1;
				pg2.TOC_list.Rows.Add(row);
			}*/
			generateTempCovers();
			pg2.cover_picturebox.Image = covers[0];
		}

		private void epubWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			generateEpub();
		}

		private void epubWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 20)
			{
				pg3.stepItem1.Value = 100;
			}
			else if (e.ProgressPercentage == 60)
			{
				pg3.stepItem2.Value = 100;
				pg3.stepItem3.Value = 100;
			}
			else if (e.ProgressPercentage == 80)
			{
				pg3.stepItem4.Value = 100;
			}
			else if (e.ProgressPercentage == 100)
			{
				pg3.stepItem5.Value = 100;
			}
		}

		private void epubWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if (!broken)
			{
				pg3.bookname.Text = bookAndAuthor[0];
				pg3.bookauthor.Text = bookAndAuthor[1];
				pg3.bookintro.Text = processedIntro;
				pg3.bookwordcount.Text = wordcount.ToString();
				pg3.bookwordcountnr.Text = wordcountnr.ToString();
				pg3.location_label.Text = "位置：" + zipPath;
				pg3.time_label.Text = "耗时：" + getProcessTime().ToString() + " 秒";
				pg3.ProcessedMode();
				if (!stsObj.embedFontSubset || URIT == null || URIB == null || noNeedEmbed)
				{
					pg3.stepItem3.Enabled = false;
					pg3.stepItem3.Visible = false;
					pg3.bookwordcount_tile.Enabled = false;
					pg3.bookwordcount_tile.Visible = false;
					pg3.bookwordcount.Enabled = false;
					pg3.bookwordcount.Visible = false;
					pg3.bookwordcount_label.Enabled = false;
					pg3.bookwordcount_label.Visible = false;
					pg3.bookwordcountnr.Enabled = false;
					pg3.bookwordcountnr.Visible = false;
					pg3.bookwordcountnr_label.Enabled = false;
					pg3.bookwordcountnr_label.Visible = false;
					pg3.bookinfo_tile.Size = new Size(432, 213);
					pg3.bookname.MinimumSize = new Size(412, 71);
					pg3.bookname.MaximumSize = new Size(412, 71);
					pg3.bookname.Size = new Size(412, 71);
					pg3.bookauthor.MinimumSize = new Size(412, 71);
					pg3.bookauthor.MaximumSize = new Size(412, 71);
					pg3.bookauthor.Size = new Size(412, 71);
				}

				notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
				showBalloonTip("温馨提示", DocName + ".epub" + "\n已生成完毕！");
			}
			else
			{
				pg3.ProcessFAILEDMode();
				notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
				showBalloonTip("温馨提示", "生成失败！");
			}

			pg3.cover.Image = covers[0];

			/*** Delete temp files ***/
			if (stsObj.deleteTempFiles)
			{
				deleteAllTempFiles();
			}

			DONE = true;
			coverChanged = false;
		}

		#endregion

	}
}
