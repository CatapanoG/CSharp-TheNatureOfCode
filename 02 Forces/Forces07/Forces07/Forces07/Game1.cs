// The nature of code
// A book by:Daniel Shiffman
// Website: http://natureofcode.com/
// 
// Code ported by Gennaro Catapano
// Website: http://www.gennarocatapano.it
// Example 2.7: Attraction with many Movers

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

using Forces07.Helpers;

namespace Forces07
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GraphicsDevice device;
        SpriteFont font;
        //Effect effect;

        int width = 900;
        int height = 900;

        Mover[] movers;
        Attractor a;
        Random rnd = new Random();
        Vector2 mouseLocation;
        bool mouseWasPressed = false;

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
            Window.Title = "Example 2.7: Attraction with many Movers";
            this.IsMouseVisible = true;

            // Graphics Init
            spriteBatch = new SpriteBatch(GraphicsDevice);
            device = graphics.GraphicsDevice;
            Helpers.Drawing.init(device, spriteBatch);

            // Objects Init
            a = new Attractor(width, height);           
            movers = new Mover[10];
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i] = new Mover(1.0f, rnd.Next(50, width - 50), rnd.Next(50, height - 50), width, height);
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

            font = Content.Load<SpriteFont>("stdFont");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            MouseState mouState = Mouse.GetState();
            mouseLocation = new Vector2(mouState.X,mouState.Y);

            if (mouState.LeftButton == ButtonState.Pressed)
            {
                float dist = Vector2.Subtract(mouseLocation, a.location).Length();

                if (dist < a.radius)
                {
                    a.selected = true;
                    mouseWasPressed = true;
                    a.location = mouseLocation;
                }
            }
            if (mouState.LeftButton == ButtonState.Released && mouseWasPressed == true)
            {
                a.selected = false;
                mouseWasPressed = false;
            }

            for (int i = 0; i < movers.Length; i++)
            {
                Vector2 force = a.attract(movers[i]);
                movers[i].applyForce(force);
                movers[i].update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            device.Clear(Color.White);

            //Helpers._3d.drawScene();

            spriteBatch.Begin();

            a.display();
            for (int i = 0; i < movers.Length; i++)
            {
                movers[i].display();
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
