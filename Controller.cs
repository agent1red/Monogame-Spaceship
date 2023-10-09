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

        public void ControllerUpdate(GameTime gameTime)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;

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
