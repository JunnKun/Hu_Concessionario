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
            Program.prova.Clear();
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
                    VeicoloGenerico vg = new VeicoloGenerico(tipo, veicolo);
                    Program.prova.Add(vg);
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool controllo = false;
            int opzione = 2;
            Veicolo veicolo = new Veicolo();
            
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    if (listView1.SelectedItems[0].SubItems[4].Text == "-" && listView1.SelectedItems[0].SubItems[4].Text == "-" && Convert.ToInt32(listView1.SelectedItems[0].SubItems[6].Text) == 0 && Convert.ToInt32(listView1.SelectedItems[0].SubItems[7].Text) == 0 && listView1.SelectedItems[0].SubItems[9].Text == "-") opzione = 0;
                    else if (listView1.SelectedItems[0].SubItems[4].Text != "-" && listView1.SelectedItems[0].SubItems[4].Text == "-" && Convert.ToInt32(listView1.SelectedItems[0].SubItems[6].Text) == 0 && Convert.ToInt32(listView1.SelectedItems[0].SubItems[7].Text) == 0 && listView1.SelectedItems[0].SubItems[9].Text != "-") opzione = 1;
                    else opzione = 2;
                    veicolo = new Veicolo(listView1.SelectedItems[0].SubItems[1].Text, listView1.SelectedItems[0].SubItems[2].Text, listView1.SelectedItems[0].SubItems[3].Text, listView1.SelectedItems[0].SubItems[4].Text, listView1.SelectedItems[0].SubItems[5].Text, Convert.ToInt32(listView1.SelectedItems[0].SubItems[6].Text), listView1.SelectedItems[0].SubItems[9].Text, Convert.ToInt32(listView1.SelectedItems[0].SubItems[7].Text), float.Parse(listView1.SelectedItems[0].SubItems[8].Text));
                    controllo = true;
                }catch(Exception error)
                {
                    Console.WriteLine(error);
                }
            }

            if (controllo)
            {
                Contratta contratta = new Contratta(veicolo, opzione, label15.Text);
                contratta.Show();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (textBox4.TextLength != 0)
            {
                Console.WriteLine("dentro 1");
                foreach (VeicoloGenerico veicolo in Program.prova)
                {
                    bool check = false;
                    switch (comboBox2.Text)
                    {
                        case "Tipo":
                            for (int i = 0; i < textBox4.TextLength; i++)
                            {
                                if (textBox4.Text[i] == veicolo.Tipo[i]) check = true;
                                else
                                {
                                    check = false;
                                    i = 10000;
                                }
                            }
                            break;
                        case "Marca":
                            for (int i = 0; i < textBox4.TextLength; i++)
                            {
                                if (textBox4.Text[i] == veicolo.Veicoloo.Marca[i]) check = true;
                                else
                                {
                                    check = false;
                                    i = 10000;
                                }
                            }
                            break;
                        case "Modello":
                            for (int i = 0; i < textBox4.TextLength; i++)
                            {
                                if (textBox4.Text[i] == veicolo.Veicoloo.Modello[i]) check = true;
                                else
                                {
                                    check = false;
                                    i = 10000;
                                }
                            }
                            break;
                        case "Alimentazione":
                            for (int i = 0; i < textBox4.TextLength; i++)
                            {
                                if (textBox4.Text[i] == veicolo.Veicoloo.Alimentazione[i]) check = true;
                                else
                                {
                                    check = false;
                                    i = 10000;
                                }
                            }
                            break;
                        case "Colore":
                            for (int i = 0; i < textBox4.TextLength; i++)
                            {
                                if (textBox4.Text[i] == veicolo.Veicoloo.Colore[i]) check = true;
                                else
                                {
                                    check = false;
                                    i = 10000;
                                }
                            }
                            break;
                    }
                    if (check)
                    {
                        string[] all = { veicolo.Tipo, veicolo.Veicoloo.Marca, veicolo.Veicoloo.Modello, veicolo.Veicoloo.Alimentazione, veicolo.Veicoloo.Colore, veicolo.Veicoloo.Targa, veicolo.Veicoloo.KmPercorsi.ToString(), veicolo.Veicoloo.AnnoImmatricolazione.ToString(), veicolo.Veicoloo.Prezzo.ToString(), veicolo.Veicoloo.Id };
                        listView1.Items.Add(new ListViewItem(all));
                    }
                }
            }
            else
            {
                listLoader();
            }
        }

        public void visualizzazione()
        {
            Cliente cliente = conc.getCliente(email, psw);
            label2.Text = cliente.Name;
            label3.Text = cliente.Surname;
            label5.Text += cliente.Contact;
            label7.Text = cliente.Email;
            label15.Text = cliente.ID;
            label9.Text = cliente.indirizzoo.getIndirizzo();
        }
    }
}
