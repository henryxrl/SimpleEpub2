using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace SimpleEpub2
{
	internal class FontNameFile
	{
		public static String getFontFileName(String fontname)
		{
            //Console.WriteLine("In getFontFileName fontname: " + fontname);
			String folderFullName = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
			DirectoryInfo TheFolder = new DirectoryInfo(folderFullName);
			foreach (FileInfo NextFile in TheFolder.GetFiles())
			{
				if (NextFile.Exists)
				{
					String result = getFontName(NextFile.FullName);
                    //Console.WriteLine("In getFontFileName: " + fontname + "\t" + NextFile.FullName + "\t" + result);
                    //Console.WriteLine("In getFontFileName result: " + result);
                    if (fontname == result)
                    {
                        //Console.WriteLine("MATCHED");
                        return NextFile.FullName;
                    }
				}
			}

			// Windows now install fonts for a single user in a new directory
			folderFullName = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Windows\\Fonts";
			//Console.WriteLine(Directory.Exists(folderFullName));
			if (Directory.Exists(folderFullName))
            {
				TheFolder = new DirectoryInfo(folderFullName);
				foreach (FileInfo NextFile in TheFolder.GetFiles())
				{
					if (NextFile.Exists)
					{
						String result = getFontName(NextFile.FullName);
						//Console.WriteLine("In getFontFileName: " + fontname + "\t" + NextFile.FullName + "\t" + result);
						//Console.WriteLine("In getFontFileName result: " + result);
						if (fontname == result)
						{
							//Console.WriteLine("MATCHED");
							return NextFile.FullName;
						}
					}
				}
			}
			
			return "";
		}

		private static String getFontName(String fontfilename)
		{
			String ext = fontfilename.Substring(fontfilename.LastIndexOf(".") + 1).ToUpper();
            //Console.WriteLine("In getFontName: " + fontfilename + "\t" + ext);
			if (ext.CompareTo("TTF") == 0)
			{
				PrivateFontCollection pfc = new PrivateFontCollection();
				try
				{
					pfc.AddFontFile(Path.GetFullPath(fontfilename));
                }
				catch
				{
					return "";
				}

                try
                {
                    return (pfc.Families[0].GetName(0));
                }
                catch
                {
                    return "";
                }
            }
			else
				return "";
		}
    }
}
