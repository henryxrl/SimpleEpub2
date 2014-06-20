using INI;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SimpleEpub2
{
	internal class SettingsObject
	{
		#region Variables

		protected internal String iniPath;
		protected internal INIFile ini;

		protected internal Boolean coverFirstPage;
		protected internal Boolean coverNoTOC;
		protected internal Boolean verticalText;
		protected internal Boolean replaceNumByHan;
		protected internal Boolean StT;
		protected internal Boolean TtS;
		protected internal Boolean embedFontSubset;
		protected internal String bookNameFont;
		protected internal String authorNameFont;
		protected internal Color pageColor;
		protected internal Single marginT;
		protected internal Single marginB;
		protected internal Single marginL;
		protected internal Single marginR;
		protected internal String titleFont;
		protected internal Single titleSize;
		protected internal Color titleColor;
		protected internal String bodyFont;
		protected internal Single bodySize;
		protected internal Color bodyColor;
		protected internal Single lineSpacing;
		protected internal Boolean addParagraphSpacing;
		protected internal String fileLocation;
		protected internal Boolean deleteTempFiles;
		protected internal Boolean autoUpdate;

		#endregion

		public SettingsObject(String path)
		{
			//iniPath = Path.Combine(Path.GetTempPath(), "SimpleEpub2") + "\\Resources\\settings.ini";
			iniPath = path;
			ini = new INIFile(iniPath);

			coverFirstPage = false;
			coverNoTOC = false;
			verticalText = false;
			replaceNumByHan = false;
			StT = false;
			TtS = false;
			embedFontSubset = false;
			bookNameFont = "微软雅黑";
			authorNameFont = "微软雅黑";
			pageColor = Color.Empty;
			marginT = 0;
			marginB = 0;
			marginL = 1;
			marginR = 1;
			titleFont = "微软雅黑";
			titleSize = 24;
			titleColor = Color.SteelBlue;
			bodyFont = "微软雅黑";
			bodySize = 14;
			bodyColor = Color.Black;
			lineSpacing = 115;
			addParagraphSpacing = false;
			fileLocation = Application.StartupPath;
			deleteTempFiles = true;
			autoUpdate = true;
		}

		public void loadFromSettings(Settings sts)
		{
			coverFirstPage = sts.pg1.settings1_3_coverfirstpage.Value;
			coverNoTOC = sts.pg1.settings1_3_covernoTOC.Value;
			verticalText = sts.pg1.settings1_3_vertical.Value;
			replaceNumByHan = sts.pg1.settings1_3_replace.Value;
			StT = sts.pg1.settings1_3_StT.Value;
			TtS = sts.pg1.settings1_3_TtS.Value;
			embedFontSubset = sts.pg1.settings1_3_embedFontSubset.Value;
			bookNameFont = sts.pg2.settings2_3_booknamefont.Text;
			authorNameFont = sts.pg2.settings2_3_authornamefont.Text;
			pageColor = sts.pg2.settings2_1_pc.SelectedColor;
			marginT = Int32.Parse(sts.pg2.settings2_2_pmT.Text);
			marginB = Int32.Parse(sts.pg2.settings2_2_pmB.Text);
			marginL = Int32.Parse(sts.pg2.settings2_2_pmL.Text);
			marginR = Int32.Parse(sts.pg2.settings2_2_pmR.Text);
			titleFont = sts.pg3.settings3_1_tfont.Text;
			titleSize = Int32.Parse(sts.pg3.settings3_1_tsize.Text);
			titleColor = sts.pg3.settings3_1_tcolor.SelectedColor;
			bodyFont = sts.pg3.settings3_2_bfont.Text;
			bodySize = Int32.Parse(sts.pg3.settings3_2_bsize.Text);
			bodyColor = sts.pg3.settings3_2_bcolor.SelectedColor;
			lineSpacing = Int32.Parse(sts.pg3.settings3_3_linespacing.Text);
			addParagraphSpacing = sts.pg3.settings3_3_addparagraphspacing.Value;
			fileLocation = sts.pg4.settings4_1_filelocation.Text;
			deleteTempFiles = sts.pg4.settings4_2_deletetempfiles.Value;
			autoUpdate = sts.pg4.settings4_4_chkupd.Value;
		}

		public void writeToSettings(Settings sts)
		{
			sts.pg1.settings1_3_coverfirstpage.Value = coverFirstPage;
			sts.pg1.settings1_3_covernoTOC.Value = coverNoTOC;
			if (!sts.pg1.settings1_3_coverfirstpage.Value)
			{
				sts.pg1.settings1_3_covernoTOC.Value = false;
				sts.pg1.settings1_3_covernoTOC.Enabled = false;
			}
			sts.pg1.settings1_3_vertical.Value = verticalText;
			sts.pg1.settings1_3_replace.Value = replaceNumByHan;
			sts.pg1.settings1_3_StT.Value = StT;
			sts.pg1.settings1_3_TtS.Value = TtS;
			if (sts.pg1.settings1_3_StT.Value)
			{
				sts.pg1.settings1_3_TtS.Value = false;
				sts.pg1.settings1_3_TtS.Enabled = false;
			}
			if (sts.pg1.settings1_3_TtS.Value)
			{
				sts.pg1.settings1_3_StT.Value = false;
				sts.pg1.settings1_3_StT.Enabled = false;
			}
			sts.pg1.settings1_3_embedFontSubset.Value = embedFontSubset;
			sts.pg2.settings2_3_booknamefont.Text = bookNameFont;
			sts.pg2.settings2_3_authornamefont.Text = authorNameFont;
			sts.pg2.settings2_1_pc.SelectedColor = pageColor;
			sts.pg2.settings2_2_pmT.Text = marginT.ToString();
			sts.pg2.settings2_2_pmB.Text = marginB.ToString();
			sts.pg2.settings2_2_pmL.Text = marginL.ToString();
			sts.pg2.settings2_2_pmR.Text = marginR.ToString();
			sts.pg3.settings3_1_tfont.Text = titleFont;
			sts.pg3.settings3_1_tsize.Text = titleSize.ToString();
			sts.pg3.settings3_1_tcolor.SelectedColor = titleColor;
			sts.pg3.settings3_2_bfont.Text = bodyFont;
			sts.pg3.settings3_2_bsize.Text = bodySize.ToString();
			sts.pg3.settings3_2_bcolor.SelectedColor = bodyColor;
			sts.pg3.settings3_3_linespacing.Text = lineSpacing.ToString();
			sts.pg3.settings3_3_addparagraphspacing.Value = addParagraphSpacing;
			sts.pg4.settings4_1_filelocation.Text = fileLocation;
			sts.pg4.settings4_2_deletetempfiles.Value = deleteTempFiles;
			sts.pg4.settings4_4_chkupd.Value = autoUpdate;
		}

		public void loadFromIni()
		{
			coverFirstPage = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "Cover_FirstPage")));
			coverNoTOC = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "Cover_NoTOC")));
			verticalText = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "Vertical")));
			replaceNumByHan = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "Replace")));
			StT = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "StT")));
			TtS = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "TtS")));
			embedFontSubset = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_1", "Embed_Font_Subset")));
			bookNameFont = ini.INIReadValue("Tab_2", "Cover_BookName_Font");
			authorNameFont = ini.INIReadValue("Tab_2", "Cover_AuthorName_Font");
			pageColor = ColorTranslator.FromHtml(ini.INIReadValue("Tab_2", "Page_Color"));
			marginT = Int32.Parse(ini.INIReadValue("Tab_2", "Page_Margin_Top"));
			marginB = Int32.Parse(ini.INIReadValue("Tab_2", "Page_Margin_Bottom"));
			marginL = Int32.Parse(ini.INIReadValue("Tab_2", "Page_Margin_Left"));
			marginR = Int32.Parse(ini.INIReadValue("Tab_2", "Page_Margin_Right"));
			titleFont = ini.INIReadValue("Tab_3", "Title_Font");
			titleSize = Int32.Parse(ini.INIReadValue("Tab_3", "Title_Size"));
			titleColor = ColorTranslator.FromHtml(ini.INIReadValue("Tab_3", "Title_Color"));
			bodyFont = ini.INIReadValue("Tab_3", "Body_Font");
			bodySize = Int32.Parse(ini.INIReadValue("Tab_3", "Body_Size"));
			bodyColor = ColorTranslator.FromHtml(ini.INIReadValue("Tab_3", "Body_Color"));
			lineSpacing = Int32.Parse(ini.INIReadValue("Tab_3", "Line_Spacing"));
			addParagraphSpacing = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_3", "Add_Paragraph_Spacing")));
			fileLocation = ini.INIReadValue("Tab_4", "Generated_File_Location");
			deleteTempFiles = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_4", "Delete_Temp_Files")));
			autoUpdate = Convert.ToBoolean(Convert.ToInt32(ini.INIReadValue("Tab_4", "Auto_Update")));
		}

		public void writeToIni()
		{
			ini.INIWriteValue("Tab_1", "Cover_FirstPage", (Convert.ToInt32(coverFirstPage)).ToString());
			ini.INIWriteValue("Tab_1", "Cover_NoTOC", (Convert.ToInt32(coverNoTOC)).ToString());
			ini.INIWriteValue("Tab_1", "Vertical", (Convert.ToInt32(verticalText)).ToString());
			ini.INIWriteValue("Tab_1", "Replace", (Convert.ToInt32(replaceNumByHan)).ToString());
			ini.INIWriteValue("Tab_1", "StT", (Convert.ToInt32(StT)).ToString());
			ini.INIWriteValue("Tab_1", "TtS", (Convert.ToInt32(TtS)).ToString());
			ini.INIWriteValue("Tab_1", "Embed_Font_Subset", (Convert.ToInt32(embedFontSubset)).ToString());
			ini.INIWriteValue("Tab_2", "Cover_BookName_Font", bookNameFont);
			ini.INIWriteValue("Tab_2", "Cover_AuthorName_Font", authorNameFont);
			ini.INIWriteValue("Tab_2", "Page_Color", ColorTranslator.ToHtml(pageColor));
			ini.INIWriteValue("Tab_2", "Page_Margin_Top", marginT.ToString());
			ini.INIWriteValue("Tab_2", "Page_Margin_Bottom", marginB.ToString());
			ini.INIWriteValue("Tab_2", "Page_Margin_Left", marginL.ToString());
			ini.INIWriteValue("Tab_2", "Page_Margin_Right", marginR.ToString());
			ini.INIWriteValue("Tab_3", "Title_Font", titleFont);
			ini.INIWriteValue("Tab_3", "Title_Size", titleSize.ToString());
			ini.INIWriteValue("Tab_3", "Title_Color", ColorTranslator.ToHtml(titleColor));
			ini.INIWriteValue("Tab_3", "Body_Font", bodyFont);
			ini.INIWriteValue("Tab_3", "Body_Size", bodySize.ToString());
			ini.INIWriteValue("Tab_3", "Body_Color", ColorTranslator.ToHtml(bodyColor));
			ini.INIWriteValue("Tab_3", "Line_Spacing", lineSpacing.ToString());
			ini.INIWriteValue("Tab_3", "Add_Paragraph_Spacing", (Convert.ToInt32(addParagraphSpacing)).ToString());
			ini.INIWriteValue("Tab_4", "Generated_File_Location", fileLocation);
			ini.INIWriteValue("Tab_4", "Delete_Temp_Files", (Convert.ToInt32(deleteTempFiles)).ToString());
			ini.INIWriteValue("Tab_4", "Auto_Update", (Convert.ToInt32(autoUpdate)).ToString());
		}
	}
}
