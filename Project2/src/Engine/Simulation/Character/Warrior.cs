using Microsoft.Xna.Framework;
using Project1.src.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{
    public class Warrior : BaseCharacter
    {
        public Warrior(Vector2 position, Vector2 dimensions) : base("Assets/Game/warrior", position, dimensions)
        {
            health = 150;
        }

        public override void Update()
        {
            // Decrease speed over time --> Friction
            speed.X = speed.X > 0 ? speed.X - 1 : speed.X;
            speed.X = speed.X < 0 ? speed.X + 1 : speed.X;
            speed.Y = speed.Y > 0 ? speed.Y - 1 : speed.Y;
            speed.Y = speed.Y < 0 ? speed.Y + 1 : speed.Y;

            // Handle Player Input
            if (GlobalParameters.GlobalKeyboard.GetPress("W"))
            {
                speed.Y -= 2;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("S"))
            {
                speed.Y += 2;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("A"))
            {
                speed.X -= 2;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("D"))
            {
                speed.X += 2;
            }

            // Cap Player Speed
            if (speed.X > 15) speed.X = 15;
            if (speed.X < -15) speed.X = -15;
            if (speed.Y > 15) speed.Y = 15;
            if (speed.Y < -15) speed.Y = -15;

            base.Update();
        }
    }
}
