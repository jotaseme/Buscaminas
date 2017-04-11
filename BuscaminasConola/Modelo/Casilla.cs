using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola.Modelo
{
    class Casilla
    {
        private bool bomba;
        private int valor;
        private bool levantada;

        public Casilla()
        {
            levantada = false;
            valor = 0;
            bomba = false;
        }

        internal void PonBomba()
        {
            bomba = true;
        }

        internal void SumaUno()
        {
            valor++;
        }

        public override string ToString()
        {
            if (!levantada) return "X";
            else if (bomba) return "B";
            else if (valor > 0) return "" + valor;
            else return "-";

        }
    }
}
