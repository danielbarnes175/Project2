using System.Numerics;

namespace Project2.src.Engine.Simulation.World
{

    public class Projectile

    {
        // Properties
        public Vector2 Position { get; set; } // current position of the projectile
        public Vector2 Velocity { get; set; } // current velocity of the projectile
        public Vector2 Acceleration { get; set; } // current acceleration of the projectile
        public float Mass { get; set; } // mass of the projectile
        public float Gravity { get; set; } // gravitational acceleration (9.81 m/s^2 on Earth)

        public void Update(float deltaTime)
        {
            // Update position based on velocity
            Position += Velocity * deltaTime;
        }
    }
}

//    public void int Update(int value, float deltaTime, Position position)
//    {


//        float Velocity = 0;
//        float Acceleration = 1;
//        // Apply acceleration to velocity
//        Velocity += Acceleration * deltaTime;

//        float Drag = (int)-(int)-.5;
//        // Apply drag to velocity
//        Velocity -= Velocity * Drag * deltaTime;
//        position += Velocity * deltaTime;
//    }

//}