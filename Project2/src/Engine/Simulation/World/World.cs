using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project2.src.Engine;
using Project2.src.UI;
using Project2.src.Engine.Simulation.Character;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using Project2.src.Engine.Helpers;

namespace Project2.src.Engine.Simulation.World
{
    public class World
    {
        public readonly int WORLD_HEIGHT;
        public readonly int WORLD_WIDTH;

        public readonly int TILE_HEIGHT;
        public readonly int TILE_WIDTH;

        public Vector2 spawnLocation;

        private TerrainType[,] map;
        private List<BaseTexture> textures;

        private bool drawTexturesEnabled;

        public World(int width, int height)
        {
            WORLD_HEIGHT = height;
            WORLD_WIDTH = width;

            TILE_HEIGHT = 32;
            TILE_WIDTH = 32;

            spawnLocation = Vector2.Zero;

            textures = new List<BaseTexture>();
            drawTexturesEnabled = false;
            map = new TerrainType[WORLD_WIDTH, WORLD_HEIGHT];
            GenerateWorld();
        }

        public void Update()
        {
            // Toggle if drawing textures
            if (GlobalParameters.GlobalKeyboard.GetPressSingle("T"))
            {
                drawTexturesEnabled = !drawTexturesEnabled;
            }

            if (drawTexturesEnabled)
            {
                foreach (BaseTexture texture in textures)
                {
                    texture.Update();
                }
            }

            if (GlobalParameters.GlobalKeyboard.GetPressSingle("R"))
            {
                GenerateWorld();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    if (map[i, j] == TerrainType.NONE || map[i, j] == TerrainType.STONE || map[i, j] == TerrainType.WALL) continue;

                    Vector2 position = new Vector2(i * TILE_WIDTH, j * TILE_HEIGHT);
                    GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.smallFont, map[i, j].ToString(), position, Color.Black, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.9f);
                }
            }

