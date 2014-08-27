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

using Forces02.Helpers;

namespace Forces02
{
    class Mover
    {
        Vector2 location;
        Vector2 velocity;
        Vector2 acceleration;
        Vector2 dir;
        float mass;

        static Vector2 mouse;
        static Random rnd = new Random();
        static int width;
        static int height;
        static float maxSpeed = 10;

        public Mover(float m, float x, float y, int Width, int Height)
        {
            width = Width;
            height = Height;

            location = new Vector2(x, y);
            velocity = new Vector2(0f, 0f);
            acceleration = new Vector2(0f, 0f);
            mass = m;
        }

        public void update()
        {
            velocity = Vector2.Add(velocity, acceleration);
            //limitSpeed();
            location = Vector2.Add(location, velocity);
            
            acceleration = Vector2.Multiply(acceleration, 0f);
        }

        public void applyForce(Vector2 force)
        {
            force = Vector2.Divide(force, mass);
            acceleration = Vector2.Add(acceleration, force);
        }

        public static void updateMouse(Vector2 Mouse)
        {
            mouse = Mouse;
        }

        public void display()
        {
            Drawing.strokeCircle((int)location.X, (int)location.Y, 16 * (int)mass, Color.Black * 0.25f, 6, Color.Gray * 0.25f);
        }

        public void checkEdges() 
        {
            if (location.X > width)
            {
                velocity.X *= -1;
                location.X = width;
            }
            else if (location.X < 0)
            {
                velocity.X *= -1;
                location.X = 0;
            }

            if (location.Y > height)
            {
                velocity.Y *= -1;
                location.Y = height;
            }
            else if (location.Y < 0)
            {
                velocity.Y *= -1;
                location.Y = 0;
            }
        }

        void limitSpeed()
        {
            if (velocity.Length() > maxSpeed)
            {
                velocity.Normalize();
                velocity = Vector2.Multiply(velocity, maxSpeed);
            }
        }
    }
}
