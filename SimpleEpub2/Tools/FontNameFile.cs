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
            Console.WriteLine("fontname: " + fontname);
			String folderFullName = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
			DirectoryInfo TheFolder = new DirectoryInfo(folderFullName);
			foreach (FileInfo NextFile in TheFolder.GetFiles())
			{
				if (NextFile.Exists)
				{
					String result = getFontName(NextFile.FullName);
                    //Console.WriteLine(fontname + "\n" + NextFile.FullName + "\n" + result);
                    //Console.WriteLine("result: " + result);
                    if (fontname == result)
                    {
                        //Console.WriteLine("MATCHED");
                        return NextFile.FullName;
                    }
				}
			}
			return "";
		}

		private static String getFontName(String fontfilename)
		{
			String ext = fontfilename.Substring(fontfilename.LastIndexOf(".") + 1).ToUpper();
            //Console.WriteLine(fontfilename + "\n" + ext);
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
