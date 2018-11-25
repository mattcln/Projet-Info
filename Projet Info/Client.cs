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
        private string Nom;
        private string Prénom;
        private string TypePermis;
        private int ID; 
        private List<Véhicule> listVeh;

        //  CONSTRUCTEUR
        public Client(string Nom, string Prénom, string TypePermis, int ID)
        {
            this.Nom = Nom;
            this.Prénom = Prénom;
            this.TypePermis = TypePermis;
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
        public string Tostring()
        {
            string str = "Nom: " + Nom + "Prénom: " + Prénom + "Permis : " + TypePermis + "ID:" + ID + "\n";
            for (int i = 0; i < listVeh.Count; i++)
            {
                str += listVeh[i].ToString();
            }
            return str;
        }
    }
}
