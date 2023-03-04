using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MiNET;
using MonoGame.Framework.Utilities;
using Project1.src.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Project2.src.Engine.Simulation.Character
{
    /**
     * Wizard is a subclass of BaseCharacter, denoted by "Rogue : BaseCharacter"
     * This means that everything the BaseCharacter can do, so can the rogue. However, we want to have it be its own thing and have its own functionality in some cases.
     * 
     * Think of an example of an Animal vs a Chicken. A Chicken is a type of Animal, in Object Oriented Programming, this is the concept of Inheritance.
     * Chicken is a subclass of the parent class, Animal. The subclass "inherits" the properties of the parent class.
     * 
     * So our BaseCharacter has things like speed and health, because all characters will have that. But the Wizard has things that not all characters have,
     * like a mana bar.
     */

    public class Wizard : BaseCharacter
    {
        // int, short for integer, is a type of variable that is a number without a decimal place.
        int currentMana;
        int maxMana;
        // private bool isTeleport;
        int acceleration;
        int baseSpeed;
        public object fireball;
        private object objectToMove;
        private static object transform;
        private Vector2 teleportPosition;

        // The constructor for our object. Whenever we want one of these, we can call code such as follows:
        // Wizard myWizard = new Wizard(...);
        // We can pass in the specific initial values that the object holds. For this one, we decide that there's a position and dimensions.
        // base(...) is calling the constructor for the parent class, where we set the given parameters.
        public Wizard(Vector2 position, Vector2 dimensions) : base("Assets/Game/wizard", position, dimensions)
        {
            health = 100;
            baseSpeed = 1;
            acceleration = 1;
            currentMana = 0;
            maxMana = 100;
            var isTeleport = false;
        }

        public class Teleport
        {
            public Wizard wizard;
            public Vector3 teleportPosition;
            private bool isTeleport;

            private void Update()
            {
                isTeleport = GlobalParameters.GlobalKeyboard.IsKeyHeldDown(Keys.LeftShift) ? true : false;

            }

            private void TeleportPlayer(object transform) => transform.position = teleportPosition;





            /**
             * Wizard are a slower class, opting to use more spells for their movement.
             */
            public override void Update()
        {
            // Vector2 targetPosition = new Vector2(0, 0);
            // isTeleport = GlobalParameters.GlobalKeyboard.IsKeyHeldDown(Keys.LeftShift) ? true : false;
            //  position = teleportPosition;



            speed.X = speed.X > 0 ? speed.X - (int)1.5 : speed.X;
            speed.X = speed.X < 0 ? speed.X + (int)1.5 : speed.X;
            speed.Y = speed.Y > 0 ? speed.Y - (int)1.5 : speed.Y;
            speed.Y = speed.Y < 0 ? speed.Y + (int)1.5 : speed.Y;

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
            // Speed Cap
            if (speed.X > 10) speed.X = 10;
            if (speed.X < -10) speed.X = -10;
            if (speed.Y > 10) speed.Y = 10;
            if (speed.Y < -10) speed.Y = -10;

            base.Update();
        }
    }
}



/* TODO:  Update the speed of this object based on input. See src/Engine/Simulation/Character/Warrior.cs as an example.
* 
  ////* BONUS: Wizards have the ability to "blink" or teleport a short distance. Unfortunately, this uses their mana. Implement the ability to blink when pressing "SHIFT"
  * Hint:  You will have to make multiple checks. Is the shift key pressed? Does the player have sufficient mana? If so, we can update the position directly here, but
  *        make sure that we subtract the mana we've used!
  */
// Call the Update function of the parent class, BaseCharacter.



