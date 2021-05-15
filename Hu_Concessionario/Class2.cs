using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;

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

        public Nuovo(string mrc, string mdl, string alm, string clr, string trg, int yGrz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = trg;
            kmPercorsi = 0;
            anniGaranzia = yGrz;
        }

        /*public string getPlate()
        {
            string targa = targa.ToString();
        }*/

    }

    public class Venditore : Persona
    {
        public void caricaVeicoli()
        {
            string file = File.ReadAllText("veicoli.json");
            Program.carList = JsonConvert.DeserializeObject<List<Veicolo>>(file);
        }

        public void aggiuntaVeicolo(Nuovo nuovoVeicolo)
        {

        }
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
            conc = "";
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
            for (int i = 0; i <= 6; i++)
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

        public bool ricercaPresenza(string targa)
        {
            foreach(Veicolo veicolo in Program.carList)
            {
                if (targa == veicolo.Targa) return false;
                else return true;
            }
            return false;
        }
    }

    public class Persona
    {
        protected string name;
        protected string surname;
        protected string contact;
        protected string email;


    }

    public class Cliente : Persona
    {
        // ATTRIBUTI OLTRE A QUELLI DERIVATI

        private string password;
        private Indirizzo indirizzo;
        
        // GET SET

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        public Indirizzo indirizzoo { get { return indirizzo; } set { indirizzo = value; } }
        
        public Cliente()
        {
            name = "z";
            surname = "z";
            contact = "z";
            email = "z@z.z";
            password = "z";
            indirizzo = new Indirizzo();
        }

        public Cliente(string n, string s, string c, string e, string p, Indirizzo i)
        {
            name = n;
            surname = s;
            contact = c;
            email = e;
            password = p;
            indirizzo = i;
        }
    }

    public class Indirizzo
    {
        private string via;
        private int nCivico;
        private string comune;
        private string provincia;

        public string[] abbr() 
        {
            string[] abbreviazione = File.ReadAllLines("provincie.txt");
            return abbreviazione;
        }

        public Indirizzo()
        {
            via = "z";
            nCivico = 1;
            comune = "z";
            provincia = "z";
        }

        public Indirizzo(string v, int n, string c, string p)
        {
            via = v;
            nCivico = n;
            comune = c;
            provincia = p;
        }
        public string Via { get { return via; } set { via = value; } }
        public int NCivico 
        { 
            get { return nCivico; }
            set
            {
                if (value > 0)
                {
                    nCivico = value;
                }
                else
                {
                    Console.WriteLine("Valore non valido");
                    nCivico = 1;
                }
            }
        }

        public string Comune { get { return comune; } set { comune = value; } }

        public string Provincia
        {
            get { return provincia; }
            set
            {
                bool check = false;
                foreach(string abbreviazione in abbr())
                {
                    if (value == abbreviazione) check = true;
                }

                if (check) provincia = value;
                else Console.WriteLine("non esiste");
            }
        }
    }

    public class Visualizzazione
    {
    }

    public class Concessionaria
    {
        private List<Cliente> client = new List<Cliente>();

        public Concessionaria()
        {
            loadList();
        }

        public void registrazioneUtente(Cliente cle)
        {
            client.Add(cle);
            string json = JsonConvert.SerializeObject(client);
            Console.WriteLine(json);
            File.WriteAllText("clienti.json", json);
        }
        public void loadList()
        {
            string file = File.ReadAllText("clienti.json");
            client = JsonConvert.DeserializeObject<List<Cliente>>(file);
            Console.WriteLine(file);
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
