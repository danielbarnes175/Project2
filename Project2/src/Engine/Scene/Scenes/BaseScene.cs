using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.Engine.Scene.Scenes
{
    public class BaseScene
    {
        public BaseScene() { }

        public virtual void LoadContent() { }

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(Vector2 offset) { }
    }
}
