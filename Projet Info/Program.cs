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
            Authentification();
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
            Console.WriteLine(" 1 -   Création d'un nouveau compte client");
            Console.WriteLine(" 2 -   Enregistrement d'un nouveau véhicule");
            Console.WriteLine(" 3 -   Enregistrement d'un nouveau trajet");
            Console.WriteLine(" 4 -   Mise à jour de l'état d'un trajet");
            Console.WriteLine(" 5 -   Fermeture du programme");
            Console.WriteLine("");
            Console.WriteLine(" Choississez une action avec un chiffre : ");
            int ChoixMenu = int.Parse(Console.ReadLine());
            while (ChoixMenu != 1 && ChoixMenu != 2 && ChoixMenu != 3 && ChoixMenu != 4 && ChoixMenu != 5)
            {
                Console.WriteLine(" Ceci ne correspond à aucune action, choississez une des actions disponibles :");
                ChoixMenu = int.Parse(Console.ReadLine());
            }
            switch (ChoixMenu)
            {
                case 1:
                    C.CréerClient(NombreAléatoire);
                    Console.WriteLine("Le client a été créé avec succès !\n");
                    break;
                case 2:
                    C.EnregistrerVéhicule();
                    Console.WriteLine("Le véhicule a été enregistré avec succès !\n");
                    break;                    
                case 3:
                    C.CréerTrajet();
                    Console.WriteLine("Le trajet a été enregistré avec succès !\n");
                    break;
                case 4:
                    Console.WriteLine("\nVeuillez renseigner l'ID du trajet que vous voulez mette à jour :");
                    int IDTrajet = int.Parse(Console.ReadLine());
                    C.MaJTrajet(IDTrajet);
                    Console.WriteLine("L'état du trajet a bien été mis à jour !\n");
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine(" Valeur non-attendue reçu");
                    break;
            }
            if (ChoixMenu == 1 || ChoixMenu == 2 || ChoixMenu == 3 || ChoixMenu == 4)
            {
                Menu();
            }
        }        
    }
}
