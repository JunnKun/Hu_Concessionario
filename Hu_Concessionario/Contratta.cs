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
            Offerta offerta = new Offerta(2, veicolo, id);
            conc.aggiungiOfferta(offerta);
            switch (opzione)
            {
                case 0:
                    SceltaComponenti sc = new SceltaComponenti();
                    sc.Show();
                    this.Close();
                    break;
                case 1:

                    break;
                case 2:

                    break;
            }
        }

        private void Contratta_Load(object sender, EventArgs e)
        {
            textBox1.Text = veicolo.Prezzo.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            veicolo.Prezzo = conc.getPrezzoScontato(veicolo.Prezzo, (float)numericUpDown1.Value);
            textBox3.Text = veicolo.Prezzo.ToString();
        }
    }
}
