using System;
using System.Drawing;

namespace SimpleEpub2
{
	public partial class Settings_Page1 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public Settings_Page1(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

			settings1_3_coverfirstpage.ValueChanged += settings1_3_coverfirstpage_ValueChanged;
			settings1_3_StT.ValueChanged += settings1_3_StT_ValueChanged;
			settings1_3_TtS.ValueChanged += settings1_3_TtS_ValueChanged;

            settings1_3_coverfirstpage_label.Text = LANG.getString("settings1_3_coverfirstpage_label");     // 封面作为电子书的第一页
            settings1_3_covernoTOC_label.Text = LANG.getString("settings1_3_covernoTOC_label");     // 第一页的封面不出现在目录里
            settings1_3_vertical_label.Text = LANG.getString("settings1_3_vertical_label");     // 整本书竖排版
            settings1_3_replace_label.Text = LANG.getString("settings1_3_replace_label");       // 替换标题中的数字为汉字
            settings1_3_StT_label.Text = LANG.getString("settings1_3_StT_label");       // 简体转繁体
            settings1_3_TtS_label.Text = LANG.getString("settings1_3_TtS_label");       // 繁体转简体
            settings1_3_embedFontSubset_label.Text = LANG.getString("settings1_3_embedFontSubset_label");       // 嵌入字体（子集）

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
