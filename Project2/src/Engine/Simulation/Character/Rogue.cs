using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{
    /**
     * Rogue is a subclass of BaseCharacter, denoted by "Rogue : BaseCharacter"
     * This means that everything the BaseCharacter can do, so can the rogue. However, we want to have it be its own thing and have its own functionality in some cases.
     * 
     * Think of an example of an Animal vs a Chicken. A Chicken is a type of Animal, in Object Oriented Programming, this is the concept of Inheritance.
     * Chicken is a subclass of the parent class, Animal. The subclass "inherits" the properties of the parent class.
     * 
     * So our BaseCharacter has things like speed and health, because all characters will have that. But the Rogue has things that not all characters have,
     * like the ability to go invisible.
     */
    public class Rogue : BaseCharacter
    {
        // bool, short for boolean, is a type of variable that can be 2 values, true, or false.
        bool isInvisible;

        // The constructor for our object. Whenever we want one of these, we can call code such as follows:
        // Rogue myRogue = new Rogue(...);
        // We can pass in the specific initial values that the object holds. For this one, we decide that there's a position and dimensions.
        // base(...) is calling the constructor for the parent class, where we set the given parameters.
        public Rogue(Vector2 position, Vector2 dimensions) : base("Assets/Game/rogue", position, dimensions)
        {
            health = 100;
            // Any variables listed above our constructor are called "instance variables" because they are specific to this instance of our object.
            // For example, We can have many different Rogues in the world, and they all might hold different values for position within the world.
            // So we create a separate instance of the Rogue class.
            isInvisible = false;
        }

        public override void Update()
        {
            // Decrease acceleration over time --> Friction
            speed.X = speed.X > 0 ? speed.X - 1 : speed.X;
            speed.X = speed.X < 0 ? speed.X + 1 : speed.X;
            speed.Y = speed.Y > 0 ? speed.Y - 1 : speed.Y;
            speed.Y = speed.Y < 0 ? speed.Y + 1 : speed.Y;


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

            // Cap Speed
            if (speed.X > 10) speed.X = 10;
            if (speed.X < -10) speed.X = -10;
            if (speed.Y > 10) speed.Y = 10;
            if (speed.Y < -10) speed.Y = -10;

            //Invisibility Implementation
            if (GlobalParameters.GlobalKeyboard.GetPress("SHIFT"))
            {
                isInvisible = true;
            }
            else
            {
                isInvisible = false;
            }   
            
            // Call the Update function of the parent class, BaseCharacter.
            base.Update();
        }

        //Draw
        public override void Draw(Vector2 offset)
        {
            if (!isInvisible)
            {
                base.Draw(offset);
            }
        }
    }
}
