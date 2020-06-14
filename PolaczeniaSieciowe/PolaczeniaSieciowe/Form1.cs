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
using System.Net.NetworkInformation;

namespace PolaczeniaSieciowe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void siec()
        {
            IPGlobalProperties wlasnosciIP = IPGlobalProperties.GetIPGlobalProperties();
            textBox1.Text=("Nazwa hosta: " + wlasnosciIP.HostName + Environment.NewLine);
            textBox1.Text += ("Nazwa domeny: " + wlasnosciIP.DomainName + Environment.NewLine);
            
            int licznik = 0;
            foreach (NetworkInterface kartySieciowe in NetworkInterface.GetAllNetworkInterfaces())
            {
                textBox1.Text += ("Karta #" + ++licznik + ": " + kartySieciowe.Id + Environment.NewLine);
                textBox1.Text += (" Adres MAC: " + kartySieciowe.GetPhysicalAddress().ToString() + Environment.NewLine);
                textBox1.Text += (" Nazwa: " + kartySieciowe.Name + Environment.NewLine);
                textBox1.Text += (" Opis: " + kartySieciowe.Description + Environment.NewLine);
                textBox1.Text += (" Adresy bram sieciowych:" + Environment.NewLine);
                foreach (GatewayIPAddressInformation adresBramy in kartySieciowe.GetIPProperties().GatewayAddresses)
                    textBox1.Text += (" " + adresBramy.Address.ToString() + Environment.NewLine);
                textBox1.Text += (" Serwery DNS:" + Environment.NewLine);
                foreach (IPAddress adresIP in kartySieciowe.GetIPProperties().DnsAddresses)
                    textBox1.Text += (" " + adresIP.ToString() + Environment.NewLine);
                foreach (IPAddress adresIP in kartySieciowe.GetIPProperties().DhcpServerAddresses)
                    textBox1.Text += (" " + adresIP.ToString() + Environment.NewLine);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            siec();
        }
    }
}
