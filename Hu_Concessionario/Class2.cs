using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft;
using System.Text.RegularExpressions;

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
        protected string id;
        protected int annoImmatricolazione;
        protected float prezzo;

        public string[] brands()
        {
            string[] marche = File.ReadAllLines("marche.txt");
            return marche;
        }

        public string[] color()
        {
            string[] colori = File.ReadAllLines("colori.txt");
            return colori;
        }

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
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }

        public float Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }

        public Veicolo()
        {
            marca = "-";
            modello = "-";
            alimentazione = "-";
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = 0;
        }

        public Veicolo(string mrc, string mdl, string alm, string clr, string trg, int km, string id, int ymt, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = trg;
            kmPercorsi = km;
            this.id = id;
            annoImmatricolazione = ymt;
            prezzo = prz;
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
        public new string Id
        {
            get { return id; }
            set { id = value; }
        }
        public new int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }
        public new float Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }

        public Usato()
        {
            marca = "-";
            modello = "-";
            alimentazione = "-";
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = 0;
        }
        public Usato(string mrc, string mdl, string alm, string clr, string trg, int km, string id, int ymt, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = "-";
            kmPercorsi = km;
            this.id = id;
            annoImmatricolazione = ymt;
            prezzo = prz;
        }

        public void check(string targa)
        {
            Regex rgx = new Regex(@"^[a-zA-Z]{2}[0-9]{3,4}[a-zA-Z]{2}$$");
            Console.WriteLine("{0} {1} a valid part number.", targa, rgx.IsMatch(targa) ? "is" : "is not");
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
            set {
                if (value == 0) kmPercorsi = value;
                else kmPercorsi = 0;
            }
        }
        public new string Id
        {
            get { return id; }
            set { id = value; }
        }
        public new int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }
        public new float Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }
        public Nuovo(string mrc, string mdl, string alm, string clr, string trg, string id, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = trg;
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = Convert.ToInt32(DateTime.Now.Year);
            prezzo = prz;
        }

        public Nuovo(string mrc, string mdl, string alm, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = prz;
        }

        public Nuovo()
        {
            marca = "-";
            modello = "-";
            alimentazione = "-";
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = 0;
        }

        /*public string getPlate()
        {
            string targa = targa.ToString();
        }*/

    }

    public class Km0 : Veicolo
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
            set { 
                if (value >= 0 && value <= 50) kmPercorsi = value;
                else kmPercorsi = 0;
            }
        }
        public new string Id
        {
            get { return id; }
            set { id = value; }
        }
        public new int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }
        public new float Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }
        public Km0()
        {
            marca = "-";
            modello = "-";
            alimentazione = "-";
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = 0;
        }
        public Km0(string mrc, string mdl, string alm, string clr, string trg, int km, string id, int ymt, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = trg;
            kmPercorsi = km;
            this.id = id;
            annoImmatricolazione = ymt;
            prezzo = prz;
        }
    }

    public class PConsegna : Veicolo
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
            set
            {
                if (value == 0) kmPercorsi = value;
                else kmPercorsi = 0;
            }
        }
        public new string Id
        {
            get { return id; }
            set { id = value; }
        }
        public new int AnnoImmatricolazione
        {
            get { return annoImmatricolazione; }
            set { annoImmatricolazione = value; }
        }
        public new float Prezzo
        {
            get { return prezzo; }
            set { prezzo = value; }
        }
        public PConsegna()
        {
            marca = "-";
            modello = "-";
            alimentazione = "-";
            colore = "-";
            targa = "-";
            kmPercorsi = 0;
            id = "-";
            annoImmatricolazione = 0;
            prezzo = 0;
        }
        public PConsegna(string mrc, string mdl, string alm, string clr, string id, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = "-";
            kmPercorsi = 0;
            this.id = id;
            annoImmatricolazione = 0;
            prezzo = prz;
        }
        public PConsegna(string mrc, string mdl, string alm, string clr, string id, int anno, float prz)
        {
            marca = mrc;
            modello = mdl;
            alimentazione = alm;
            colore = clr;
            targa = "-";
            kmPercorsi = 0;
            this.id = id;
            annoImmatricolazione = anno;
            prezzo = prz;
        }
    }

    public class Venditore : Persona
    {
        public void addNewCar(Nuovo nuovoVeicolo)
        {
            CarLoad("Veicoli/nuovo.json");
            Program.carList.Add(nuovoVeicolo);
            string json = JsonConvert.SerializeObject(Program.carList);
            File.WriteAllText("Veicoli/nuovo.json", json);
        }

        public void addUsedCar(Usato veicoloUsato)
        {
            CarLoad("Veicoli/usato.json");
            Program.carList.Add(veicoloUsato);
            string json = JsonConvert.SerializeObject(Program.carList);
            File.WriteAllText("Veicoli/usato.json", json);
        }
        private void CarLoad(string path)
        {
            string file = File.ReadAllText(path);
            Program.carList = JsonConvert.DeserializeObject<List<Veicolo>>(file);
        }
        public void addKmCar(Km0 km0)
        {
            CarLoad("Veicoli/km0.json");
            Program.carList.Add(km0);
            string json = JsonConvert.SerializeObject(Program.carList);
            File.WriteAllText("Veicoli/km0.json", json);
        }
        public void addPConsegnaCar(PConsegna pconsegna)
        {
            CarLoad("Veicoli/pConsegna.json");
            Program.carList.Add(pconsegna);
            string json = JsonConvert.SerializeObject(Program.carList);
            File.WriteAllText("Veicoli/pConsegna.json", json);
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
        private string id;
        private Indirizzo indirizzo;
        
        // GET SET

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Contact { get { return contact; } set { contact = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }

        public string ID { get { return id; } set { id = value; } }
        public Indirizzo indirizzoo { get { return indirizzo; } set { indirizzo = value; } }
        
        public Cliente()
        {
            name = "z";
            surname = "z";
            contact = "z";
            email = "z@z.z";
            password = "z";
            id = "z";
            indirizzo = new Indirizzo();
        }

        public Cliente(string n, string s, string c, string e, string p, string d, Indirizzo i)
        {
            name = n;
            surname = s;
            contact = c;
            email = e;
            password = p;
            id = d;
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

        public string getIndirizzo()
        {
            return via + ", " + nCivico + " " + comune + "(" + Provincia + ")";
        }
    }

    public class Visualizzazione
    {
    }

    public class Concessionaria
    {
        private List<Cliente> client = new List<Cliente>();
        private List<Veicolo> veicolo = new List<Veicolo>();
        private List<Offerta> offerte = new List<Offerta>();

        public Concessionaria()
        {
            loadList();
        }

        public void registrazioneUtente(Cliente cle)
        {
            client.Add(cle);
            fileSaving();
        }

        public void fileSaving()
        {
            string json = JsonConvert.SerializeObject(client);
            // Console.WriteLine(json);
            File.WriteAllText("clienti.json", json);
        }

        public bool ricercaCliente(string email, string psw)
        {
            loadList();
            foreach(Cliente cliente in client)
            {
                if(email == cliente.Email && psw == cliente.Password)
                {
                    return true;
                }
            }
            return false;
        }
        public Cliente getCliente(string email, string psw)
        {
            loadList();
            foreach (Cliente clientee in client)
            {
                if (email == clientee.Email && psw == clientee.Password)
                {
                    return clientee;
                }
            }
            Cliente cliente = new Cliente();
            return cliente;
        }
        public void loadList()
        {
            string file = File.ReadAllText("clienti.json");
            client = JsonConvert.DeserializeObject<List<Cliente>>(file);
            // Console.WriteLine(file);
        }
        public void carLoad(int i)
        {
            string file = "";
            switch (i)
            {
                case 0:
                    file = File.ReadAllText("Veicoli/nuovo.json");
                    break;
                case 1:
                    file = File.ReadAllText("Veicoli/usato.json");
                    break;
                case 2:
                    file = File.ReadAllText("Veicoli/km0.json");
                    break;
                case 3:
                    file = File.ReadAllText("Veicoli/pConsegna.json");
                    break;
            }
            veicolo = JsonConvert.DeserializeObject<List<Veicolo>>(file);
        }
        public List<Veicolo> getCarList()
        {
            return veicolo;
        }
        public void userChangePassword(string email, string vpsw, string npsw)
        {
            foreach (Cliente cliente in client)
            {
                if (email == cliente.Email)
                {
                    if (vpsw == cliente.Password) cliente.Password = npsw;
                    else System.Windows.Forms.MessageBox.Show("Vecchia Password errata! Riinserire prego");
                }
            }
            fileSaving();
        }
        public bool check(string targa)
        {
            Regex rgx = new Regex(@"^[a-zA-Z]{2}[0-9]{3,4}[a-zA-Z]{2}$$");
            Console.WriteLine("{0} {1} a valid part number.", targa, rgx.IsMatch(targa) ? "is" : "is not");
            if (rgx.IsMatch(targa)) return true;
            else return false;
        }
        public string generatoreID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            return GuidString;
        }

        public string generatoreIDCliente()
        {
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            return myuuidAsString;
        }
        public float getPrezzoScontato(float prezzo, float percentuale)
        {
            return ( prezzo / 100 ) * ( 100 - percentuale );
        }
        public void aggiungiOfferta(Offerta offerta)
        {
            OfferteListLoad();
            offerte.Add(offerta);
            string json = JsonConvert.SerializeObject(offerte);
            File.WriteAllText("offerte.json", json);
        }

        private void OfferteListLoad()
        {
            string file = File.ReadAllText("offerte.json");
            offerte = JsonConvert.DeserializeObject<List<Offerta>>(file);
        }
    }
    public class Offerta
    {
        private int stato;
        private Veicolo veicolo;
        private string idUtente;

        public int Stato { get { return stato; } set { if(value == 0 || value == 1 || value == 2) stato = value; } }
        
        public Veicolo Veicolo { get { return veicolo; } set { veicolo = value; } }

        public string IDUtente { get { return idUtente; } set { idUtente = value; } }

        public Offerta()
        {
            stato = 0;
            Veicolo = new Veicolo();
            idUtente = "-";
        }

        public Offerta(int stato, Veicolo veicolo, string idUtente)
        {
            this.stato = stato;
            this.veicolo = veicolo;
            this.idUtente = idUtente;
        }
    }

    class VeicoloGenerico
    {
        private Veicolo veicolo;
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Veicolo Veicoloo
        {
            get { return veicolo; }
            set { veicolo = value; }
        }

        public VeicoloGenerico()
        {
            tipo = "-";
            veicolo = new Veicolo();
        }

        public VeicoloGenerico(string tp, Veicolo veicolo)
        {
            tipo = tp;
            this.veicolo = veicolo;
        }
    }
}
