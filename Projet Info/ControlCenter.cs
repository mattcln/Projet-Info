﻿using System;
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

        public void CréerClient(List<int> NombreAléatoire)
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
        public int CréerID(List<int> NombreAléatoire)
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

        public void EnregistrerVéhicule()
        {
            Console.WriteLine("Veuillez renseigner les informations du véhicule : " + "\n Immatriculation : ");
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
        public void CréerTrajet()
        {
            Console.WriteLine("Veuillez renseigner les informations du véhicule : " + "\nVille de départ : ");
            string VilleDépart = Console.ReadLine();
            Console.WriteLine("Ville d'arrivée : ");
            string VilleArrivée = Console.ReadLine();
            Console.WriteLine("Nombre de km à parcourir : ");
            int NbKm = int.Parse(Console.ReadLine());
            Console.WriteLine("Est-ce que le trajet est sur autoroute ? : ");
            string LireAutoRoute = Console.ReadLine();
            LireAutoRoute = LireAutoRoute.ToLower();
            bool Autoroute = false;
            while(LireAutoRoute != "oui" && LireAutoRoute != "non")
            {
                Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :" );
                LireAutoRoute = Console.ReadLine();
                LireAutoRoute = LireAutoRoute.ToLower();
            }
            if (LireAutoRoute == "oui")
            {
                Autoroute = true;
            }
            Console.WriteLine("Est-ce un trajet Aller/Retour ? : ");
            string LireAllerRetour = Console.ReadLine();
            LireAllerRetour = LireAllerRetour.ToLower();
            bool AllerRetour = false;
            while (LireAllerRetour != "oui" && LireAllerRetour != "non")
            {
                Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                LireAllerRetour = Console.ReadLine();
                LireAllerRetour = LireAllerRetour.ToLower();
            }
            if (LireAllerRetour == "oui")
            {
                AllerRetour = true;
            }
            Console.WriteLine("Saisir l'ID du client affecté à ce trajet: ");
            int IDClient = int.Parse(Console.ReadLine());
            bool ExistenceClient = false;
            ExistenceClient = VérifierExistenceClient(IDClient);
            while (ExistenceClient == false) //Faut créer un while pour vérifier si l'ID du client existe bien (et sinon proposer de créer un nouveau client je pense)
            {
                Console.WriteLine("Il n'existe aucun client avec cet ID, voulez-vous réessayer ?");
                string LireRéponseID = Console.ReadLine();
                LireRéponseID = LireRéponseID.ToLower();
                bool RéponseID = false;
                while (LireRéponseID != "oui" && LireRéponseID != "non")
                {
                    Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                    LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                }
                if (LireRéponseID == "oui")
                {
                    RéponseID = true;
                }
                if(RéponseID == true)
                {
                    Console.WriteLine("Saisir l'ID du client affecté à ce trajet: ");
                    IDClient = int.Parse(Console.ReadLine());
                    ExistenceClient = VérifierExistenceClient(IDClient);
                }
                if(RéponseID == false)
                {
                    Console.WriteLine("Voulez-vous créer le profil de ce client ?");
                    string LireRéponseProfile = Console.ReadLine();
                    LireRéponseProfile = LireRéponseProfile.ToLower();                    
                    while(LireRéponseProfile != "oui" && LireRéponseProfile != "non")
                    {
                        Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                        LireRéponseProfile = Console.ReadLine();
                        LireRéponseProfile = LireRéponseProfile.ToLower();
                    }
                    if (LireRéponseProfile == "oui")
                    {
                        CréerClient(NombreAléatoire);
                    }
                    else ExistenceClient = true; // y'a un soucis ici, faudrait que le void s'arrête parce qu'on a décidé de rien faire finalement
                }
            }
            Console.WriteLine("Saisir l'immatriculation du véhicule affecté à ce trajet: ");
            string Immatriculation = Console.ReadLine();
            //while () //Faut créer un while pour vérifier si l'immat existe bien (et sinon proposer de créer un nouveau véhicule je pense)
            {

            }
            int IDTrajet = CréerID(NombreAléatoire);
            Trajet Trajet = new Trajet(NbKm, VilleDépart, VilleArrivée, Autoroute, AllerRetour, IDClient, Immatriculation, IDTrajet);

        }
        public bool VérifierExistenceClient (int iD)
        {
            bool existe = false;
            for (int i = 0; i<listClient.Count;i++)
            { 
                if (listClient[i].ID == iD)
                {
                    existe = true;
                }
            }
            return existe;
        }
    }
}
