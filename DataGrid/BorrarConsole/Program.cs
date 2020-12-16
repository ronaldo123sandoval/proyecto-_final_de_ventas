using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorrarConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hola Mundo");
            Console.WriteLine("Ingresa tu nombre");
            string nombre = Console.ReadLine();
            Console.WriteLine("Hola "+nombre);
            Console.ReadKey();
        }
    }
}
