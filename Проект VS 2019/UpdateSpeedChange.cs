using System;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml.Linq;


namespace RSS_fider
{
    public partial class UpdateSpeedChange : Form
    {
        public string speedUpdate;
        public UpdateSpeedChange()
        {
            InitializeComponent();

        }

        public void buttonSpeedSetting_Click(object sender, EventArgs e)
        {
            string getPath = Environment.CurrentDirectory.ToString();
            string path = getPath + "\\config.xml";


            int res;
            bool isInt = Int32.TryParse(textBoxSpeedUpdate.Text, out res);
            if (isInt)
            {
                int test = Convert.ToInt32(textBoxSpeedUpdate.Text);
                if (test < 10 || test > 1000)
                {
                    MessageBox.Show("Введеное число некоректно. Введите число от 10 до 1000");
                }
                else
                {
                    test = test * 1000;
                    speedUpdate = test.ToString();

                    XDocument xdoc = XDocument.Load(path);
                    var xobject = xdoc.Root.XPathSelectElement("/habr/speedUpdate/speedUpdate");
                    if (xobject != null)
                    {
                        xobject.Attribute("value").Value = speedUpdate;
                    }
                    xdoc.Save("config.xml");
                    MessageBox.Show("Частота обноваления изменена на один раз в " + test / 1000 + " секунд. Изменения вступят в силу после следующего обновления ленты");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Введите частоту обновления!");
            }
        }
    }
}
