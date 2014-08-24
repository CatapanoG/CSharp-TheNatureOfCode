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

using I06.Helpers;

namespace I06
{
    class Walker
    {
        int x;
        int y;
        float tx = 0;
        float ty = 10000;
        Perlin perlin;
        int width;
        int height;

        public Walker(int Width, int Height)
        {
            x = Width / 2;
            y = Height / 2;

            perlin = new Perlin(99);

            width = Width;
            height = Height;
        }

        public void display()
        {
            Drawing.strokeCircle(x, y, 64, Color.White, 6, Color.Gray);
        }

        public void step()
        {
            x += (int)((perlin.Noise(tx, 0.1, 0.1))*10);
            y += (int)((perlin.Noise(ty, 0.1, 0.1))*10);

            tx += 0.05f;
            ty += 0.05f;
        }
    }
}
