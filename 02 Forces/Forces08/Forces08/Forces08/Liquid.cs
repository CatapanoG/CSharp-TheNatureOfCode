using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Forces08.Helpers;

namespace Forces08
{
    class Liquid
    {
        public float x, y, w, h;
        public float c;

        public Liquid(float x_, float y_, float w_, float h_, float c_)
        {
            x = x_;
            y = y_;
            w = w_;
            h = h_;
            c = c_;
        }

        public void display()
        {
            Drawing.rectangle((int)x, (int)y, (int)w, (int)h, Color.Aquamarine * 0.5f);
        }
    }
}
