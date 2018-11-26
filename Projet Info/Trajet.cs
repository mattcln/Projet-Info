using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Trajet
    {
        private int NbKm;
        private string VilleDépart;
        private string VilleArrivée;
        private bool Autoroute;
        private bool AllerRetour;
        private int IDClient;
        private string Immatriculation;

        public Trajet(int NbKm, string VilleDépart, string VilleArrivée, bool Autoroute, bool AllerRetour, int IDClient, string Immatriculation)
        {
            this.NbKm = NbKm;
            this.VilleDépart = VilleDépart;
            this.VilleArrivée = VilleArrivée;
            this.Autoroute = Autoroute;
            this.AllerRetour = AllerRetour;
            this.IDClient = IDClient;
            this.Immatriculation = Immatriculation;
        }
        
        public override string ToString()
        {
            string str = "";
            str = "Nombre de kilomètre : " + NbKm + "\nVille de départ : " + VilleDépart + "\nVille d'arrivée : " + VilleArrivée + "\nAutoroute : " + Autoroute + "\nAller / Retour : " + AllerRetour;            
            return str;
        }               
    }
}
