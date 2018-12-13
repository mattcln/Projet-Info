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
        bool Dispo;

        Parking(int Arrondissement, string Place, bool Dispo)
        {
            this.Arrondissement = Arrondissement;
            this.Place = Place;
            this.Dispo = Dispo;
        }
    }
}
