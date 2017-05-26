using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace sankeGame
{
    class cola : objeto
    {
        cola siguiente;

        public cola(int x, int y)
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }

        public void dibujar(Graphics g)
        {
            if (siguiente != null)
            {
                siguiente.dibujar(g);
            }

            g.FillRectangle(new SolidBrush(Color.Blue),this.x,this.y,this.ancho,this.ancho);
        }
        //Mover vibora
        public void setxy(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }

            this.x = x;
            this.y = y;
        }

        public void meter()
        {
            if (siguiente == null)
            {
                siguiente = new cola(this.x, this.y);
            }
            else
            {
                siguiente.meter();
            }
        }

        //Obtener valores de x y
        public int verX()
        {
            return this.x;
        }

        public int verY()
        {
            return this.y;
        }

        public cola verSiguiente()
        {
            return siguiente;
        }


    }
}
