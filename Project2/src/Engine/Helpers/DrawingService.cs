using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.UI;
using System;
using System.Linq;

namespace Project2.src.Engine.Helpers
{
    public class DrawingService
    {
        public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint, Shapes shape)
        {
            //initialize a texture
            Texture2D texture = new Texture2D(device, width, height);

            //the array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            switch (shape)
            {
                case Shapes.CIRCLE:
                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            double distance = Math.Sqrt(Math.Pow(i - height / 2, 2) + Math.Pow(j - width / 2, 2));
                            if (distance <= width / 2.0)
                            {
                                data[width * i + j] = paint(width * i + j);
                            }
                        }
                    }
                    break;
                case Shapes.RECTANGLE:
                    for (int pixel = 0; pixel < data.Count(); pixel++)
                    {
                        //the function applies the color according to the specified pixel
                        data[pixel] = paint(pixel);
                    }
                    break;
            }

            //set the color
            texture.SetData(data);

            return texture;
        }
    }
}
