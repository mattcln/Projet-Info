using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Parking
    {
        protected int Arrondissement;
        protected string Place;
        protected bool Dispo;
        public bool dispo
        {
            get { return Dispo; }
        }
        public int arrondissement
        {
            get { return Arrondissement; }
        }
        public string place
        {
            get { return Place; }
        }

        public Parking(int Arrondissement, string Place, bool Dispo)
        {
            this.Arrondissement = Arrondissement;
            this.Place = Place;
            this.Dispo = Dispo;
        }
        public void ChangerDispo()
        {
            if (Dispo == true)
            {
                Dispo = false;
            }
            else Dispo = true;
        }
    }
}
