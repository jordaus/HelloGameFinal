using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HelloGame
{
    public class HelloGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 ballPos;
        private Vector2 velocity;
        private Texture2D ballTex;

        public HelloGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "Wassup Game!";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ballPos = new Vector2(
                GraphicsDevice.Viewport.Width / 2,
                GraphicsDevice.Viewport.Height / 2
                );

            System.Random random = new System.Random();
            velocity = new Vector2(
                (float)random.NextDouble(),
                (float)random.NextDouble()
                );

            velocity.Normalize();
            velocity *= 100;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ballTex = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            ballPos += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(ballPos.X < GraphicsDevice.Viewport.X || ballPos.X > GraphicsDevice.Viewport.Width - 64)
            {
                velocity.X *= -1;
            }

            if(ballPos.Y < GraphicsDevice.Viewport.Y || ballPos.Y > GraphicsDevice.Viewport.Height - 64)
            {
                velocity.Y *= -1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTex, ballPos, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
