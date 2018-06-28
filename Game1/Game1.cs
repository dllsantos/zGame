using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D square;
        Vector2 position = new Vector2(0, 0);
        Vector2 velocity = new Vector2(10, 10);
        bool pulo = false;
        Vector2 salto = new Vector2(0, 10);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            square = this.Content.Load<Texture2D>("square");
            position.Y = graphics.GraphicsDevice.Viewport.Height - square.Height;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManag    er content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && position.X + square.Width < graphics.GraphicsDevice.Viewport.Width)
                position.X += velocity.X;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && position.X > 0)
                position.X -= velocity.X;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && pulo == false)
                pulo = true;
            if (pulo){
                position.Y -= salto.Y;
                if (position.Y < 100)
                    salto.Y *= -1;
                if (position.Y >= graphics.GraphicsDevice.Viewport.Height - square.Height) {
                    pulo = false;
                    salto.Y *= -1;
                    position.Y = graphics.GraphicsDevice.Viewport.Height - square.Height;
                }
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(square, position: position);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
