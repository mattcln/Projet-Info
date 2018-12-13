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
        //  CONSTRUCTEUR
        public Véhicule(string Immat, string TypeVeh, string Marque, string Modèle, string Contrôleur)
        {
            this.immat = Immat;
            this.TypeVeh = TypeVeh;
            this.Marque = Marque;
            this.Modèle = Modèle;
            this.Contrôleur = Contrôleur;
        }

        // METHODE        

        public override string ToString()
        {
            string str = "";
            str = Immat + ";" + TypeVeh + ";" + Marque + ";" + Modèle + ";" + Contrôleur;
            return str;
        }
        public abstract double CalculCout(int NbKm);        
    }
}
