using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return SimpleEpub2.Properties.Resources.ResourceManager.GetString(langCode + input);
        }
    }
}
