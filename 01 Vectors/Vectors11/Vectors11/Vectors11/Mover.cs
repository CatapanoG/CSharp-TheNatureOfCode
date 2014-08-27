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

using Vectors11.Helpers;

namespace Vectors11
{
    class Mover
    {
        Vector2 location;
        Vector2 velocity;
        Vector2 acceleration;
        static Vector2 mouse;
        Vector2 dir;

        static Random rnd = new Random();
        static int width;
        static int height;
        static float maxSpeed = 10;

        public Mover(int Width, int Height)
        {
            width = Width;
            height = Height;

            location = new Vector2(rnd.Next(0,width), rnd.Next(0,height));
            velocity = new Vector2(0f, 0f);
            acceleration = new Vector2(0f, 0f);
        }

        public void update()
        {
            dir = Vector2.Subtract(mouse, location);
            dir.Normalize();
            dir = Vector2.Multiply(dir, 0.5f);

            acceleration = dir;

            velocity = Vector2.Add(velocity, acceleration);

            if (velocity.Length() > maxSpeed)
            {
                velocity.Normalize();
                velocity = Vector2.Multiply(velocity, maxSpeed);
            }

            location = Vector2.Add(location, velocity);
        }

        public static void updateMouse(Vector2 Mouse)
        {
            mouse = Mouse;
        }

        public void display()
        {
            Drawing.strokeCircle((int)location.X, (int)location.Y, 64, Color.Black * 0.75f, 6, Color.Gray * 0.45f);
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
