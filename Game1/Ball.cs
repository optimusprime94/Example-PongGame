using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongGame
{
    public class Ball: Sprite
    {

        private Paddle attachedToPaddle;

        public Ball(Texture2D texture, Vector2 location, Rectangle screenBounds) : base(texture, location, screenBounds)
        {
        }

        protected override void CheckBounds()
        {
            // Works like a charm
            //Location.Y = MathHelper.Clamp(Location.Y, 0, gameBoundaries.Height - Texture.Height);
            //Location.X = MathHelper.Clamp(Location.X, 0, gameBoundaries.Width - Texture.Width);

            if (Location.Y >= (gameBoundaries.Height - this.Height) || Location.Y <= 0)
            {
                var newVeloxity = new Vector2(Velocity.X, -Velocity.Y);
                Velocity = newVeloxity;
            } 
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && attachedToPaddle != null)
            {
                var newVelocity = new Vector2(2.5f, attachedToPaddle.Velocity.Y * 0.65f);
                Velocity = newVelocity;
                attachedToPaddle = null;
            }

            if (attachedToPaddle != null)
            {
                //Bollens position + paddel with (kollision, den går inte förbi den)
                Location.X = attachedToPaddle.Location.X + attachedToPaddle.Width;
                Location.Y = attachedToPaddle.Location.Y;
            }
            else
            {
                if (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) ||
                    BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                {
                    Velocity = new Vector2(-Velocity.X, Velocity.Y);
                }
            }

            base.Update(gameTime, gameObjects);
        }

        public void AttachTo(Paddle paddle)
        {
            attachedToPaddle = paddle;
        }
    }
}