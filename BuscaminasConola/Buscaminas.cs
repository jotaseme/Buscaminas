using BuscaminasConsola.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola
{
    class Buscaminas
    {
        static void Main(string[] args)
        {
            new Buscaminas().Jugar();
        }

        private Tablero tablero;

        private void Jugar()
        {
            tablero = new Tablero(10,13);
            Console.WriteLine(tablero);
            //tablero.Levanta(fil,col);
            Console.ReadLine();
        }
    }
}
