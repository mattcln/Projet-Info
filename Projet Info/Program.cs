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
            Console.ReadKey();
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
