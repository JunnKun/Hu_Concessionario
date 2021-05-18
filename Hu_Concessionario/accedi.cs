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
    public partial class accedi : Form
    {
        Concessionaria conc = new Concessionaria();
        public accedi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(conc.ricercaCliente(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Accesso avvenuto con successo");
                Form2 form2 = new Form2(textBox1.Text, textBox2.Text);
                form2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Accesso negato. Rincontrollare i campi inseriti");
            }
        }
    }
}
