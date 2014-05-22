using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Page3 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public Page3(Color c)
		{
			InitializeComponent();
			
			themeColor = c;

			SlideOutButtonVisible = false;

			AllowDrop = false;

			cover.BackgroundImage = drawBackGroundImage();

			circularProgress.ProgressColor = themeColor;

			stepItem1.ProgressColors = new Color[] { Color.FromArgb(150, themeColor) };
			stepItem2.ProgressColors = new Color[] { Color.FromArgb(150, themeColor) };
			stepItem3.ProgressColors = new Color[] { Color.FromArgb(150, themeColor) };
			stepItem4.ProgressColors = new Color[] { Color.FromArgb(150, themeColor) };
			stepItem5.ProgressColors = new Color[] { Color.FromArgb(150, themeColor) };

			newbook_button.Text = "➢          下    本    书          ➣";
			newbook_button.FlatStyle = FlatStyle.Flat;
			newbook_button.FlatAppearance.BorderSize = 0;
			newbook_button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 250, 242, 255);
			newbook_button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 198, 174, 213);

			//ProcessingMode();

			//ProcessedMode();
			
		}

		public void ProcessingMode()
		{
			newbook_button.Visible = false;
			FAILED.Visible = false;

			processing_label.Location = new Point(72, 10);
			processing_label.Text = "正在生成……";
			location_label.Visible = false;
			location_label.Text = "";
			time_label.Visible = false;
			time_label.Text = "";

			progressSteps.Location = new Point(79, 90);
			stepItem1.Text = "<font size=\"+2\"><b>加载设置</b></font><br/><font size=\"-1\">加载字体样式、<br/>段落样式等设置</font>";
			stepItem2.Text = "<font size=\"+2\"><b>生成HTML文件</b></font><br/><font size=\"-1\">用正则表达式提取章节<br/>并按章节生成HTML文件</font>";
			stepItem3.Text = "<font size=\"+2\"><b>生成内嵌字体文件</b></font><br/><font size=\"-1\">提取TXT文件的所有字符<br/>生成字体文件的子集</font>";
			stepItem4.Text = "<font size=\"+2\"><b>生成其它文件</b></font><br/><font size=\"-1\">生成图片、CSS、OPF、<br/>NCX、MIMETYPE等文件</font>";
			stepItem5.Text = "<font size=\"+2\"><b>生成EPUB文件</b></font><br/><font size=\"-1\">打包所有文件，<br/>严格按照EPUB规则生成电子书</font>";

			circularProgress.Visible = true;
			circularProgress.IsRunning = true;

			cover.Visible = false;
			bookname_label.Visible = false;
			bookname.Visible = false;
			bookauthor_label.Visible = false;
			bookauthor.Visible = false;
			bookinfo_tile.Visible = false;
			bookwordcount_label.Visible = false;
			bookwordcount.Visible = false;
			bookwordcountnr_label.Visible = false;
			bookwordcountnr.Visible = false;
			bookwordcount_tile.Visible = false;
			bookintro_label.Visible = false;
			bookintro.Visible = false;
			bookintro_tile.Visible = false;
		}

		public void ProcessedMode()
		{
			newbook_button.Visible = true;
			FAILED.Visible = false;
			//this.Size = new Size(841, 605);

			processing_label.Location = new Point(72, 0);
			processing_label.Text = "生成完毕！";
			location_label.Location = new Point(79, 58);
			location_label.Visible = true;
			//location_label.Text = "位置：";
			time_label.Location = new Point(75, 88);
			time_label.Visible = true;
			//time_label.Text = "耗时：";

			progressSteps.Location = new Point(79, 122);
			stepItem1.Text = "<font size=\"+2\"><b>  加载设置  </b></font>";
			stepItem2.Text = "<font size=\"+2\"><b>  生成HTML文件  </b></font>";
			stepItem3.Text = "<font size=\"+2\"><b>  生成内嵌字体文件  </b></font><br/>";
			stepItem4.Text = "<font size=\"+2\"><b>  生成其它文件  </b></font><br/>";
			stepItem5.Text = "<font size=\"+2\"><b>  生成EPUB文件  </b></font><br/>";

			circularProgress.Visible = false;
			circularProgress.IsRunning = false;

			cover.BackgroundImage = null;

			cover.Visible = true;
			bookname_label.Visible = true;
			bookname.Visible = true;
			bookauthor_label.Visible = true;
			bookauthor.Visible = true;
			bookinfo_tile.Visible = true;
			bookwordcount_label.Visible = true;
			bookwordcount.Visible = true;
			bookwordcountnr_label.Visible = true;
			bookwordcountnr.Visible = true;
			bookwordcount_tile.Visible = true;
			bookintro_label.Visible = true;
			bookintro.Visible = true;
			bookintro_tile.Visible = true;

			bookname_label.ForeColor = Color.White;
			bookname.ForeColor = Color.White;
			bookauthor_label.ForeColor = Color.White;
			bookauthor.ForeColor = Color.White;
			bookinfo_tile.ForeColor = Color.White;
			bookwordcount_label.ForeColor = Color.White;
			bookwordcount.ForeColor = Color.White;
			bookwordcountnr_label.ForeColor = Color.White;
			bookwordcountnr.ForeColor = Color.White;
			bookwordcount_tile.ForeColor = Color.White;
			bookintro_label.ForeColor = Color.White;
			bookintro.ForeColor = Color.White;
			bookintro_tile.ForeColor = Color.White;
			
			bookname_label.BackColor = themeColor;
			bookname.BackColor = themeColor;
			bookauthor_label.BackColor = themeColor;
			bookauthor.BackColor = themeColor;
			bookinfo_tile.BackColor = themeColor;
			bookwordcount_label.BackColor = themeColor;
			bookwordcount.BackColor = themeColor;
			bookwordcountnr_label.BackColor = themeColor;
			bookwordcountnr.BackColor = themeColor;
			bookwordcount_tile.BackColor = themeColor;
			bookintro_label.BackColor = themeColor;
			bookintro.BackColor = themeColor;
			bookintro_tile.BackColor = themeColor;
		}

		public void ProcessFAILEDMode()
		{
			newbook_button.Visible = true;
			FAILED.Visible = true;

			processing_label.Location = new Point(72, 10);
			processing_label.Text = "生成失败！！";
			location_label.Visible = false;
			location_label.Text = "";
			time_label.Visible = false;
			time_label.Text = "";

			progressSteps.Enabled = false;
			progressSteps.Visible = false;

			circularProgress.Visible = false;
			circularProgress.IsRunning = false;

			cover.Visible = false;
			bookname_label.Visible = false;
			bookname.Visible = false;
			bookauthor_label.Visible = false;
			bookauthor.Visible = false;
			bookinfo_tile.Visible = false;
			bookwordcount_label.Visible = false;
			bookwordcount.Visible = false;
			bookwordcountnr_label.Visible = false;
			bookwordcountnr.Visible = false;
			bookwordcount_tile.Visible = false;
			bookintro_label.Visible = false;
			bookintro.Visible = false;
			bookintro_tile.Visible = false;
		}

		private Image drawBackGroundImage()
		{
			Image img = new Bitmap(cover.Width, cover.Height);

			using (Graphics g = Graphics.FromImage(img))
			{
				using (Pen pen = new Pen(themeColor, 5))
				{
					pen.DashStyle = DashStyle.Dash;
					pen.DashPattern = new Single[] { 2f, 2.2f, 2f, 2.2f };

					g.DrawLine(pen, 0, 0, cover.Width, 0);
					g.DrawLine(pen, 0, 0, 0, cover.Height);
					g.DrawLine(pen, cover.Width, cover.Height - 1, 0, cover.Height - 1);
					g.DrawLine(pen, cover.Width - 1, cover.Height, cover.Width - 1, 0);
				}

				using (SolidBrush b = new SolidBrush(themeColor))
				{
					String s = "封面图片";
					Font f = new Font("微软雅黑", 25, FontStyle.Bold);
					SizeF size = g.MeasureString(s, f);
					Single px = cover.Width / 2 - size.Width / 2;
					Single py = cover.Height / 2 - size.Height / 2 - 20;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);
				}
			}

			return img;
		}
	}
}
