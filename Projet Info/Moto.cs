using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Moto : Véhicule
    {
        private int Puissance;
        private string Couleur;
        
        public Moto(string Immat, string Marque, string Modèle, string TypeVeh, string Couleur, int Puissance) : base(Immat, Marque, Modèle, TypeVeh)
        {
            this.Puissance = Puissance;
            this.Couleur = Couleur;
        }

        public override string ToString()
        {
            return base.ToString() + "Couleur: " + Couleur + "\n Puissance du moteur: " + Puissance + "\n";
        }
    }
}
