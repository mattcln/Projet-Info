using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> NombreAléatoire = new List<int>();           
            CréerClient(NombreAléatoire);
            Console.ReadKey();            
        }
        static void CréerClient(List<int> NombreAléatoire)
        {
            Console.WriteLine("Veuillez renseigner les informations du client :" + "\nNom : ");
            string Nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string Prénom = Console.ReadLine();
            Console.WriteLine("Type de permis : ");
            string TypePermis = Console.ReadLine();
            int ID = CréerIDClient(NombreAléatoire);
            string NomClasseClient = "C" + NombreAléatoire.Count();
            Console.WriteLine(NomClasseClient);
            Client Client = new Client(Nom, Prénom, TypePermis, ID);            
        }        
        static int CréerIDClient(List<int> NombreAléatoire)
        {
            
            Random Aléatoire = new Random();
            int ID = Aléatoire.Next(100000, 999999);
            bool ExisteDeja = NombreAléatoire.Contains(ID);
            while (ExisteDeja == true)
            {                
                ID = Aléatoire.Next(100000, 999999);
                ExisteDeja = NombreAléatoire.Contains(ID);
            }
            NombreAléatoire.Add(ID);
            Console.WriteLine("ID Client : " + ID);
            return ID;
        }
        static void EnregistrerVéhicule()
        {
            Console.WriteLine("Veuillez renseigner les informations du véhicules : " + "\n Immatriculation : ");            
            string Immatriculation = Console.ReadLine();
            Console.WriteLine("Marque : ");
            string Marque = Console.ReadLine();
            Console.WriteLine("Modèle : ");
            string Modèle = Console.ReadLine();
            Console.WriteLine("Voulez - vous ajouter une moto, un camion ou une voiture ? ");
            string TypeVéhicule = Console.ReadLine();
            if (TypeVéhicule == "moto")
            {
                Console.WriteLine("Puissance : ");
                int Puissance = int.Parse(Console.ReadLine());
                Console.WriteLine("Couleur : ");
                string Couleur = Console.ReadLine();
                Moto Moto = new Moto(Immatriculation, Marque, Modèle, TypeVéhicule, Couleur, Puissance);                
            }
            if (TypeVéhicule == "camion")
            {

            }
            if (TypeVéhicule == "voiture")
            {

            }

        }
    }
}
