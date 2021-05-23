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
    public partial class Contratta : Form
    {
        Concessionaria conc = new Concessionaria();
        Veicolo veicolo = new Veicolo();
        private int opzione;
        private string id;
        public Contratta()
        {
            InitializeComponent();
        }
        public Contratta(Veicolo veicolo, int opzione, string id)
        {
            InitializeComponent();
            this.veicolo = veicolo;
            this.opzione = opzione;
            this.id = id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (opzione == 0)
            {
                SceltaComponenti sc = new SceltaComponenti(veicolo, id);
                sc.Show();
                this.Close();
            }
            else
            {
                Offerta offerta = new Offerta(2, id, getTipo(), veicolo);
                conc.aggiungiOfferta(offerta);
                MessageBox.Show("Richiesta mandata...");
                this.Close();
            }
        }

        private string getTipo()
        {
            string tipo;
            if (opzione == 0) tipo = "Nuovo";
            else if (opzione == 1) tipo = "Pronta Consegna";
            else if (opzione == 2) tipo = "Km 0";
            else tipo = "Usato";
            return tipo;
        }
        private void Contratta_Load(object sender, EventArgs e)
        {
            textBox3.Text = textBox1.Text;
            textBox1.Text = veicolo.Prezzo.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            veicolo.Prezzo = conc.getPrezzoScontato(float.Parse(textBox1.Text), (float)numericUpDown1.Value);
            textBox3.Text = veicolo.Prezzo.ToString();
        }
    }
}
