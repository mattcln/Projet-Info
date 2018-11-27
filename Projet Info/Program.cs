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
            List<int> NombreAléatoire = new List<int>();
            ControlCenter C = new ControlCenter();
            C.CréerTrajet();
            Console.ReadKey();
        }
        static void Menu()
        {

        }
    }
}
