using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Forces08.Helpers;

namespace Forces08
{
    class Attractor
    {
        float mass;
        public Vector2 location;
        float G;
        public int radius = 64;
        Color colorSelected = Color.LightGray;
        Color colorUnselected = Color.Gray;
        public bool selected;

        public Attractor(Vector2 location, float mass, int width, int height)
        {
            location = new Vector2(width / 2 - 100, height / 2);
            mass = 100f;
            G = 1f;
            selected = false;
        }

        public void display()
        {
            Drawing.strokeCircle((int)location.X, (int)location.Y, radius, Color.Black, 6, colorSelected);        
        }

        public Vector2 attract(Mover m)
        {
            Vector2 force = Vector2.Subtract(location, m.location);
            float distance = force.Length();
            /*if (distance > 25f)
            {
                distance = 25.0f;
            }
            else if (distance < 5.0f)
            {
                distance = 5.0f;
            }*/

            force.Normalize();
            float strength = (G * mass * m.mass) / (distance * distance);
            Vector2.Multiply(force, strength);

            return force;
        }
    }
}
