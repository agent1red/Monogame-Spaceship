using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Spaceship
{
    public class Ship
    {
        public Vector2 position = new Vector2(100, 100);

        public int spaceshipSpeed = 4;

        public void ShipUpdate()
        {
            KeyboardState kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Right))
            {
                position.X += spaceshipSpeed; 
            }

            if (kState.IsKeyDown(Keys.Left))
            {
                position.X -= spaceshipSpeed;
            }

            if (kState.IsKeyDown(Keys.Up))
            {
                position.Y -= spaceshipSpeed;
            }

            if (kState.IsKeyDown(Keys.Down))
            {
                position.Y += spaceshipSpeed;
            }
        }
    }
}
