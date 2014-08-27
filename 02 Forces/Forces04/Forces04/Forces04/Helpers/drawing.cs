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

using Forces04.Helpers;

namespace Forces04.Helpers
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
            //sb.Draw(circleTexture, new Rectangle(x,y,radius,radius), color);
            sb.Draw(circleTexture, new Rectangle(x, y, radius, radius), null, color, 0f, new Vector2(circleTexture.Width / 2, circleTexture.Height / 2), SpriteEffects.None, 0f);
        }

        public static void strokeCircle(int x, int y, int radius, Color color, int stroke, Color strokeColor)
        {
            circle(x, y, radius, color);
            circle(x, y , radius - stroke, strokeColor);
        }

        // Draws a perlin image
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

        public static void line(int x0, int y0, int x1, int y1, Color color, int stroke)
        {
            float tempx = x0;
            float tempy = y0;
            float slope;
            float direction;
            int points;

            if (x1 - x0 != 0)
            {
                slope = (float)(y1 - y0) / (float)(x1 - x0);

                if (Math.Abs(slope) > 1)
                {
                    points = (int)(Math.Abs(y0 - y1));
                    slope = (float)(x1 - x0) / (float)(y1 - y0);
                    direction = (y1 - y0) / (Math.Abs(y1 - y0));

                    for (int i = 0; i < points; i++)
                    {
                        tempx += slope * direction;
                        tempy += direction;

                        rectangle((int)tempx, (int)tempy, stroke, stroke, color);
                    }
                }
                else
                {
                    points = (int)(Math.Abs(x0 - x1)); 
                    direction = (x1 - x0) / (Math.Abs(x1 - x0));

                    for (int i = 0; i < points; i++)
                    {
                        tempx += direction;
                        tempy += slope * direction;

                        rectangle((int)tempx, (int)tempy, stroke, stroke, color);
                    }
                }
            }
        }
        #endregion
    }
}
