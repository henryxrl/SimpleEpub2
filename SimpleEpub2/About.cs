using System;
using System.Drawing;

namespace SimpleEpub2
{
	public partial class About : DevComponents.DotNetBar.Controls.SlidePanel
	{
		Color themeColor;
        Language LANG;

		public About(Color c, Language lang)
		{
			InitializeComponent();

			themeColor = c;
            LANG = lang;

			SlideOutButtonVisible = false;

			ok.Click += ok_Click;
			ok.Text = LANG.getString("button_ok");

			//pictureBox.Image = Image.FromFile(@"D:\Users\Henry\Documents\Visual Studio 2012\Projects\SimpleEpub2\SimpleEpub2\Resources\About.png");
			version.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			author.Text = "Henry Xu";
			email.Text = "HenryXrl@Gmail.com";
            intro.Text = String.Format(LANG.getString("about_intro"), Environment.NewLine);

            version_label.ForeColor = themeColor;
            author_label.ForeColor = themeColor;
            email_label.ForeColor = themeColor;
            intro_label.ForeColor = themeColor;

            version_label.Text = LANG.getString("about_version_label");
            author_label.Text = LANG.getString("about_author_label");
            email_label.Text = LANG.getString("about_email_label");
            intro_label.Text = LANG.getString("about_intro_label");

            // DPI settings
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            // Set UI Font according to language
            LANG.setFont(this.Controls);
            Font = new Font(LANG.getFont(), Font.Size, Font.Style);
        }

		private void ok_Click(object sender, EventArgs e)
		{
			this.IsOpen = false;
		}
		
	}
}
