using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Client
    {
        //  ATTRIBUTS
        private string nom;
        private string prénom;
        private string typePermis;
        private int ID;  // string ou int, à choisir en fonction du type d'ID
        private List<Véhicule> listVeh;

        //  CONSTRUCTEUR
        public Client(string nom, string prénom, int ID)
        {
            this.nom = nom;
            this.prénom = prénom;
            this.ID = ID;
            listVeh = new List<Véhicule>();
        }

        //  METHODE
        public void AjoutVéhicule(Véhicule V)
        {
            listVeh.Add(V);
        }
        public void SuppVéhicule(Véhicule V)
        {
            listVeh.Remove(V);
        }
        public override string Tostring()
        {
            string str = "Véhicule: " + nom + "\n";
            for (int i = 0; i < listVeh.Count; i++)
            {
                str += listVeh[i].ToString();
            }
            return str;
        }
    }
}
