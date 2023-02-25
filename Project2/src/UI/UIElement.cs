using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.UI
{
    public class UIElement : BaseTexture
    {
        public bool isBeingMousedOver;
        public string text;
        public Color? textColor;

        public UIElement(string path, Vector2 position, Vector2 dimensions, String text = null) : base(path, position, dimensions)
        {
            isBeingMousedOver = false;
            textColor = new Color(255, 255, 255);
            this.text = text;
        }

        public UIElement(Texture2D texture, Vector2 position, Vector2 dimensions, String text = null) : base(texture, position, dimensions)
        {
            isBeingMousedOver = false;
            textColor = new Color(255, 255, 255);
            this.text = text;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            Color color = isBeingMousedOver ? new Color(255, 255, 255, 0.8f) : Color.White;
            Color textColorAdjusted = (Color)(isBeingMousedOver ? (textColor * 0.5f) : textColor);

            if (texture != null)
            {
                GlobalParameters.GlobalSpriteBatch.Draw(texture,
                    new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X,
                        (int)dimensions.Y), null, color, rotation,
                    new Vector2(0, 0), new SpriteEffects(), 0.2f);
            }

            if (!string.IsNullOrEmpty(text))
            {
                Vector2 stringSize = GlobalParameters.font.MeasureString(text);
                GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, text, new Vector2(position.X + ((dimensions.X - stringSize.X) / 2), position.Y + ((dimensions.Y - stringSize.Y) / 2)), textColorAdjusted);
            }
        }

        public override void Draw(Vector2 offset, Vector2 origin)
        {
            Color color = isBeingMousedOver ? new Color(255, 255, 255, 0.8f) : Color.White;
            Color textColorAdjusted = (Color)(isBeingMousedOver ? (textColor * 0.5f) : textColor);

            if (texture != null)
            {
                GlobalParameters.GlobalSpriteBatch.Draw(texture,
                new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), (int)dimensions.X,
                    (int)dimensions.Y), null, color, rotation, new Vector2(origin.X, origin.Y),
                new SpriteEffects(), 0.2f);
            }

            if (!string.IsNullOrEmpty(text))
            {
                Vector2 stringSize = GlobalParameters.font.MeasureString(text);
                GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, text, new Vector2(position.X + ((dimensions.X - stringSize.X) / 2), position.Y + ((dimensions.Y - stringSize.Y) / 2)), textColorAdjusted);
            }
        }
    }
}
