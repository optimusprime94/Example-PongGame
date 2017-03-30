using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongGame
{
    public abstract class Sprite
    {
        protected readonly Texture2D Texture;

        public int Width
        {
            get { return Texture.Width; }
        }
        public int Height
        {
            get { return Texture.Height; }
        }

        // Rektangel som används för kollision detection: från övre kanten X,Y till andra sidan Width, height
        public Rectangle BoundingBox => new Rectangle((int) Location.X, (int)Location.Y, Width, Height);

        public Vector2 Velocity { get; protected set; }
        public Vector2 Location;
        public Rectangle gameBoundaries;

        public Sprite(Texture2D texture, Vector2 Location, Rectangle gameBoundaries)
        {
            this.Texture = texture;
            this.Location = Location;
            Velocity = Vector2.Zero;
            this.gameBoundaries = gameBoundaries;
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            // Uppdaterar sin position genom att plusa på med accelerationen
            Location += Velocity;

            CheckBounds();
        }

        protected abstract void CheckBounds();

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Location, Color.White);
            spriteBatch.End();
        }

    }
}