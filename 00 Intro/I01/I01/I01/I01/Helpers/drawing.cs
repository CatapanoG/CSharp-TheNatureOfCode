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

namespace I01.Helpers
{
    class drawing
    {
        // Vars
        static Texture2D pointTexture;
        static Color defaultColor = Color.White;
        static SpriteBatch sb;

        // Constructor
        public drawing(GraphicsDevice graphDev, SpriteBatch spriteBatch)
        {
            pointTexture = new Texture2D(graphDev, 1, 1, false, SurfaceFormat.Color);
            pointTexture.SetData<Color>(new Color[] { defaultColor });

            sb = spriteBatch;
        }

        // Methods
        public static void point(int x, int y, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, 2, 2), color);
        }

        public static void rectangle(int x, int y, int width, int height, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, width, height), color);
        }
    }
}
