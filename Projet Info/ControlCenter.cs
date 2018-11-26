using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class ControlCenter
    {
        List<int> NombreAléatoire = new List<int>();
        private List<Véhicule> listVéhicule;
        private List<Client> listClient;
        private List<Trajet> listTrajet;

        public ControlCenter()
        {
            listVéhicule = new List<Véhicule>();
            listClient = new List<Client>();
            listTrajet = new List<Trajet>();
        }

        static void CréerClient(List<int> NombreAléatoire)
        {
            Console.WriteLine("Veuillez renseigner les informations du client :" + "\nNom : ");
            string Nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string Prénom = Console.ReadLine();
            Console.WriteLine("Type de permis : ");
            string TypePermis = Console.ReadLine();
            int ID = CréerID(NombreAléatoire);
            Client Client = new Client(Nom, Prénom, TypePermis, ID);
        }
        static int CréerID(List<int> NombreAléatoire)
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
            Console.WriteLine("ID : " + ID);
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
            TypeVéhicule = TypeVéhicule.ToLower(); //Permet de mettre le string en minuscule pour être sure que le type soit compris
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
                Console.WriteLine("Volume : ");
                int Volume = int.Parse(Console.ReadLine());
                Camion Camion = new Camion(Immatriculation, Marque, Modèle, TypeVéhicule, Volume);
            }
            if (TypeVéhicule == "voiture")
            {
                Console.WriteLine("Couleur : ");
                string Couleur = Console.ReadLine();
                Console.WriteLine("Nombre de portes : ");
                int NbPortes = int.Parse(Console.ReadLine());
                Voiture Voiture = new Voiture(Immatriculation, Marque, Modèle, TypeVéhicule, Couleur, NbPortes);
            }
        }
        static void CréerTrajet()
        {

        }
    }
}
