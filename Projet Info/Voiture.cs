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

        //  CONSTRUCTEUR
        public Voiture(string Immat, string Marque, string Modèle, string TypeVeh, string Couleur, int NbPortes) : base(Immat, Marque, Modèle, TypeVeh)
        {
            this.Couleur = Couleur;
            this.NbPortes = NbPortes;
        }

        //  METHODE        
        public override string ToString()
        {
            return base.ToString() + "Couleur: " + Couleur + "\n Nombre de portes: " + NbPortes + "\n";
        }
    }
}