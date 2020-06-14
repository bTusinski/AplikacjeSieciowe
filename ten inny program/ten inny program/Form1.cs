using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace ten_inny_program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
                                             

        private void kliknij()
        {
            if (textBox1.Text != "")
            {
                PingOptions opcje = new PingOptions();
                opcje.Ttl = (int)numericUpDown2.Value;
                opcje.DontFragment = true;
                string dane = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                byte[] bufor = Encoding.ASCII.GetBytes(dane);
                int timeout = 120;
                if (textBox1.Text != "")
                {
                    for (int i = 0; i < (int)numericUpDown1.Value; i++)
                        listBox1.Items.Add(this.wyslijPing(textBox1.Text, timeout, bufor, opcje));
                    listBox1.Items.Add("------------------");
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono adresu", "Błąd");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kliknij();
        }


        private string wyslijPing(string adres, int timeout, byte[] bufor, PingOptions opcje)
        {
            Ping ping = new Ping();
            try
            {
                PingReply odpowiedz = ping.Send(adres, timeout, bufor, opcje);
                if (odpowiedz.Status == IPStatus.Success)
                    return "Odpowiedź z " + adres + " bajtów = " + odpowiedz.Buffer.Length + " czs = " + odpowiedz.RoundtripTime + "ms TTL= " + odpowiedz.Options.Ttl;
                else
                    return "Błąd: " + adres + " " + odpowiedz.Status.ToString();
            }
            catch (Exception ex)
            {
                return "Błąd: " + adres + " " + ex.Message;
            }
        }
        

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
             textBox1.Text = listView1.SelectedItems[0].Text;
        }



        private void dodaj()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
                return;
            {
                ListViewItem item = new ListViewItem(textBox2.Text);
                listView1.Items.Add(item);
                textBox2.Clear();
            }
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            dodaj();
        }
    
        private void usun()
        {
            if (listView1.Items.Count > 0)
                listView1.Items.Remove(listView1.SelectedItems[0]);
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            usun();   
        }

     


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
               kliknij();                       
        }

        private void listView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                kliknij();
        }

        //Po kliklnieciu "ENTER" przy dodawaniu do listy
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dodaj();
        }
    }
}