﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Info
{
    class Trajet
    {
        private int NbKm;
        private string VilleDépart;
        private string VilleArrivée;
        private bool Autoroute;
        private bool AllerRetour;
        private int IDClient;
        private string Immatriculation;
        private int IDTrajet;
        private bool Actif;
        public int idtrajet
        {
            get { return IDTrajet; }
        }
        public bool actif
        {
            get { return Actif; }
        }       

        public Trajet(int NbKm, string VilleDépart, string VilleArrivée, bool Autoroute, bool AllerRetour, int IDClient, string Immatriculation, int IDTrajet, bool Actif)
        {
            this.NbKm = NbKm;
            this.VilleDépart = VilleDépart;
            this.VilleArrivée = VilleArrivée;
            this.Autoroute = Autoroute;
            this.AllerRetour = AllerRetour;
            this.IDClient = IDClient;
            this.Immatriculation = Immatriculation;
            this.IDTrajet = IDTrajet;
            this.Actif = Actif;
        }
        public void ChangerActif()
        {
            if (Actif == true)
            {
                Actif = false;
            }
            else Actif = true;
        }
        public override string ToString()
        {
            string str = "";
            str = "Nombre de kilomètre : " + NbKm + "\nVille de départ : " + VilleDépart + "\nVille d'arrivée : " + VilleArrivée + "\nAutoroute : " + Autoroute + "\nAller / Retour : " + AllerRetour + "\nID client: " + IDClient + "\nImmatriculation du véhicule: " + Immatriculation + "\nID trajet: " + IDTrajet + "Activité du trajet: " + Actif;
            return str;
        }               
    }
}
