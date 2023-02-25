using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{ // MICHAEL TODO
    public class Rogue : BaseCharacter
    {
        public Rogue(Vector2 position, Vector2 dimensions) : base("Assets/Game/rogue", position, dimensions)
        {
            health = 100;
        }
    }
}
