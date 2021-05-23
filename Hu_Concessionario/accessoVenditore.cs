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
    public partial class accessoVenditore : Form
    {
        Concessionaria conc = new Concessionaria();
        public accessoVenditore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conc.verify(textBox1.Text, textBox2.Text))
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                MessageBox.Show("Accesso negato...");
            }
        }
    }
}
