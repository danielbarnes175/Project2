using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.Engine.Helpers;
using Project2.src.Engine.Simulation.World;
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
            if (isPlayerMoving())
            {
                // Move to the new position based on speed, unless the new location will be in a wall
                World.World currentWorld = GlobalParameters.Game.world;
                Vector2 newPosition = new Vector2(position.X + speed.X, position.Y + speed.Y);
                Vector2 newPositionOnMap = currentWorld.getMapPositionFromScreenPosition(newPosition.X, newPosition.Y);
                Rectangle characterRectangle = new Rectangle(
                    (int)newPosition.X,
                    (int)newPosition.Y,
                    texture.Width,
                    texture.Height
                    );

                // Check if any of the intersecting tiles are walls
                for (int y = (int)newPositionOnMap.Y - 1; y <= newPositionOnMap.Y + 1; y++)
                {
                    for (int x = (int)newPositionOnMap.X - 1; x <= newPositionOnMap.X + 1; x++)
                    {
                        Rectangle tile = new Rectangle(x, y, currentWorld.TILE_WIDTH, currentWorld.TILE_HEIGHT);
                        BaseTexture tileTexture = currentWorld.getTextureFromMapPosition(x, y);
                        if (!currentWorld.isPositionTraversable(x, y) ||
                            (tileTexture != null &&
                            CollisionService.CheckTexturesCollision(this, tileTexture)))
                        {
                            // A wall was found, so the player cannot move to the new position
                            return;
                        }
                    }
                }

                position = newPosition;
            }
        }

        public bool isPlayerMoving()
        {
            return (speed.X != 0 || speed.Y != 0);
        }
    }
}
