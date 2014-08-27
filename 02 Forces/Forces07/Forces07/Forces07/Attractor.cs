using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Forces07.Helpers;

namespace Forces07
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

        public Attractor(int width, int height)
        {
            location = new Vector2(width / 2, height / 2);
            mass = 20f;
            G = 0.4f;
            selected = false;
        }

        public void display()
        {
            if (selected)
            {
                Drawing.strokeCircle((int)location.X, (int)location.Y, radius, Color.Black, 6, colorSelected);
            }
            else
            {
                Drawing.strokeCircle((int)location.X, (int)location.Y, radius, Color.Black, 6, colorUnselected);
            }          
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
