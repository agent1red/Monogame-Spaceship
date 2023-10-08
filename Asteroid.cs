using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Monogame_Spaceship
{
    public  class Asteroid
    {
        public Vector2 position = new Vector2(600, 300);

        public Random random = new Random();

        // in pixels per second across the map. 
        public int asteroidSpeed;

        public int radius = 59;

        public Asteroid(int newSpeed)
        {
            asteroidSpeed = newSpeed;

            position.X = 1380;
            position.Y = random.Next(25, 575);

        }

        public void AsteroidUpdate(GameTime gameTime)
        {
            // Grab real time seconds elapsed and multiply it by asteroid speed
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X -= asteroidSpeed * deltaTime;

        }
    }
}
