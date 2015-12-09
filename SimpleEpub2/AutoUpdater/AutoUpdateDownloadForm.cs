using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SimpleEpub2.AutoUpdater
{
	/// <summary>
	/// Form that download the update
	/// </summary>
	internal partial class AutoUpdateDownloadForm : DevComponents.DotNetBar.Metro.MetroForm
	{
        /// <summary>
        /// The program to update's info
        /// </summary>
        private AutoUpdatable applicationInfo;

        /// <summary>
        /// The program to update's langCode
        /// </summary>
        private Language lang;

		/// <summary>
		/// The web client to download the update
		/// </summary>
		private WebClient webClient;

		/// <summary>
		/// The thread to hash the file on
		/// </summary>
		private BackgroundWorker bgWorker;

		/// <summary>
		/// A temp file name to download to
		/// </summary>
		private String tempFile;

		/// <summary>
		/// The MD5 hash of the file to download
		/// </summary>
		private String md5;

		/// <summary>
		/// Gets the temp file path for the downloaded file
		/// </summary>
		internal String TempFilePath
		{
			get { return this.tempFile; }
		}

		/// <summary>
		/// Creates a new AutoUpdateDownloadForm
		/// </summary>
        internal AutoUpdateDownloadForm(AutoUpdatable applicationInfo, Uri location, String md5, Icon programIcon)
		{
			InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.lang = applicationInfo.Lang;

			if (programIcon != null)
				this.Icon = programIcon;

            this.Text = applicationInfo.ApplicationName + " - " + lang.getString("update_download");

            this.lblDownloading.Text = lang.getString("update_downloading");

			// Set the temp file name and create new 0-byte file
			tempFile = Path.GetTempFileName();

			this.md5 = md5;

			// Set up WebClient to download file
			webClient = new WebClient();
			webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
			webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);

			// Set up backgroundworker to hash file
			bgWorker = new BackgroundWorker();
			bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
			bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

			// Download file
			try { webClient.DownloadFileAsync(location, this.tempFile); }
			catch { this.DialogResult = DialogResult.No; this.Close(); }

            // DPI settings
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
        }

		/// <summary>
		/// Downloads file from server
		/// </summary>
		private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			// Update progressbar on download
			this.lblPercentage.Text = String.Format(lang.getString("update_completed") + " {0}", FormatPercentage(e.BytesReceived, e.TotalBytesToReceive, 0));
            this.lblProgress.Text = String.Format(lang.getString("update_downloaded") + " {0} / {1}", FormatBytes(e.BytesReceived, 1, true), FormatBytes(e.TotalBytesToReceive, 1, true));
			this.progressBar.Value = e.ProgressPercentage;
		}

		private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				this.DialogResult = DialogResult.No;
				this.Close();
			}
			else if (e.Cancelled)
			{
				this.DialogResult = DialogResult.Abort;
				this.Close();
			}
			else
			{
				// Show the "Hashing" label and set the progressbar to marquee
                this.lblProgress.Text = lang.getString("update_verifying");

				// Start the hashing
				bgWorker.RunWorkerAsync(new String[] { this.tempFile, this.md5 });
			}
		}

		private String FormatPercentage(Int64 bytes1, Int64 bytes2, Int32 decimalPlaces)
		{
			Double newBytes1 = bytes1;
			Double newBytes2 = bytes2;

			return (newBytes1 / newBytes2).ToString("P" + decimalPlaces);
		}

		/// <summary>
		/// Formats the byte count to closest byte type
		/// </summary>
		/// <param name="bytes">The amount of bytes</param>
		/// <param name="decimalPlaces">How many decimal places to show</param>
		/// <param name="showByteType">Add the byte type on the end of the string</param>
		/// <returns>The bytes formatted as specified</returns>
		private String FormatBytes(Int64 bytes, Int32 decimalPlaces, Boolean showByteType)
		{
			Double newBytes = bytes;
			String formatString = "{0";
			String byteType = "B";

			// Check if best size in KB
			if (newBytes > 1024 && newBytes < 1048576)
			{
				newBytes /= 1024;
				byteType = "KB";
			}
			else if (newBytes > 1048576 && newBytes < 1073741824)
			{
				// Check if best size in MB
				newBytes /= 1048576;
				byteType = "MB";
			}
			else
			{
				// Best size in GB
				newBytes /= 1073741824;
				byteType = "GB";
			}

			// Show decimals
			if (decimalPlaces > 0)
				formatString += ":0.";

			// Add decimals
			for (Int32 i = 0; i < decimalPlaces; i++)
				formatString += "0";

			// Close placeholder
			formatString += "}";

			// Add byte type
			if (showByteType)
				formatString += byteType;

			return String.Format(formatString, newBytes);
		}

		private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			String file = ((String[])e.Argument)[0];
			String updateMD5 = ((String[])e.Argument)[1];

			// Hash the file and compare to the hash in the update xml
			if (Hash.HashFile(file, HashType.MD5).ToUpper() != updateMD5.ToUpper())
				e.Result = DialogResult.No;
			else
				e.Result = DialogResult.OK;
		}

		private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.DialogResult = (DialogResult)e.Result;
			this.Close();
		}

		private void AutoUpdateDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			if (webClient.IsBusy)
			{
				webClient.CancelAsync();
				this.DialogResult = DialogResult.Abort;
			}

			if (bgWorker.IsBusy)
			{
				bgWorker.CancelAsync();
				this.DialogResult = DialogResult.Abort;
			}
		}
	}
}
