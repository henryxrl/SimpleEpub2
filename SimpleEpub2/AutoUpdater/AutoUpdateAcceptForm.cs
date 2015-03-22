using System;
using System.Windows.Forms;

namespace SimpleEpub2.AutoUpdater
{
	/// <summary>
	/// Form to prompt the user to accept the update
	/// </summary>
	internal partial class AutoUpdateAcceptForm : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// The program to update's info
		/// </summary>
		private AutoUpdatable applicationInfo;

		/// <summary>
		/// The update info from the update.xml
		/// </summary>
		private AutoUpdateXml updateInfo;

        /// <summary>
        /// The program to update's langCode
        /// </summary>
        private Language lang;

		/// <summary>
		/// Creates a new AutoUpdateAcceptForm
		/// </summary>
		/// <param name="applicationInfo"></param>
		/// <param name="updateInfo"></param>
		internal AutoUpdateAcceptForm(AutoUpdatable applicationInfo, AutoUpdateXml updateInfo)
		{
			InitializeComponent();

			this.applicationInfo = applicationInfo;
			this.updateInfo = updateInfo;
            this.lang = applicationInfo.Lang;

			this.Text = lang.getString("update_found_title");

            this.lblAppName.Text = this.applicationInfo.ApplicationName;
            this.lblUpdateAvail.Text = lang.getString("update_found");
            this.lblNewVersion_label.Text = lang.getString("update_new");
            this.lblCurVersion_label.Text = lang.getString("update_cur");
            this.lblDescription.Text = lang.getString("update_description");

            this.btnYes.Text = lang.getString("button_ok");
            this.btnNo.Text = lang.getString("button_cancel");

			// Assigns the icon if it isn't null
			if (this.applicationInfo.ApplicationIcon != null)
				this.Icon = this.applicationInfo.ApplicationIcon;

			// Adds the current version # to the form
			this.lblCurVersion.Text = applicationInfo.ApplicationAssembly.GetName().Version.ToString();

			// Adds the update version # to the form
			this.lblNewVersion.Text = this.updateInfo.Version.ToString();

			// Fill in update info
			this.txtDescription.Text = updateInfo.Description;
		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.No;
			this.Close();
		}

		private void txtDescription_KeyDown(object sender, KeyEventArgs e)
		{
			// Only allow Cntrl - C to copy text
			if (!(e.Control && e.KeyCode == Keys.C))
				e.SuppressKeyPress = true;
		}
	}
}
