using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_Info
{
    abstract class Véhicule
    {
        //  ATTRIBUTS
        protected string immat;
        protected string TypeVeh;
        protected string Marque;
        protected string Modèle;
        protected string Contrôleur;
        protected string Emplacement;
        protected int NbKm;
        public string Immat
        {
            get { return immat; }
        }
        public string typeveh
        {
            get { return TypeVeh; }
        }
        public string marque
        {
            get { return Marque; }
        }
        public string modèle
        {
            get { return Modèle; }
        }
        public string contrôleur
        {
            get { return Contrôleur; }
        }
        public string emplacement
        {
            get { return Emplacement; }
        }
        public int nbkm
        {
            get { return NbKm; }
        }
        //  CONSTRUCTEUR
        public Véhicule(string Immat, string TypeVeh, string Marque, string Modèle, string Contrôleur, string Emplacement, int NbKm)
        {
            this.immat = Immat;
            this.TypeVeh = TypeVeh;
            this.Marque = Marque;
            this.Modèle = Modèle;
            this.Contrôleur = Contrôleur;
            this.Emplacement = Emplacement;
            this.NbKm = NbKm;
        }

        // METHODE        

        public override string ToString()
        {
            string str = "";
            str = Immat + ";" + TypeVeh + ";" + Marque + ";" + Modèle + ";" + Contrôleur + ";" + Emplacement + ";" + NbKm;
            return str;
        }
        public abstract double CalculCout(int NbKm);
        public void ChangerEmplacement(string NewEmplacement)
        {
            Emplacement = NewEmplacement;            
        }
        public void AjouterKm(int NbKmEnPlus)
        {
            NbKm += NbKmEnPlus;
            Console.WriteLine(NbKmEnPlus + "km ont été ajoutés au véhicule.");
            Console.WriteLine("\nCe véhicule a maintenant parcouru un total de " + NbKm + "km.");
        }
    }
}
