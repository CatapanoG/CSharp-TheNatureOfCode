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

using I09.Helpers;

namespace I09.Helpers
{
    class Drawing
    {
        #region Variables
        static SpriteBatch sb;
        static GraphicsDevice device;

        static Texture2D pointTexture;
        static Texture2D circleTexture;

        static Texture2D perlinTexture;
        static Color[] textureColors;
        static float perlinTime = 0f;
        static int perlinWidth;
        static int perlinHeight;

        static Color defaultColor = Color.White;
        static float stdAlpha = 1.00f;
        #endregion

        #region Public methods
        public static void init(GraphicsDevice graphDev, SpriteBatch spriteBatch)
        {
            // init pointTexture
            pointTexture = new Texture2D(graphDev, 1, 1, false, SurfaceFormat.Color);
            pointTexture.SetData<Color>(new Color[] { defaultColor });

            // init circleTexture
            int circleRadius = 200;
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
            circleTexture.SetData<Color>(colorData);

            // spriteBatch & GraphDev references
            sb = spriteBatch;
            device = graphDev;
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

        public static void strokeCircle(int x, int y, int radius, Color color, int stroke, Color strokeColor)
        {
            circle(x, y, radius, color);
            circle(x + stroke / 2, y + stroke / 2, radius - stroke, strokeColor);
        }

        public static void perlin(int xPos, int yPos, int width, int height)
        {
            //perlinTexture = new Texture2D(device, width, height, false, SurfaceFormat.Color);

            for (int x = 0; x < perlinWidth; x++)
            {
                for (int y = 0; y < perlinHeight; y++)
                {
                    float perlin = Noise.GetNoise(0.1 + x * 0.05, 0.1 + y * 0.05, 0.1 + perlinTime);
                    textureColors[x + y * width] = new Color(
                            perlin,
                            perlin,
                            perlin);
                }
            }

            device.Textures[0] = null;
            perlinTexture.SetData<Color>(textureColors);
            sb.Draw(perlinTexture, new Rectangle(xPos, yPos, width, height), Color.White);
            
            // Set perlinTime > 0 for a dynamic effect
            perlinTime += 0.05f;
        }

        public static void perlinInit(int xPos, int yPos, int width, int height)
        {
            perlinTexture = new Texture2D(device, width, height, false, SurfaceFormat.Color);
            textureColors = new Color[width * height];
            perlinWidth = width;
            perlinHeight = height;
        }
        #endregion
    }
}
