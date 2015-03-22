using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings : DevComponents.DotNetBar.Controls.SlidePanel
	{
		protected internal Settings_Page1 pg1;
		protected internal Settings_Page2 pg2;
		protected internal Settings_Page3 pg3;
		protected internal Settings_Page4 pg4;

		//private DevComponents.DotNetBar.Controls.SlidePanel[] cq = null;
		private Int32 cqIDX = 0;

		Color themeColor;
        Language LANG;

		public Settings(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

            settings_done_button.Text = LANG.getString("settings_settings_done_button");
			settings_done_button.FlatStyle = FlatStyle.Flat;
			settings_done_button.FlatAppearance.BorderSize = 0;
			settings_done_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 250, 242, 255);
			settings_done_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 198, 174, 213);
			settings_done_button.Click += settings_done_button_Click;

			superTabItem1.Click += superTabItem1_Click;
			superTabItem2.Click += superTabItem2_Click;
			superTabItem3.Click += superTabItem3_Click;
			superTabItem4.Click += superTabItem4_Click;

            superTabItem1.Text = LANG.getString("settings_item1");
            superTabItem2.Text = LANG.getString("settings_item2");
            superTabItem3.Text = LANG.getString("settings_item3");
            superTabItem4.Text = LANG.getString("settings_item4");


			SuspendLayout();

			Size = new Size(950, 650);
			pageSlider1.SelectedPageIndex = 0;

			// Page 1
            pg1 = new Settings_Page1(themeColor, LANG);
			pg1.IsOpen = true;
			pg1.SetBounds(-12, 0, 742, 595);
			pg1.Parent = this;
			pageSliderPage1.Controls.Add(pg1);

			// Page 2
            pg2 = new Settings_Page2(themeColor, LANG);
			pg2.IsOpen = true;
			pg2.SetBounds(-12, 0, 742, 595);
			pg2.Parent = this;
			pageSliderPage2.Controls.Add(pg2);

			// Page 3
            pg3 = new Settings_Page3(themeColor, LANG);
			pg3.IsOpen = true;
			pg3.SetBounds(-12, 0, 742, 595);
			pg3.Parent = this;
			pageSliderPage3.Controls.Add(pg3);

			// Page 4
            pg4 = new Settings_Page4(themeColor, LANG);
			pg4.IsOpen = true;
			pg4.SetBounds(-12, 0, 742, 595);
			pg4.Parent = this;
			pageSliderPage4.Controls.Add(pg4);

			ResumeLayout(false);


			// Fill font combobox
			InstalledFontCollection installedFontCollection = new InstalledFontCollection();
			FontFamily[] fontFamilies = installedFontCollection.Families;

			for (Int32 i = 0; i < fontFamilies.Length; i++)
			{
				String fontName = fontFamilies[i].Name.ToString();

				Regex r = new Regex(@"[\u4e00-\u9fa5]+");       // Chinese fonts only
				Match mc = r.Match(fontName);
				if (mc.Length != 0 && !fontName.Contains("Adobe"))
				{
					pg2.settings2_3_booknamefont.Items.Add(fontName);
					pg2.settings2_3_authornamefont.Items.Add(fontName);
					pg3.settings3_1_tfont.Items.Add(fontName);
					pg3.settings3_2_bfont.Items.Add(fontName);
				}
			}

		}

		private void superTabItem1_Click(object sender, EventArgs e)
		{
			cqIDX = 0;
			pageSlider1.SelectedPageIndex = cqIDX;
		}

		private void superTabItem2_Click(object sender, EventArgs e)
		{
			cqIDX = 1;
			pageSlider1.SelectedPageIndex = cqIDX;
		}

		private void superTabItem3_Click(object sender, EventArgs e)
		{
			cqIDX = 2;
			pageSlider1.SelectedPageIndex = cqIDX;
		}

		private void superTabItem4_Click(object sender, EventArgs e)
		{
			cqIDX = 3;
			pageSlider1.SelectedPageIndex = cqIDX;
		}

		private void settings_done_button_Click(object sender, EventArgs e)
		{
			this.IsOpen = false;

			ToastNotification.CustomGlowColor = themeColor;
			ToastNotification.ToastBackColor = themeColor;
            ToastNotification.Show(this.Parent, LANG.getString("settings_settings_success"),
                null, 3000, eToastGlowColor.Custom, 428, 615);
		}
	}
}
