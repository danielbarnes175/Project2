using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.src.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.UI
{
    public class BasicTexture
    {
        public float rotation;
        public Vector2 position, dimensions;
        public Texture2D texture;

        public BasicTexture(string path, Vector2 pos, Vector2 dimensions)
        {
            position = pos;
            this.dimensions = dimensions;

            texture = GlobalParameters.GlobalContent.Load<Texture2D>(path);
        }

        public BasicTexture(Texture2D texture, Vector2 pos, Vector2 dimensions)
        {
            position = pos;
            this.dimensions = dimensions;

            this.texture = texture;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (texture != null)
            {
                GlobalParameters.GlobalSpriteBatch.Draw(texture,
                    new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y), (int)dimensions.X,
                        (int)dimensions.Y), null, Color.White, rotation,
                    new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), new SpriteEffects(), 0.5f);
            }
        }

        public virtual void Draw(Vector2 OFFSET, Vector2 ORIGIN)
        {
            GlobalParameters.GlobalSpriteBatch.Draw(texture,
                new Rectangle((int)(position.X + OFFSET.X), (int)(position.Y + OFFSET.Y), (int)dimensions.X,
                    (int)dimensions.Y), null, Color.White, rotation, new Vector2(ORIGIN.X, ORIGIN.Y),
                new SpriteEffects(), 0.1f);
        }
    }
}
