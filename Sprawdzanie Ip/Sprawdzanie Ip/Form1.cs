using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Sprawdzanie_Ip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sprawdzIP()
        {
            string NazwaHosta = Dns.GetHostName();
            IPHostEntry AdresyIP = Dns.GetHostEntry(NazwaHosta);
            textBox1.Text+=("nazwa komputera: " + NazwaHosta + Environment.NewLine);
            int licznik = 0;
            foreach (IPAddress AdresIP in AdresyIP.AddressList)
            {
                if (AdresIP.ToString() == "127.0.0.1")
                    textBox1.Text += ("Komputer nie jest podłączony do sieci. Adres IP: " + AdresIP.ToString() + Environment.NewLine);
                else
                    textBox1.Text += (" adres IP #" + ++licznik + ": " + AdresIP.ToString() + Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            sprawdzIP();
        }
    }
}
