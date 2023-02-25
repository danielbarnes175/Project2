using Microsoft.Xna.Framework;
using Project1.src.engine;
using Project1.src.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.Engine.Scene.Scenes
{
    public class GameScene : BaseScene
    {
            private List<BasicTexture> _textures;

            public GameScene()
            {
                _textures = new List<BasicTexture>();
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
            }

            public override void Draw(Vector2 offset)
            {
                GlobalParameters.Game.Draw(offset);
                foreach (BasicTexture texture in _textures)
                {
                    texture.Draw(offset);
                }

                string desc = "Game Scene";

                GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, desc, new Vector2(5, 5), Color.Black);
                base.Draw(offset);
            }
        }
    }
