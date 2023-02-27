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
                if (canTextureMoveHorizontally(speed))
                {
                    position.X += speed.X;
                }
                if (canTextureMoveVertically(speed))
                {
                    position.Y += speed.Y;
                }
            }
        }

        public bool canTextureMoveHorizontally(Vector2 speed)
        {
            World.World currentWorld = GlobalParameters.Game.world;
            Vector2 newPositionX = new Vector2(position.X + speed.X, position.Y);
            Vector2 newPositionOnMapX = currentWorld.getMapPositionFromScreenPosition(newPositionX.X, newPositionX.Y);

            for (int y = (int)newPositionOnMapX.Y - 1; y <= newPositionOnMapX.Y + 1; y++)
            {
                for (int x = (int)newPositionOnMapX.X - 1; x <= newPositionOnMapX.X + 1; x++)
                {
                    Rectangle tile = new Rectangle(x, y, currentWorld.TILE_WIDTH, currentWorld.TILE_HEIGHT);
                    BaseTexture tileTexture = currentWorld.getTextureFromMapPosition(x, y);
                    if (!currentWorld.isPositionTraversable(x, y) ||
                        (tileTexture != null &&
                        CollisionService.CheckTexturesCollision(this, tileTexture)))
                    {
                        // A wall was found, so the player cannot move to the new position
                        return false;
                    }
                }
            }

            return true;
        }

        public bool canTextureMoveVertically(Vector2 speed)
        {
            World.World currentWorld = GlobalParameters.Game.world;
            Vector2 newPositionY = new Vector2(position.X, position.Y + speed.Y);
            Vector2 newPositionOnMapY = currentWorld.getMapPositionFromScreenPosition(newPositionY.X, newPositionY.Y);

            for (int y = (int)newPositionOnMapY.Y - 1; y <= newPositionOnMapY.Y + 1; y++)
            {
                for (int x = (int)newPositionOnMapY.X - 1; x <= newPositionOnMapY.X + 1; x++)
                {
                    Rectangle tile = new Rectangle(x, y, currentWorld.TILE_WIDTH, currentWorld.TILE_HEIGHT);
                    BaseTexture tileTexture = currentWorld.getTextureFromMapPosition(x, y);
                    if (!currentWorld.isPositionTraversable(x, y) ||
                        (tileTexture != null &&
                        CollisionService.CheckTexturesCollision(this, tileTexture)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool isPlayerMoving()
        {
            return (speed.X != 0 || speed.Y != 0);
        }
    }
}
