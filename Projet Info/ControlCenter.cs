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
        private List<Parking> listParking;

        public ControlCenter()
        {
            listVéhicule = new List<Véhicule>();
            listClient = new List<Client>();
            listTrajet = new List<Trajet>();
            listVoiture = new List<Voiture>();
            listMoto = new List<Moto>();
            listCamion = new List<Camion>();
            listParking = new List<Parking>();
        }

                //CLIENTS
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
            Client C = new Client(Nom, Prénom, TypePermis, ID, 0);
            listClient.Add(C);
            Console.WriteLine("Le client a bien été enregistré.");
            Console.WriteLine("\nAppuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
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
            Console.WriteLine("\nAppuyez sur un bouton pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
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
        public void ListeClients()
        {
            Console.WriteLine("Voici la liste complète des clients enregistrés:");
            Console.WriteLine("\n| Nom |" + "    " + " | Prénom | " + "     | ID |");
            for (int i = 0; i < listClient.Count; i++)
            {
                Console.WriteLine(listClient[i].nom + "      " + listClient[i].prénom + "       " + listClient[i].ID);
            }
            Console.WriteLine("\nPressez un bouton pour retourner au menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void SauvegardeClient()
        {
            try
            {
                StreamWriter EcritureFichierClient = new StreamWriter("C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Clients.txt");
                for (int i = 0; i < listClient.Count; i++)
                {
                    EcritureFichierClient.WriteLine(listClient[i].nom + ";" + listClient[i].prénom + ";" + listClient[i].typepermis + ";" + listClient[i].ID + ";" + listClient[i].dépensetotale);
                }
                EcritureFichierClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public bool VérifierExistenceClient(int iD)
        {
            bool existe = false;
            for (int i = 0; i < listClient.Count; i++)
            {
                if (listClient[i].ID == iD)
                {
                    existe = true;
                    Console.WriteLine("L'ID client est vérifié.");
                }
            }
            return existe;
        }

                //VEHICULES
        public void EnregistrerVéhicule()
        {
            Console.Clear();
            int NbContrôleur = listVéhicule.Count; string Contrôleur ="";
            Console.WriteLine(" Veuillez renseigner les informations du véhicule : " + "\n" + "\n Immatriculation : ");
            string Immatriculation = Console.ReadLine();
            Console.WriteLine("\nMarque : ");
            string Marque = Console.ReadLine();
            Console.WriteLine("\nModèle : ");
            string Modèle = Console.ReadLine();
            string TypeVéhicule = "";
            Console.WriteLine();
            string Emplacement = AttributionPlaceParking();
            Console.WriteLine("\nVoulez - vous ajouter une moto, un camion ou une voiture ? ");
            if (NbContrôleur % 3 == 0)
            {
                Contrôleur = "ContrôleurA";
            }
            if (NbContrôleur % 3 == 1)
            {
                Contrôleur = "ContrôleurB";
            }
            if (NbContrôleur % 3 == 2)
            {
                Contrôleur = "ContrôleurC";
            }            
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
                Moto Moto = new Moto(Immatriculation, TypeVéhicule, Marque, Modèle, Contrôleur, Emplacement, 0, Couleur, Puissance);
                listVéhicule.Add(Moto);
            }
            if (TypeVéhicule == "camion")
            {
                Console.WriteLine("\nVolume : ");
                int Volume = int.Parse(Console.ReadLine());
                Camion Camion = new Camion(Immatriculation, TypeVéhicule, Marque, Modèle, Contrôleur, Emplacement, 0, Volume);
                listVéhicule.Add(Camion);
            }
            if (TypeVéhicule == "voiture")
            {
                Console.WriteLine("\nCouleur : ");
                string Couleur = Console.ReadLine();
                Console.WriteLine("\nNombre de portes : ");
                int NbPortes = int.Parse(Console.ReadLine());
                Voiture Voiture = new Voiture(Immatriculation, TypeVéhicule, Marque, Modèle, Contrôleur, Emplacement, 0, Couleur, NbPortes);
                listVéhicule.Add(Voiture);
            }
            Console.WriteLine("Le véhicule a été créé, appuyer sur une touche pour revenir au menu." + listVéhicule.Count);
            Console.ReadKey();
            Console.Clear();
            SauvegardeVéhicule();
        }
        public void InformationsVéhicule()
        {
            Console.WriteLine("Quel est l'immatriculation du véhicule dont voulez-vous avoir les informations ?");
            string Immat = Console.ReadLine();
            string Informations = ""; bool Trouvé = false;
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == Immat)
                {
                    Informations = listVéhicule[i].ToString();
                    string[] Info = Informations.Split(';');
                    Console.WriteLine("\nVoici les informations du véhicules: \n");
                    Console.WriteLine("Immatriculation: " + Info[0]);
                    Console.WriteLine("Type de véhicule: " + Info[1]);
                    Console.WriteLine("Marque: " + Info[2]);
                    Console.WriteLine("Modèle: " + Info[3]);
                    Console.WriteLine("Couleur: " + Info[7]);
                    Console.WriteLine("Nombre de portes: " + Info[8]);
                    Console.WriteLine("Contrôleur attitré: " + Info[4]);
                    Console.WriteLine("Place de parking : " + Info[5]);
                    if (Info[3] == "voiture")
                    {
                        Console.WriteLine("Couleur: " + Info[6]);
                        Console.WriteLine("Nombre de portes: " + Info[7] + "\n");
                    }
                    if (Info[3] == "camion")
                    {
                        Console.WriteLine("Volume: " + Info[6] + "\n");
                    }
                    if (Info[3] == "moto")
                    {
                        Console.WriteLine("Couleur: " + Info[6]);
                        Console.WriteLine("Puissance: " + Info[7] + "\n");
                    }
                    Trouvé = true;
                }
            }
            if (Trouvé == false)
            {
                Console.WriteLine("\nAucun véhicule avec cet ID n'a été trouvé.");
            }
            Console.WriteLine("\nAppuyez sur un bouton pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
        }
        public void SupprimerVéhicule()
        {
            Console.WriteLine("Veuillez renseigner l'immatriculation du véhicule que vous voulez supprimer:");
            bool Supprimer = false;
            string Immat = Console.ReadLine();
            Immat = Immat.ToUpper();
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == Immat)
                {
                    listVéhicule.RemoveAt(i);
                    Supprimer = true;
                }
            }
            Console.Clear();
            if (Supprimer == true)
            {
                Console.WriteLine("Le véhicule a bien été supprimé.");
            }
            else Console.WriteLine("Aucun véhicule avec cette immatriculation n'a été trouvé.");
            SauvegardeVéhicule();
        }
        public void ListeVéhicules()
        {
            Console.WriteLine("Voici la liste complète des véhicules enregistrés:");
            Console.WriteLine("\n| Immat |" + "    " + " | Marque | " + "     | Modèle |");
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                Console.WriteLine("  " + listVéhicule[i].Immat + "       " + listVéhicule[i].marque + "            " + listVéhicule[i].modèle);
            }
            Console.WriteLine("\nPressez un bouton pour retourner au menu." + listVéhicule.Count);
            Console.ReadKey();
            Console.Clear();
        }
        public void SauvegardeVéhicule()
        {
            try
            {
                StreamWriter EcritureFichierVéhicule = new StreamWriter("C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Véhicules.txt");

                for (int i = 0; i < listVéhicule.Count; i++)
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
        public bool VérifierExistenceImmatriculation(string immat)
        {
            bool existe = false;
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == immat)
                {
                    existe = true;
                    Console.WriteLine("L'immatriculation du véhicule est vérifiée.");
                }
            }
            return existe;
        } 
        public void ListeParMarque()
        {
            Console.WriteLine("De quelle marque voulez-vous avez la liste ?");
            string Marque = Console.ReadLine();
            for(int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].marque == Marque)
                {
                    Console.WriteLine("  " + listVéhicule[i].Immat + "      " + listVéhicule[i].marque + "         " + listVéhicule[i].modèle);
                }
            }
            Console.WriteLine("\nAppoyez sur une touche pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
        }
        
                //TRAJETS
        public void CréerTrajet()
        {
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
                if (LireRéponseID == "oui")
                {
                    if (NouveauClient == true)
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
                if (LireRéponseID == "non")
                {
                    Console.WriteLine("\nVoulez-vous créer le profil de ce client ?");
                    string LireRéponseProfile = Console.ReadLine();
                    LireRéponseProfile = LireRéponseProfile.ToLower();
                    while (LireRéponseProfile != "oui" && LireRéponseProfile != "non")
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
            string Immatriculation = "";
            bool ExistenceImmatriculation = false;
            bool DispoVéhicule = false;
            string LireRéponseImmat = "oui";
            bool ImmatVérifié = false;
            string LireRéponseVéhicule = "oui";
            if (ArrêtDeLaMéthode == false)
            {
                while (LireRéponseImmat == "oui")
                {
                    Console.WriteLine("\nSaisir l'immatriculation du véhicule affecté à ce trajet: ");
                    Immatriculation = Console.ReadLine();
                    ExistenceImmatriculation = VérifierExistenceImmatriculation(Immatriculation);
                    DispoVéhicule = VérifierDispoVoiture(Immatriculation);
                    if (ExistenceImmatriculation == false)
                    {
                        Console.WriteLine("Il n'existe aucun véhicule avec cette immatriculation, voulez-vous réessayer ?");
                        LireRéponseImmat = OuiNon();
                    }
                    if (ExistenceImmatriculation == true && DispoVéhicule == false)
                    {
                        Console.WriteLine("\nLe véhicule sélectionné n'est pas disponible, il est surement déjà utilisé dans un autre trajet.");
                        Console.WriteLine("Voulez-vous essayer avec une autre immatriculation ?");
                        LireRéponseImmat = OuiNon();
                    }
                    if (ExistenceImmatriculation == true && DispoVéhicule == true)
                    {
                        LireRéponseImmat = "non"; //On fait ça pour close le while, vu que l'immat sélectionné est bon.
                        ImmatVérifié = true;
                    }
                }
                if (ImmatVérifié == false)
                {
                    Console.WriteLine("Voulez-vous créer un nouveau véhicule ?");
                    LireRéponseVéhicule = OuiNon();
                    if (LireRéponseVéhicule == "oui")
                    {
                        EnregistrerVéhicule();
                        Immatriculation = listVéhicule[listVéhicule.Count - 1].Immat;
                        LireRéponseVéhicule = "non"; //On fait ça pour close le while, vu que l'immat sélectionné est bon.
                    }
                    else ArrêtDeLaMéthode = true;
                }
            }
            double Coût = CoûtTrajet(Immatriculation, NbKm);
            if (AllerRetour == true)
            {
                Coût = Coût * 2;
            }
            Console.WriteLine("\nLe coût du trajet est de : " + Coût);
            Console.WriteLine("\nCréation d'un ID pour le trajet :");
            int IDTrajet = CréerID(NombreAléatoire);
            if (ArrêtDeLaMéthode == false)
            {
                DépartVoiture(Immatriculation);
                Trajet Trajet = new Trajet(NbKm, VilleDépart, VilleArrivée, Autoroute, AllerRetour, IDClient, Immatriculation, IDTrajet, Coût, true);
                listTrajet.Add(Trajet);
                SauvegardeTrajet();
                SauvegardeParking();
            }
            if (ArrêtDeLaMéthode == true)
            {
                Console.WriteLine("\nLa création du trajet est annulée, il manquait des informations.");
            }
            Console.WriteLine("Appuyez sur une touche pour retourner au menu");
            Console.ReadKey();
            Console.Clear();
        }
        public void InformationsTrajet()
        {
            Console.WriteLine("Quel est l'ID du trajet dont voulez-vous avoir les informations ?");
            int IDTrajet = int.Parse(Console.ReadLine());
            string Informations = ""; bool Trouvé = false;
            for (int i = 0; i < listTrajet.Count; i++)
            {
                if (listTrajet[i].idtrajet == IDTrajet)
                {
                    Informations = listTrajet[i].ToString();
                    Trouvé = true;
                }
            }
            if (Trouvé == true)
            {
                Console.WriteLine("\n" + Informations + "\n");
                Console.WriteLine("Appuyez sur un bouton pour revenir au menu");
                Console.ReadKey();
                Console.Clear();
            }
            else Console.WriteLine("\nAucun trajet avec cet ID n'a été trouvé.");
        }
        public void SupprimerTrajet(int ID)
        {
            bool Supprimer = false;
            for (int i = 0; i < listTrajet.Count; i++)
            {
                if (listTrajet[i].idtrajet == ID)
                {
                    listTrajet.RemoveAt(i);
                    Supprimer = true;
                }
            }
            Console.Clear();
            if (Supprimer == true)
            {
                Console.WriteLine("Le trajet a bien été supprimé.");
            }
            else Console.WriteLine("Aucun trajet avec cet ID n'a été trouvé.");
            SauvegardeTrajet();
        }
        public void ListeTrajets()
        {
            {
                Console.WriteLine("Voici la liste complète des trajets enregistrés :");
                Console.WriteLine("\n| Ville de départ |" + "    " +
                    " | Ville d'arrivée | " + "| ID du client |" + "| ID du trajet |");
                for (int i = 0; i < listTrajet.Count; i++)
                {
                    Console.WriteLine(listTrajet[i].villedépart + "             |            " + listTrajet[i].villearrivée + "        |       " + listTrajet[i].idclient + "    |     " + listTrajet[i].idtrajet + "    |     ");
                }
                Console.WriteLine("\nPressez un bouton pour retourner au menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SauvegardeTrajet()
        {
            try
            {
                StreamWriter EcritureFichierTrajets = new StreamWriter("C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Trajets.txt");
                for (int i = 0; i < listTrajet.Count; i++)
                {
                    EcritureFichierTrajets.WriteLine(listTrajet[i].nbKm + ";" + listTrajet[i].villedépart + ";" + listTrajet[i].villearrivée + ";" + listTrajet[i].autoroute + ";" + listTrajet[i].allerretour + ";" + listTrajet[i].idclient + ";" + listTrajet[i].immatriculation + ";" + listTrajet[i].idtrajet + ";" + listTrajet[i].coût + ";" + listTrajet[i].actif);
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
                    if (listTrajet[i].idtrajet == IDTrajet && listTrajet[i].actif == true)
                    {
                        Existe = true;
                        Console.WriteLine("Le trajet a bien été sélectionné, il est actuellement considéré étant en cours. Voulez-vous cloturer le trajet ?");
                        string LireRéponseID = OuiNon();
                        if (LireRéponseID == "oui")
                        {
                            for (int j = 0; j < listTrajet.Count; j++)
                            {
                                if (listTrajet[j].idtrajet == IDTrajet)
                                {
                                    listTrajet[j].ChangerActif();
                                    Continue = false;
                                }
                            }
                        } else Continue = false;
                    }
                    if (listTrajet[i].idtrajet == IDTrajet && listTrajet[i].actif == false && Existe == false)
                    {
                        Existe = true;
                        Console.WriteLine("Le trajet a bien été sélectionné, il est actuellement considéré étant cloturer. Voulez-vous relancer le trajet ?");
                        string LireRéponseID = OuiNon();
                        if (LireRéponseID == "oui")
                        {
                            for (int j = 0; j < listTrajet.Count; j++)
                            {
                                if (listTrajet[j].idtrajet == IDTrajet)
                                {
                                    listTrajet[j].ChangerActif();
                                    Continue = false;
                                }
                            }
                        } else Continue = false;
                    }
                }
                if (Existe == false)
                {
                    Continue = false;
                    Console.WriteLine("\nIl n'existe aucun trajet avec cet ID.");
                }
            }
            Console.WriteLine("\nVeuillez appuyer sur une touche pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
            SauvegardeTrajet();

        }        
        public double CoûtTrajet(string immat, int NbKm)
        {
            double Coût = 0;
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == immat)
                {
                    Coût = listVéhicule[i].CalculCout(NbKm);
                }
            }
            return Coût;
        }
        public void RetourTrajet()
        {
            Console.WriteLine("Quel est l'ID du trajet qui se cloture ?");
            int IDTrajet = int.Parse(Console.ReadLine());
            MaJTrajet(IDTrajet);
            string ImmatVéhicule = "";
            int i = 0;
            int IDClient = 0;
            double DépenseàAjouter = 0;
            for (i = 0; i<listTrajet.Count; i++)
            {
                if(IDTrajet == listTrajet[i].idtrajet)
                {
                    ImmatVéhicule = listTrajet[i].immatriculation;
                    IDClient = listTrajet[i].idclient;
                    DépenseàAjouter = listTrajet[i].coût;
                }
            }
            i--;
            string AncienEmplacement = ""; int AncienArrondissement = 0; string AnciennePlace = "";
            string NewEmplacement = ""; int NewArrondissement = 0; int Place = 0; string NewPlace = "";
            for (int j = 0; j<listVéhicule.Count; j++)
            {
                if(ImmatVéhicule == listVéhicule[j].Immat)
                {
                    listVéhicule[j].AjouterKm(listTrajet[i].nbKm);
                    AncienEmplacement = listVéhicule[j].emplacement;
                    string[] tab = AncienEmplacement.Split('-');
                    AncienArrondissement = Convert.ToInt32(tab[0]);
                    AnciennePlace = tab[1];
                    Console.WriteLine("\nDans quel arrondissement est garé le véhicule ?");
                    while (NewArrondissement < 1 || NewArrondissement > 22)
                    {
                        NewArrondissement = int.Parse(Console.ReadLine());
                        if (NewArrondissement < 1 || NewArrondissement > 22)
                        {
                            Console.WriteLine("Veuillez saisir un arrondissement compris entre 1 et 22, 21 étant le parking de Roissy et 22 étant le parking de Orly.");
                        }
                    }
                    Console.WriteLine("\nA quel place est garé le véhicule ? (de 0 à 9)");
                    Place = int.Parse(Console.ReadLine());
                    while (Place < 0 || Place > 9)
                    {
                        Place = int.Parse(Console.ReadLine());
                        if (Place < 0 || Place > 9)
                        {
                            Console.WriteLine("Veuillez saisir une place comprise entre 0 et 9.");
                        }
                    }                    
                    NewPlace = "A" + Place;
                    NewEmplacement = NewArrondissement + "-" + NewPlace;
                    listVéhicule[j].ChangerEmplacement(NewEmplacement);
                    SauvegardeVéhicule();
                }
            }
            for(int g = 0; g<listClient.Count; g++)
            {
                if (listClient[g].ID == IDClient)
                {
                    listClient[i].AjouterDépense(DépenseàAjouter);
                }
            }
            ChangerDispoEmplacement(NewArrondissement, NewPlace);
            SauvegardeClient();
            SauvegardeParking();
            Console.WriteLine("Appuyez sur une touche pour revenir au menu.");
            Console.ReadKey();
            Console.Clear();
        }
        
                //AUTRES METHODES
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
        public string OuiNon()
        {
            string Réponse = Console.ReadLine();
            Réponse = Réponse.ToLower();
            while (Réponse != "oui" && Réponse != "non")
            {
                Console.WriteLine("\n Il y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît: ");
                Réponse = Console.ReadLine();
                Réponse = Réponse.ToLower();
            }
            return Réponse;
        }
        public void ChargementDonnées()
        {
            try
            {
                string LocalisationClient = "C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Clients.txt";
                StreamReader LectureFichierClient = new StreamReader(LocalisationClient);
                string ligne = "";
                while (LectureFichierClient.EndOfStream == false)
                {
                    ligne = LectureFichierClient.ReadLine();
                    string[] tab = ligne.Split(';');
                    int ID = Convert.ToInt32(tab[3]);
                    int DépenseTotale = Convert.ToInt32(tab[4]);
                    Client C = new Client(tab[0], tab[1], tab[2], ID, DépenseTotale);
                    listClient.Add(C);
                }                
                LectureFichierClient.Close();
                string LocalisationVéhicules = "C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Véhicules.txt";
                StreamReader LectureFichierVéhicules = new StreamReader(LocalisationVéhicules);
                int NbKmV = 0;
                while (LectureFichierVéhicules.EndOfStream == false)
                {
                    ligne = LectureFichierVéhicules.ReadLine();
                    string[] tab = ligne.Split(';');
                    NbKmV = Convert.ToInt32(tab[6]);
                    if (tab[1] == "voiture")
                    {
                        int NbPortes = Convert.ToInt32(tab[8]);                        
                        Voiture Voiture = new Voiture(tab[0], tab[1], tab[2], tab[3], tab[4], tab[5], NbKmV, tab[7], NbPortes);
                        listVéhicule.Add(Voiture);
                    }
                    if (tab[1] == "camion")
                    {
                        int VolumeCamion = Convert.ToInt32(tab[7]);
                        Camion Camion = new Camion(tab[0], tab[1], tab[2], tab[3], tab[4], tab[5], NbKmV, VolumeCamion);
                        listVéhicule.Add(Camion);
                    }
                    if (tab[1] == "moto")
                    {
                        int Puissance = Convert.ToInt32(tab[8]);
                        Moto Moto = new Moto(tab[0], tab[1], tab[2], tab[3], tab[4], tab[5], NbKmV, tab[7], Puissance);
                        listVéhicule.Add(Moto);
                    }
                }
                LectureFichierVéhicules.Close();
                string LocationTrajets = "C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Trajets.txt";
                StreamReader LectureFichierTrajets = new StreamReader(LocationTrajets);
                while (LectureFichierTrajets.EndOfStream == false)
                {
                    ligne = LectureFichierTrajets.ReadLine();
                    string[] tab = ligne.Split(';');
                    int NbKm = Convert.ToInt32(tab[0]);
                    int IDTrajet = Convert.ToInt32(tab[7]);
                    int IDClient = Convert.ToInt32(tab[5]);
                    double Coût = Convert.ToDouble(tab[8]);
                    bool Autoroute; bool AllerRetour; bool Actif;
                    if (tab[3] == "True")
                    {
                        Autoroute = true;
                    }
                    else Autoroute = false;
                    if (tab[4] == "True")
                    {
                        AllerRetour = true;
                    }
                    else AllerRetour = false;
                    if (tab[9] == "True")
                    {
                        Actif = true;
                    }
                    else Actif = false;
                    Trajet T = new Trajet(NbKm, tab[1], tab[2], Autoroute, AllerRetour, IDClient, tab[6], IDTrajet, Coût, Actif);
                    listTrajet.Add(T);
                }
                LectureFichierTrajets.Close();
                string LocationParking = "C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Parkings.txt";
                StreamReader LectureFichierParkings = new StreamReader(LocationParking);
                while (LectureFichierParkings.EndOfStream == false)
                {
                    ligne = LectureFichierParkings.ReadLine();
                    string[] tab = ligne.Split(';');
                    int NbArrondissement = Convert.ToInt32(tab[0]);
                    bool Dispo = false;
                    if(tab[2] == "True")
                    {
                        Dispo = true;
                    }
                    Parking P = new Parking(NbArrondissement, tab[1], Dispo);
                    listParking.Add(P);
                }
                LectureFichierParkings.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }     
        public string AttributionPlaceParking()
        {
            Random Aléatoire = new Random();
            int Arrondissement = 0;
            int NbPlace = Aléatoire.Next(1, 9);
            string Place = "";
            bool PlaceTrouvé = false;
            while (PlaceTrouvé == false)
            {
                Arrondissement = Aléatoire.Next(1, 22);
                NbPlace = Aléatoire.Next(1, 9);
                Place = "A" + NbPlace;
                for(int i = 0;i<listParking.Count;i++)
                {
                    if (Arrondissement == listParking[i].arrondissement && Place == listParking[i].place && listParking[i].dispo == true)
                    {
                        PlaceTrouvé = true;
                        if (Arrondissement == 21)
                        {
                            Console.WriteLine("La place sélectionnée est à Roissy à la place " + Place);
                        }
                        if (Arrondissement == 22)
                        {
                            Console.WriteLine("La place sélectionnée est à Orly à la place " + Place);
                        }
                        if (Arrondissement <= 20)
                        {
                            Console.WriteLine("La place sélectionnée est dans le " + Arrondissement + "ème arrondissement à la place " + Place);
                        }
                        listParking[i].ChangerDispo();
                    }
                }
            }
            SauvegardeParking();
            string Emplacement = Arrondissement + "-" + Place;
            return Emplacement;
            
        }
        public void SauvegardeParking()
        {
            try
            {
                StreamWriter EcritureFichierParking = new StreamWriter("C:\\Users\\natha\\source\\repos\\Projet-Info\\Projet Info\\bin\\Debug\\Parkings.txt");
                for (int i = 0; i < listParking.Count; i++)
                {
                    EcritureFichierParking.WriteLine(listParking[i].arrondissement + ";" + listParking[i].place + ";" + listParking[i].dispo);
                }
                EcritureFichierParking.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DépartVoiture(string immat)
        {
            string EmplacementParking = "";
            for (int i = 0; i < listVéhicule.Count; i++)
            {
                if (listVéhicule[i].Immat == immat)
                {
                    for (int j = 0; j < listParking.Count; j++)
                    {
                        EmplacementParking = listParking[j].arrondissement + "-" + listParking[j].place;
                        if (listVéhicule[i].emplacement == EmplacementParking)
                        {
                            listParking[j].ChangerDispo();
                        }
                    }

                }
            }
        }
        public void ChangerDispoEmplacement(int Arrondissement, string Place)
        {
            for (int i = 0; i<listParking.Count; i++)
            {
                if(listParking[i].arrondissement == Arrondissement && listParking[i].place == Place)
                {
                    listParking[i].ChangerDispo();
                }
            }
            SauvegardeParking();
        }
        public bool VérifierDispoVoiture(string Immat)
        {
            bool Dispo = true;
            for (int i = 0; i<listTrajet.Count;i++)
            {
                if (listTrajet[i].immatriculation == Immat)
                {
                    if (listTrajet[i].actif == true)
                    {
                        Dispo = false;
                    }
                }
            }
            return Dispo;
        }
    }
}
