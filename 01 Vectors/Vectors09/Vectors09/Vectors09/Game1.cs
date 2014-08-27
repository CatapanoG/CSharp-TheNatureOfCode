// The nature of code
// A book by:Daniel Shiffman
// Website: http://natureofcode.com/
// 
// Code ported by Gennaro Catapano
// Website: http://www.gennarocatapano.it
// Example 1.9: Motion 101 (velocity and random acceleration)

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

using Vectors09.Helpers;

namespace Vectors09
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        //Effect effect;

        int width = 900;
        int height = 900;

        Mover mover;

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
            Window.Title = "Example 1.9: Motion 101 (velocity and random acceleration)";

            this.IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            Helpers.Drawing.init(device, spriteBatch);

            mover = new Mover(width, height);

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

            mover.update();
            mover.checkEdges();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.White);

            //Helpers._3d.drawScene();

            spriteBatch.Begin();
            mover.display();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
