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

namespace I04.Helpers
{
    class Drawing
    {
        // Vars
        static Texture2D pointTexture;
        static Texture2D circleTexture;
        static int circleRadius = 100;
        static Color defaultColor = Color.White;
        static SpriteBatch sb;
        static float stdAlpha = 1.00f;

        // Methods
        public static void init(GraphicsDevice graphDev, SpriteBatch spriteBatch)
        {
            // init pointTexture
            pointTexture = new Texture2D(graphDev, 1, 1, false, SurfaceFormat.Color);
            pointTexture.SetData<Color>(new Color[] { defaultColor });

            // init circleTexture
            circleTexture = new Texture2D(graphDev, circleRadius, circleRadius);
            Color[] colorData = new Color[circleRadius * circleRadius];

            float diam = circleRadius / 2f;
            float diamsq = diam * diam;

            for (int x = 0; x < circleRadius; x++)
            {
                for (int y = 0; y < circleRadius; y++)
                {
                    int index = x * circleRadius + y;
                    Vector2 pos = new Vector2(x - diam, y - diam);
                    if (pos.LengthSquared() <= diamsq)
                    {
                        colorData[index] = defaultColor;
                    }
                    else
                    {
                        colorData[index] = Color.Transparent;
                    }
                }
            }
            circleTexture.SetData(colorData);

            // spriteBatch reference
            sb = spriteBatch;
        }

        public static void point(int x, int y, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, 1, 1), color * stdAlpha);
        }

        public static void rectangle(int x, int y, int width, int height, Color color)
        {
            sb.Draw(pointTexture, new Rectangle(x, y, width, height), color);
        }

        public static void circle(int x, int y, int radius, Color color)
        {
            sb.Draw(circleTexture, new Rectangle(x,y,radius,radius), color);
        }
    }
}
