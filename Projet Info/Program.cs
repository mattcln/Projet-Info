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
            ControlCenter C = new ControlCenter();
            C.CréerTrajet();            
            Console.ReadKey();           
        }        
    }
}
