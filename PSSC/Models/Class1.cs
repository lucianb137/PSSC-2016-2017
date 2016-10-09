using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Facultate
    {
        public string denumire { get; }
        public string[] departamente { get; }

        List<Profesor> listaProfesori;
        public Facultate(string denumire, string[] departamente, List<Profesor> listaProfesori)
        {
            this.denumire = denumire;
            this.departamente = departamente;
            this.listaProfesori = listaProfesori;
        }
        public void Afisare()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Denumire facultate : " + denumire + "\n");
            str.Append("Departamente : " + departamente + "\n");
            str.Append("Profesori : ");
            string s = str.ToString();
            Console.WriteLine(s);
            foreach (var item in listaProfesori)
            {
                Console.Write(item + " ");
            }
        }
    }

    public class Materie
    {
        public string denumire { get; }
        public UInt16 nrOreCurs { get; }
        public UInt16 nrOreLab { get; }
        public UInt16 nrOreProiect { get; }
        public UInt16 nrCredite { get; }
        public string sala { get; set; }
        public Materie(string denumire, UInt16 nrOreCurs, UInt16 nrOreLab, UInt16 nrOreProiect, UInt16 nrCredite, string sala)
        {
            this.denumire = denumire;
            this.nrOreCurs = nrOreCurs;
            this.nrOreLab = nrOreLab;
            this.nrOreProiect = nrOreProiect;
            this.nrCredite = nrCredite;
            this.sala = sala;
        }
        public void Afisare()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Denumire materie : " + denumire + "\n");
            str.Append("Numar ore curs : " + nrOreCurs + "\n");
            str.Append("Numar ore laborator : " + nrOreLab + "\n");
            str.Append("Numar ore proiect : " + nrOreProiect + "\n");
            str.Append("Numar credite : " + nrCredite + "\n");
            str.Append("Sala : " + sala + "\n");
            string s = str.ToString();
            Console.WriteLine(s);
        }
    }

    public class Persoana
    {
        public string nume { get; }
        public string prenume { get; }
        public string adresa { get; }
        public string cnp { get; }
        public string sex { get; }
        public string dataNasterii { get; }
        public Persoana(string nume, string prenume, string adresa, string cnp)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.adresa = adresa;
            this.cnp = cnp;
            this.sex = CalculSex(this.cnp[0]);
            this.dataNasterii = CalculDataNasterii(cnp);
        }

        public virtual void Afisare()
        {
            StringBuilder str = new StringBuilder();
            str.Append("Nume : " + nume + "\n");
            str.Append("Prenume : " + prenume + "\n");
            str.Append("Adresa : " + adresa + "\n");
            str.Append("CNP : " + cnp + "\n");
            str.Append("Sex : " + sex + "\n");
            str.Append("Data nasterii : " + dataNasterii);
            string s = str.ToString();
            Console.WriteLine(s);
        }

        private string CalculSex(char s)
        {
            int val = Convert.ToInt16(s);
            string sex = string.Empty;
            if (s % 2 == 0)
            {
                sex = "F";
            }
            else
            {
                sex = "M";
            }
            return sex;
        }

        private string CalculDataNasterii(string cnp)
        {
            string dataNast = string.Concat(cnp[5] + "" + cnp[6] + "." + cnp[3] + cnp[4] + ".");
            if (cnp[0] == '1' || cnp[0] == '2')
            {
                dataNast = dataNast + "19" + cnp[1] + cnp[2];
            }
            if (cnp[0] == '3' || cnp[0] == '4')
            {
                dataNast = dataNast + "18" + cnp[1] + cnp[2];
            }
            if (cnp[0] == '5' || cnp[0] == '6')
            {
                dataNast = dataNast + "20" + cnp[1] + cnp[2];
            }
            return dataNast;
        }
    }

    public class Student : Persoana
    {
        UInt16 marca { get; }
        UInt16 an { get; set; }
        string facultate { get; }
        public Student(string nume, string prenume, string adresa, string cnp, UInt16 marca, string facultate, UInt16 an) : base(nume, prenume, adresa, cnp)
        {
            this.marca = marca;
            this.an = an;
            this.facultate = facultate;
        }

        public override void Afisare()
        {
            base.Afisare();
            StringBuilder str = new StringBuilder();
            str.Append("Marca : " + marca + "\n");
            str.Append("An : " + an + "\n");
            str.Append("Facultate : " + facultate + "\n");
            string s = str.ToString();
            Console.WriteLine(s);
        }
    }

    public class Profesor : Persoana
    {
        string departament { get; }
        UInt16 salariu { get; set; }
        Materie[] materii { get; set; }
        public Profesor(string nume, string prenume, string adresa, string cnp, string dep, UInt16 salariu, params Materie[] materii) : base(nume, prenume, adresa, cnp)
        {
            this.departament = dep;
            this.salariu = salariu;
            this.materii = materii;
        }
        public override void Afisare()
        {
            base.Afisare();
            StringBuilder str = new StringBuilder();
            str.Append("Departament : " + departament + "\n");
            str.Append("Salariu : " + salariu + "\n");
            str.Append("Materii : ");
            string s = str.ToString();
            Console.WriteLine(s);
            foreach (Materie m in materii)
            {
                Console.WriteLine(m.denumire + " in sala : " + m.sala);
            }
        }
    }
}