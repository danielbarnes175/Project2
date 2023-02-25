using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project2;
using Project2.src.Engine;
using System.Collections.Generic;
using System;
using Project2.src.UI;
using Project2.src.Engine.Input;
using Project2.src.Engine.Scene.Scenes;

using var game = new Main();
game.Run();

namespace Project2
{
    public class Main : Game
    {
        private GraphicsDeviceManager graphics;
        private BaseTexture cursor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            GlobalParameters.screenWidth = 1600;
            GlobalParameters.screenHeight = 900;

            graphics.PreferredBackBufferWidth = GlobalParameters.screenWidth;
            graphics.PreferredBackBufferHeight = GlobalParameters.screenHeight;

            GlobalParameters.random = new Random((int)DateTime.Now.Ticks);

            GlobalParameters.Scenes = new Dictionary<string, BaseScene>
            {
                { "Menu Scene", new MenuScene() },
                { "Game Scene", new GameScene() },
                { "Lobby Scene", new LobbyScene() }
            };

            GlobalParameters.CurrentScene = GlobalParameters.Scenes["Menu Scene"];
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GlobalParameters.GlobalContent = this.Content;
            GlobalParameters.GlobalSpriteBatch = new SpriteBatch(GraphicsDevice);
            GlobalParameters.GlobalGraphics = graphics.GraphicsDevice;
            GlobalParameters.GlobalKeyboard = new KeyboardController();
            GlobalParameters.GlobalMouse = new MouseController();

            GlobalParameters.Scenes["Game Scene"].LoadContent();

            GlobalParameters.font = Content.Load<SpriteFont>("Assets\\Fonts/Arial");
            GlobalParameters.smallFont = Content.Load<SpriteFont>("Assets\\Fonts/Arial");
            cursor = new BaseTexture("Assets\\cursor", new Vector2(0, 0), new Vector2(28, 28));

            foreach (KeyValuePair<string, BaseScene> scene in GlobalParameters.Scenes)
            {
                scene.Value.LoadContent();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GlobalParameters.GlobalMouse.Update();
            GlobalParameters.GlobalKeyboard.Update();

            GlobalParameters.GlobalKeyboard.UpdateOld();

            GlobalParameters.CurrentScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GlobalParameters.GlobalSpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullCounterClockwise, null, GlobalParameters.Game.GameCamera.Transform);

            GlobalParameters.CurrentScene.Draw(Vector2.Zero);
            cursor.Draw(GlobalParameters.Game.GameCamera.getMouseWorldPosition(), new Vector2(0, 0));

            GlobalParameters.GlobalSpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}