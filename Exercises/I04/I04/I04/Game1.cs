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

using I04.Helpers;

namespace I04
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D rt;

        int width = 800;
        int height = 800;

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
            rt = new RenderTarget2D(GraphicsDevice,
                width,
                height,
                false,
                graphics.GraphicsDevice.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24,
                0,
                RenderTargetUsage.PreserveContents);
            graphics.GraphicsDevice.SetRenderTarget(rt);
            GraphicsDevice.Clear(Color.Black);
            graphics.GraphicsDevice.SetRenderTarget(null);

            Drawing.init(GraphicsDevice, spriteBatch);
            Stats.init();

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
            float numX = Stats.stdNormal();
            float numY = Stats.stdNormal();
            float sdX = width;
            float meanX = width / 2;
            float sdY = height;
            float meanY = height / 2;

            float x = sdX * numX + meanX;
            float y = sdY * numY + meanY;

            int r = (int)((Stats.stdNormal() + 0.5f) * 255f);
            int g = (int)((Stats.stdNormal() + 0.5f) * 255f);
            int b = (int)((Stats.stdNormal() + 0.5f) * 255f);

            Color rndColor = new Color(r, g, b);

            graphics.GraphicsDevice.SetRenderTarget(rt);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            Drawing.circle((int)x - 32, (int)y - 32, 64, rndColor * 0.05f);

            spriteBatch.End();
            graphics.GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin();
            spriteBatch.Draw((Texture2D)rt, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
