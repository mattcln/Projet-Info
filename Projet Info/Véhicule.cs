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
        protected string typeVeh;
        protected string marque;
        protected string modèle;

        //  CONSTRUCTEUR
        public Véhicule(string immat, string typeVeh, string marque, string modèle)
        {
            this.immat = immat;
            this.typeVeh = typeVeh;
            this.marque = marque;
            this.modèle = modèle;
        }

        // METHODE

        public string Immat
        {
            get { return immat; }
        }
        public string TypeVeh
        {
            get { return typeVeh; }
        }
        public string Marque
        {
            get { return marque; }
        }
        public string Modèle
        {
            get { return modèle; }
        }

        public override string ToString()
        {
            string str = "";
            str = "Immatriculation: " + immat + "\n Type de véhicule: " + typeVeh + "\n Marque: " + marque + "\n Modèle: " + modèle + "\n";
            return str;
        }
    }
}
