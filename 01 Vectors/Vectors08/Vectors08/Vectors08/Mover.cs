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

using Vectors08.Helpers;

namespace Vectors08
{
    class Mover
    {
        Vector2 location;
        Vector2 velocity;
        Vector2 acceleration;

        static Random rnd = new Random();
        static int width;
        static int height;
        static float maxSpeed = 10;

        public Mover(int Width, int Height)
        {
            width = Width;
            height = Height;

            location = new Vector2(width/2, height/2);
            velocity = new Vector2(0f, 0f);
            acceleration = new Vector2(-0.001f, 0.01f);
        }

        public void update()
        {
            velocity = Vector2.Add(velocity, acceleration);

            if (velocity.Length() > maxSpeed)
            {
                velocity.Normalize();
                velocity = Vector2.Multiply(velocity, maxSpeed);
            }

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
