using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.Engine.Input;
using Project2.src.Engine.Scene.Scenes;
using System;
using System.Collections.Generic;

namespace Project2.src.Engine
{
    class GlobalParameters
    {
        public static int screenHeight, screenWidth;

        public static ContentManager GlobalContent;
        public static SpriteBatch GlobalSpriteBatch;
        public static GraphicsDevice GlobalGraphics;
        public static MouseController GlobalMouse;
        public static KeyboardController GlobalKeyboard;

        public static GameManager Game;
        public static Random random;

        public static Dictionary<string, BaseScene> Scenes;
        public static BaseScene CurrentScene;

        public static SpriteFont font;
        public static SpriteFont smallFont;
    }
}
