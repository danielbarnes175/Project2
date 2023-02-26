using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Project2.src.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.src.Engine.Simulation.World
{
    public class Camera
    {
        public float Zoom { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Bounds { get; protected set; }
        public Rectangle VisibleArea { get; protected set; }
        public Matrix Transform { get; protected set; }

        private float currentMouseWheelValue, previousMouseWheelValue, zoom, previousZoom;

        public Camera(Viewport viewport)
        {
            Bounds = viewport.Bounds;
            Zoom = 1f;
            Position = new Vector2(GlobalParameters.screenWidth / 2, GlobalParameters.screenHeight / 2);

            UpdateMatrix();
        }


        private void UpdateVisibleArea()
        {
            var inverseViewMatrix = Matrix.Invert(Transform);

            var tl = Vector2.Transform(Vector2.Zero, inverseViewMatrix);
            var tr = Vector2.Transform(new Vector2(Bounds.X, 0), inverseViewMatrix);
            var bl = Vector2.Transform(new Vector2(0, Bounds.Y), inverseViewMatrix);
            var br = Vector2.Transform(new Vector2(Bounds.Width, Bounds.Height), inverseViewMatrix);

            var min = new Vector2(
                MathHelper.Min(tl.X, MathHelper.Min(tr.X, MathHelper.Min(bl.X, br.X))),
                MathHelper.Min(tl.Y, MathHelper.Min(tr.Y, MathHelper.Min(bl.Y, br.Y))));
            var max = new Vector2(
                MathHelper.Max(tl.X, MathHelper.Max(tr.X, MathHelper.Max(bl.X, br.X))),
                MathHelper.Max(tl.Y, MathHelper.Max(tr.Y, MathHelper.Max(bl.Y, br.Y))));
            VisibleArea = new Rectangle((int)min.X, (int)min.Y, (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        private void UpdateMatrix()
        {
            Transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                    Matrix.CreateScale(Zoom) *
                    Matrix.CreateTranslation(new Vector3(Bounds.Width * 0.5f, Bounds.Height * 0.5f, 0));
            UpdateVisibleArea();
        }

        public void MoveCamera(Vector2 movePosition)
        {
            Vector2 newPosition = Position + movePosition;
            Position = newPosition;
        }

        public void AdjustZoom(float zoomAmount)
        {
            Zoom += zoomAmount;
            if (Zoom < .35f)
            {
                Zoom = .35f;
            }
            if (Zoom > 2f)
            {
                Zoom = 2f;
            }
        }

        public void UpdateCamera(Viewport bounds)
        {
            // Track the player
            if (GameSettings.player.isPlayerMoving())
            {
                Position = new Vector2(GameSettings.player.position.X, GameSettings.player.position.Y);
            }

            // Make sure the camera can't be moved off the world
            if (Position.X * 2 - bounds.Width < 0)
                Position = new Vector2(bounds.Width / 2, Position.Y);
            if (Position.Y * 2 - Bounds.Height < 0)
                Position = new Vector2(Position.X, bounds.Height / 2);

            if (Position.X + bounds.Width / 2 > GlobalParameters.Game.world.TILE_WIDTH * GlobalParameters.Game.world.WORLD_WIDTH)
            {
                Position = new Vector2(
                    GlobalParameters.Game.world.TILE_WIDTH * GlobalParameters.Game.world.WORLD_WIDTH - bounds.Width / 2, Position.Y);
            }

            if (Position.Y + bounds.Height / 2 > GlobalParameters.Game.world.TILE_HEIGHT * GlobalParameters.Game.world.WORLD_HEIGHT)
                Position = new Vector2(Position.X, GlobalParameters.Game.world.TILE_HEIGHT * GlobalParameters.Game.world.WORLD_HEIGHT - bounds.Height / 2);

            Bounds = bounds.Bounds;
            UpdateMatrix();

            Vector2 cameraMovement = Vector2.Zero;
            int moveSpeed;

            if (Zoom > .8f)
            {
                moveSpeed = 15;
            }
            else if (Zoom < .8f && Zoom >= .6f)
            {
                moveSpeed = 20;
            }
            else if (Zoom < .6f && Zoom > .35f)
            {
                moveSpeed = 25;
            }
            else if (Zoom <= .35f)
            {
                moveSpeed = 30;
            }
            else
            {
                moveSpeed = 10;
            }

            // Handle manual camera movement
            if (GlobalParameters.GlobalKeyboard.GetPress("ARROW_UP") || getMouseScreenPosition().Y <= 3)
            {
                cameraMovement.Y = -moveSpeed;
            }

            if (GlobalParameters.GlobalKeyboard.GetPress("ARROW_DOWN") || getMouseScreenPosition().Y >= GlobalParameters.screenHeight)
            {
                cameraMovement.Y = moveSpeed;
            }

            if (GlobalParameters.GlobalKeyboard.GetPress("ARROW_LEFT") || getMouseScreenPosition().X <= 0)
            {
                cameraMovement.X = -moveSpeed;
            }

            if (GlobalParameters.GlobalKeyboard.GetPress("ARROW_RIGHT") || getMouseScreenPosition().X >= GlobalParameters.screenWidth)
            {
                cameraMovement.X = moveSpeed;
            }

            // Handle zoom
            previousMouseWheelValue = currentMouseWheelValue;
            currentMouseWheelValue = Mouse.GetState().ScrollWheelValue;

            if (currentMouseWheelValue > previousMouseWheelValue)
            {
                AdjustZoom(.05f);
            }

            if (currentMouseWheelValue < previousMouseWheelValue)
            {
                AdjustZoom(-.05f);
            }

            previousZoom = zoom;
            zoom = Zoom;

            MoveCamera(cameraMovement);
        }

        public Vector2 getMouseScreenPosition()
        {
            Vector2 mouse = GlobalParameters.GlobalMouse.newMousePos;
            return new Vector2(mouse.X, mouse.Y);
        }

        public Vector2 getMouseWorldPosition()
        {
            Vector2 mouse = GlobalParameters.GlobalMouse.newMousePos;

            mouse = Vector2.Transform(mouse, Matrix.Invert(Transform));
            return mouse;
        }
    }
}
