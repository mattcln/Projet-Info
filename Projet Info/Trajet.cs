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
        private List<Véhicule> listVeh;

        public Trajet(int NbKm, string VilleDépart, string VilleArrivée, bool Autoroute, bool AllerRetour)
        {
            this.NbKm = NbKm;
            this.VilleDépart = VilleDépart;
            this.VilleArrivée = VilleArrivée;
            this.Autoroute = Autoroute;
            this.AllerRetour = AllerRetour;
            listVeh = new List<Véhicule>();
        }

        public void AjoutVéhicule(Véhicule V)
        {
            listVeh.Add(V);
        }
        public void SuppVéhicule(Véhicule V)
        {
            listVeh.Remove(V);
        }
        public override string ToString()
        {
            string str = "";
            str = "Nombre de kilomètre : " + NbKm + "\nVille de départ : " + VilleDépart + "\nVille d'arrivée : " + VilleArrivée + "\nAutoroute : " + Autoroute + "\nAller / Retour : " + AllerRetour;
            Console.WriteLine("Voici les informations du véhicule assigné au trajet : ");
            for (int i = 0; i < listVeh.Count; i++)
            {
                str += listVeh[i].ToString();
            }      //Je comprends pas trop cette méthode, la ça affiche tout les véhicules de la liste nan ?

            return str;
        }
    }
}
