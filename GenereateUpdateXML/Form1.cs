using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Xml;

namespace GenereateUpdateXML
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        static String xml_dir = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
        static String xml_path = Path.Combine(xml_dir, @"SimpleEpub2_Update.xml");
        static String exe_path = Path.Combine(xml_dir, @"SimpleEpub2\bin\Release\SimpleEpub2.exe");
        static String exe_name = Path.GetFileName(exe_path);
        static String exe_name_no_ext = Path.GetFileNameWithoutExtension(exe_path);
        static String exe_URL = "https://raw.githubusercontent.com/henryxrl/SimpleEpub2/master/SimpleEpub2/bin/Release/SimpleEpub2.exe";
        static String exe_MD5 = GetMd5(exe_path);
        static String exe_ver = FileVersionInfo.GetVersionInfo(exe_path).ProductVersion;

        XmlDocument doc = new XmlDocument();
        XmlNode root;
        XmlNode update;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            root = doc.CreateElement("sharpUpdate");
            doc.AppendChild(root);

            update = doc.CreateElement("update");
            XmlAttribute attribute = doc.CreateAttribute("appID");
            attribute.Value = exe_name_no_ext;
            update.Attributes.Append(attribute);
            root.AppendChild(update);

            appendNode("version", exe_ver);
            appendNode("url", exe_URL);
            appendNode("fileName", exe_name);
            appendNode("md5", exe_MD5);
            appendNode("launchArgs", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String log = "";
            String log_en = "";
            String log_cn = "";

            var log_en_array = textBox1.Lines;
            if (log_en_array.Length == 0)
                log_en = "";
            else
                log_en = String.Join("\n\t", log_en_array);

            var log_cn_array = textBox2.Lines;
            if (log_cn_array.Length == 0)
                log_cn = "";
            else
                log_cn = String.Join("\n\t", log_cn_array);

            String date = DateTime.Today.ToString("d");

            log = String.Concat(date, " Update:\n\t", log_en, "\n\n", date, " 更新：\n\t", log_cn);

            appendNode("description", log);
            doc.Save(xml_path);

            Environment.Exit(1);
        }

        static private String GetMd5(String path)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            FileInfo fi = new FileInfo(path);
            FileStream stream = File.Open(path, FileMode.Open);

            md5.ComputeHash(stream);

            stream.Close();

            string rtrn = "";
            for (int i = 0; i < md5.Hash.Length; i++)
            {
                rtrn += (md5.Hash[i].ToString("x2"));
            }

            return rtrn.ToUpper();
        }

        private void appendNode(String nodeName, String value)
        {
            XmlNode version = doc.CreateElement(nodeName);
            version.InnerText = value;
            update.AppendChild(version);
        }
    }
}
