// The nature of code
// A book by:Daniel Shiffman
// Website: http://natureofcode.com/
// 
// Code ported by Gennaro Catapano
// Website: http://www.gennarocatapano.it
// Example 2.4: Including friction

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

namespace Forces04
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        //Effect effect;

        int width = 900;
        int height = 450;

        Mover[] movers;
        Vector2 wind = new Vector2(0.01f, 0f);
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
            Window.Title = "Example 2.4: Including friction";

            this.IsMouseVisible = true;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;

            Helpers.Drawing.init(device, spriteBatch);

            movers = new Mover[10];

            for (int i = 0; i < movers.Length; i++)
            {
                movers[i] = new Mover(rnd.Next(1, 5), rnd.Next(50, width - 50), 50f, width, height);
            }

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


            for (int i = 0; i < movers.Length; i++)
            {
                float c = 0.05f;
                Vector2 friction = new Vector2(movers[i].velocity.X, movers[i].velocity.Y);
                friction = Vector2.Multiply(friction, -1f);
                if (friction.Length() > 0)
                {
                    friction.Normalize();
                }
                friction = Vector2.Multiply(friction, c);

                float m = movers[i].mass;
                Vector2 gravity = new Vector2(0f, 0.1f * m);

                movers[i].applyForce(friction);
                movers[i].applyForce(wind);
                movers[i].applyForce(gravity);
                
                movers[i].update();
                movers[i].checkEdges();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.White);

            //Helpers._3d.drawScene();

            spriteBatch.Begin();

            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].display();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
