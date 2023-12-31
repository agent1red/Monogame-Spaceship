﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        Controller gameController = new();


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

            if (gameController.inGame)
            {
                player.ShipUpdate(gameTime);
            }
         

            gameController.ControllerUpdate(gameTime);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                gameController.asteroids[i].AsteroidUpdate(gameTime);

                int sum = gameController.asteroids[i].radius + player.radius;

                if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
                {
                    gameController.inGame = false;
                    player.position = Ship.defaultPosition;
                    gameController.asteroids.Clear();
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_spaceSprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(_shipSprite, new Vector2(player.position.X - 34, player.position.Y - 50), Color.White);

            for (int i = 0; i < gameController.asteroids.Count; i++)
            {
                _spriteBatch.Draw(_asteroidSprite, new Vector2(gameController.asteroids[i].position.X - gameController.asteroids[i].radius, gameController.asteroids[i].position.Y - gameController.asteroids[i].radius), Color.White);
            }

            if (!gameController.inGame)
            {
                string menuMessage = "Press ENTER to begin!";

                // Getting the measurement value of the string text
                Vector2 sizeOfText =  _gameFont.MeasureString(menuMessage);

                int halfWidthOfScreen = _graphics.PreferredBackBufferWidth / 2;

                _spriteBatch.DrawString(_gameFont, menuMessage, new Vector2(halfWidthOfScreen - sizeOfText.X/2, 200), Color.White);

            }

            _spriteBatch.DrawString(_timerFont, $"Time: {Math.Floor(gameController.totalTime)}", new Vector2(3,3), Color.White);

            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}