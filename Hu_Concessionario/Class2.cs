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
            get { return marca; }
            set { marca = value; }
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
        public new string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public new string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public new string Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }
        public new string Colore
        {
            get { return colore; }
            set { colore = value; }
        }
        public new string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public new int KmPercorsi
        {
            get { return kmPercorsi; }
            set { kmPercorsi = value; }
        }
        public new int AnniGaranzia
        {
            get { return anniGaranzia; }
            set { anniGaranzia = value; }
        }
    }

    public class Nuovo : Veicolo
    {
        public new string Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public new string Modello
        {
            get { return modello; }
            set { modello = value; }
        }
        public new string Alimentazione
        {
            get { return alimentazione; }
            set { alimentazione = value; }
        }
        public new string Colore
        {
            get { return colore; }
            set { colore = value; }
        }
        public new string Targa
        {
            get { return targa; }
            set { targa = value; }
        }
        public new int KmPercorsi
        {
            get { return kmPercorsi; }
            set { kmPercorsi = value; }
        }
        public new int AnniGaranzia
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
            //targa = getPlate();
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

        public string getPlate()
        {
            string line = getFileText();
            char[] targa = { line[0], line[1], line[2], line[3], line[4], line[5], line[6] };
            string plate = Increase(targa);
            fileSaving(plate);

            return plate;
        }

        public string Increase(char[] trg)
        {
            string conc = "";
            if (trg[6] < 90)
            {
                trg[6] = (char)(trg[6] + 1);
            }
            else if (trg[5] < 90)
            {
                trg[5] = (char)(trg[5] + 1);
                trg[6] = 'A';
            }
            else if (trg[4] < 57)
            {
                trg[4] = (char)(trg[4] + 1);
                trg[5] = 'A';
                trg[6] = 'A';
            }
            else if (trg[3] < 57)
            {
                trg[3] = (char)(trg[3] + 1);
                trg[4] = '0';
                trg[5] = 'A';
                trg[6] = 'A';
            }
            else if (trg[2] < 57)
            {
                trg[2] = (char)(trg[2] + 1);
                trg[3] = '0';
                trg[4] = '0';
                trg[5] = 'A';
                trg[6] = 'A';
            }
            else if (trg[1] < 90)
            {
                trg[1] = (char)(trg[1] + 1);
                trg[2] = '0';
                trg[3] = '0';
                trg[4] = '0';
                trg[5] = 'A';
                trg[6] = 'A';
            }
            else if (trg[0] < 90)
            {
                trg[0] = (char)(trg[0] + 1);
                trg[1] = 'A';
                trg[2] = '0';
                trg[3] = '0';
                trg[4] = '0';
                trg[5] = 'A';
                trg[6] = 'A';
            }
            for(int i = 0; i <= 6; i++) 
            {
                conc += trg[i];
            }
            return conc;
        }

        public void fileSaving(string text)
        {
            StreamWriter sw = new StreamWriter("targhe.txt");
            sw.WriteLine(text);
            sw.Close();
        }

        public string getFileText()
        {
            StreamReader sr = new StreamReader("targhe.txt");
            string line = sr.ReadLine();
            sr.Close();
            return line;
        }
    }
}
/*private void incrementaTarga()
{
    public string acquisisciTarga()
    {
        Console.WriteLine("1: " + trg);
        string targa = trg.ToString();
        Console.WriteLine("2: " + targa);
        incrementaTarga();
        return targa;
    }*/
