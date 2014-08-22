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

namespace I01
{
    class Walker
    {
        int x;
        int y;
        Random rnd = new Random();

        public Walker()
        {
            x = I01.Game1.width / 2;
            y = I01.Game1.height / 2;
        }

        public void display()
        {
            Helpers.drawing.point(x, y, Color.Red);
        }

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
    }
}
