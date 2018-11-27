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

        public void CréerClient(List<int> NombreAléatoire)
        {            
            Console.WriteLine("Veuillez renseigner les informations du client :" + "\nNom : ");
            string Nom = Console.ReadLine();
            Console.WriteLine("Prénom : ");
            string Prénom = Console.ReadLine();
            Console.WriteLine("Type de permis : ");
            string TypePermis = Console.ReadLine();
            int ID = CréerID(NombreAléatoire);
            Client C = new Client(Nom, Prénom, TypePermis, ID);
            listClient.Add(C);            
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
                listVéhicule.Add(Moto);
            }
            if (TypeVéhicule == "camion")
            {
                Console.WriteLine("Volume : ");
                int Volume = int.Parse(Console.ReadLine());
                Camion Camion = new Camion(Immatriculation, Marque, Modèle, TypeVéhicule, Volume);
                listVéhicule.Add(Camion);
            }
            if (TypeVéhicule == "voiture")
            {
                Console.WriteLine("Couleur : ");
                string Couleur = Console.ReadLine();
                Console.WriteLine("Nombre de portes : ");
                int NbPortes = int.Parse(Console.ReadLine());
                Voiture Voiture = new Voiture(Immatriculation, Marque, Modèle, TypeVéhicule, Couleur, NbPortes);
                listVéhicule.Add(Voiture);
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
            bool ArrêtDeLaMéthode = false;
            bool NouveauClient = false;
            string LireRéponseID = "";
            while (ExistenceClient == false)
            {
                ArrêtDeLaMéthode = false;                
                if (NouveauClient == false)
                {
                    Console.WriteLine("Il n'existe aucun client avec cet ID, voulez-vous réessayer ?");
                    LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                }                                    
                while (LireRéponseID != "oui" && LireRéponseID != "non")
                {
                    Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                    LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                }                
                if(LireRéponseID == "oui")
                {                    
                    if(NouveauClient == true)
                    {
                        Console.WriteLine("Veuillez renseigner l'ID du nouveau client s'il-vous-plaît :");
                        IDClient = int.Parse(Console.ReadLine());
                        ExistenceClient = VérifierExistenceClient(IDClient);
                        if (ExistenceClient == false)
                        {
                            Console.WriteLine("Vous avez fait une erreur en recopiant l'ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Saisir l'ID du client affecté à ce trajet: ");
                        IDClient = int.Parse(Console.ReadLine());
                        ExistenceClient = VérifierExistenceClient(IDClient);
                    }
                }
                if(LireRéponseID == "non")
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
                        LireRéponseID = "oui";
                        NouveauClient = true;
                    }
                    else
                    {
                        ExistenceClient = true;
                        ArrêtDeLaMéthode = true;
                    }
                }
            }
            if (ArrêtDeLaMéthode == false) //Permet d'arrêter le programme vu que aucun ID Client n'a été affecté
            {
                Console.WriteLine("Saisir l'immatriculation du véhicule affecté à ce trajet: ");
                string Immatriculation = Console.ReadLine();
                bool ExistenceImmatriculation = false;
                ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);
                while (ExistenceImmatriculation == false)
                {
                    Console.WriteLine("Il n'existe aucun véhicule avec cet ID, vous-voulez réessayer ?");
                    string LireRéponseImmat = Console.ReadLine();
                    LireRéponseImmat = LireRéponseImmat.ToLower();
                    while (LireRéponseImmat != "oui" && LireRéponseImmat != "non")
                    {
                        Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                        LireRéponseImmat = Console.ReadLine();
                        LireRéponseImmat = LireRéponseImmat.ToLower();
                    }
                    if (LireRéponseImmat == "oui")
                    {
                        Console.WriteLine("Saisir l'immatriculation du véhicule affecté à ce trajet: ");
                        Immatriculation = Console.ReadLine();
                        ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);

                    }
                    if (LireRéponseImmat == "non")
                    {
                        Console.WriteLine("Voulez-vous créer un nouveau véhicule ?");
                        string LireRéponseVéhicule = Console.ReadLine();
                        LireRéponseVéhicule = LireRéponseVéhicule.ToLower();
                        while(LireRéponseVéhicule != "oui" && LireRéponseVéhicule != "non")
                        {
                            Console.WriteLine("Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                            LireRéponseVéhicule = Console.ReadLine();
                            LireRéponseVéhicule = LireRéponseVéhicule.ToLower();
                        }
                        if (LireRéponseVéhicule == "oui")
                        {
                            EnregistrerVéhicule();
                        }
                        else ArrêtDeLaMéthode = true;
                    }
                }
                int IDTrajet = CréerID(NombreAléatoire);
                if (ArrêtDeLaMéthode == false)
                {
                    Trajet Trajet = new Trajet(NbKm, VilleDépart, VilleArrivée, Autoroute, AllerRetour, IDClient, Immatriculation, IDTrajet);
                }                
            }
            if (ArrêtDeLaMéthode == true)
            {
                Console.WriteLine("La création du trajet est annulée, il manquait des informations.");
            }

        }
        public bool VérifierExistenceClient (int iD)
        {            
            bool existe = false;            
            for (int i = 0; i<listClient.Count;i++)
            {                
                if (listClient[i].ID == iD)
                {
                    existe = true;
                    Console.WriteLine("L'ID client est vérifié.");
                }
            }            
            return existe;
        }
        public bool VérifierExistenceImmatriculation (string immat)
        {
            bool existe = false;
            for(int i = 0; i<listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == immat)
                {                    
                    existe = true;
                    Console.WriteLine("L'immatriculation du véhicule est vérifiée.");
                }
            }
            return existe;
        }
    }
}
