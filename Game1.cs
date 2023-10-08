using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Spaceship
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D _shipSprite;
        Texture2D _asteroidSprite;
        Texture2D _spaceSprite;
        SpriteFont _gameFont;
        SpriteFont _timerFont;

        Ship player = new Ship();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _shipSprite = Content.Load<Texture2D>("ship");
            _spaceSprite = Content.Load<Texture2D>("space");
            _asteroidSprite = Content.Load<Texture2D>("asteroid");
            _gameFont = Content.Load<SpriteFont>("spaceFont");
            _timerFont = Content.Load<SpriteFont>("timerFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.ShipUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_shipSprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);
            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}