using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleEpub2
{
	public partial class Settings_Page4 : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public Settings_Page4(Color c)
		{
			InitializeComponent();

			themeColor = c;

			SlideOutButtonVisible = false;

            settings4_1_filelocation_button.Click += settings4_1_filelocation_button_Click;
		}

		private void settings4_1_filelocation_button_Click(object sender, EventArgs e)
		{
			if (settings4_1_filelocation_dialog.ShowDialog(this.Parent.Parent) == System.Windows.Forms.DialogResult.OK)
			{
				settings4_1_filelocation.Text = settings4_1_filelocation_dialog.SelectedPath;
			}
		}

		
	}
}
