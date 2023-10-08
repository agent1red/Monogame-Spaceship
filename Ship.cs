using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Spaceship
{
    public class Ship
    {
        public Vector2 position = new Vector2(100, 100);

        // in pixels per second across the map. 
        public int spaceshipSpeed = 180;

        public void ShipUpdate(GameTime gameTime)
        {


            KeyboardState kState = Keyboard.GetState();

            // Grab realtime seconds elapsed and multiply it by player speed
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Right))
            {
                position.X += spaceshipSpeed * deltaTime; 
            }

            if (kState.IsKeyDown(Keys.Left))
            {
                position.X -= spaceshipSpeed * deltaTime;
            }

            if (kState.IsKeyDown(Keys.Up))
            {
                position.Y -= spaceshipSpeed * deltaTime;
            }

            if (kState.IsKeyDown(Keys.Down))
            {
                position.Y += spaceshipSpeed * deltaTime;
            }
        }
    }
}
