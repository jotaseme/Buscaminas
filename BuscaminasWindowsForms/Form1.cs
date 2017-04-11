using BuscaminasConsola.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuscaminasWindowsForms
{

    public partial class Form1 : Form
    {
        private Tablero tablero;
        private Button[,] botones;
        int size;
        private buscaminasEntities db = new buscaminasEntities();

        public Form1()
        {
            Prompt pr = new Prompt();
            bool dificultad = pr.CreateMyForm();
            
            InitializeComponent();
            if (dificultad)
            {
                size = 5;
            }else
            {
                size = 8;
            }

            tablero_layout.RowCount = size;
            tablero_layout.ColumnCount = size;
            tablero = new Tablero(size, size);
            botones = new Button[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    botones[i, j] = new miBoton(i, j);
                    botones[i, j].Image = global::BuscaminasWindowsForms.Properties.Resources.blank;
                    botones[i, j].AutoSize = true;
                    botones[i, j].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                    botones[i, j].Click += new System.EventHandler(this.click_boton);
                    tablero_layout.Controls.Add(botones[i, j]);
                }
            }

        }

       

        private void click_boton(object sender, EventArgs e)
        {
            tablero.LevantaCasilla(((miBoton)sender).f + 1,
                             ((miBoton)sender).c + 1);            
            updateTablero();
            checkIfWin();
            counter.Text = "" + finalCounter();
            if (tablero.valorCasilla(((miBoton)sender).f + 1,
                             ((miBoton)sender).c + 1) == "B")
            {
                
                counter.Text = "" + (finalCounter()+1);
                MessageBox.Show("Perdiste!");
                // Guardar en bd
                Puntuacion p = new Puntuacion();
                if (size == 5)
                {
                    p.nivel = "Facil";
                }
                else
                {
                    p.nivel = "Dificil";
                }
                p.puntuacion1 = finalCounter()+1;
                p.fecha = DateTime.Now;
                db.Puntuacion.Add(p);
                db.SaveChanges();
                for (int fil = 1; fil <= size; fil++)
                {
                    for (int col = 1; col <= size; col++)
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                    }
                }
                


            }

        }

        

        private void updateTablero()
        {
            for (int fil = 1; fil <= size; fil++)
                for (int col = 1; col <= size; col++)
                {
                    string str = tablero.valorCasilla(fil, col);

                    if (str.Equals("-"))
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                        botones[fil - 1, col - 1].Text = "Levantada";

                    }
                    else if (str.Equals("B"))
                    {

                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.bomb;
                    }
                    else if (str.Equals("1"))
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.one;
                    }
                    else if (str.Equals("2"))
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.two;
                    }
                    else if (str.Equals("3"))
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.three;
                    }
                    else if (str.Equals("4"))
                    {
                        botones[fil - 1, col - 1].Enabled = false;
                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.four;
                    }
                    else
                    {
                        botones[fil - 1, col - 1].Image = global::BuscaminasWindowsForms.Properties.Resources.blank;
                    }
                }
        }

        private void checkIfWin()
        {
            if (finalCounter() + tablero.getBombas() == size*size)
            {
                MessageBox.Show("Ganaste!");
                
                Puntuacion p = new Puntuacion();
                if (size == 5)
                {
                    p.nivel = "Facil";
                }
                else
                {
                    p.nivel = "Dificil";
                }
                p.puntuacion1 = finalCounter();
                p.fecha = DateTime.Now;
                db.Puntuacion.Add(p);
                db.SaveChanges();
            }
            
        }

        private int finalCounter()
        {
            int counter = 0;
            for (int fil = 1; fil <= size; fil++)
                for (int col = 1; col <= size; col++)
                {
                    if (!botones[fil - 1, col - 1].Enabled)
                    {
                        counter++;
                    }
                }
            return counter;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}


