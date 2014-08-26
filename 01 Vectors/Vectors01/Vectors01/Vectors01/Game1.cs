// Example 1.1: Bouncing ball with no vectors

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

using Vectors01.Helpers;

namespace Vectors01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        //Effect effect;

        int width = 900;
        int height = 900;

        float x = 100f;
        float y = 100f;
        float xspeed = 1f;
        float yspeed = 3.3f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Screen Init
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
            Window.Title = "Example 1.1: Bouncing ball with no vectors";

            this.IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            Helpers.Drawing.init(device, spriteBatch);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //effect = Content.Load<Effect>("effects");
            //Helpers._3d.init(device, effect);
            //Helpers._3d.setUpCamera();
            //Helpers._3d.loadHeightData();
            //Helpers._3d.setUpVertices();
            //Helpers._3d.setUpIndex();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //KeyboardState keyState = Keyboard.GetState();
            //Helpers._3d.moveCamera(keyState);
            //Helpers._3d.setUpCamera();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.White);

            //Helpers._3d.drawScene();

            x = x + xspeed;
            y = y + yspeed;

            if ((x < 0) || (x > width))
            {
                xspeed = xspeed * -1;
            }
            if ((y < 0) || (y > height))
            {
                yspeed = yspeed * -1;
            }

            spriteBatch.Begin();
            //Helpers.Drawing.circle((int)x, (int)y, 32, Color.White);
            Helpers.Drawing.strokeCircle((int)x, (int)y, 64, Color.Black, 10, Color.Gray);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
