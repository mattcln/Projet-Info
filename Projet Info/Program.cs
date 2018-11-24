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
            CréerClient();
            Console.ReadKey();

        }
        static void CréerClient()
        {
            Console.WriteLine("Veuillez renseigner les informations du client :" + "\nNom : ");
            string Nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string Prénom = Console.ReadLine();
            int ID = CréerIDClient();
            Client C1 = new Client(Nom, Prénom, ID);            
        }
        static int CréerIDClient()
        {
            List<int> NombreAléatoire = new List<int>();
            Random Aléatoire = new Random();
            int ID = Aléatoire.Next(100000, 999999);
            while (NombreAléatoire.BinarySearch(ID) == 0)
            {
                ID = Aléatoire.Next(100000, 999999);                
            }
            NombreAléatoire.Add(ID);
            Console.WriteLine("ID Client créée : " + ID);
            return ID;
        }
    }
}
