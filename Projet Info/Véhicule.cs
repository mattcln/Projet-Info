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
        protected string Immat;
        protected string TypeVeh;
        protected string marque;
        protected string modèle;

        //  CONSTRUCTEUR
        public Véhicule(string Immat, string TypeVeh, string marque, string modèle)
        {
            this.Immat = Immat;
            this.TypeVeh = TypeVeh;
            this.marque = marque;
            this.modèle = modèle;
        }

        // METHODE

        public string ImmatReturn
        {
            get { return Immat; }
        }
        public string TypeVehReturn
        {
            get { return TypeVeh; }
        }
        public string MarqueReturn
        {
            get { return marque; }
        }
        public string ModèleReturn
        {
            get { return modèle; }
        }

        public override string ToString()
        {
            string str = "";
            str = "Immatriculation: " + Immat + "\n Type de véhicule: " + TypeVeh + "\n Marque: " + marque + "\n Modèle: " + modèle + "\n";
            return str;
        }
    }
}
