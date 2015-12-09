using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page4 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public Settings_Page4(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

            settings4_1_filelocation_button.Click += settings4_1_filelocation_button_Click;
            settings4_4_language.Items.AddRange(new object[] {"简体中文", "English"});
            settings4_4_language.DrawItem += settings4_4_language_DrawItem;
            settings4_4_language.SelectionChangeCommitted += settings4_4_language_SelectionChangeCommitted;

            settings4_1_filelocation_label.Text = LANG.getString("settings4_1_filelocation_label");
            settings4_1_filelocation_button.Text = LANG.getString("settings4_1_filelocation_button");
            settings4_2_deletetempfiles_label.Text = LANG.getString("settings4_2_deletetempfiles_label");
            settings4_4_chkupd_label.Text = LANG.getString("settings4_4_chkupd_label");
            settings4_4_chkupd_button.Text = LANG.getString("settings4_4_chkupd_button");
            settings4_3_reset_button.Text = LANG.getString("settings4_3_reset_button");
            settings4_1_filelocation_dialog.Description = LANG.getString("settings4_1_filelocation_dialog");
            settings4_4_language_label.Text = LANG.getString("settings4_4_language_label");

            // DPI settings
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
        }

		private void settings4_1_filelocation_button_Click(object sender, EventArgs e)
		{
			if (settings4_1_filelocation_dialog.ShowDialog(this.Parent.Parent) == System.Windows.Forms.DialogResult.OK)
			{
				settings4_1_filelocation.Text = settings4_1_filelocation_dialog.SelectedPath;
			}
		}

        private void settings4_4_language_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font objFonts = new Font(this.Font.Name, 14, FontStyle.Bold);
            e.DrawBackground();

            e.Graphics.DrawString(settings4_4_language.Items[e.Index].ToString(), objFonts, new SolidBrush(e.ForeColor), new Point(e.Bounds.Left, e.Bounds.Top));
        }

        private void settings4_4_language_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.MessageBoxEx.Show(this, LANG.getString("settings4_4_language_changed"));
        }

	}
}
