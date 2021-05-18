using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hu_Concessionario
{
    public partial class Form2 : Form
    {
        private string email, psw;
        Concessionaria conc = new Concessionaria();
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string email, string psw)
        {
            InitializeComponent();
            this.email = email;
            this.psw = psw;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            visualizzazione();
            listLoader();
        }
        private void listLoader()
        {
            listView1.Items.Clear();
            string tipo = "";
            for (int i = 0; i < 4; i++) {
                switch (i)
                {
                    case 0: tipo = "Nuovo";
                        break;
                    case 1: tipo = "Usato";
                        break;
                    case 2: tipo = "Km0";
                        break;
                    case 3: tipo = "Pronta Consegna";
                        break;
                }
                conc.carLoad(i);
                foreach (Veicolo veicolo in conc.getCarList())
                {
                    string[] all = { tipo, veicolo.Marca, veicolo.Modello, veicolo.Alimentazione, veicolo.Colore, veicolo.Targa, veicolo.KmPercorsi.ToString(), veicolo.AnnoImmatricolazione.ToString(), veicolo.Prezzo.ToString(), veicolo.Id };
                    listView1.Items.Add(new ListViewItem(all));
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == textBox3.Text && textBox2.Text != "")
            {
                button1.Show();
            }
            else
            {
                button1.Hide();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text == textBox2.Text && textBox3.Text != "")
            {
                button1.Show();
            }
            else
            {
                button1.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conc.userChangePassword(label7.Text, textBox1.Text, textBox2.Text);
        }

        public void visualizzazione()
        {
            Cliente cliente = conc.getCliente(email, psw);
            label2.Text = cliente.Name;
            label3.Text = cliente.Surname;
            label5.Text += cliente.Contact;
            label7.Text = cliente.Email;
            label9.Text = cliente.indirizzoo.getIndirizzo();
        }
    }
}
