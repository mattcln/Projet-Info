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
        public string nom
        {
            get { return Nom; }
        }
        public string prénom
        {
            get { return Prénom; }
        }
        public string typepermis
        {
            get { return TypePermis; }
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
            string str = "\n|Nom: " + Nom + "\n|Prénom: " + Prénom + "\n|Permis : " + TypePermis + "\n|ID:" + ID;            
            return str;            
        }        
    }
}
