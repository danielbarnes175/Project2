using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.src.engine.controllers
{
    class MouseController
    {
        public bool dragging, rightDrag;

        public Vector2 newMousePos, oldMousePos, firstMousePos;

        public MouseState newMouse, oldMouse, firstMouse;

        public MouseController()
        {
            dragging = false;

            newMouse = Mouse.GetState();
            oldMouse = newMouse;
            firstMouse = newMouse;

            newMousePos = new Vector2(newMouse.X, newMouse.Y);
            oldMousePos = new Vector2(newMouse.X, newMouse.Y);
            firstMousePos = new Vector2(newMouse.X, newMouse.Y);

            //screenLoc = new Vector2((int)(systemCursorPos.X/GlobalParameters.screenWidth), (int)(systemCursorPos.Y/GlobalParameters.screenHeight));

        }

        public void Update()
        {
            oldMouse = newMouse;
            newMouse = Mouse.GetState();

            oldMousePos = newMousePos;
            newMousePos = new Vector2(newMouse.X, newMouse.Y);
        }

        public bool LeftClick()
        {
            return (newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released);
        }

        public bool LeftClickHold()
        {
            return (newMouse.LeftButton == ButtonState.Pressed);
        }

        public bool RightClick()
        {
            return (newMouse.RightButton == ButtonState.Pressed && oldMouse.RightButton == ButtonState.Released);
        }

        public bool RightClickHold()
        {
            return (newMouse.RightButton == ButtonState.Pressed);
        }
    }
}
