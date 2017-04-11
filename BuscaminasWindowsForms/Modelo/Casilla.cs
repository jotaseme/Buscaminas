using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola.Modelo
{
    class Casilla
    {
        private int valor;
        private bool levantada;
        private bool bomba;

        // constructor

        public bool EsBomba()
        {
            return bomba;
        }

        public void SumarUno()
        {
            valor = valor + 1;
        }

        public void PonBomba()
        {
            bomba = true;
        }

        public override string ToString()
        {
            string msg = "";
            if (!levantada) msg = "X";
            else if (bomba) msg = "B";
            else if (valor == 0) msg = "-";
            else msg = ""+valor;
            return msg;
        }

        public Casilla() 
        {
            levantada = false;
            valor = 0;
            bomba = false;
        }


        internal void Levanta()
        {
            levantada = true;
        }

        internal bool EsVacia()
        {
            return valor == 0 ;
        }

        internal bool EstaLevantada()
        {
            return levantada;
        }
    }
}
