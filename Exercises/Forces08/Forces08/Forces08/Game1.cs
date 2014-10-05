// The nature of code
// A book by:Daniel Shiffman
// Website: http://natureofcode.com/
// 
// Code ported by Gennaro Catapano
// Website: http://www.gennarocatapano.it
// Exercise 2.8: 
// In the example above, we have a system (i.e. array) of Mover objects and one Attractor object. 
// Build an example that has systems of both movers and attractors. 
// What if you make the attractors invisible? Can you create a pattern/design from the trails of objects moving around attractors? 
// See the Metropop Denim project by Clayton Cubitt and Tom Carden for an example.

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

using Forces08.Helpers;

namespace Forces08
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        SpriteFont font;
        RenderTarget2D rt;
        Texture2D sm;

        int width = 1000;
        int height = 1000;

        Mover[] movers;
        Attractor[] attractors;
        Attractor center;
        Random rnd = new Random();

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
            Window.Title = "Exercise 2.8";
            this.IsMouseVisible = true;

            // Graphics Init
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            Helpers.Drawing.init(device, spriteBatch);
            device.Clear(Color.White);

            // RenderTarget Init
            rt = new RenderTarget2D(device, width, height, true, device.DisplayMode.Format, DepthFormat.Depth24, 1, RenderTargetUsage.PreserveContents);
            device.SetRenderTarget(rt);
            device.Clear(Color.Gray);
            device.SetRenderTarget(null);

            // Objects Init         
            movers = new Mover[900];
            float step = (float)width/(float)movers.Length;

            for (int i = 0; i < movers.Length; i++)
            {
                movers[i] = new Mover(200, step * i, 0, width, height);
            }

            attractors = new Attractor[1];
            attractors[0] = new Attractor(width, height);

            center = new Attractor
            //
            base.Initialize();
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("stdFont");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].applyForce(attractors[0].attract(movers[i]));
                movers[i].update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //device.Clear(Color.White);
            device.SetRenderTarget(rt);

            spriteBatch.Begin();
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].display();
            }

            attractors[0].display();
            spriteBatch.End();

            device.SetRenderTarget(null);
            sm = (Texture2D)rt;

            spriteBatch.Begin();
            spriteBatch.Draw(sm, new Rectangle(0, 0, width, height), Color.White);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
