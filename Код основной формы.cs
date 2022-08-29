using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace RSS_fider
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        public string linkOnWebsite;
        public string speedUpdate;
        public string proxyServerAdress;
        public string proxyServerLogin;
        public string proxyServerPassword;
        public string pathToRssText;

        public string pathToConfigTempFile;

        public string title;
        public string pubDate;
        public string description;
        public bool skipWebsiteTitle;
        public string[] linksOnPaper = new string[20];

        public void MainMenu_Load(object sender, EventArgs e)
        {
            ConfigRead();
            ButtonUpdateTips();

            DialogResult result = MessageBox.Show("Вы хотите подключиться через proxy-сервер?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if(result == DialogResult.Yes)
            {
                ConnectingToProxy();
                TimerUpdateTickHandler(null, null);
            }
            else
            {
                pathToRssText = linkOnWebsite;
                TimerUpdateTickHandler(null, null);
            }
        }

        public void ConnectingToProxy()
        {
            try
            {
                WebProxy wp = new WebProxy(proxyServerAdress, true);
                wp.Credentials = new NetworkCredential(proxyServerLogin, proxyServerPassword);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = WebRequest.Create(linkOnWebsite);
                request.Proxy = wp;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                string getPath = Environment.CurrentDirectory.ToString();
                pathToRssText = getPath + "\\RssTextTempFile.xml";
                using (StreamWriter tempFile = new StreamWriter(pathToRssText))
                {
                    tempFile.Write(responseFromServer);
                    tempFile.Close();
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("Попытка подключения к прокси-серверу оказалась безуспешной. Попробовать еще раз?", "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    ConnectingToProxy();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void TimerUpdateTickHandler(object sender, EventArgs e) // Защита от размножения процессов
        {
            tableLayoutPanelRSS.Controls.Clear();
            skipWebsiteTitle = false;
            ConfigRead();
            CreateLinksOnPaper();
            ReadRss();
            TimerStart();
            textBoxUpdateInfo.Text = " Обновлено в " + DateTime.Now.ToString("HH:mm");
        }

        public void ConfigRead()
        {
            string getPath = Environment.CurrentDirectory.ToString();
            pathToConfigTempFile = getPath + "\\config.xml";
            XmlReader configReader = XmlReader.Create(pathToConfigTempFile);
            while (configReader.Read())
            {
                if (configReader.NodeType == XmlNodeType.Element)
                {
                    if (configReader.HasAttributes)
                    {
                        if (configReader.Name == "link")
                        {
                            linkOnWebsite = configReader.GetAttribute("value");
                        }
                        if (configReader.Name == "speedUpdate")
                        {
                            speedUpdate = configReader.GetAttribute("value");
                        }
                        if (configReader.Name == "proxyServerAdress")
                        {
                            proxyServerAdress = configReader.GetAttribute("value");
                        }
                        if (configReader.Name == "proxyServerLogin")
                        {
                            proxyServerLogin = configReader.GetAttribute("value");
                        }
                        if (configReader.Name == "proxyServerPassword")
                        {
                            proxyServerPassword = configReader.GetAttribute("value");
                        }
                    }
                }
            }
            configReader.Close();

        }

        public void CreateLinksOnPaper()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            XmlTextReader RSSreader2 = new XmlTextReader(pathToRssText);

            int count = 0;
            while (RSSreader2.Read())
            {
                if (RSSreader2.Name == "guid")
                {
                    linksOnPaper[count] = RSSreader2.ReadString();
                    count++;
                }
            }
        }

        public void ReadRss()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            XmlTextReader RSSreader = new XmlTextReader(pathToRssText);

            int linksCount = 0;
            while (RSSreader.Read())
            {
                if (RSSreader.Name == "item") { skipWebsiteTitle = true; }
                if (skipWebsiteTitle == true)
                {
                    if (RSSreader.Name == "title")
                    {
                        GenerateTitle(RSSreader, linksCount);
                        linksCount++;
                    }
                    if (RSSreader.Name == "pubDate")
                    {
                        GeneratePubDate(RSSreader);
                    }
                    if (RSSreader.Name == "description")
                    {
                        GenerateDescription(RSSreader);
                    }
                }
            }
        }

        public void GenerateTitle(XmlTextReader RSSreader, int linksCount)
        {
            Button textButtonTitle = new Button();

            textButtonTitle.Size = new Size(410, 150);
            textButtonTitle.Font = new Font("Microsoft Sans Serif", 14);
            textButtonTitle.BackColor = Button.DefaultBackColor;
            textButtonTitle.Click += (sender, e) => { Process.Start(linksOnPaper[linksCount]); };
            textButtonTitle.Text = RSSreader.ReadString();

            tableLayoutPanelRSS.Controls.Add(textButtonTitle);
        }

        public void GeneratePubDate(XmlTextReader RSSreader)
        {
            TextBox textButtonPubDate = new TextBox();

            textButtonPubDate.Size = new Size(410, 150);
            textButtonPubDate.Font = new Font("Microsoft Sans Serif", 20);
            textButtonPubDate.BackColor = Button.DefaultBackColor;
            textButtonPubDate.Multiline = true;
            textButtonPubDate.TextAlign = HorizontalAlignment.Center;
            textButtonPubDate.ReadOnly = true;

            textButtonPubDate.Text = RSSreader.ReadString();
            textButtonPubDate.Text = Environment.NewLine + ConvertDate(textButtonPubDate.Text);

            tableLayoutPanelRSS.Controls.Add(textButtonPubDate);
        }

        public void GenerateDescription(XmlTextReader RSSreader)
        {
            TextBox textBoxDescription = new TextBox();
            string resultText;

            textBoxDescription.Size = new Size(410, 150);
            textBoxDescription.Font = new Font("Microsoft Sans Serif", 14);
            textBoxDescription.BackColor = Button.DefaultBackColor;
            textBoxDescription.Multiline = true;
            textBoxDescription.ScrollBars = ScrollBars.Vertical;
            textBoxDescription.ReadOnly = true;

            resultText = RSSreader.ReadString();
            resultText = DescriptionFormatting(resultText);
            textBoxDescription.Text = resultText;
            tableLayoutPanelRSS.Controls.Add(textBoxDescription);
        }

        string DescriptionFormatting(string resultText)
        {
            resultText = Regex.Replace(resultText, "<p>", "");
            resultText = Regex.Replace(resultText, "</p>", "");
            resultText = Regex.Replace(resultText, "<strong>", "");
            resultText = Regex.Replace(resultText, "</strong>", "");
            resultText = Regex.Replace(resultText, "<br>", "");
            resultText = Regex.Replace(resultText, "<em>", "");
            resultText = Regex.Replace(resultText, "</em>", "");
            resultText = Regex.Replace(resultText, "<code>", "");
            resultText = Regex.Replace(resultText, "</code>", "");
            resultText = Regex.Replace(resultText, "<&nbsp>", "");

            var s = resultText.Split(' ');
            int countDeleteSymb = s.Where(w => w.Contains("</a>")).Count();
            for (int i = 0; i < countDeleteSymb; i++)
            {
                int deleteA = resultText.IndexOf("<a");
                int deleteAS = resultText.IndexOf("</a>");
                int deleteResult = deleteAS - deleteA + 4;
                resultText = resultText.Remove(deleteA, deleteResult);
            }

            s = resultText.Split(' ');
            countDeleteSymb = s.Where(w => w.Contains("</div>")).Count();
            for (int i = 0; i < countDeleteSymb; i++)
            {
                int deleteA = resultText.IndexOf("<div");
                int deleteAS = resultText.IndexOf("</div>");
                int deleteResult = deleteAS - deleteA + 6;
                resultText = resultText.Remove(deleteA, deleteResult);
            }

            s = resultText.Split(' ');
            countDeleteSymb = s.Where(w => w.Contains("<img")).Count();
            for (int i = 0; i < countDeleteSymb; i++)
            {
                int deleteA = resultText.IndexOf("<img");
                resultText = resultText.Remove(deleteA, 83);
            }

            resultText = Regex.Replace(resultText, @"^\s*\r?\n|\r?\n(?!\s*\S)", "", RegexOptions.Multiline);
            return resultText;
        }

        public string ConvertDate(string date)
        {
            char[] symb = { ' ', ':', ',' };
            string[] words = date.Split(symb);
            date = "";
            words[5] = (Convert.ToInt32(words[5]) + 3).ToString();
            date += words[2] + GenerateMounth(words[3]) + words[4] + " года, " + words[5] + "ч " + words[6] + "м " + "(по МСК)";

            return date;
        }

        public string GenerateMounth(string mounth)
        {
            if (mounth == "Aug") {mounth = " августа "; }
            if (mounth == "Sept") {mounth = " сентября "; }
            if (mounth == "Oct") { mounth = " октября "; }
            if (mounth == "Nov") { mounth = " ноября "; }
            if (mounth == "Dec") { mounth = " декабря "; }
            if (mounth == "Jan") { mounth = " января "; }
            if (mounth == "Feb") { mounth = " февраля "; }
            if (mounth == "Mar") { mounth = " марта "; }
            if (mounth == "Apr") { mounth = " апреля "; }
            if (mounth == "May") { mounth = " мая "; }
            if (mounth == "June") { mounth = " Июня "; }
            if (mounth == "July") { mounth = " июля "; }
            return mounth;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            TimerUpdateTickHandler(null, null);
        }

        private void buttonUpdateSettings_Click(object sender, EventArgs e)
        {
            UpdateSpeedChange updateSpeedChange = new UpdateSpeedChange();
            updateSpeedChange.ShowDialog();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            TimerUpdateTickHandler(null, null);
        }

        public void ButtonUpdateTips()
        {
            ToolTip buttonsTips = new ToolTip();
            buttonsTips.SetToolTip(buttonUpdate, "Обновить ленту");
            buttonsTips.SetToolTip(buttonUpdateSettings, "Изенить частоту обновления");
        }

        public void TimerStart()
        {
            timerUpdate.Stop();
            timerUpdate.Interval = Convert.ToInt32(speedUpdate);
            timerUpdate.Start();
        }
    }
}
