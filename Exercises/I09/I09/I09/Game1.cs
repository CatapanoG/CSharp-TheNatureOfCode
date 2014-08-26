// Exercise I.8
// Play with color, noiseDetail(), and the rate at which xoff and yoff are incremented to achieve different visual effects. 

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

namespace I09
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        //RenderTarget2D rt;

        int width = 900;
        int height = 900;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
            Window.Title = "Exercise I.9";

            this.IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            /*rt = new RenderTarget2D(GraphicsDevice,
                width,
                height,
                false,
                device.PresentationParameters.BackBufferFormat,
                DepthFormat.Depth24,
                0,
                RenderTargetUsage.PreserveContents);
            
            device.SetRenderTarget(rt);
            device.Clear(Color.Black);
            device.SetRenderTarget(null);*/

            Drawing.init(device, spriteBatch);

            Drawing.perlinInit(0, 0, width, height);

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
            // The code below is for using the rendertarget
            //
            /*graphics.GraphicsDevice.SetRenderTarget(rt);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.End();
            graphics.GraphicsDevice.SetRenderTarget(null);

            spriteBatch.Begin();
            spriteBatch.Draw((Texture2D)rt, new Vector2(0, 0), Color.White);
            spriteBatch.End();*/

            spriteBatch.Begin();
            Drawing.perlin(0, 0, width, height);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