            if (drawTexturesEnabled)
            {
                foreach (BaseTexture texture in textures)
                {
                    texture.Draw(Vector2.Zero);
                }
            }
            
        }

        private void GenerateWorld()
        {
            textures = new List<BaseTexture>();

            // Initialize the map with walls
            for (int x = 0; x < WORLD_WIDTH; x++)
            {
                for (int y = 0; y < WORLD_HEIGHT; y++)
                {
                    map[x, y] = TerrainType.WALL;
                }
            }

            // Randomly generate the initial map
            for (int x = 1; x < WORLD_WIDTH - 1; x++)
            {
                for (int y = 1; y < WORLD_HEIGHT - 1; y++)
                {
                    if (new Random().Next(0, 100) < 50)
                    {
                        map[x, y] = TerrainType.DIRT;
                    }
                }
            }

            // Apply cellular automaton rules to smooth out the map
            for (int i = 0; i < 3; i++)
            {
                TerrainType[,] newMap = new TerrainType[WORLD_WIDTH, WORLD_HEIGHT];

                for (int x = 1; x < WORLD_WIDTH - 1; x++)
                {
                    for (int y = 1; y < WORLD_HEIGHT - 1; y++)
                    {
                        int wallCount = GetSurroundingWallCount(map, x, y);

                        if (map[x, y] == TerrainType.WALL && wallCount < 4)
                        {
                            newMap[x, y] = TerrainType.DIRT;
                        }
                        else if (map[x, y] == TerrainType.DIRT && wallCount >= 5)
                        {
                            // Check if this tile is part of a connected region
                            bool isConnected = IsTileConnected(map, x, y);

                            if (isConnected)
                            {
                                newMap[x, y] = TerrainType.WALL;
                            }
                            else
                            {
                                newMap[x, y] = TerrainType.DIRT;
                            }
                        }
                        else
                        {
                            newMap[x, y] = map[x, y];
                        }
                    }
                }

                map = newMap;


                Texture2D dirtTexture = DrawingService.CreateTexture(GlobalParameters.GlobalGraphics, TILE_WIDTH, TILE_HEIGHT, pixel => Color.SandyBrown, Shapes.RECTANGLE);
                Texture2D stoneTexture = DrawingService.CreateTexture(GlobalParameters.GlobalGraphics, TILE_WIDTH, TILE_HEIGHT, pixel => Color.DarkSlateGray, Shapes.RECTANGLE);

                // Initialize the map with walls
                for (int x = 0; x < WORLD_WIDTH; x++)
                {
                    for (int y = 0; y < WORLD_HEIGHT; y++)
                    {
                        Texture2D texture = null;
                        switch(map[x,y])
                        {
                            case TerrainType.DIRT:
                                texture = dirtTexture;
                                break;
                            case TerrainType.WALL:
                            case TerrainType.STONE:
                                texture = stoneTexture;
                                break;
                            default:
                                break; // TODO add missing texture?
                        }

                        if (texture != null)
                        {
                            textures.Add(new BaseTexture(texture, getScreenPositionFromMapPosition(x, y), new Vector2(TILE_WIDTH, TILE_HEIGHT)));
                        }
                    }
                }
            }

            // Randomly select valid spots for the SPAWN and END locations
            bool spawnLocationValid = false;
            bool endLocationValid = false;

            while (!spawnLocationValid)
            {
                int spawnX = new Random().Next(1, WORLD_WIDTH - 1);
                int spawnY = new Random().Next(1, WORLD_HEIGHT - 1);

                if (map[spawnX, spawnY] == TerrainType.DIRT)
                {
                    map[spawnX, spawnY] = TerrainType.SPAWN_LOCATION;
                    spawnLocation = new Vector2(spawnX, spawnY);
                    spawnLocationValid = true;
                }
            }

            while (!endLocationValid)
            {
                int endX = new Random().Next(1, WORLD_WIDTH - 1);
                int endY = new Random().Next(1, WORLD_HEIGHT - 1);

                if (map[endX, endY] == TerrainType.DIRT)
                {
                    map[endX, endY] = TerrainType.END_LOCATION;
                    endLocationValid = true;
                }
            }
        }

        // Get mapping of map x, y, to Monogame Screen X, Y
        public Vector2 getScreenPositionFromMapPosition(float x, float y)
        {
            return new Vector2(x * TILE_WIDTH, y * TILE_HEIGHT);
        }

        public Vector2 getMapPositionFromScreenPosition(float x, float y)
        {
            return new Vector2(x / TILE_WIDTH, y / TILE_HEIGHT);
        }

        public bool isPositionTraversable(float x, float y)
        {
            bool isTraversable = false;
            if (x < 0 || y < 0 || x >= WORLD_WIDTH || y >= WORLD_HEIGHT) return false;
            TerrainType terrain = map[(int)x, (int)y];

            switch (terrain)
            {
                case TerrainType.DIRT:
                    isTraversable = true;
                    break;
                default:
                    isTraversable = false;
                    break;
            }

            return isTraversable;
        }

        public BaseTexture getTextureFromMapPosition(float x, float y)
        {
            foreach (BaseTexture texture in textures)
            {
                Vector2 screenPosition = getScreenPositionFromMapPosition(x, y);

                if (screenPosition.X >= texture.position.X && x <= texture.position.X + texture.texture.Width &&
                    screenPosition.Y >= texture.position.Y && y <= texture.position.Y + texture.texture.Height)
                {
                    // Return the texture if it overlaps with the given coordinates
                    return texture;
                }
            }

            return null;
        }

        // Get number of walls surrounding a given tile
        private int GetSurroundingWallCount(TerrainType[,] map, int x, int y)
        {
            int wallCount = 0;

            for (int neighborX = x - 1; neighborX <= x + 1; neighborX++)
            {
                for (int neighborY = y - 1; neighborY <= y + 1; neighborY++)
                {
                    // Skip the current tile
                    if (neighborX == x && neighborY == y)
                    {
                        continue;
                    }

                    // Check if the neighbor is out of bounds
                    if (neighborX < 0 || neighborX >= WORLD_WIDTH || neighborY < 0 || neighborY >= WORLD_HEIGHT)
                    {
                        wallCount++;
                    }
                    else if (map[neighborX, neighborY] == TerrainType.WALL)
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        // Check if a tile is connected to any other dirt tiles
        private bool IsTileConnected(TerrainType[,] map, int x, int y)
        {
            bool[,] visited = new bool[WORLD_WIDTH, WORLD_HEIGHT];
            bool connected = false;

            Queue<Vector2> queue = new Queue<Vector2>();
            queue.Enqueue(new Vector2(x, y));

            while (queue.Count > 0)
            {
                Vector2 current = queue.Dequeue();

                if (!visited[(int)current.X, (int)current.Y] && map[(int)current.X, (int)current.Y] == TerrainType.DIRT)
                {
                    visited[(int)current.X, (int)current.Y] = true;

                    if (current.X == 0 || current.X == WORLD_WIDTH - 1 || current.Y == 0 || current.Y == WORLD_HEIGHT - 1)
                    {
                        connected = true;
                        break;
                    }

                    queue.Enqueue(new Vector2(current.X + 1, current.Y));
                    queue.Enqueue(new Vector2(current.X - 1, current.Y));
                    queue.Enqueue(new Vector2(current.X, current.Y + 1));
                    queue.Enqueue(new Vector2(current.X, current.Y - 1));
                }
            }

            return connected;
        }
    }
}
