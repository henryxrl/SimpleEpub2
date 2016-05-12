using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEpub2
{
    public class Language
    {
        private String langCode;

        public String Lang
        {
            get { return langCode; }
        }

        public Language(String lang)
        {
            langCode = lang;
        }

        public String getString(String input)
        {
            return Properties.Resources.ResourceManager.GetString(langCode + input);
        }

        public Boolean isLangChinese()
        {
            return (langCode == "zh_");
        }

        public String getFont()
        {
            return (isLangChinese() ? "Microsoft YaHei UI" : "Segoe UI");
        }

        public void setFont(Control.ControlCollection ctrls)
        {
            foreach (Control ctr in ctrls)
            {
                ctr.Font = new Font(getFont(), ctr.Font.Size, ctr.Font.Style);
                if (ctr.HasChildren)
                {
                    setFont(ctr.Controls);
                }
            }
        }
    }
}
