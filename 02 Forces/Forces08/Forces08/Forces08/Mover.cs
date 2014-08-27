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

using Forces08.Helpers;

namespace Forces08
{
    class Mover
    {
        public Vector2 location;
        public Vector2 velocity;
        Vector2 acceleration;
        public float mass;

        static Vector2 mouse;
        static Random rnd = new Random();
        static int width;
        static int height;
        static float maxSpeed = 15;
        static float G = 0.01f;

        public Mover(float m, float x, float y, int Width, int Height)
        {
            width = Width;
            height = Height;

            location = new Vector2(x, y);
            velocity = new Vector2(rnd.Next((int)maxSpeed * -1, (int)maxSpeed), rnd.Next((int)maxSpeed * -1, (int)maxSpeed));
            acceleration = new Vector2(0f, 0f);
            mass = m;
        }

        public void update()
        {
            velocity = Vector2.Add(velocity, acceleration);
            limitSpeed();
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
            Drawing.strokeCircle((int)location.X, (int)location.Y, 1 * (int)mass, Color.Black * 0.45f, 6, Color.Gray * 0.25f);
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

        public Boolean isInside(Liquid l)
        {
            if (location.X > l.x && location.X < l.x + l.w && location.Y > l.y && location.Y < l.y + l.h)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void drag(Liquid l) {
 
            float speed = velocity.Length();
            float dragMagnitude = l.c * speed * speed;

            Vector2 drag = new Vector2(velocity.X, velocity.Y);
            drag = Vector2.Multiply(drag, -1f);
            drag.Normalize();
 
            drag = Vector2.Multiply(drag, dragMagnitude);
 
            applyForce(drag);
          }

        public Vector2 attract(Mover m)
        {
            Vector2 force = Vector2.Subtract(location, m.location);
            float distance = force.Length();
            if (distance > 25f)
            {
                distance = 25.0f;
            }
            else if (distance < 5.0f)
            {
                distance = 5.0f;
            }

            force.Normalize();
            float strength = (G * mass * m.mass) / (distance * distance);
            Vector2.Multiply(force, strength);

            return force;
        }

    }
}
