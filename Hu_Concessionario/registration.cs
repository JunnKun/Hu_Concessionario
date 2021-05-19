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
    public partial class registration : Form
    {
        Concessionaria concessionaria = new Concessionaria();
        public registration()
        {
            InitializeComponent();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            provinciaLoad();
        }

        private void provinciaLoad()
        {
            Indirizzo indirizzo = new Indirizzo();
            foreach (string prov in indirizzo.abbr())
            {
                comboBox1.Items.Add(prov);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            try
            {
                n = Convert.ToInt32(textBox7.Text);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                MessageBox.Show("numero civico non valido, RINSERIRE");
            }

            if (n != 0 && check()) {
                Indirizzo indirizzo = new Indirizzo(textBox6.Text, n, textBox8.Text, comboBox1.SelectedItem.ToString());
                string id = concessionaria.generatoreIDCliente();
                Cliente cliente = new Cliente(textBox1.Text, textBox2.Text, textBox3.Text, textBox5.Text, textBox9.Text, id, indirizzo);
                concessionaria.registrazioneUtente(cliente);
                MessageBox.Show("Registrazione avvenuta con successo... Il suo id: " + id);
                this.Close();
            }
            else { MessageBox.Show("Riempire tutti i campi"); }
        }

        private bool check()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)) return false;
            else return true;
        }
    }
}
