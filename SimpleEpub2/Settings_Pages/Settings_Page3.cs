using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page3 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public Settings_Page3(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

			settings3_1_tfont.DrawItem += settings3_1_tfont_DrawItem;
			settings3_1_tfont.MeasureItem += settings3_1_tfont_MeasureItem;
			settings3_2_bfont.DrawItem += settings3_2_bfont_DrawItem;
			settings3_2_bfont.MeasureItem += settings3_2_bfont_MeasureItem;
            settings3_3_dropCap.ValueChanged += settings3_3_dropCap_ValueChanged;
            settings3_3_stickupCap.ValueChanged += settings3_3_stickupCap_ValueChanged;

            tabItem3.Text = LANG.getString("settings3_tabItem3");
            tabItem4.Text = LANG.getString("settings3_tabItem4");
            settings3_1_tfont_label.Text = LANG.getString("settings3_1_tfont_label");
            settings3_1_tsize_label.Text = LANG.getString("settings3_1_tsize_label");
            settings3_1_tcolor_label.Text = LANG.getString("settings3_1_tcolor_label");
            settings3_2_bfont_label.Text = LANG.getString("settings3_2_bfont_label");
            settings3_2_bsize_label.Text = LANG.getString("settings3_2_bsize_label");
            settings3_2_bcolor_label.Text = LANG.getString("settings3_2_bcolor_label");
            settings3_3_linespacing_label.Text = LANG.getString("settings3_3_linespacing_label");
            settings3_3_addparagraphspacing_label.Text = LANG.getString("settings3_3_addparagraphspacing_label");
            settings3_3_dropCap_label.Text = LANG.getString("settings3_3_dropCap_label");
            settings3_3_stickupCap_label.Text = LANG.getString("settings3_3_stickupCap_label");

		}

		private void settings3_1_tfont_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			Font objFonts = new Font(settings3_1_tfont.Items[e.Index].ToString(), 14);
			e.ItemHeight = objFonts.Height;
		}

		private void settings3_1_tfont_DrawItem(object sender, DrawItemEventArgs e)
		{
			System.Drawing.Font objFonts = new Font(settings3_1_tfont.Items[e.Index].ToString(), 14);
			e.DrawBackground();

			e.Graphics.DrawString(settings3_1_tfont.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
		}

		private void settings3_2_bfont_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			Font objFonts = new Font(settings3_2_bfont.Items[e.Index].ToString(), 14);
			e.ItemHeight = objFonts.Height;
		}

		private void settings3_2_bfont_DrawItem(object sender, DrawItemEventArgs e)
		{
			System.Drawing.Font objFonts = new Font(settings3_2_bfont.Items[e.Index].ToString(), 14);
			e.DrawBackground();

			e.Graphics.DrawString(settings3_2_bfont.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
		}

        private void settings3_3_dropCap_ValueChanged(object sender, EventArgs e)
        {
            this.settings3_3_stickupCap.Enabled = !this.settings3_3_dropCap.Value;

            if (!this.settings3_3_stickupCap.Enabled)
            {
                this.settings3_3_stickupCap.Value = false;
                this.settings3_3_stickupCap.Enabled = false;
            }
            else
            {
                this.settings3_3_stickupCap.Value = false;
                this.settings3_3_stickupCap.Enabled = true;
            }
        }

        private void settings3_3_stickupCap_ValueChanged(object sender, EventArgs e)
        {
            this.settings3_3_dropCap.Enabled = !this.settings3_3_stickupCap.Value;

            if (!this.settings3_3_dropCap.Enabled)
            {
                this.settings3_3_dropCap.Value = false;
                this.settings3_3_dropCap.Enabled = false;
            }
            else
            {
                this.settings3_3_dropCap.Value = false;
                this.settings3_3_dropCap.Enabled = true;
            }
        }

	}
}
