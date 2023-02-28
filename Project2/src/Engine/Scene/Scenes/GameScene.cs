﻿using Microsoft.Xna.Framework;
using Project2.src.UI;
using System;
using System.Collections.Generic;
using System.Timers;

namespace Project2.src.Engine.Scene.Scenes
{
    public class GameScene : BaseScene
    {
        private List<BaseTexture> _textures;

        public GameScene()
        {
            _textures = new List<BaseTexture>();
        }

        public override void LoadContent()
        {
            GlobalParameters.Game = new GameManager();
        }

        public override void Update(GameTime gameTime)
        {
            GlobalParameters.Game.Update();
            base.Update(gameTime);

            if (GlobalParameters.GlobalKeyboard.GetPress("BACKSPACE"))
                GlobalParameters.CurrentScene = GlobalParameters.Scenes["Menu Scene"];
            if (GlobalParameters.GlobalKeyboard.GetPress("L"))
                GlobalParameters.CurrentScene = GlobalParameters.Scenes["Lobby Scene"];
        }

        public override void Draw(Vector2 offset)
        {
            GlobalParameters.Game.Draw(offset);
            foreach (BaseTexture texture in _textures)
            {
                texture.Draw(offset);
            }

                string desc = "Game Scene";

            GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, desc, new Vector2(5, 5), Color.White);
            base.Draw(offset);
        }
    }
}
