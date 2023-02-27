using Microsoft.Xna.Framework;
using Project2.src.Engine;
using Project2.src.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.src.Engine.Helpers
{
    public class CollisionService
    {
        /**
         * Helper method to determine if two textures collide. Returns true if they collide, otherwise false.
         */
        public static bool CheckTexturesCollision(BaseTexture texture1, BaseTexture texture2)
        {
            Rectangle rect1 = new Rectangle((int)texture1.position.X, (int)texture1.position.Y, (int)texture1.dimensions.X, (int)texture1.dimensions.Y);
            Rectangle rect2 = new Rectangle((int)texture2.position.X, (int)texture2.position.Y, (int)texture2.dimensions.X, (int)texture2.dimensions.Y);

            if (rect1.Intersects(rect2))
            {
                Rectangle intersection = Rectangle.Intersect(rect1, rect2);

                for (int x = intersection.X; x < intersection.X + intersection.Width; x++)
                {
                    for (int y = intersection.Y; y < intersection.Y + intersection.Height; y++)
                    {
                        int pixel1 = texture1.colorData[x - (int)texture1.position.X, y - (int)texture1.position.Y].A;
                        int pixel2 = texture2.colorData[x - (int)texture2.position.X, y - (int)texture2.position.Y].A;

                        if (pixel1 != 0 && pixel2 != 0) return true;
                    }
                }
            }
            return false;
        }

        public static bool CheckRectangleCollision(Rectangle rect1, Rectangle rect2)
        {
            return (!rect1.Intersects(rect2));
        }

        /**
         * Helper function to check if a mouse if hovering over a given texture. Returns true if they collide, otherwise false.
         */
        public static bool CheckMouseCollision(BaseTexture texture1)
        {
            Rectangle rect1 = new Rectangle((int)texture1.position.X, (int)texture1.position.Y, (int)texture1.dimensions.X, (int)texture1.dimensions.Y);
            Rectangle mouseRect = new Rectangle((int)GlobalParameters.GlobalMouse.newMousePos.X, (int)GlobalParameters.GlobalMouse.newMousePos.Y, 1, 1);

            if (rect1.Intersects(mouseRect))
            {
                Rectangle intersection = Rectangle.Intersect(rect1, mouseRect);
                for (int x = intersection.X; x < intersection.X + intersection.Width; x++)
                {
                    for (int y = intersection.Y; y < intersection.Y + intersection.Height; y++)
                    {
                        int pixel1 = texture1.colorData[x - (int)texture1.position.X, y - (int)texture1.position.Y].A;

                        if (pixel1 != 0) return true;
                    }
                }
            }
            return false;
        }
    }
}
