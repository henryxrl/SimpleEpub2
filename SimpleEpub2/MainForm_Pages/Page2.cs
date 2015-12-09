using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Page2 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public Page2(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

            TOC_list_ChapterTitle.HeaderText = LANG.getString("mainpage2_TOC_list_ChapterTitle");
            TOC_list_LineNumber.HeaderText = LANG.getString("mainpage2_TOC_list_LineNumber");
			
			overlay_cover.BackColor = Color.FromArgb(150, Color.Black);
			overlay_cover.Parent = cover_picturebox;
			overlay_cover.Location = new Point(0, 0);
			overlay_cover.Size = new Size(450, 600);

			overlay_TOC.BackColor = Color.FromArgb(150, Color.Black);
			overlay_TOC.Parent = TOC_list;
			overlay_TOC.Location = new Point(0, 0);
			overlay_TOC.Size = new Size(450, 600);

			overlay_TOC_buttons.BackColor = Color.FromArgb(150, Color.Black);
			overlay_TOC_buttons.Parent = TOC_list;
			overlay_TOC_buttons.Location = new Point(0, 0);
			overlay_TOC_buttons.Size = new Size(450, 600);

			Int32 gap = 25;
			TOC_export.Parent = overlay_TOC_buttons;
            TOC_export.Text = LANG.getString("mainpage2_TOC_export");
			TOC_export.Location = new Point(overlay_TOC_buttons.Width / 2 - TOC_export.Width / 2, overlay_TOC_buttons.Height / 2 - 4 * gap - TOC_export.Height / 2);
			//TOC_export.Click += TOC_export_Click;
			TOC_import.Parent = overlay_TOC_buttons;
            TOC_import.Text = LANG.getString("mainpage2_TOC_import");
			TOC_import.Location = new Point(overlay_TOC_buttons.Width / 2 - TOC_import.Width / 2, overlay_TOC_buttons.Height / 2);
			//TOC_import.Click += TOC_import_Click;
			TOC_clear.Parent = overlay_TOC_buttons;
            TOC_clear.Text = LANG.getString("mainpage2_TOC_clear");
			TOC_clear.Location = new Point(overlay_TOC_buttons.Width / 2 - TOC_clear.Width / 2, overlay_TOC_buttons.Height / 2 + 4 * gap + TOC_clear.Height / 2);
			//TOC_clear.Click += TOC_clear_Click;

			AllowDrop = true;
			TOC_list.AllowDrop = true;
			TOC_list.DragEnter += TOC_list_DragEnter;
			//TOC_list.DragDrop += TOC_list_DragDrop;
			TOC_list.DragLeave += TOC_list_DragLeave;
			TOC_list.DoubleClick += TOC_list_DoubleClick;
			TOC_list.MouseClick += TOC_list_MouseClick;

			((Control)cover_picturebox).AllowDrop = true;
			cover_picturebox.DragEnter += cover_picturebox_DragEnter;
			//cover_picturebox.DragDrop += cover_picturebox_DragDrop;
			cover_picturebox.DragLeave += cover_picturebox_DragLeave;
			//cover_picturebox.DoubleClick += cover_picturebox_DoubleClick;
			cover_picturebox.BackgroundImageLayout = ImageLayout.Stretch;
			cover_picturebox.BackgroundImage = drawBackGroundImage();

			overlay_TOC_buttons.Click += overlay_TOC_buttons_Click;
			overlay_cover.Click += overlay_cover_Click;

			openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			openFileDialog.Multiselect = false;
			openFileDialog.FilterIndex = 1;

			radialMenu1.Symbol = "";
			radialMenu1.SubMenuEdgeWidth = 5;
			radialMenu1.CenterButtonDiameter = 50;
            radialMenu1.Diameter = 210;
			//radialMenu1.ItemClick += RadialMenu1ItemClick;
            Item1.Text = LANG.getString("mainpage2_rm1_item1");     // 导出目录
            Item2.Text = LANG.getString("mainpage2_rm1_item2");     // 清空目录
            Item3.Text = LANG.getString("mainpage2_rm1_item3");     // 导入目录

			radialMenu2.Symbol = "";
			radialMenu2.SubMenuEdgeWidth = 5;
			radialMenu2.CenterButtonDiameter = 50;
            radialMenu2.Diameter = 210;
			//radialMenu2.ItemClick += RadialMenu2ItemClick;
            Item4.Text = LANG.getString("mainpage2_rm2_item1");     // 选中章节升一级
            Item5.Text = LANG.getString("mainpage2_rm2_item2");     // 选中章节降一级

			radialMenu3.Symbol = "";
			radialMenu3.SubMenuEdgeWidth = 5;
			radialMenu3.CenterButtonDiameter = 50;
            radialMenu3.Diameter = 210;
			//radialMenu3.ItemClick += RadialMenu2ItemClick;
            Item6.Text = LANG.getString("mainpage2_rm3_item1");     // 使用自动生成封面
            Item7.Text = LANG.getString("mainpage2_rm3_item2");     // 选择封面图片

			// Set cell font colors
			setCellFontColor(System.Drawing.Color.Black, themeColor);

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
			if (files[0].ToLower().EndsWith(".jpg") || files[0].ToLower().EndsWith(".jpeg"))
			{
				overlay_cover.Hide();
				cover_picturebox.Image = Image.FromFile(files[0]);
			}
			else
			{
				MessageBoxEx.Show("只能拖入JPG文件！");
				overlay_cover.Hide();
			}
		}*/

		private void cover_picturebox_DragLeave(object sender, EventArgs e)
		{
			overlay_cover.Hide();
		}

		/*private void cover_picturebox_DoubleClick(object sender, EventArgs e)
		{
			overlay_cover.Show();

			openFileDialog.Title = "请选择封面图片";
			openFileDialog.Filter = "Image Files|*.jpg";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				MessageBoxEx.Show(openFileDialog.FileName);
			}

			overlay_cover.Hide();
		}*/

		private void TOC_list_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
				overlay_TOC.Show();
			}
			else
				e.Effect = DragDropEffects.None;
		}

		/*private void TOC_list_DragDrop(object sender, DragEventArgs e)
		{
			String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length != 1)
			{
				MessageBoxEx.Show("只能拖入一个文件！");
				overlay_TOC.Hide();
				return;
			}
			if (files[0].ToLower().EndsWith(".txt"))
			{
				overlay_TOC.Hide();
				MessageBoxEx.Show("读取目录");
			}
			else
			{
				MessageBoxEx.Show("只能拖入TXT文件！");
				overlay_TOC.Hide();
			}
		}*/

		private void TOC_list_DragLeave(object sender, EventArgs e)
		{
			overlay_TOC.Hide();
		}

		private void TOC_list_DoubleClick(object sender, EventArgs e)
		{
			overlay_TOC_buttons.Show();
			/*TOC_import.Show();
			TOC_export.Show();
			TOC_clear.Show();*/

			radialMenu1.MenuLocation = new Point(Control.MousePosition.X - radialMenu1.Diameter / 2, Control.MousePosition.Y - radialMenu1.Diameter / 2);
			radialMenu1.IsOpen = true;
		}

		private void TOC_list_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				/*ContextMenu m = new ContextMenu();
				MenuItem i1 = new MenuItem();
				i1.Text = "导出目录";
				i1.Click += TOC_export_Click;
				MenuItem i2 = new MenuItem();
				i2.Text = "导入目录";
				i2.Click += TOC_import_Click;
				MenuItem i3 = new MenuItem();
				i3.Text = "清空目录";
				i3.Click += TOC_clear_Click;
				m.MenuItems.Add(i1);
				m.MenuItems.Add(i2);
				m.MenuItems.Add(i3);
				m.Show(TOC_list, new Point(e.X, e.Y));*/

				if (TOC_list.SelectedRows.Count > 0)
				{
					overlay_TOC_buttons.Show();
					radialMenu2.MenuLocation = new Point(Control.MousePosition.X - radialMenu2.Diameter / 2, Control.MousePosition.Y - radialMenu2.Diameter / 2);
					radialMenu2.IsOpen = true;
				}
				else
				{
					TOC_list_DoubleClick(sender, e);
				}
			}
		}

		private void overlay_TOC_buttons_Click(object sender, EventArgs e)
		{
			overlay_TOC_buttons.Hide();
			/*TOC_import.Hide();
			TOC_export.Hide();
			TOC_clear.Hide();*/

			radialMenu1.IsOpen = false;
			radialMenu2.IsOpen = false;
		}

		private void overlay_cover_Click(object sender, EventArgs e)
		{
			overlay_cover.Hide();
			/*TOC_import.Hide();
			TOC_export.Hide();
			TOC_clear.Hide();*/

			radialMenu3.IsOpen = false;
		}

		/*private void TOC_import_Click(object sender, EventArgs e)
		{
			openFileDialog.Title = "请选择目录文件";
			openFileDialog.Filter = "Text Files|*.txt";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				MessageBoxEx.Show(openFileDialog.FileName);
			}

			overlay_TOC_buttons.Hide();
			TOC_import.Hide();
			TOC_export.Hide();
		}*/

		/*private void TOC_export_Click(object sender, EventArgs e)
		{
			MessageBoxEx.Show("导出目录");

			overlay_TOC_buttons.Hide();
			TOC_import.Hide();
			TOC_export.Hide();
		}*/

		/*private void TOC_clear_Click(object sender, EventArgs e)
		{
			MessageBoxEx.Show("清空目录");

			overlay_TOC_buttons.Hide();
			TOC_import.Hide();
			TOC_export.Hide();
		}*/

		/*private void RadialMenuItemClick(object sender, EventArgs e)
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
						MessageBoxEx.Show(item.Text);
						break;
				}
			}
		}*/

		private Image drawBackGroundImage()
		{
			Image img = new Bitmap(cover_picturebox.Width, cover_picturebox.Height);

			using (Graphics g = Graphics.FromImage(img))
			{
				using (Pen pen = new Pen(themeColor, 5))
				{
					pen.DashStyle = DashStyle.Dash;
					pen.DashPattern = new Single[] { 2f, 2.4f, 2f, 2.4f };

					g.DrawLine(pen, 0, 0, cover_picturebox.Width, 0);
					g.DrawLine(pen, 0, 0, 0, cover_picturebox.Height);
					g.DrawLine(pen, cover_picturebox.Width, cover_picturebox.Height - 1, 0, cover_picturebox.Height - 1);
					g.DrawLine(pen, cover_picturebox.Width - 1, cover_picturebox.Height, cover_picturebox.Width - 1, 0);
				}

				using (SolidBrush b = new SolidBrush(themeColor))
				{
                    String s = LANG.getString("mainpage2_img_string");
                    Font f = new Font("Microsoft YaHei UI", 35, FontStyle.Bold);
					SizeF size = g.MeasureString(s, f);
					Single px = cover_picturebox.Width / 2 - size.Width / 2;
					Single py = cover_picturebox.Height / 2 - size.Height / 2 - 27;
					g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					g.DrawString(s, f, b, px, py);
				}
			}

			return img;
		}

		private void setCellFontColor(System.Drawing.Color a, System.Drawing.Color b)
		{
			TOC_list.Columns[0].DefaultCellStyle.ForeColor = a;
			TOC_list.Columns[1].DefaultCellStyle.ForeColor = b;
		}

	}
}
