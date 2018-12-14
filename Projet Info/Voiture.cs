using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Voiture : Véhicule
    {
        //  ATTRIBUTS
        private string Couleur;
        private int NbPortes;
        public string couleur
        {
            get { return Couleur; }
        }
        public int nbportes
        {
            get { return NbPortes; }
        }

        //  CONSTRUCTEUR
        public Voiture(string immat, string Marque, string Modèle, string TypeVeh, string Contrôleur, string Emplacement, string Couleur, int NbPortes) : base(immat, Marque, Modèle, TypeVeh, Contrôleur, Emplacement)
        {
            this.Couleur = Couleur;
            this.NbPortes = NbPortes;
        }

        //  METHODE        
        public override string ToString()
        {
            return base.ToString() + ";" + Couleur + ";" + NbPortes;
        }

        public override double CalculCout(int nbKm)
        {
            double c = 0;
            c = 0.25 * nbKm;
            return c;
        }
    }
}