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

        //  CONSTRUCTEUR
        public Client(string Nom, string Prénom, string TypePermis, int ID)
        {
            this.Nom = Nom;
            this.Prénom = Prénom;
            this.TypePermis = TypePermis;
            this.ID = ID;            
        }

        //  METHODE
        
        public string Tostring()
        {
            string str = "Nom: " + Nom + "\nPrénom: " + Prénom + "\nPermis : " + TypePermis + "\nID:" + ID;            
            return str;
        }
    }
}
