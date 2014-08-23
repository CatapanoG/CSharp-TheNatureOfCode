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

namespace I02.Helpers
{
    class Drawing
    {
        // Vars
        static Texture2D pointTexture;
        static Color defaultColor = Color.White;
        static SpriteBatch sb;
        static float stdAlpha = 1.00f;

        // Constructor
        public Drawing(GraphicsDevice graphDev, SpriteBatch spriteBatch)
        {
            pointTexture = new Texture2D(graphDev, 1, 1, false, SurfaceFormat.Color);
            pointTexture.SetData<Color>(new Color[] { defaultColor });

            sb = spriteBatch;
        }

        // Methods
        public static void init(GraphicsDevice graphDev, SpriteBatch spriteBatch)
        {
            pointTexture = new Texture2D(graphDev, 1, 1, false, SurfaceFormat.Color);
            pointTexture.SetData<Color>(new Color[] { defaultColor });

            sb = spriteBatch;
        }

        public static void point(int x, int y, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, 1, 1), color * stdAlpha);
        }

        public static void rect(int x, int y, int width, int height, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, width, height), color);
        }

        public static void rect(int x, int y, int width, int height, Color color, int stroke, Color strokeColor)
        {
            rect(x, y, width, height, strokeColor);
            rect(x + stroke, y + stroke, width - 2 * stroke, height - 2 * stroke, color);
        }
    }
}
