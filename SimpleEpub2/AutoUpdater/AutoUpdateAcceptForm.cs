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
		/// The update info display form
		/// </summary>
		private AutoUpdateInfoForm updateInfoForm;

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

			this.Text = this.applicationInfo.ApplicationName + " - Update Available";

			// Assigns the icon if it isn't null
			if (this.applicationInfo.ApplicationIcon != null)
				this.Icon = this.applicationInfo.ApplicationIcon;

			// Adds the current version # to the form
			this.lblCurVersion.Text = String.Format("Current Version: {0}", applicationInfo.ApplicationAssembly.GetName().Version);

			// Adds the update version # to the form
			this.lblNewVersion.Text = String.Format("New Version: {0}", this.updateInfo.Version.ToString());
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

		private void btnDetails_Click(object sender, EventArgs e)
		{
			if (this.updateInfoForm == null)
				this.updateInfoForm = new AutoUpdateInfoForm(this.applicationInfo, this.updateInfo);

			// Shows the details form
			this.updateInfoForm.ShowDialog(this);
		}
	}
}
