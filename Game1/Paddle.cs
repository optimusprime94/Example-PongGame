using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }
    public class Paddle : Sprite
    {
        private PlayerTypes playerType;

        public Paddle(Texture2D texture, Vector2 location, Rectangle screenbounds, PlayerTypes playerType) : 
            base(texture, location, screenbounds)
        {
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (playerType == PlayerTypes.Computer)
            {
                // Computer logic
                if(gameObjects.Ball.Location.Y + gameObjects.Ball.Height < Location.Y)
                    Velocity = new Vector2(0, -2.5f);

                if (gameObjects.Ball.Location.Y > Location.Y + Height)
                    Velocity = new Vector2(0, 2.5f);
            }


            if (playerType == PlayerTypes.Human)
            {
                // Getstate hämtar nuvarande tillståndet på tangentbordet
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    // rör paddle uppåt
                    Velocity = new Vector2(0, -2.5f);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    // rör paddle neråt
                    Velocity = new Vector2(0, 2.5f);
                }
            }
            base.Update(gameTime, gameObjects);
        }

        protected override void CheckBounds()
        {
            // Begränsar första parametern till att hålla sig mellan min och max (0) övre hörnet
            // och höjden neråt - objektet
           Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - Texture.Height);
        }
    }
}
