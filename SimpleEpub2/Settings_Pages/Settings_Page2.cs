using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page2 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public Settings_Page2(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

			settings2_3_booknamefont.DrawItem += settings2_3_booknamefont_DrawItem;
			settings2_3_booknamefont.MeasureItem += settings2_3_booknamefont_MeasureItem;
			settings2_3_authornamefont.DrawItem += settings2_3_authornamefont_DrawItem;
			settings2_3_authornamefont.MeasureItem += settings2_3_authornamefont_MeasureItem;

            tabItem1.Text = LANG.getString("settings2_tabItem1");
            tabItem2.Text = LANG.getString("settings2_tabItem2");
            settings2_3_booknamefont_label.Text = LANG.getString("settings2_3_booknamefont_label");
            settings2_3_authornamefont_label.Text = LANG.getString("settings2_3_authornamefont_label");
            settings2_1_pc_label.Text = LANG.getString("settings2_1_pc_label");
            settings2_2_pmU_label.Text = LANG.getString("settings2_2_pmU_label");
            settings2_2_pmD_label.Text = LANG.getString("settings2_2_pmD_label");
            settings2_2_pmL_label.Text = LANG.getString("settings2_2_pmL_label");
            settings2_2_pmR_label.Text = LANG.getString("settings2_2_pmR_label");

		}

		private void settings2_3_booknamefont_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			Font objFonts = new Font(settings2_3_booknamefont.Items[e.Index].ToString(), 14);
			e.ItemHeight = objFonts.Height;
		}

		private void settings2_3_booknamefont_DrawItem(object sender, DrawItemEventArgs e)
		{
			Font objFonts = new Font(settings2_3_booknamefont.Items[e.Index].ToString(), 14);
			e.DrawBackground();

			e.Graphics.DrawString(settings2_3_booknamefont.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
		}

		private void settings2_3_authornamefont_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
		{
			Font objFonts = new Font(settings2_3_authornamefont.Items[e.Index].ToString(), 14);
			e.ItemHeight = objFonts.Height;
		}

		private void settings2_3_authornamefont_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			Font objFonts = new Font(settings2_3_authornamefont.Items[e.Index].ToString(), 14);
			e.DrawBackground();

			e.Graphics.DrawString(settings2_3_authornamefont.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
		}

	}
}
