using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hu_Concessionario
{
    static class Program
    {
        static public List<Veicolo> carList = new List<Veicolo>();
        static public List<VeicoloGenerico> prova = new List<VeicoloGenerico>();
        static public List<Usato> usato = new List<Usato>();
        static public List<Km0> km0 = new List<Km0>();
        static public List<PConsegna> pConsegna = new List<PConsegna>();
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
