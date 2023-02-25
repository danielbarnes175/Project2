using Microsoft.Xna.Framework;
using Project1.src.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.Engine.Scene.Scenes
{
    public class MenuScene : BaseScene
    {
        private List<BasicTexture> _textures;

        public MenuScene()
        {
            _textures = new List<BasicTexture>();
        }

        public override void LoadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (GlobalParameters.GlobalKeyboard.GetPress("SPACEBAR"))
            {
                GlobalParameters.CurrentScene = GlobalParameters.Scenes["Game Scene"];
            }

            base.Update(gameTime);
        }

        public override void Draw(Vector2 offset)
        {
            foreach (BasicTexture texture in _textures)
            {
                texture.Draw(offset);
            }

            String title = "Project2 Game v0.0.1";
            String desc = "Press [ Spacebar ] to continue";

            Vector2 descSize = GlobalParameters.font.MeasureString(desc);
            Vector2 titleSize = GlobalParameters.font.MeasureString(title);

            Vector2 titleLoc = new Vector2(GlobalParameters.screenWidth / 2 - descSize.X / 2, GlobalParameters.screenHeight / 2);
            Vector2 descLoc = new Vector2(GlobalParameters.screenWidth / 2 - titleSize.X / 2, GlobalParameters.screenHeight / 4);

            GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, desc, titleLoc, Color.Black);
            GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.font, title, descLoc, Color.Black);
            base.Draw(offset);
        }
    }
}
