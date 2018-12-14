using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet_Info
{
    class Program
    {
        static void Main(string[] args)
        {      
            Menu();
            System.Threading.Thread.Sleep(2000);
        }
        static void Authentification()
        {
            StreamReader FichierAuthentification = new StreamReader("C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Authentification.txt");            
            Console.WriteLine("Bienvenue sur le programme de gestion du park automobile.");
            string ligne = "";
            string Pseudo = ""; string MDP = ""; bool Continuer = true; bool Vérif = false; bool boucle = false; bool end = false;
            while(Continuer == true)
            {
                if (boucle == true)
                {
                    FichierAuthentification = new StreamReader("C:\\Users\\user\\Documents\\Cours\\Ingé 2\\Informatique\\Données projet\\Authentification.txt");
                }
                Console.WriteLine("\n Veuillez renseigner votre pseudonyme:");
                Pseudo = Console.ReadLine();
                Console.WriteLine("\n Veuillez renseigner votre mot de passe:");
                MDP = Console.ReadLine();
                Console.Clear();
                while(FichierAuthentification.EndOfStream == false)
                {
                    ligne = FichierAuthentification.ReadLine();
                    string[] tab = ligne.Split(';');
                    if(tab[0] == Pseudo && tab[1] == MDP)
                    {
                        Console.WriteLine("Authentification vérifiée.");
                        Continuer = false;
                        Vérif = true;
                    }                    
                }
                if (Continuer == true)
                {
                    Console.WriteLine("Authentification non-vérifiée, voulez-vous réessayer ?");
                    string LireRéponseEssaie = Console.ReadLine();
                    LireRéponseEssaie = LireRéponseEssaie.ToLower();
                    while (LireRéponseEssaie != "oui" && LireRéponseEssaie != "non")
                    {
                        Console.WriteLine("\nIl y a eu une erreur de compréhension, veuillez renseigner de nouveau par 'oui' ou 'non' s'il-vous-plaît :");
                        LireRéponseEssaie = Console.ReadLine();
                        LireRéponseEssaie = LireRéponseEssaie.ToLower();
                    }
                    if (LireRéponseEssaie == "non")
                    {
                        Continuer = false;
                        end = true;
                    }
                    else
                    {
                        boucle = true;
                        FichierAuthentification.Close();
                    }
                }
                if (end == true)
                {
                    Console.WriteLine("Merci d'avoir utilisé notre programme de gestion, à bientôt !");
                }
            }
            FichierAuthentification.Close();            
            if (Vérif == true)
            {
                Console.WriteLine("Chargement des données...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("...");
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Données chargées avec succès !");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Menu();
                Console.WriteLine("Merci d'avoir utilisé notre programme de gestion, à bientôt !");
            }
        }
        static void Menu()
        {
            List<int> NombreAléatoire = new List<int>();
            ControlCenter C = new ControlCenter();
            C.ChargementDonnées();            
            Console.WriteLine("-----------------M E N U   D E    G E S T I O N-----------------");
            Console.WriteLine("");
            Console.WriteLine(" Voici les options à votre dispositions :");
            Console.WriteLine("");
            Console.WriteLine(" 1 -   Menu Client");
            Console.WriteLine(" 2 -   Menu Véhicule");
            Console.WriteLine(" 3 -   Menu Trajet");
            Console.WriteLine(" 4 -   Fermeture du programme");
            Console.WriteLine("");
            Console.WriteLine(" Choississez une action avec un chiffre : ");
            int ChoixMenu = int.Parse(Console.ReadLine());
            while (ChoixMenu != 1 && ChoixMenu != 2 && ChoixMenu != 3 && ChoixMenu != 4)
            {
                Console.WriteLine(" Ceci ne correspond à aucune action, choississez une des actions disponibles :");
                ChoixMenu = int.Parse(Console.ReadLine());
            }
            switch (ChoixMenu)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("-----------------M E N U   C L I E N T S-----------------");
                    Console.WriteLine("");
                    Console.WriteLine(" Voici les options à votre dispositions :");
                    Console.WriteLine("");
                    Console.WriteLine(" 1 -   Création d'un nouveau compte client");
                    Console.WriteLine(" 2 -   Supprimer un compte client");
                    Console.WriteLine(" 3 -   Informations client");
                    Console.WriteLine(" 4 -   Afficher la liste des clients");
                    Console.WriteLine(" 5 -   Retour au menu principal");
                    int ChoixMenu2 = int.Parse(Console.ReadLine());
                    while (ChoixMenu2 != 1 && ChoixMenu2 != 2 && ChoixMenu2 != 3 && ChoixMenu2 != 4 && ChoixMenu2 != 5)
                    {
                        Console.WriteLine(" Ceci ne correspond à aucune action, choississez une des actions disponibles :");
                        ChoixMenu2 = int.Parse(Console.ReadLine());
                    }
                    switch (ChoixMenu2)
                    {
                        case 1:
                            Console.Clear();
                            C.CréerClient(NombreAléatoire);
                            Console.WriteLine("Le client a été créé avec succès !\n");
                            break;

                        case 2:
                            Console.Clear();
                            C.SupprimerClient();                            
                            break;

                        case 3:
                            Console.Clear();
                            C.InformationsClient();
                            // afficher les infos clients
                            break;

                        case 4:
                            Console.Clear();
                            C.ListeClients();
                            
                            break;
                        case 5:
                            Console.Clear();
                            // methode retourner au menu principal
                            break;
                    }
                   break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("-----------------M E N U   V E H I C U L E-----------------");
                    Console.WriteLine("");
                    Console.WriteLine(" Voici les options à votre dispositions :");
                    Console.WriteLine("");
                    Console.WriteLine(" 1 -   Attribuer un véhicule");
                    Console.WriteLine(" 2 -   Retirer un véhicule");
                    Console.WriteLine(" 3 -   Information véhicule");
                    Console.WriteLine(" 4 -   Liste des véhicules");
                    Console.WriteLine(" 5 -   Retour au menu principal");
                    int ChoixMenu3 = int.Parse(Console.ReadLine());
                    while (ChoixMenu3 != 1 && ChoixMenu3 != 2 && ChoixMenu3 != 3 && ChoixMenu3 != 4 && ChoixMenu3 != 5)
                    {
                        Console.WriteLine(" Ceci ne correspond à aucune action, choississez une des actions disponibles :");
                        ChoixMenu3 = int.Parse(Console.ReadLine());
                    }
                    switch (ChoixMenu3)
                    {
                        case 1:
                            Console.Clear();
                            C.EnregistrerVéhicule();
                            break;

                        case 2:
                            Console.Clear();
                            C.SupprimerVéhicule();
                            // retirer un véhicule
                            break;

                        case 3:
                            Console.Clear();
                            C.InformationsVéhicule();
                            // info véhicule
                            break;

                        case 4:
                            Console.Clear();
                            C.ListeVéhicules();
                            break;
                        case 5:
                            Console.Clear();
                            // methode retourner au menu principal
                            break;
                    }                    
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("-----------------M E N U   T R A J E T-----------------");
                    Console.WriteLine("");
                    Console.WriteLine(" Voici les options à votre dispositions :");
                    Console.WriteLine("");
                    Console.WriteLine(" 1 -   Attribuer un trajet");
                    Console.WriteLine(" 2 -   Retirer un trajet");
                    Console.WriteLine(" 3 -   Modifier l'état d'un trajet");
                    Console.WriteLine(" 4 -   Information trajet");
                    Console.WriteLine(" 5 -   Afficher la liste des trajets");
                    Console.WriteLine(" 6 -   Retour au menu principal");
                    int ChoixMenu4 = int.Parse(Console.ReadLine());
                    while (ChoixMenu4 != 1 && ChoixMenu4 != 2 && ChoixMenu4 != 3 && ChoixMenu4 != 4 && ChoixMenu4 != 5 && ChoixMenu4 != 6)
                    {
                        Console.WriteLine(" Ceci ne correspond à aucune action, choississez une des actions disponibles :");
                        ChoixMenu4 = int.Parse(Console.ReadLine());
                    }
                    switch (ChoixMenu4)
                    {
                        case 1:
                            Console.Clear();
                            C.CréerTrajet();
                            Console.WriteLine("Le trajet a été enregistré avec succès !\n");
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Veuillez renseigner l'ID du trajet que vous voulez supprimer:");
                            int ID = int.Parse(Console.ReadLine());
                            C.SupprimerTrajet(ID);
                            // retirer un trajet
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Veuillez renseigner l'ID du trajet que vous voulez mette à jour:");
                            int IDTrajet = int.Parse(Console.ReadLine());
                            C.MaJTrajet(IDTrajet);
                            Console.WriteLine("L'état du trajet a bien été mis à jour !\n");
                            break;

                        case 4:
                            Console.Clear();
                            C.InformationsTrajet();
                            // info trajet
                            break;

                        case 5:
                            Console.Clear();                            
                            C.ListeTrajets();
                            break;
                        case 6:
                            Console.Clear();
                            // methode retourner au menu principal
                            break;
                    }
                    break;

                case 4:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine(" Valeur non-attendue reçu");
                    break;
            }
            if (ChoixMenu == 1 || ChoixMenu == 2 || ChoixMenu == 3)
            {
                Menu();
            }
        }
    }
}
