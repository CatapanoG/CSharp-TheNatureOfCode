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

namespace Forces02.Helpers
{
    class _3d
    {
        static GraphicsDevice device;

        static Matrix viewMatrix;
        static Matrix projectMatrix;
        static Effect effect;

        public static VertexPositionColor[] vertices;
        static int[] index;

        static int terrainWidth = 400;
        static int terrainHeight = 400;
        static float[,] heightData;

        static Vector3 camPos = new Vector3(terrainWidth/2,terrainHeight/2,150);
        static Vector3 camLook = new Vector3(terrainWidth / 2, terrainHeight / 2, 0);
        static Vector3 camUp = new Vector3(0, 1, 0);

        #region Initialization
        public static void init(GraphicsDevice gd, Effect eff)
        {
            device = gd;
            effect = eff;
        }
        #endregion
        #region Camera
        public static void setUpCamera()
        {
            viewMatrix = Matrix.CreateLookAt(camPos, camLook, camUp);
            projectMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, device.Viewport.AspectRatio, 1.0f, 300.0f);
        }

        public static void moveCamera(KeyboardState kb)
        {
            if (kb.IsKeyDown(Keys.PageDown))
            {
                camPos.Z -= 1;
            }
            else if (kb.IsKeyDown(Keys.PageUp))
            {
                camPos.Z += 1;
            }
            else if (kb.IsKeyDown(Keys.Down))
            {
                camPos.Y += 1;
                camPos.Z += 1;
            }
            else if (kb.IsKeyDown(Keys.Up))
            {
                camPos.Y -= 1;
                camPos.Z -= 1;
            }
            else if (kb.IsKeyDown(Keys.W))
            {
                camPos.Y += 1;
                camLook.Y += 1;
            }
            else if (kb.IsKeyDown(Keys.S))
            {
                camPos.Y -= 1;
                camLook.Y -= 1;
            }
            else if (kb.IsKeyDown(Keys.A))
            {
                camPos.X -= 1;
                camLook.X -= 1;
            }
            else if (kb.IsKeyDown(Keys.D))
            {
                camPos.X += 1;
                camLook.X += 1;
            }
            
        }
        #endregion
        #region Terrain setup
        public static void setUpVertices()
        {
            vertices = new VertexPositionColor[terrainWidth * terrainHeight];

            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    vertices[x + y * terrainWidth].Position = new Vector3(x, y, heightData[x,y]);
                    vertices[x + y * terrainWidth].Color = Color.White;
                }
            }
        }

        public static void setUpIndex()
        {
            index = new int[(terrainWidth - 1) * (terrainHeight - 1) * 3 * 2];
            int counter = 0;

            for (int x = 0; x < terrainWidth - 1; x++)
            {
                for (int y = 0; y < terrainHeight - 1; y++)
                {
                    int lowerLeft = x + y * terrainWidth;
                    int lowerRight = (x + 1) + y * terrainWidth;
                    int topLeft = x + (y + 1) * terrainWidth;
                    int topRight = (x + 1) + (y + 1) * terrainWidth;

                    index[counter++] = topLeft;
                    index[counter++] = lowerRight;
                    index[counter++] = lowerLeft;

                    index[counter++] = topLeft;
                    index[counter++] = topRight;
                    index[counter++] = lowerRight;
                }
            }
        }

        public static void loadHeightData()
        {
            heightData = new float[terrainWidth, terrainHeight];
            for (int x = 0; x < terrainWidth; x++)
            {
                for (int y = 0; y < terrainHeight; y++)
                {
                    heightData[x, y] = Noise.GetNoise(0.1 + 0.1 * x, 0.1 + 0.1 * y, 0.1) * 20;
                }
            }
        }
        #endregion
        #region rendering
        public static void drawScene()
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            device.RasterizerState = rs;

            //device.DrawUserPrimitives(PrimitiveType.TriangleList, vertices, 0, 1, VertexPositionColor.VertexDeclaration);
            //Matrix worldMatrix = Matrix.CreateRotationZ(3 * angle);
            //effect.Parameters["xWorld"].SetValue(worldMatrix);

            effect.CurrentTechnique = effect.Techniques["ColoredNoShading"];
            effect.Parameters["xView"].SetValue(viewMatrix);
            effect.Parameters["xProjection"].SetValue(projectMatrix);
            effect.Parameters["xWorld"].SetValue(Matrix.Identity);

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, vertices.Length, index, 0, index.Length / 3, VertexPositionColor.VertexDeclaration);
            }

        }
        #endregion
    }
}
