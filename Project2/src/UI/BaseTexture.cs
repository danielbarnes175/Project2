using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.src.UI
{
    public class BaseTexture
    {
        public float rotation;
        public Vector2 position, dimensions;
        public Texture2D texture;

        public Color[] data;
        public Color[,] colorData;

        public BaseTexture(string path, Vector2 position, Vector2 dimensions)
        {
            this.position = position;
            this.dimensions = dimensions;

            texture = GlobalParameters.GlobalContent.Load<Texture2D>(path);

            data = new Color[this.texture.Width * this.texture.Height];
            this.texture.GetData<Color>(data);
            colorData = new Color[this.texture.Width, this.texture.Height];

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    colorData[x, y] = data[x + y * texture.Width];
                }
            }
        }

        public BaseTexture(Texture2D texture, Vector2 position, Vector2 dimensions)
        {
            this.position = position;
            this.dimensions = dimensions;

            this.texture = texture;

            data = new Color[this.texture.Width * this.texture.Height];
            this.texture.GetData<Color>(data);
            colorData = new Color[this.texture.Width, this.texture.Height];

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    colorData[x, y] = data[x + y * texture.Width];
                }
            }
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if (texture != null)
            {
                GlobalParameters.GlobalSpriteBatch.Draw(texture,
                    new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X,
                        (int)dimensions.Y), null, Color.White, rotation,
                    new Vector2(texture.Bounds.Width / 2, texture.Bounds.Height / 2), new SpriteEffects(), 0.5f);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin)
        {
            GlobalParameters.GlobalSpriteBatch.Draw(texture,
                new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X,
                    (int)dimensions.Y), null, Color.White, rotation, new Vector2(origin.X, origin.Y),
                new SpriteEffects(), 0.1f);
        }
    }
}
