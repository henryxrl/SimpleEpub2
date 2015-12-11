using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Page1 : DevComponents.DotNetBar.Controls.SlidePanel
	{
        private Color themeColor;
        private Language LANG;
        private Tuple<Single, Single> DPI;

        public Page1(Color c, Language lang, Tuple<Single, Single> dpi)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;
            DPI = dpi;

			SlideOutButtonVisible = false;

			AllowDrop = true;
			
			overlay_cover.BackColor = Color.FromArgb(150, Color.Black);
			overlay_cover.Parent = txt_picturebox;
			overlay_cover.Location = new Point(0, 0);
			overlay_cover.Size = new Size(600, 600);

			((Control)txt_picturebox).AllowDrop = true;
			txt_picturebox.DragEnter += cover_picturebox_DragEnter;
			//cover_picturebox.DragDrop += cover_picturebox_DragDrop;
			txt_picturebox.DragLeave += cover_picturebox_DragLeave;
			//cover_picturebox.DoubleClick += cover_picturebox_DoubleClick;
			//txt_picturebox.BackgroundImage = drawBackGroundImage();

			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			openFileDialog.Multiselect = false;
			openFileDialog.FilterIndex = 1;

			cover_bookname_tile.BackColor = themeColor;
			cover_bookname_label.Parent = cover_bookname_tile;
            cover_bookname_label.Text = LANG.getString("mainpage1_cover_bookname_label");
			cover_bookname_label.ForeColor = Color.White;
			cover_bookname_label.Location = new Point(5, 2);
			cover_bookname_label.Size = new Size(100, 30);
			//cover_bookname_textbox.Parent = cover_bookname_tile;		// If this is set, cannot input Chinese
			cover_bookname_textbox.Multiline = true;
			cover_bookname_textbox.BorderStyle = BorderStyle.None;
			cover_bookname_textbox.BackColor = themeColor;
			cover_bookname_textbox.ForeColor = Color.White;
			cover_bookname_textbox.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
			cover_bookname_textbox.Location = new Point(626, 32);
			cover_bookname_textbox.Size = new Size(287, 107);
			cover_bookname_textbox.MouseLeave += cover_bookname_textbox_MouseLeave;

			cover_author_tile.BackColor = themeColor;
			cover_author_label.Parent = cover_author_tile;
            cover_author_label.Text = LANG.getString("mainpage1_cover_author_label");
			cover_author_label.ForeColor = Color.White;
			cover_author_label.Location = new Point(5, 2);
			cover_author_label.Size = new Size(100, 30);
			//cover_author_textbox.Parent = cover_author_tile;
			cover_author_textbox.Multiline = true;
			cover_author_textbox.BorderStyle = BorderStyle.None;
			cover_author_textbox.BackColor = themeColor;
			cover_author_textbox.ForeColor = Color.White;
			cover_author_textbox.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
			cover_author_textbox.Location = new Point(626, 183);
			cover_author_textbox.Size = new Size(287, 107);
			cover_author_textbox.MouseLeave += cover_author_textbox_MouseLeave;

			cover_intro_tile.BackColor = themeColor;
			cover_intro_label.Parent = cover_intro_tile;
            cover_intro_label.Text = LANG.getString("mainpage1_cover_intro_label");
			cover_intro_label.ForeColor = Color.White;
			cover_intro_label.Location = new Point(5, 2);
			cover_intro_label.Size = new Size(100, 30);
			//cover_intro_textbox.Parent = cover_intro_tile;
			cover_intro_textbox.Multiline = true;
			cover_intro_textbox.BorderStyle = BorderStyle.None;
			cover_intro_textbox.BackColor = themeColor;
			cover_intro_textbox.ForeColor = Color.White;
			cover_intro_textbox.Font = new Font("Microsoft YaHei UI", 10, FontStyle.Bold);
			cover_intro_textbox.Location = new Point(626, 334);
			cover_intro_textbox.Size = new Size(287, 261);
			cover_intro_textbox.MouseLeave += cover_intro_textbox_MouseLeave;

			circularProgress.ProgressColor = themeColor;

            // DPI settings
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        private void cover_picturebox_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
				overlay_cover.Show();
			}
			else
				e.Effect = DragDropEffects.None;
		}

		/*private void cover_picturebox_DragDrop(object sender, DragEventArgs e)
		{
			String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBoxEx.Show("只能拖入一个文件！");
				overlay_cover.Hide();
				return;
			}
			if (!files[0].ToLower().EndsWith(".txt"))
			{
				MessageBoxEx.Show("只能拖入TXT文件！");
				overlay_cover.Hide();
			}
			else
			{
				overlay_cover.Hide();
				MessageBoxEx.Show(files[0]);

				TXTPath = files[0];

				// Get file name
				String filename = Path.GetFileNameWithoutExtension(TXTPath);

				// Get book name and author info to fill the first two rows of TOC_list
				bookAndAuthor = getBookNameAndAuthorInfo(TXTPath, filename);

				// Fill author and bookname textboxes on the right side
				cover_bookname_textbox.Text = bookAndAuthor[0];
				cover_author_textbox.Text = bookAndAuthor[1];

				// Fill intro textbox on the right side
				Intro = getIntroInfo(TXTPath);
				if (Intro.Contains("\n"))
					Intro = Intro.Replace("\n", "\r\n");
				cover_intro_textbox.Text = Intro;
			}
		}*/

		private void cover_picturebox_DragLeave(object sender, EventArgs e)
		{
			overlay_cover.Hide();
		}

		/*private void cover_picturebox_DoubleClick(object sender, EventArgs e)
		{
			overlay_cover.Show();

			openFileDialog.Title = "请选择TXT文件";
			openFileDialog.Filter = "Text Files|*.txt";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				MessageBoxEx.Show(openFileDialog.FileName);
			}

			overlay_cover.Hide();
		}*/

		private void cover_bookname_textbox_MouseLeave(object sender, EventArgs e)
		{
			cover_bookname_label.Focus();
		}

		private void cover_author_textbox_MouseLeave(object sender, EventArgs e)
		{
			cover_author_label.Focus();
		}

		private void cover_intro_textbox_MouseLeave(object sender, EventArgs e)
		{
			cover_intro_label.Focus();
		}
		
		private Image drawBackGroundImage()
		{
			Image img = new Bitmap(txt_picturebox.Width, txt_picturebox.Height);

			using (Graphics g = Graphics.FromImage(img))
			{
				using (Pen pen = new Pen(themeColor, 5))
				{
					pen.DashStyle = DashStyle.Dash;
					pen.DashPattern = new Single[] { 2f, 2.37f, 2f, 2.37f };

					g.DrawLine(pen, 0, 0, txt_picturebox.Width, 0);
					g.DrawLine(pen, 0, 0, 0, txt_picturebox.Height);
					g.DrawLine(pen, txt_picturebox.Width, txt_picturebox.Height - 1, 0, txt_picturebox.Height - 1);
					g.DrawLine(pen, txt_picturebox.Width - 1, txt_picturebox.Height, txt_picturebox.Width - 1, 0);
				}

				using (SolidBrush b = new SolidBrush(themeColor))
				{
                    String s = LANG.getString("mainpage1_img1_string1");
					Font f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					SizeF size = g.MeasureString(s, f);
					Single px = txt_picturebox.Width / 2 - size.Width / 2;
					Single py = txt_picturebox.Height / 2 - size.Height / 2 - 50 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);

                    s = LANG.getString("mainpage1_img1_string2");
					f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					size = g.MeasureString(s, f);
					px = txt_picturebox.Width / 2 - size.Width / 2;
					py = txt_picturebox.Height / 2 - size.Height / 2 + 10 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);
				}
			}

			return img;
		}

		private Image drawBackGroundImage2()
		{
			Image img = new Bitmap(txt_picturebox.Width, txt_picturebox.Height);

			using (Graphics g = Graphics.FromImage(img))
			{
				using (Pen pen = new Pen(themeColor, 5))
				{
					pen.DashStyle = DashStyle.Dash;
					pen.DashPattern = new Single[] { 2f, 2.37f, 2f, 2.37f };

					g.DrawLine(pen, 0, 0, txt_picturebox.Width, 0);
					g.DrawLine(pen, 0, 0, 0, txt_picturebox.Height);
					g.DrawLine(pen, txt_picturebox.Width, txt_picturebox.Height - 1, 0, txt_picturebox.Height - 1);
					g.DrawLine(pen, txt_picturebox.Width - 1, txt_picturebox.Height, txt_picturebox.Width - 1, 0);
				}

				using (SolidBrush b = new SolidBrush(themeColor))
				{
                    String s = LANG.getString("mainpage1_img2_string1");
					Font f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					SizeF size = g.MeasureString(s, f);
					Single px = txt_picturebox.Width / 2 - size.Width / 2;
					Single py = txt_picturebox.Height / 2 - size.Height / 2 - 180 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);

                    s = LANG.getString("mainpage1_img2_string2");
					f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					size = g.MeasureString(s, f);
					px = txt_picturebox.Width / 2 - size.Width / 2;
					py = txt_picturebox.Height / 2 - size.Height / 2 - 110 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);
				}
			}

			return img;
		}

		private Image drawBackGroundImage3()
		{
			Image img = new Bitmap(txt_picturebox.Width, txt_picturebox.Height);

			using (Graphics g = Graphics.FromImage(img))
			{
				using (Pen pen = new Pen(themeColor, 5))
				{
					pen.DashStyle = DashStyle.Dash;
					pen.DashPattern = new Single[] { 2f, 2.37f, 2f, 2.37f };

					g.DrawLine(pen, 0, 0, txt_picturebox.Width, 0);
					g.DrawLine(pen, 0, 0, 0, txt_picturebox.Height);
					g.DrawLine(pen, txt_picturebox.Width, txt_picturebox.Height - 1, 0, txt_picturebox.Height - 1);
					g.DrawLine(pen, txt_picturebox.Width - 1, txt_picturebox.Height, txt_picturebox.Width - 1, 0);
				}

				using (SolidBrush b = new SolidBrush(themeColor))
				{
					String s = "✔";
					Font f = new Font("Microsoft YaHei UI", 50, FontStyle.Bold);
					SizeF size = g.MeasureString(s, f);
					Single px = txt_picturebox.Width / 2 - size.Width / 2;
					Single py = txt_picturebox.Height / 2 - size.Height / 2 - 180 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);

                    s = LANG.getString("mainpage1_img3_string1");
					f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					size = g.MeasureString(s, f);
					px = txt_picturebox.Width / 2 - size.Width / 2;
					py = txt_picturebox.Height / 2 - size.Height / 2 - 110 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);

                    s = LANG.getString("mainpage1_img1_string1");
					f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					size = g.MeasureString(s, f);
					px = txt_picturebox.Width / 2 - size.Width / 2;
					py = txt_picturebox.Height / 2 - size.Height / 2 - 10 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);

                    s = LANG.getString("mainpage1_img1_string2");
					f = new Font("Microsoft YaHei UI", 25, FontStyle.Bold);
					size = g.MeasureString(s, f);
					px = txt_picturebox.Width / 2 - size.Width / 2;
					py = txt_picturebox.Height / 2 - size.Height / 2 + 50 * DPI.Item2 / 96f;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);
				}
			}

			return img;
		}

		public void preProcessMode()
		{
			txt_picturebox.BackgroundImage = drawBackGroundImage();

			circularProgress.Visible = false;
			circularProgress.IsRunning = false;
		}

		public void processingMode()
		{
			txt_picturebox.BackgroundImage = drawBackGroundImage2();

			circularProgress.Visible = true;
			circularProgress.IsRunning = true;
		}

		public void processedMode()
		{
			txt_picturebox.BackgroundImage = drawBackGroundImage3();

			circularProgress.Visible = false;
			circularProgress.IsRunning = false;
		}

	}
}
