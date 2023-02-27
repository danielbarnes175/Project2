using Microsoft.Xna.Framework;
using Project2.src.UI;

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
        int acceleration;
        int baseSpeed;

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
        }

        /**
         * Wizard are a slower class, opting to use more spells for their movement.
         */
        public override void Update()
        {
            // Regen the currentMana on every game update, but make sure that we're making sure it doesn't go above our max mana.
            // Daniel's Code :^)
            speed.X = speed.X > 0 ? speed.X - 1 : speed.X;
            speed.X = speed.X < 0 ? speed.X + 1 : speed.X;
            speed.Y = speed.Y > 0 ? speed.Y - 1 : speed.Y;
            speed.Y = speed.Y < 0 ? speed.Y + 1 : speed.Y;

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
            if (speed.X > 15) speed.X = 15;
            if (speed.X < -15) speed.X = -15;
            if (speed.Y > 15) speed.Y = 15;
            if (speed.Y < -15) speed.Y = -15;

            /* TODO:  Update the speed of this object based on input. See src/Engine/Simulation/Character/Warrior.cs as an example.
             * 
             ////* BONUS: Wizards have the ability to "blink" or teleport a short distance. Unfortunately, this uses their mana. Implement the ability to blink when pressing "SHIFT"
             * Hint:  You will have to make multiple checks. Is the shift key pressed? Does the player have sufficient mana? If so, we can update the position directly here, but
             *        make sure that we subtract the mana we've used!
             */

            // Call the Update function of the parent class, BaseCharacter.
            base.Update();
        }
    }
}
