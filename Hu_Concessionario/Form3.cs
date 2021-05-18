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
    public partial class Form3 : Form
    {
        Venditore venditore = new Venditore();
        Concessionaria conc = new Concessionaria();
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
    }
}
