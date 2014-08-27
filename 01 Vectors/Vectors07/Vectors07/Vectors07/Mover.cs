using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Vectors07.Helpers;

namespace Vectors07
{
    class Mover
    {
        Vector2 location;
        Vector2 velocity;

        static Random rnd = new Random();
        static int width;
        static int height;

        public Mover(int Width, int Height)
        {
            width = Width;
            height = Height;

            location = new Vector2(rnd.Next(width), rnd.Next(height));
            velocity = new Vector2(rnd.Next(-4,4), rnd.Next(-4,4));
        }

        public void update()
        {
            location = Vector2.Add(location, velocity);
        }

        public void display()
        {
            Drawing.strokeCircle((int)location.X, (int)location.Y, 32, Color.Gray, 6, Color.Black);
        }

        public void checkEdges() 
        {
            if (location.X > width)
            {
                location.X = 0;
            }
            else if (location.X < 0)
            {
                location.X = width;
            }

            if (location.Y > height)
            {
                location.Y = 0;
            }
            else if (location.Y < 0)
            {
                location.Y = height;
            }
        }
    }
}
