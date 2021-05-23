using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft;

namespace Hu_Concessionario
{
    public partial class Form3 : Form
    {
        Venditore venditore = new Venditore();
        Concessionaria conc = new Concessionaria();
        Offerta offerta = new Offerta();
        public Form3()
        {
            InitializeComponent();
            brandsLoad();
            colorLoad();
        }

        private void brandsLoad()
        {
            Veicolo veicolo = new Veicolo();
            foreach(string marca in veicolo.brands())
            {
                comboBox1.Items.Add(marca);
            }
        }

        private void colorLoad()
        {
            Veicolo veicolo = new Veicolo();
            foreach (string marca in veicolo.color())
            {
                comboBox4.Items.Add(marca);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            Motorizzazione mtr = new Motorizzazione();
            string targa = mtr.getPlate();
            textBox3.Text = targa;
        }

        /*private void button3_Click(object sender, EventArgs e)
        {
            Nuovo nuovo = new Nuovo(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), textBox2.Text, textBox3.Text);
            venditore.aggiuntaVeicolo(nuovo);
        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem)
            {
                case "Nuovo":
                    addNewCar();
                    break;
                case "Usato":
                    addOldKmCar(0);
                    break;
                case "Km0":
                    addOldKmCar(1);
                    break;
                case "Pronta Consegna":
                    addProntaConsegnaCar();
                    break;
            }
        }

        private void addNewCar()
        {
            Nuovo nuovo = new Nuovo(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), (float)numericUpDown1.Value);
            venditore.addNewCar(nuovo);
        }
        private void addOldKmCar(int option)
        {
            int ann = 0;
            int km = 0;

            for (int i = 0; i < 2; i++) // Controllo valore numerico
            {
                try
                {
                    if(i == 0) km = Convert.ToInt32(textBox4.Text);
                    else ann = Convert.ToInt32(textBox6.Text);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error);
                    if (i == 0) MessageBox.Show("KM Percorsi... Valore inserito non valido, RINSERIRE PREGO");
                    else MessageBox.Show("Anno Immatricolazione... Valore inserito non valido, RINSERIRE PREGO");
                }
            }

            if (conc.check(textBox3.Text)) // Controllo targa
            {
                if (ann != 0 && km != 0)
                {
                    if (option == 0)
                    {
                        Usato usato = new Usato(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), textBox3.Text, km, textBox5.Text, ann, (float)numericUpDown1.Value);
                        venditore.addUsedCar(usato);
                    }
                    else
                    {
                        Km0 km0 = new Km0(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), textBox3.Text, km, textBox5.Text, ann, (float)numericUpDown1.Value);
                        venditore.addKmCar(km0);
                    }
                }
            }
            else
            {
                MessageBox.Show("Targa inserita non valida, RINSERIRE PREGO");
            }
        }

        private void addProntaConsegnaCar()
        {
            PConsegna pconsegna = new PConsegna(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), comboBox4.SelectedItem.ToString(), textBox5.Text, (float)numericUpDown1.Value);
            venditore.addPConsegnaCar(pconsegna);
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem)
            {
                case "Nuovo":
                    newCar();
                    break;
                case "Usato":
                    usedCar();
                    break;
                case "Km0":
                    kmCar();
                    break;
                case "Pronta Consegna":
                    pConsegnaCar();
                    break;
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            string json = "";
            listVisualizer();
            conc.km0Loader();
            json = JsonConvert.SerializeObject(Program.km0);
            Console.WriteLine(json);
            conc.pConsegnaLoader();
            json = JsonConvert.SerializeObject(Program.pConsegna);
            Console.WriteLine(json);
            conc.UsatoLoader();
            json = JsonConvert.SerializeObject(Program.usato);
            Console.WriteLine(json);
        }

        private void newCar()
        {
            comboBox4.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button4.Enabled = false;
        }

        private void usedCar()
        {
            comboBox4.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = false;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button4.Enabled = true;
        }

        private void kmCar()
        {
            comboBox4.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = false;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            button4.Enabled = true;
        }

        private void pConsegnaCar()
        {
            comboBox4.Enabled = true;
            textBox3.Enabled = false;
            button1.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = true;
            textBox6.Enabled = false;
            button4.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = conc.generatoreID();
        }

        private void button2_Click(object sender, EventArgs e) // ACCETTA
        {
            if (listView2.SelectedItems.Count > 0)
            {
                if (listView2.SelectedItems[0].SubItems[0].Text == "in attesa...")
                {
                    foreach (Offerta offerta in conc.getOfferteList()) {
                        if(offerta.Veicolo.Id == listView2.SelectedItems[0].SubItems[5].Text)
                        {
                            deleteElement();
                            conc.setOfferteList(offerta, 0);
                            conc.OfferteListLoad();
                            listVisualizer();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("già confermato o rifiutato...");
                }
            }
        }
        private void deleteElement()
        {
            if (listView2.SelectedItems.Count > 0)
            {
                switch (listView2.SelectedItems[0].SubItems[4].Text)
                {
                    case "Pronta Consegna":
                        foreach (PConsegna pCons in Program.pConsegna)
                        {
                            if (pCons.Id == listView2.SelectedItems[0].SubItems[5].Text)
                            {
                                Program.pConsegna.Remove(pCons);
                                break;
                            }
                        }
                        conc.pConsegnaSaver();
                        break;
                    case "Km 0":
                        foreach (Km0 km0 in Program.km0)
                        {
                            if (km0.Id == listView2.SelectedItems[0].SubItems[5].Text)
                            {
                                Program.km0.Remove(km0);
                                break;
                            }
                        }
                        conc.km0Saver();
                        break;
                    case "Usato":
                        foreach (Usato usato in Program.usato)
                        {
                            if (usato.Id == listView2.SelectedItems[0].SubItems[5].Text)
                            {
                                Program.usato.Remove(usato);
                                break;
                            }
                        }
                        conc.UsatoSaver();
                        break;
                }
            }
        }
        private void button5_Click(object sender, EventArgs e) // RIFIUTA
        {
            if (listView2.SelectedItems.Count > 0)
            {
                if (listView2.SelectedItems[0].SubItems[0].Text == "in attesa...")
                {
                    foreach (Offerta offerta in conc.getOfferteList())
                    {
                        if (offerta.Veicolo.Id == listView2.SelectedItems[0].SubItems[5].Text)
                        {
                            conc.setOfferteList(offerta, 1);
                            conc.OfferteListLoad();
                            listVisualizer();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("già confermato o rifiutato...");
                }
            }
        }

        

        private void listVisualizer()
        {
            listView2.Items.Clear();
            conc.getOfferteList();
            foreach (Offerta offerta in conc.getOfferteList())
            {
                string state = "";
                switch (offerta.Stato)
                {
                    case 0:
                        state = "confermato";
                        break;
                    case 1:
                        state = "rifiutato";
                        break;
                    case 2:
                        state = "in attesa...";
                        break;
                }
                float prezzo = 0;
                for(int i = 0; i < 4; i++)
                {
                    conc.carLoad(i);
                    foreach (Veicolo veicolo in conc.getCarList())
                    {
                        if(veicolo.Id == offerta.Veicolo.Id)
                        {
                            prezzo = veicolo.Prezzo;
                        }
                    }
                }
                string[] all = { state, offerta.IDUtente, offerta.Veicolo.Marca, offerta.Veicolo.Modello, offerta.Tipo, offerta.Veicolo.Id, prezzo.ToString(), offerta.Veicolo.Prezzo.ToString() };
                listView2.Items.Add(new ListViewItem(all));
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button5.Enabled = true;
        }
    }
}
