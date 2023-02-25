using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Simulation.Character
{
    public class BaseCharacter : BaseTexture
    {
        public Vector2 speed;
        public int health;

        public BaseCharacter(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions) 
        {
            speed = new Vector2(0, 0);
        }

        public override void Update()
        {
            // TODO: Implement real physics w/ acceleration
            position = new Vector2(position.X + speed.X, position.Y + speed.Y);
        }
    }
}
