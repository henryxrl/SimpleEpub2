using System;
using System.Drawing;

namespace SimpleEpub2
{
	public partial class About : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor = Color.Black;

		public About(Color c)
		{
			InitializeComponent();

			themeColor = c;

			SlideOutButtonVisible = false;

			ok.Click += ok_Click;
			ok.Text = "确定";

			//pictureBox.Image = Image.FromFile(@"D:\Users\Henry\Documents\Visual Studio 2012\Projects\SimpleEpub2\SimpleEpub2\Resources\About.png");
			version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			author.Text = "Henry Xu";
			email.Text = "HenryXrl@Gmail.com";
		}

		private void ok_Click(object sender, EventArgs e)
		{
			this.IsOpen = false;
		}
		
	}
}
