﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.src.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.Engine.Simulation.World
{
    public class World
    {
        public readonly int WORLD_HEIGHT;
        public readonly int WORLD_WIDTH;

        public readonly int TILE_HEIGHT;
        public readonly int TILE_WIDTH;
        private TerrainType[,] map;

        public World(int width, int height)
        {
            WORLD_HEIGHT = height;
            WORLD_WIDTH = width;

            TILE_HEIGHT = 30;
            TILE_WIDTH = 30;

            map = new TerrainType[WORLD_WIDTH, WORLD_HEIGHT];
            GenerateWorld();
        }

        public void Update()
        {

        }

        public void Draw()
        {
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    Vector2 position = new Vector2(i * TILE_WIDTH, j * TILE_HEIGHT);
                    GlobalParameters.GlobalSpriteBatch.DrawString(GlobalParameters.smallFont, map[i, j].ToString(), position, Color.Black, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.9f);
                }
            }
        }

        private void GenerateWorld()
        {
            for (int i = 0; i < WORLD_WIDTH; i++)
            {
                for (int j = 0; j < WORLD_HEIGHT; j++)
                {
                    int whichType = GlobalParameters.random.Next(1, 3);
                    switch (whichType)
                    {
                        case 1:
                            map[i, j] = TerrainType.DIRT;
                            break;
                        case 2:
                            map[i, j] = TerrainType.GRASS;
                            break;
                        case 3:
                            map[i, j] = TerrainType.STONE;
                            break;
                        default:
                            map[i, j] = TerrainType.NONE;
                            break;
                    }
                }
            }
        }
    }
}
