using BuscaminasConsola.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaminasConsola.Modelo
{
    class Tablero
    {
        private int fils;
        private int cols;

        private Casilla[,] casillas;

        public Tablero(int v1, int v2)
        {
            this.fils = v1+2;
            this.cols = v2+2;
            casillas = new Casilla[fils, cols];
            
            for(int f = 0;f < fils; f++)
            {
                
                for (int c = 0;c < cols; c++)
                {
                    casillas[f, c] = new Casilla();
                }
            }


            InicializaConBombas();
            PonUnosBorde();
        }

        private void PonUnosBorde()
        {
            for (int i = 0;i<cols;i++)
            {
                casillas[0, i].SumaUno();
                casillas[fils - 1, i].SumaUno();
            }
            for (int j = 0; j < fils; j++)
            {
                casillas[j, 0].SumaUno();
                casillas[j, cols-1].SumaUno();
            }
        }

        private void InicializaConBombas()
        {
            Random random = new Random();
            for (int f = 1; f < fils - 1; f++)
            {
                
                for (int c = 1; c < cols - 1; c++)
                {
                   
                    if (random.Next(100)<20)
                    {
                        casillas[f, c].PonBomba();
                        SumaUnosAlrededor(f, c);
                    }
                }
            }
        }

        public override string ToString()
        {
            string msg = "";
            for (int f = 1; f < fils -1;f++)
            {
                for (int c = 1; c < cols-1; c++)
                {
                    msg += casillas[f, c] + " ";
                }
                msg += "\n";
            }
            
            return msg;
        }

        private void SumaUnosAlrededor(int f, int c)
        {
            for (int fil = f-1; fil <= f+1; fil++)
            {
               
                for (int col = c-1; col <= c+1; col++)
                {
                    casillas[fil, col].SumaUno();
                }
            }
        }
    }
}
