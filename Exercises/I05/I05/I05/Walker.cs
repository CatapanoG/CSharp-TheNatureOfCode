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

using I05.Helpers;

namespace I05
{
    class Walker
    {
        int x;
        int y;
        Random rnd = new Random();
        Color color = Color.White;

        public Walker(int width, int height)
        {
            x = width / 2;
            y = height / 2;
        }

        public void display()
        {
            Drawing.point(x, y, color);
        }

        public void step()
        {
            int direction = Stats.discreteUniform();
            int step = (int)((Stats.stdNormal() + 0.5f) * 4);

            if (direction < 25)
            {
                x += step;
            }
            else if (direction < 50)
            {
                x -= step;
            }
            else if (direction < 75)
            {
                y += step;
            }
            else
            {
                y -= step;
            }
        }
    }
}
