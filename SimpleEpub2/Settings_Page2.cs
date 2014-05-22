using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page2 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public Settings_Page2(Color c)
		{
			InitializeComponent();

			themeColor = c;

			SlideOutButtonVisible = false;

			settings2_3_booknamefont.DrawItem += settings2_3_booknamefont_DrawItem;
			settings2_3_booknamefont.MeasureItem += settings2_3_booknamefont_MeasureItem;
			settings2_3_authornamefont.DrawItem += settings2_3_authornamefont_DrawItem;
			settings2_3_authornamefont.MeasureItem += settings2_3_authornamefont_MeasureItem;

		}

		private void settings2_3_booknamefont_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			Font objFonts = new Font(settings2_3_booknamefont.Items[e.Index].ToString(), 14);
			e.ItemHeight = objFonts.Height;
		}

		private void settings2_3_booknamefont_DrawItem(object sender, DrawItemEventArgs e)
		{
			System.Drawing.Font objFonts = new Font(settings2_3_booknamefont.Items[e.Index].ToString(), 14);
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
			System.Drawing.Font objFonts = new Font(settings2_3_authornamefont.Items[e.Index].ToString(), 14);
			e.DrawBackground();

			e.Graphics.DrawString(settings2_3_authornamefont.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
		}

	}
}
