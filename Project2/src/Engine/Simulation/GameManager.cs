using Project2.src.Engine.Simulation.World;
using Project2.src.Engine;
using Project2.src.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Project2.src.Engine.Simulation;

namespace Project2.src.Engine
{
    class GameManager
    {
        public World world;
        public Camera GameCamera;

        public GameManager()
        {
            world = new World(100, 100);
            GameCamera = new Camera(GlobalParameters.GlobalGraphics.Viewport);
        }

        public void Update()
        {
            GameCamera.UpdateCamera(GlobalParameters.GlobalGraphics.Viewport);
            world.Update();
            GameSettings.player.Update();
        }

        public void Draw(Vector2 offset)
        {
            world.Draw();
            GameSettings.player.Draw(offset);
        }
    }
}
