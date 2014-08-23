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

using I03.Helpers;

namespace I03
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
            int choice = rnd.Next(0, 100);

            if (choice < 40)
            {
                x++;
            }
            else if (choice < 60)
            {
                x--;
            }
            else if (choice < 80)
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
