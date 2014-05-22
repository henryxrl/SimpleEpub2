using System;
using System.Drawing;

namespace SimpleEpub2
{
	public partial class Settings_Page1 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public Settings_Page1(Color c)
		{
			InitializeComponent();

			themeColor = c;

			SlideOutButtonVisible = false;

			settings1_3_coverfirstpage.ValueChanged += settings1_3_coverfirstpage_ValueChanged;
			settings1_3_StT.ValueChanged += settings1_3_StT_ValueChanged;
			settings1_3_TtS.ValueChanged += settings1_3_TtS_ValueChanged;

		}

		private void settings1_3_coverfirstpage_ValueChanged(object sender, EventArgs e)
		{
			this.settings1_3_covernoTOC.Enabled = this.settings1_3_coverfirstpage.Value;

			if (!this.settings1_3_covernoTOC.Enabled)
			{
				this.settings1_3_covernoTOC.Value = false;
			}
			else
			{
				this.settings1_3_covernoTOC.Value = false;
			}
		}

		private void settings1_3_StT_ValueChanged(object sender, EventArgs e)
		{
			this.settings1_3_TtS.Enabled = !this.settings1_3_StT.Value;

			if (!this.settings1_3_TtS.Enabled)
			{
				this.settings1_3_TtS.Value = false;
				this.settings1_3_TtS.Enabled = false;
			}
			else
			{
				this.settings1_3_TtS.Value = false;
				this.settings1_3_TtS.Enabled = true;
			}
		}

		private void settings1_3_TtS_ValueChanged(object sender, EventArgs e)
		{
			this.settings1_3_StT.Enabled = !this.settings1_3_TtS.Value;

			if (!this.settings1_3_StT.Enabled)
			{
				this.settings1_3_StT.Value = false;
				this.settings1_3_StT.Enabled = false;
			}
			else
			{
				this.settings1_3_StT.Value = false;
				this.settings1_3_StT.Enabled = true;
			}
		}

	}
}
