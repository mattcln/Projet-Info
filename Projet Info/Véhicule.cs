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
        public string Immat
        {
            get { return immat; }
        }

        //  CONSTRUCTEUR
        public Véhicule(string Immat, string TypeVeh, string Marque, string Modèle)
        {
            this.immat = Immat;
            this.TypeVeh = TypeVeh;
            this.Marque = Marque;
            this.Modèle = Modèle;
        }

        // METHODE

        public string TypeVehReturn
        {
            get { return TypeVeh; }
        }
        public string MarqueReturn
        {
            get { return Marque; }
        }
        public string ModèleReturn
        {
            get { return Modèle; }
        }

        public override string ToString()
        {
            string str = "";
            str = "Immatriculation: " + Immat + "\n Type de véhicule: " + TypeVeh + "\n Marque: " + Marque + "\n Modèle: " + Modèle + "\n";
            return str;
        }
    }
}
