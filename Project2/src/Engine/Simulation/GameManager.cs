using Project1.src.Engine.Simulation.World;
using Project1.src.Engine;
using Project1.src.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Project1.src.engine
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
        }

        public void Draw(Vector2 OFFSET)
        {
            world.Draw();
        }
    }
}
