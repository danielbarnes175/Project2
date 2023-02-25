using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{ // BRAEDON TODO
    public class Wizard : BaseCharacter
    {
        public Wizard(Vector2 position, Vector2 dimensions) : base("Assets/Game/wizard", position, dimensions)
        {
            health = 100;
        }
    }
}
