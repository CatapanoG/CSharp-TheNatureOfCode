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

using Vectors01.Helpers;

namespace Vectors01
{
    class Walker
    {
        int x;
        int y;
        float tx = 0;
        float ty = 10000;
        int width;
        int height;

        public Walker(int Width, int Height)
        {
            x = Width / 2;
            y = Height / 2;

            width = Width;
            height = Height;
        }

        public void display()
        {
            Drawing.strokeCircle(x, y, 64, Color.White, 6, Color.Gray);
        }

        public void step()
        {
            x += (int)(Noise.GetNoise(tx, 0.1, 0.1));
            y += (int)(Noise.GetNoise(ty, 0.1, 0.1));

            tx += 0.05f;
            ty += 0.05f;
        }
    }
}
