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
    public partial class SceltaComponenti : Form
    {
        Concessionaria conc = new Concessionaria();
        Veicolo veicolo = new Veicolo();
        private string id;
        public SceltaComponenti()
        {
            InitializeComponent();
            colorLoad();
        }
        public SceltaComponenti(Veicolo veicolo, string id)
        {
            InitializeComponent();
            colorLoad();
            this.veicolo = veicolo;
            this.id = id;
        }
        private void colorLoad()
        {
            Veicolo veicolo = new Veicolo();
            foreach (string marca in veicolo.color())
            {
                comboBox4.Items.Add(marca);
            }
        }
        private void SceltaComponenti_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox5.Text = conc.generatoreID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check())
            {
                veicolo.Colore = comboBox4.SelectedItem.ToString();
                veicolo.Id = textBox5.Text;
                Offerta offerta = new Offerta(2, id, "Nuovo", veicolo);
                conc.aggiungiOfferta(offerta);
                MessageBox.Show("Richiesta mandata...");
                this.Close();
            }
            else
            {
                MessageBox.Show("Compilare tutti i campi...");
            }
        }

        private bool check()
        {
            if (comboBox4.SelectedItem.ToString() != "" && textBox5.Text != "") return true;
            else return false;
        }
    }
}
