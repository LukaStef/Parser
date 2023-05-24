using System.Diagnostics;

namespace Parser
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }
        //napravljeno: 20.05.2023.
        //poslednja izmena: 25.05.2023.
        private void button1_Click(object sender, EventArgs e)
        {
            SQL f = new();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ATS f = new();
            f.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://www.lukastefanovic.com/parser.html";
            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };
            Process.Start(psi);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = "https://github.com/LukaStef/parser";
            var psi = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };
            Process.Start(psi);
        }
    }
}