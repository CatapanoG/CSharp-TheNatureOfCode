using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using I04.Helpers;

namespace I04
{
    class Walker
    {
        int x;
        int y;
        Random rnd = new Random();
        Color color = Color.Black;

        public int mouseX = 0;
        public int mouseY = 0;

        public Walker(int width, int height)
        {
            x = width / 2;
            y = height / 2;
        }

        public void display()
        {
            //Drawing.point(x, y, color);
            Drawing.circle(x, y, 50, Color.White);
        }

        public void step()
        {
            int realization = rnd.Next(0, 100);

            if (realization < 50)
            {
                int dirX = mouseX - x;
                int dirY = mouseY - y;

                if (dirX != 0)
                {
                    x += dirX / Math.Abs(dirX);
                }
                if (dirY != 0)
                {
                    y += dirY / Math.Abs(dirY);
                }  
            }
            else
            {
                if (realization < 62.5)
                {
                    x++;
                }
                else if (realization < 75)
                {
                    x--;
                }
                else if (realization < 87.5)
                {
                    y++;
                }
                else
                {
                    y--;
                }
            }
        }
    }
}
