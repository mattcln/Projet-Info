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

        public Moto(string Immat, string marque, string modèle, string TypeVeh, string couleur, int Puissance) : base(Immat, marque, modèle, TypeVeh)
        {
            this.Puissance = Puissance;
            this.Couleur = couleur;
        }


    }
}
