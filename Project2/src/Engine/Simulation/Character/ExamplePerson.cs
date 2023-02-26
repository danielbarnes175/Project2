using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{
    // Define our class ExamplePerson
    public class ExamplePerson
    {
        // Define our parameters/instance variables, i.e. what our class HAS
        private int age;
        private string name;

        // Our constructor
        public ExamplePerson(int age, string name) 
        {
            // Instance variables must be initialized in the constructor
            this.age = age;
            this.name = name;
        }

        // Our methods, i.e. a set of functions denoting what our class CAN DO
        public void celebrateBirthday()
        {
            age += 1; // age = age + 1;
        }

        public int getAge() { return age; }
        public string getName() { return name; }
    }
}
