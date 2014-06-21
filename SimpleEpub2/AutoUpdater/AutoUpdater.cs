using DevComponents.DotNetBar;
using SimpleEpub2.Tools;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SimpleEpub2.AutoUpdater
{
	/// <summary>
	/// Provides application update support in C#
	/// </summary>
	public class AutoUpdater
	{
		/// <summary>
		/// Holds the program-to-update's info
		/// </summary>
		private AutoUpdatable applicationInfo;

		/// <summary>
		/// Thread to find update
		/// </summary>
		private BackgroundWorker bgWorker;

		private Boolean autoCheck;

		/// <summary>
		/// Creates a new AutoUpdater object
		/// </summary>
		/// <param name="applicationName">The name of the application so it can be displayed on dialog boxes to user</param>
		/// <param name="appId">A unique Id for the application, same as in update xml</param>
		/// <param name="updateXmlLocation">The Uri for the program's update.xml</param>
		public AutoUpdater(AutoUpdatable applicationInfo)
		{
			this.applicationInfo = applicationInfo;

			// Set up backgroundworker
			this.bgWorker = new BackgroundWorker();
			this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
			this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
		}

		/// <summary>
		/// Checks for an update for the program passed.
		/// If there is an update, a dialog asking to download will appear
		/// </summary>
		public void DoUpdate(Boolean auto)
		{
			autoCheck = auto;

			if (!this.bgWorker.IsBusy)
				this.bgWorker.RunWorkerAsync(this.applicationInfo);
		}

		/// <summary>
		/// Checks for/parses update.xml on server
		/// </summary>
		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			AutoUpdatable application = (AutoUpdatable)e.Argument;

			// Check for update on server
			if (!AutoUpdateXml.ExistsOnServer(application.UpdateXmlLocation))
				e.Cancel = true;
			else // Parse update xml
				e.Result = AutoUpdateXml.Parse(application.UpdateXmlLocation, application.ApplicationID);
		}

		/// <summary>
		/// After the background worker is done, prompt to update if there is one
		/// </summary>
		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// If there is a file on the server
			if (!e.Cancelled)
			{
				AutoUpdateXml update = (AutoUpdateXml)e.Result;

				// Check if the update is not null and is a newer version than the current application
				if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
				{
					// Ask to accept the update
					if (new AutoUpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.Context) == DialogResult.Yes)
						this.DownloadUpdate(update); // Do the update
				}
				else
				{
					if (!autoCheck)
						MessageBoxEx.Show(this.applicationInfo.Context, "已经是最新版本！");
				}
			}
			else
				MessageBoxEx.Show(this.applicationInfo.Context, "没有找到更新信息！");
		}

		/// <summary>
		/// Downloads update and installs the update
		/// </summary>
		/// <param name="update">The update xml info</param>
		private void DownloadUpdate(AutoUpdateXml update)
		{
			AutoUpdateDownloadForm form = new AutoUpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
			DialogResult result = form.ShowDialog(this.applicationInfo.Context);

			// Download update
			if (result == DialogResult.OK)
			{
				String currentPath = this.applicationInfo.ApplicationAssembly.Location;
				String newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;

				// "Install" it
				AutoClosingMessageBox.Show(this.applicationInfo.Context, "更新成功！\n程序5秒后即将自动重启！", "更新成功", 5000);
				UpdateApplication(form.TempFilePath, currentPath, newPath, update.LaunchArgs);

				Application.Exit();
			}
			else if (result == DialogResult.Abort)
			{
				MessageBoxEx.Show(this.applicationInfo.Context, "更新过程被中断！\n无法完成更新！", "更新中断", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBoxEx.Show(this.applicationInfo.Context, "更新出错！\n请稍后再试一次！", "更新出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/// <summary>
		/// Hack to close program, delete original, move the new one to that location
		/// </summary>
		/// <param name="tempFilePath">The temporary file's path</param>
		/// <param name="currentPath">The path of the current application</param>
		/// <param name="newPath">The new path for the new file</param>
		/// <param name="launchArgs">The launch arguments</param>
		private void UpdateApplication(String tempFilePath, String currentPath, String newPath, String launchArgs)
		{
			String argument = "/C choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";

			ProcessStartInfo Info = new ProcessStartInfo();
			Info.Arguments = String.Format(argument, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
			Info.WindowStyle = ProcessWindowStyle.Hidden;
			Info.CreateNoWindow = true;
			Info.FileName = "cmd.exe";
			Process.Start(Info);
		}
	}
}
