﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sankeGame
{
    public partial class Form1 : Form
    {
        int puntaje=0;
        Graphics g;
        cola cabeza;
        Comida comida;
        //Mover la serpiente
        int xdir = 0, ydir = 0;
        int cuadro = 10;
        //bloquear movimiento  
        Boolean ejex= true, ejey=true;

        public Form1()
        {
            InitializeComponent();
            cabeza = new cola(10,10);
            comida = new Comida();
            g = canvas.CreateGraphics();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void movimiento()
        {
            cabeza.setxy(cabeza.verX() + xdir, cabeza.verY() + ydir);
        }

        private void bucle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            cabeza.dibujar(g);
            comida.dibujar(g);
            movimiento();
            choqueCuerpo();
            colisionPared();
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntaje++;
                puntos.Text = puntaje.ToString();
            }
        }

        public void finJuego()
        {
            puntaje = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            xdir = 0;
            ydir = 0;
            cabeza = new cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Perdiste");
        }

        public void colisionPared()
        {
            if (cabeza.verX() < 0 || cabeza.verX() > 770 || cabeza.verY() < 0 || cabeza.verY() > 380)
            {
                finJuego();
            }

        }


        public void choqueCuerpo()
        {
            cola temp;
            try
            {
                temp = cabeza.verSiguiente().verSiguiente();
            }
            catch (Exception err)
            {
                temp = null;
            }
            while (temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    finJuego();
                }
                else
                {
                    temp = temp.verSiguiente();
                }
            }

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = cuadro;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = cuadro;
                    ejex = true;
                    ejey = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -cuadro;
                    ejex = true;
                    ejey = false;
                }
            }
        }
    }
}