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
        public Form3()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            Motorizzazione mtr = new Motorizzazione();
            string targa = mtr.getPlate();
            textBox3.Text = targa;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nuovo nuovo = new Nuovo(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), textBox2.Text, textBox3.Text, (int)comboBox3.SelectedItem);
            venditore.aggiuntaVeicolo(nuovo);
        }
    }
}
