namespace KlanlarUygulaması
{
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        internal bool startTimer = false;
        internal bool startAtack = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.klanlar.org/");
            maskedTextBox1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            maskedTextBox2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startTimer = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (startTimer)
            {
                HtmlElement element = webBrowser1.Document.GetElementById("serverTime");
                if (null != element)
                {
                    String time = webBrowser1.Document.GetElementById("serverTime").InnerHtml;
                    String date = webBrowser1.Document.GetElementById("serverDate").InnerHtml;
                    label1.Text = date + " " + time;

                    if (startAtack)
                    {
                        time = time.Length == 7 ? "0" + time : time;
                        String serverTime = time + " " + date;
                        String programTime = maskedTextBox2.Text + " " + maskedTextBox1.Text;

                        if (serverTime.Equals(programTime))
                        {
                            HtmlElement atackButton = webBrowser1.Document.GetElementById("troop_confirm_go");
                            atackButton.InvokeMember("Click");
                            startAtack = false;
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlElement element = webBrowser1.Document.GetElementById("troop_confirm_go");
            if (null != element)
            {
                startAtack = true;
            }
        }
    }
}
