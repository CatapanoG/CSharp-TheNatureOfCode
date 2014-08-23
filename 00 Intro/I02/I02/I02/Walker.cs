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

using I02.Helpers;

namespace I02
{
    class Walker
    {
        int x;
        int y;
        Random rnd = new Random();
        Color color = Color.Black;

        public Walker(int width, int height)
        {
            x = width / 2;
            y = height / 2;
        }

        public void display()
        {
            Drawing.point(x, y, color);
        }

        // 4 possible steps
        public void step()
        {
            int choice = (int)rnd.Next(4);

            if (choice == 0)
            {
                x++;
            }
            else if (choice == 1)
            {
                x--;
            }
            else if (choice == 2)
            {
                y++;
            }
            else
            {
                y--;
            }
        }
        // 8 possible steps
        public void step2()
        {
            int stepx = rnd.Next(-1, 2);
            int stepy = rnd.Next(-1, 2);

            x += stepx;
            y += stepy;
        }
    }
}
