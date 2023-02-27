﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine.Helpers;
using Project2.src.Engine.Simulation;
using Project2.src.Engine.Simulation.Character;
using Project2.src.UI;
using System.Collections.Generic;

namespace Project2.src.Engine.Scene.Scenes
{
    public class LobbyScene : BaseScene
    {
        private List<BaseTexture> _textures;

        public LobbyScene()
        {
            _textures = new List<BaseTexture>();
        }

        public override void LoadContent()
        {
            GameSettings.player = new Warrior(new Vector2(80, 100), new Vector2(80, 100));

            Texture2D startGameButtonTexture = DrawingService.CreateTexture(GlobalParameters.GlobalGraphics, 200, 50, pixel => Color.Brown, Shapes.RECTANGLE);
            Button startGameButton = new Button(startGameButtonTexture, new Vector2((GlobalParameters.screenWidth / 2) - 100, (float)(GlobalParameters.screenHeight * .8)), new Vector2(200, 50), () =>
            {
                GlobalParameters.CurrentScene = GlobalParameters.Scenes["Game Scene"];
            }, "START GAME");

            Button warriorButton = new Button("Assets/Game/warrior", new Vector2((float)(GlobalParameters.screenWidth * 0.2) - 150, (GlobalParameters.screenHeight / 2) - 400), new Vector2(300, 600), () =>
            {
                GameSettings.player = new Warrior(new Vector2(80, 100), new Vector2(80, 100));
            });

            Button rogueButton = new Button("Assets/Game/rogue", new Vector2((float)(GlobalParameters.screenWidth * 0.5) - 150, (GlobalParameters.screenHeight / 2) - 400), new Vector2(300, 600), () =>
            {
                GameSettings.player = new Rogue(new Vector2(80, 100), new Vector2(80, 100));
            });

            Button wizardButton = new Button("Assets/Game/wizard", new Vector2((float)(GlobalParameters.screenWidth * 0.8) - 150, (GlobalParameters.screenHeight / 2) - 400), new Vector2(300, 600), () =>
            {
                GameSettings.player = new Wizard(new Vector2(80, 100), new Vector2(80, 100));
            });

            _textures.Add(startGameButton);
            _textures.Add(warriorButton);
            _textures.Add(rogueButton);
            _textures.Add(wizardButton);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (BaseTexture texture in _textures)
            {
                texture.Update();
            }

            base.Update(gameTime);
        }

        public override void Draw(Vector2 offset)
        {
            foreach (BaseTexture texture in _textures)
            {
                texture.Draw(offset);
            }

            base.Draw(offset);
        }
    }
}
