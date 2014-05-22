using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page3 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public Settings_Page3(Color c)
		{
			InitializeComponent();

			themeColor = c;

			SlideOutButtonVisible = false;

			settings3_1_tfont.DrawItem += settings3_1_tfont_DrawItem;
			settings3_1_tfont.MeasureItem += settings3_1_tfont_MeasureItem;
			settings3_2_bfont.DrawItem += settings3_2_bfont_DrawItem;
			settings3_2_bfont.MeasureItem += settings3_2_bfont_MeasureItem;

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

	}
}
