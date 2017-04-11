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
        public static int counter;
        public int num_bombas = 0;

        public Tablero(int n, int m)
        {
            // sumo 2 para tener un borde
            counter = 0;
            this.fils = n+2;
            this.cols = m+2;
            casillas = new Casilla[fils,cols];
            for (int f = 0; f < fils; f++)
                for (int c = 0; c < cols; c++)
                    casillas[f, c] = new Casilla();
            
            PonUnosEnElBorde();
            PonBombas();
        }

        public int getCounter()
        {
            return counter;
        }

        private void PonUnosEnElBorde()
        {
            for (int c = 0; c < cols; c++)
            {
                casillas[0, c].SumarUno();
                casillas[fils - 1, c].SumarUno();
            }

            for(int f=0; f<fils; f++)
            {
                casillas[f, 0].SumarUno();
                casillas[f, cols - 1].SumarUno();
            }
        }

        private void PonBombas()
        {
            int bombas;
            if(fils == 5){
                bombas = 10;
            }
            else
            {
                bombas = 20;
            }
            
            Random rnd = new Random();
            for (int f = 1; f < fils - 1; f++)            
                for (int c = 1; c < cols - 1; c++) {
                    if ( rnd.Next(100) < bombas ) 
                    {
                        casillas[f,c].PonBomba();
                        num_bombas++;
                        SumaUnosAlrededor(f, c);
                    }
                }
        }

        private void SumaUnosAlrededor(int f, int c)
        {
            for (int i = (f - 1); i <= (f + 1); i++)
                for (int j = (c - 1); j <= (c + 1); j++)
                    casillas[i, j].SumarUno();
        }

        public override string ToString()
        {
            string msg = "";

            for (int f = 1; f < fils - 1; f++)
            {
                for (int c = 1; c < cols - 1; c++)
                    msg += " " + casillas[f, c];
                msg += "\n";
            }
            return msg;
        }

        internal string valorCasilla(int fil, int col)
        {
            return casillas[fil, col].ToString();
        }

        public int getBombas()
        {
            return num_bombas;
        }

        internal void LevantaCasilla(int fila, int colu)
        {
            
            casillas[fila, colu].Levanta();
            counter++;
            if (!casillas[fila, colu].EsBomba() && casillas[fila, colu].EsVacia())
            {
                for (int f = fila - 1; f <= (fila + 1); f++)
                {
                    for (int c = colu - 1; c <= (colu + 1); c++)
                    {
                        if (!casillas[f, c].EstaLevantada())
                        {
                            LevantaCasilla(f, c);
                            
                            
                            
                        }
                    }
                }
            }
        }
        
    }
}
