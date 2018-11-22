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
        private string couleur;
        private int nbPortes;

        //  CONSTRUCTEUR
        public Voiture(string immat, string marque, string modèle, string typeVeh, string couleur, int nbPortes) : base(immat, marque, modèle, typeVeh)
        {
            this.couleur = couleur;
            this.nbPortes = nbPortes;
        }

        //  METHODE        
        public override string ToString()
        {
            return base.ToString() + "Couleur: " + couleur + "\n Nombre de portes: " + nbPortes + "\n";
        }
    }
}