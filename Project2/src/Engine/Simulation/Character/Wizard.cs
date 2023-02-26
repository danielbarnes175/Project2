using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // The constructor for our object. Whenever we want one of these, we can call code such as follows:
        // Wizard myWizard = new Wizard(...);
        // We can pass in the specific initial values that the object holds. For this one, we decide that there's a position and dimensions.
        // base(...) is calling the constructor for the parent class, where we set the given parameters.
        public Wizard(Vector2 position, Vector2 dimensions) : base("Assets/Game/wizard", position, dimensions)
        {
            health = 100;

            // Any variables listed above our constructor are called "instance variables" because they are specific to this instance of our object.
            // For example, We can have many different Wizard in the world, and they all might hold different values for position within the world.
            // So we create a separate instance of the Wizard class.
            currentMana = 0;
            maxMana = 100;
        }

        /**
         * Wizard are a slower class, opting to use more spells for their movement.
         */
        public override void Update()
        {
            // Regen the currentMana on every game update, but make sure that we're making sure it doesn't go above our max mana.
            currentMana += 1;
            if (currentMana > maxMana)
            {
                currentMana = maxMana;
            }

            /* TODO:  Update the speed of this object based on input. See src/Engine/Simulation/Character/Warrior.cs as an example.
             * 
             * BONUS: Wizards have the ability to "blink" or teleport a short distance. Unfortunately, this uses their mana. Implement the ability to blink when pressing "SHIFT"
             * Hint:  You will have to make multiple checks. Is the shift key pressed? Does the player have sufficient mana? If so, we can update the position directly here, but
             *        make sure that we subtract the mana we've used!
             */

            // Call the Update function of the parent class, BaseCharacter.
            base.Update();
        }
    }
}
