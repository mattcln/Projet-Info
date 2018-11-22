using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Véhicule
    {
        //  ATTRIBUTS
        protected string immat;
        protected string typeVeh;
        protected string marque;
        protected string modèle;
        protected string couleur;
        protected int nbPortes;

        //  CONSTRUCTEUR
        public Véhicule(string immat, string typeVeh, string marque, string modèle, string couleur, int nbPortes)
        {
            this.immat = immat;
            this.typeVeh = typeVeh;
            this.marque = marque;
            this.modèle = modèle;
            this.couleur = couleur;
            this.nbPortes = nbPortes;
        }

        // METHODE

        

    }
}
