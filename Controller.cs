using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Monogame_Spaceship
{
    public class Controller
    {
        public List<Asteroid> asteroids = new();
        public double timer = 2;
        public double maxTime = 2;
        public int nextSpeed = 240; 
        public bool inGame = false;

        public void ControllerUpdate(GameTime gameTime)
        {

            if (inGame)
            {
                timer -= gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                KeyboardState kState = Keyboard.GetState();

                if (kState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                }
            }
         

            if (timer <= 0)
            {
                asteroids.Add(new Asteroid(nextSpeed));
                timer = maxTime;

                if (maxTime > 0.5)
                {
                    maxTime -= 0.1;
                }

                if (nextSpeed < 720)
                {
                    nextSpeed += 4;
                }
            
            }
        }

    }
}
