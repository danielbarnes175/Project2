using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        int baseSpeed;
        int acceleration;
        bool isEnraged;

        public Warrior(Vector2 position, Vector2 dimensions) : base("Assets/Game/warrior", position, dimensions)
        {
            health = 150;
            baseSpeed = 1;
            acceleration = 0;
            isEnraged = false;
        }

        // The warrior is normally pretty slow, but he can go into an enraged form, boosting his speed.
        public override void Update()
        {
            // Decrease acceleration over time --> Friction
            speed.X = speed.X > 0 ? speed.X - 1 : speed.X;
            speed.X = speed.X < 0 ? speed.X + 1 : speed.X;
            speed.Y = speed.Y > 0 ? speed.Y - 1 : speed.Y;
            speed.Y = speed.Y < 0 ? speed.Y + 1 : speed.Y;

            // This is called a ternary operation. It is a shorter way to do a basic if/else. See the following example.
            isEnraged = GlobalParameters.GlobalKeyboard.IsKeyHeldDown(Keys.LeftShift) ? true : false;

            /*
             * This could be written like:
             *     if (isEnraged) {
             *      currentSpeed = baseSpeed * 3
             *     } else {
             *      currentSpeed = baseSpeed;
             *     }
             */
            acceleration = isEnraged ? baseSpeed * 3 : baseSpeed;

            /* Handle Player Input. We have our keyboard in GlobalParameters.GlobalKeyboard.
             * It contains many useful functions such as
             * GetPress(), IsKeyHeldDown(), OnKeyPress(), GetPressSingle()
             * Look at Engine/Input/KeyboardController to learn more.
             */
            if (GlobalParameters.GlobalKeyboard.GetPress("W"))
            {
                speed.Y -= acceleration;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("S"))
            {
                speed.Y += acceleration;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("A"))
            {
                speed.X -= acceleration;
            }
            if (GlobalParameters.GlobalKeyboard.GetPress("D"))
            {
                speed.X += acceleration;
            }

            // Cap Speed
            if (speed.X > 15) speed.X = 15;
            if (speed.X < -15) speed.X = -15;
            if (speed.Y > 15) speed.Y = 15;
            if (speed.Y < -15) speed.Y = -15;

            base.Update();
        }
    }
}
