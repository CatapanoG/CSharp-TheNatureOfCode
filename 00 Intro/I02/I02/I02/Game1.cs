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

using I02.Helpers;

namespace I02
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int[] randomCounts;
        Random random = new Random();

        int width = 640;
        int height = 240;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
 
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GraphicsDevice.Clear(Color.White);

            Drawing.init(GraphicsDevice, spriteBatch);

            randomCounts = new int[20];

            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            int index = random.Next(0, randomCounts.Length);
            randomCounts[index]++;

            int w = width / randomCounts.Length;
            spriteBatch.Begin();
            for (int x = 0; x < randomCounts.Length; x++)
            {
                Drawing.rect(x * w, height - randomCounts[x], w, randomCounts[x], Color.Gray, 2, Color.Black);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
