using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_Info
{
    class ControlCenter
    {
        List<int> NombreAléatoire = new List<int>();
        private List<Véhicule> listVéhicule;
        private List<Client> listClient;
        private List<Trajet> listTrajet;
        private List<Voiture> listVoiture;
        private List<Moto> listMoto;
        private List<Camion> listCamion;

        public ControlCenter()
        {
            listVéhicule = new List<Véhicule>();
            listClient = new List<Client>();
            listTrajet = new List<Trajet>();
            listVoiture = new List<Voiture>();
            listMoto = new List<Moto>();
            listCamion = new List<Camion>();
        }

        public void CréerClient(List<int> NombreAléatoire)
        {
            Console.Clear();
            Console.WriteLine("Veuillez renseigner les informations du client :" + "\n" + "\nNom : ");
            string Nom = Console.ReadLine();
            Console.WriteLine("\nPrénom : ");
            string Prénom = Console.ReadLine();
            Console.WriteLine("\nType de permis : ");
            string TypePermis = Console.ReadLine();
            int ID = CréerID(NombreAléatoire);
            Client C = new Client(Nom, Prénom, TypePermis, ID);
            listClient.Add(C);
            Console.Clear();
            SauvegardeClient();
        }
        public void SupprimerClient()
        {
            Console.WriteLine("Veuillez renseigner l'ID du client que vous voulez supprimer:");
            bool Supprimer = false;
            int ID = int.Parse(Console.ReadLine());
            for (int i = 0; i < listClient.Count; i++)
            {
                if (listClient[i].ID == ID)
                {
                    listClient.RemoveAt(i);
                    Supprimer = true;
                }
            }
            Console.Clear();
            if (Supprimer == true)
            {
                Console.WriteLine("Le client a bien été supprimé.");
            }
            else Console.WriteLine("Aucun client avec cet ID n'a été trouvé.");
            SauvegardeClient();
        }
        public void InformationsClient()
        {
            Console.WriteLine("Quel est l'ID du client dont voulez-vous avoir les informations ?");
            int IDClient = int.Parse(Console.ReadLine());
            string Informations = ""; bool Trouvé = false;
            for (int i = 0; i < listClient.Count; i++)
            {
                if (listClient[i].ID == IDClient)
                {
                    Informations = listClient[i].Tostring();
                    Trouvé = true;
                }
            }
            if (Trouvé == true)
            {
                Console.WriteLine(Informations);
            }
            else Console.WriteLine("\nAucun client avec cet ID n'a été trouvé.");            

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
            Console.WriteLine("ID : " + ID);
            return ID;
        }
        public void EnregistrerVéhicule()
        {
            Console.Clear();
            Console.WriteLine(" Veuillez renseigner les informations du véhicule : " + "\n" + "\n Immatriculation : ");
            string Immatriculation = Console.ReadLine();
            Console.WriteLine("\nMarque : ");
            string Marque = Console.ReadLine();
            Console.WriteLine("\nModèle : ");
            string Modèle = Console.ReadLine();
            string TypeVéhicule = "";
            Console.WriteLine("\nVoulez - vous ajouter une moto, un camion ou une voiture ? ");
            while (TypeVéhicule != "moto" && TypeVéhicule != "camion" && TypeVéhicule != "voiture")
            {  
                TypeVéhicule = Console.ReadLine();
                TypeVéhicule = TypeVéhicule.ToLower();
                if (TypeVéhicule != "moto" && TypeVéhicule != "camion" && TypeVéhicule != "voiture")
                {
                    Console.WriteLine("Ceci n'est pas un véhicule valide, veuillez réessayer s'il-vous-plaît.");
                }
            }
            if (TypeVéhicule == "moto")
            {
                Console.WriteLine("\nPuissance : ");
                int Puissance = int.Parse(Console.ReadLine());
                Console.WriteLine("\nCouleur : ");
                string Couleur = Console.ReadLine();
                Moto Moto = new Moto(Immatriculation, Marque, Modèle, TypeVéhicule, Couleur, Puissance);
                listVéhicule.Add(Moto);
            }
            if (TypeVéhicule == "camion")
            {
                Console.WriteLine("\nVolume : ");
                int Volume = int.Parse(Console.ReadLine());
                Camion Camion = new Camion(Immatriculation, Marque, Modèle, TypeVéhicule, Volume);
                listVéhicule.Add(Camion);
            }
            if (TypeVéhicule == "voiture")
            {
                Console.WriteLine("\nCouleur : ");
                string Couleur = Console.ReadLine();
                Console.WriteLine("\nNombre de portes : ");
                int NbPortes = int.Parse(Console.ReadLine());
                Voiture Voiture = new Voiture(Immatriculation, Marque, Modèle, TypeVéhicule, Couleur, NbPortes);                
                listVéhicule.Add(Voiture);                
            }
            SauvegardeVéhicule();
        }        
        public void CréerTrajet()
        {
            Console.Clear();
            Console.WriteLine("Veuillez renseigner les informations du trajet : " + "\n" + "\nVille de départ : ");
            string VilleDépart = Console.ReadLine();
            Console.WriteLine("\nVille d'arrivée : ");
            string VilleArrivée = Console.ReadLine();
            Console.WriteLine("\nNombre de km à parcourir : ");
            int NbKm = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEst-ce que le trajet est sur autoroute ? : ");            
            string LireAutoRoute = OuiNon();
            bool Autoroute = false;
            if (LireAutoRoute == "oui")
            {
                Autoroute = true;
            }
            Console.WriteLine("\nEst-ce un trajet Aller/Retour ? : ");
            string LireAllerRetour = OuiNon();
            bool AllerRetour = false;            
            if (LireAllerRetour == "oui")
            {
                AllerRetour = true;
            }
            Console.WriteLine("\nSaisir l'ID du client affecté à ce trajet: ");
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
                    Console.WriteLine("\nIl n'existe aucun client avec cet ID, voulez-vous réessayer ?");
                    LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                }                                    
                while (LireRéponseID != "oui" && LireRéponseID != "non")
                {
                    Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                    LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                }                
                if(LireRéponseID == "oui")
                {                    
                    if(NouveauClient == true)
                    {
                        Console.WriteLine("\nVeuillez renseigner l'ID du nouveau client s'il-vous-plaît :");
                        IDClient = int.Parse(Console.ReadLine());
                        ExistenceClient = VérifierExistenceClient(IDClient);
                        if (ExistenceClient == false)
                        {
                            Console.WriteLine("\nVous avez fait une erreur en recopiant l'ID.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSaisir l'ID du client affecté à ce trajet: ");
                        IDClient = int.Parse(Console.ReadLine());
                        ExistenceClient = VérifierExistenceClient(IDClient);
                    }
                }
                if(LireRéponseID == "non")
                {
                    Console.WriteLine("\nVoulez-vous créer le profil de ce client ?");
                    string LireRéponseProfile = Console.ReadLine();
                    LireRéponseProfile = LireRéponseProfile.ToLower();                    
                    while(LireRéponseProfile != "oui" && LireRéponseProfile != "non")
                    {
                        Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
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
            bool NouvelleImmatriculation = false;
            bool ExistenceImmatriculation = false;
            string Immatriculation = "";
            if (ArrêtDeLaMéthode == false) //Permet d'arrêter le programme vu que aucun ID Client n'a été affecté
            {
                if (NouvelleImmatriculation == false)
                {
                    Console.WriteLine("\nSaisir l'immatriculation du véhicule affecté à ce trajet: ");
                    Immatriculation = Console.ReadLine();                    
                    ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);
                }
                string LireRéponseImmat = "";
                while (ExistenceImmatriculation == false)
                {                    
                    if (NouvelleImmatriculation == false)
                    {
                        Console.WriteLine("\nIl n'existe aucun véhicule avec cet immatriculation, vous-voulez réessayer ?");
                        LireRéponseImmat = Console.ReadLine();
                        LireRéponseImmat = LireRéponseImmat.ToLower();
                    }                    
                    
                    while (LireRéponseImmat != "oui" && LireRéponseImmat != "non")
                    {
                        Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                        LireRéponseImmat = Console.ReadLine();
                        LireRéponseImmat = LireRéponseImmat.ToLower();
                    }
                    if (LireRéponseImmat == "oui")
                    {
                        if (NouvelleImmatriculation == true)
                        {
                            while (ExistenceImmatriculation == false)
                            {
                                Console.WriteLine("\nVeuillez renseigner l'immatriculation du nouveau véhicule s'il-vous-plaît :");
                                Immatriculation = Console.ReadLine();
                                ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);
                                if (NouvelleImmatriculation == false)
                                {
                                    Console.WriteLine("\nVous avez fait une erreur en recopiant l'immatriculation.");
                                }
                            }                            
                        }
                        else
                        {
                            Console.WriteLine("\nSaisir l'immatriculation du véhicule affecté à ce trajet: ");
                            Immatriculation = Console.ReadLine();
                            ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);
                        }
                    }
                    if (LireRéponseImmat == "non")
                    {
                        Console.WriteLine("\nVoulez-vous créer un nouveau véhicule ?");
                        string LireRéponseVéhicule = Console.ReadLine();
                        LireRéponseVéhicule = LireRéponseVéhicule.ToLower();
                        while(LireRéponseVéhicule != "oui" && LireRéponseVéhicule != "non")
                        {
                            Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                            LireRéponseVéhicule = Console.ReadLine();
                            LireRéponseVéhicule = LireRéponseVéhicule.ToLower();
                        }
                        if (LireRéponseVéhicule == "oui")
                        {
                            EnregistrerVéhicule();
                            LireRéponseImmat = "oui";
                            NouvelleImmatriculation = true;
                        }
                        else ArrêtDeLaMéthode = true;
                    }
                }
                Console.WriteLine("Création d'un ID pour le trajet :");
                int IDTrajet = CréerID(NombreAléatoire);
                if (ArrêtDeLaMéthode == false)
                {
                    Trajet Trajet = new Trajet(NbKm, VilleDépart, VilleArrivée, Autoroute, AllerRetour, IDClient, Immatriculation, IDTrajet, true);
                    SauvegardeTrajet();
                }
            }
            if (ArrêtDeLaMéthode == true)
            {
                Console.WriteLine("\nLa création du trajet est annulée, il manquait des informations.");
            }
            Console.Clear();
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
        public void ChargementDonnées()
        {
            try
            {
                string LocalisationClient = "C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Clients.txt";
                StreamReader LectureFichierClient = new StreamReader(LocalisationClient);
                string ligne = "";
                while (LectureFichierClient.EndOfStream == false)
                {
                    ligne = LectureFichierClient.ReadLine();
                    string[] tab = ligne.Split(';');
                    int ID = Convert.ToInt32(tab[3]);
                    Client C = new Client(tab[0], tab[1], tab[2], ID);
                    listClient.Add(C);
                }                
                LectureFichierClient.Close();
                string LocalisationVéhicules = "C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Véhicules.txt";
                StreamReader LectureFichierVéhicules = new StreamReader(LocalisationVéhicules);                
                while (LectureFichierVéhicules.EndOfStream == false)
                {                    
                    ligne = LectureFichierVéhicules.ReadLine();
                    string[] tab = ligne.Split(';');                    
                    if (tab[3] == "voiture")
                    {                        
                        int NbPortes = Convert.ToInt32(tab[5]);                        
                        Voiture Voiture = new Voiture(tab[0], tab[1], tab[2], tab[3], tab[4], NbPortes);                        
                        listVéhicule.Add(Voiture);                        
                    }
                    if (tab[3] == "camion")
                    {
                        int VolumeCamion = Convert.ToInt32(tab[5]);
                        Camion Camion = new Camion(tab[0], tab[1], tab[2], tab[3], VolumeCamion);
                        listVéhicule.Add(Camion);                        
                    }
                    if (tab[3] == "moto")
                    {
                        int Puissance = Convert.ToInt32(tab[5]);
                        Moto Moto = new Moto(tab[0], tab[1], tab[2], tab[3], tab[4], Puissance);
                        listVéhicule.Add(Moto);                        
                    }                    
                }
                LectureFichierVéhicules.Close(); 
                string LocationTrajets = "C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Trajets.txt";
                StreamReader LectureFichierTrajets = new StreamReader(LocationTrajets);
                while (LectureFichierTrajets.EndOfStream == false)
                {
                    ligne = LectureFichierTrajets.ReadLine();
                    string[] tab = ligne.Split(';');
                    int NbKm = Convert.ToInt32(tab[0]);
                    int IDTrajet = Convert.ToInt32(tab[7]);
                    int IDClient = Convert.ToInt32(tab[5]);
                    bool Autoroute; bool AllerRetour; bool Actif;
                    if (tab[3] == "true")
                    {
                        Autoroute = true;
                    }
                    else Autoroute = false;
                    if (tab[4] == "true")
                    {
                        AllerRetour = true;
                    }
                    else AllerRetour = false;
                    if (tab[8] == "true")
                    {
                        Actif = true;
                    }
                    else Actif = false;
                    Trajet T = new Trajet(NbKm, tab[1], tab[2], Autoroute, AllerRetour, IDClient, tab[6], IDTrajet, Actif);
                    LectureFichierTrajets.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SauvegardeClient()
        {
            try
            {
                StreamWriter EcritureFichierClient = new StreamWriter("C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Clients.txt");                
                for (int i = 0; i < listClient.Count; i++)
                {
                    EcritureFichierClient.WriteLine(listClient[i].nom + ";" + listClient[i].prénom + ";" + listClient[i].typepermis + ";" + listClient[i].ID);                    
                }
                EcritureFichierClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SauvegardeVéhicule()
        {
            try
            {
                StreamWriter EcritureFichierVéhicule = new StreamWriter("C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Véhicules.txt");        
        
                for (int i = 0; i<listVéhicule.Count; i++)
                {                    
                    string str = listVéhicule[i].ToString();
                    EcritureFichierVéhicule.WriteLine(str);                        
                }
                EcritureFichierVéhicule.Close();                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SauvegardeTrajet()
        {
            try
            {
                StreamWriter EcritureFichierTrajets = new StreamWriter("C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Trajets.txt");
                for (int i = 0; i < listClient.Count; i++)
                {
                    EcritureFichierTrajets.WriteLine(listTrajet[i].nbKm + ";" + listTrajet[i].villedépart + ";" + listTrajet[i].villearrivée + ";" + listTrajet[i].autoroute + ";" + listTrajet[i].allerretour + ";" + listTrajet[i].idclient + ";" + listTrajet[i].immatriculation + ";" + listTrajet[i].idtrajet + ";" + listTrajet[i].actif);
                }
                EcritureFichierTrajets.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void MaJTrajet(int IDTrajet)
        {
            bool Continue = true;
            while (Continue == true)
            {
                bool Existe = false;
                for (int i = 0; i < listTrajet.Count; i++)
                {
                    if (listTrajet[i].idtrajet == IDTrajet || listTrajet[i].actif == true)
                    {
                        Console.WriteLine("Le trajet a bien été sélectionné, il est actuellement considéré étant en cours. Voulez-vous cloturer le trajet ?");
                        string LireRéponseID = Console.ReadLine();
                        LireRéponseID = LireRéponseID.ToLower();
                        while (LireRéponseID != "oui" && LireRéponseID != "non")
                        {
                            Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                            LireRéponseID = Console.ReadLine();
                            LireRéponseID = LireRéponseID.ToLower();
                        }
                        if(LireRéponseID == "oui")
                        {
                            for (int j = 0; j<listTrajet.Count;j++)
                            {
                                if (listTrajet[j].idtrajet == IDTrajet)
                                {
                                    listTrajet[j].ChangerActif();
                                }
                            }
                        }
                    }
                    if (listTrajet[i].idtrajet == IDTrajet || listTrajet[i].actif == false)
                    {
                        Console.WriteLine("Le trajet a bien été sélectionné, il est actuellement considéré étant cloturer. Voulez-vous relancer le trajet ?");
                        string LireRéponseID = Console.ReadLine();
                        LireRéponseID = LireRéponseID.ToLower();
                        while (LireRéponseID != "oui" && LireRéponseID != "non")
                        {
                            Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                            LireRéponseID = Console.ReadLine();
                            LireRéponseID = LireRéponseID.ToLower();
                        }
                        if (LireRéponseID == "oui")
                        {
                            for (int j = 0; j < listTrajet.Count; j++)
                            {
                                if (listTrajet[j].idtrajet == IDTrajet)
                                {
                                    listTrajet[j].ChangerActif();
                                }
                            }
                        }
                    }
                }
                if (Existe == false)
                {
                    Console.WriteLine("\nIl n'existe aucun trajet avec cet ID, voulez-vous essayer un autre ID ?");                    
                    string LireRéponseID = Console.ReadLine();
                    LireRéponseID = LireRéponseID.ToLower();
                    while (LireRéponseID != "oui" && LireRéponseID != "non")
                    {
                        Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                        LireRéponseID = Console.ReadLine();
                        LireRéponseID = LireRéponseID.ToLower();
                    }
                    if (LireRéponseID == "non")
                    {
                        Continue = false;       
                    }
                }
            }
            
        }
        public string OuiNon()
        {
            string Réponse = Console.ReadLine();
            Réponse = Réponse.ToLower();
            while (Réponse != "oui" && Réponse != "non")
            {
                Console.WriteLine("\n Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît:");
                Réponse = Console.ReadLine();
                Réponse = Réponse.ToLower();
            }
            return Réponse;
        }

    }
}
