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

using Vectors02.Helpers;

namespace Vectors02
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        //Effect effect;

        int width = 900;
        int height = 900;

        Vector2 location = new Vector2(100f,100f);
        Vector2 velocity = new Vector2(2.5f,5f);

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

            location = Vector2.Add(location, velocity);

            if ((location.X < 0) || (location.X > width))
            {
                velocity.X = velocity.X * -1;
            }
            if ((location.Y < 0) || (location.Y > height))
            {
                velocity.Y = velocity.Y * -1;
            }

            spriteBatch.Begin();
            Helpers.Drawing.strokeCircle((int)location.X, (int)location.Y, 64, Color.Black, 10, Color.Gray);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
