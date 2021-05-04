using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu_Concessionario
{
    public class Veicolo
    {
        protected string marca;
        protected string modello;
        protected string alimentazione;
        protected string colore;
        protected string targa;
        protected int kmPercorsi;
        protected int anniGaranzia;

        public string Marca
        {
            get => marca;
            set => marca = value;
        }
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public string Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }
        public string Colore
        {
            get { return colore; }
            set { colore = value; }
        }
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public int KmPercorsi
        {
            get { return kmPercorsi; }
            set { kmPercorsi = value; }
        }
        public int AnniGaranzia
        {
            get { return anniGaranzia; }
            set { anniGaranzia = value; }
        }
    }

    public class Usato : Veicolo
    {
        public string Marca
        {
            get => marca;
            set => marca = value;
        }
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public string Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }
        public string Colore
        {
            get { return colore; }
            set { colore = value; }
        }
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public int KmPercorsi
        {
            get { return kmPercorsi; }
            set { kmPercorsi = value; }
        }
        public int AnniGaranzia
        {
            get { return anniGaranzia; }
            set { anniGaranzia = value; }
        }
    }

    public class Nuovo : Veicolo
    {
        public string Marca
        {
            get => marca;
            set => marca = value;
        }
        public string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public string Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }
        public string Colore
        {
            get { return colore; }
            set { colore = value; }
        }
        public string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public int KmPercorsi
        {
            get { return kmPercorsi; }
            set { kmPercorsi = value; }
        }
        public int AnniGaranzia
        {
            get { return anniGaranzia; }
            set { anniGaranzia = value; }
        }

        public Nuovo(string mrc, string mdl, string alm, string clr, int yGrz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = getPlate();
        }

        /*public string getPlate()
        {
            string targa = targa.ToString();
        }*/

    }

    public class Motorizzazione
    {
        private string licensePlate;
        
        public string LicensePlate
        {
            get { return licensePlate; }
            set { licensePlate = value; }
        }

        public string addPlate(Nuovo vehicle)
        {
            string line = getFileText();
            vehicle.Targa = Increase(line);
        }

        public string Increase(string icrs)
        {
            icrs[]
        }

        public void fileSaving()
        {

        }

        public string getFileText()
        {
            StreamReader sr = new StreamReader("targhe.txt");
            string line = sr.ReadToEnd();
            sr.Close();
            return line;
        }
    }
}
    /*private void incrementaTarga()
    {
        if (urca[6] < 90)
        {
            urca[6] = (char)(urca[6] + 1);
        }
        else if (urca[5] < 90)
        {
            urca[5] = (char)(urca[5] + 1);
            urca[6] = 'A';
        }
        else if (urca[4] < 57)
        {
            urca[4] = (char)(urca[4] + 1);
            urca[5] = 'A';
            urca[6] = 'A';
        }
        else if (urca[3] < 57)
        {
            urca[3] = (char)(urca[3] + 1);
            urca[4] = '0';
            urca[5] = 'A';
            urca[6] = 'A';
        }
        else if (urca[2] < 57)
        {
            urca[2] = (char)(urca[2] + 1);
            urca[3] = '0';
            urca[4] = '0';
            urca[5] = 'A';
            urca[6] = 'A';
        }
        else if (urca[1] < 90)
        {
            urca[1] = (char)(urca[1] + 1);
            urca[2] = '0';
            urca[3] = '0';
            urca[4] = '0';
            urca[5] = 'A';
            urca[6] = 'A';
        }
        else if (urca[0] < 90)
        {
            urca[0] = (char)(urca[0] + 1);
            urca[1] = 'A';
            urca[2] = '0';
            urca[3] = '0';
            urca[4] = '0';
            urca[5] = 'A';
            urca[6] = 'A';
        }

        public string acquisisciTarga()
        {
            Console.WriteLine("1: " + urca);
            string targa = urca.ToString();
            Console.WriteLine("2: " + targa);
            incrementaTarga();
            return targa;
        }*/
