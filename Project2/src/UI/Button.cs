using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.UI
{
    public class Button : UIElement
    {
        Action onClick;

        public Button(string path, Vector2 position, Vector2 dimensions, Action onClick, string text = null) : base(path, position, dimensions, text)
        {
            this.onClick = onClick;
        }


        public Button(Texture2D texture, Vector2 position, Vector2 dimensions, Action onClick, string text = null) : base(texture, position, dimensions, text)
        {
            this.onClick = onClick;
        }

        public override void Update()
        {
            if (CollisionService.CheckMouseCollision(this))
            {
                isBeingMousedOver = true;

                if (GlobalParameters.GlobalMouse.LeftClick())
                {
                    onClick.Invoke();
                }
            }
            else
            {
                isBeingMousedOver = false;
            }
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }

        public override void Draw(Vector2 offset, Vector2 origin)
        {
            base.Draw(offset, origin);
        }
    }
}
