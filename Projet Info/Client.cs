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
        private int iD;
        public int ID
        {
            get { return iD; }
        }

        //  CONSTRUCTEUR
        public Client(string Nom, string Prénom, string TypePermis, int iD)
        {
            this.Nom = Nom;
            this.Prénom = Prénom;
            this.TypePermis = TypePermis;
            this.iD = iD;            
        }

        //  METHODE
        
        public string Tostring()
        {
            string str = "|Nom: " + Nom + "\nPrénom: " + Prénom + "\nPermis : " + TypePermis + "\nID:" + ID;            
            return str;            
        }        
    }
}
