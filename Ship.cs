using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Spaceship
{
    public class Ship
    {
        static public Vector2 defaultPosition = new Vector2(640, 360);
        public Vector2 position = defaultPosition;

        // in pixels per second across the map. 
        public int spaceshipSpeed = 180;

        public void ShipUpdate(GameTime gameTime)
        {


            KeyboardState kState = Keyboard.GetState();

            // Grab real time seconds elapsed and multiply it by player speed
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
