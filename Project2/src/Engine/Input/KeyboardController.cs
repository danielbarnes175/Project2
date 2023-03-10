using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project2.src.Engine.Input
{
    class KeyboardController
    {
        private KeyboardState _currentKeyboard, _previousKeyboard;

        public KeyboardController()
        {

        }

        public virtual void Update()
        {
            _previousKeyboard = _currentKeyboard;
            _currentKeyboard = Microsoft.Xna.Framework.Input.Keyboard.GetState();
        }

        public void UpdateOld()
        {

        }

        public bool GetPress(string KEY)
        {
            Keys key = GetKeyFromString(KEY);
            return IsKeyHeldDown(key);
        }

        public bool GetPressSingle(string KEY)
        {
            Keys key = GetKeyFromString(KEY);
            return OnKeyPress(key);
        }

        public bool OnKeyPress(Keys key)
        {
            if (_currentKeyboard.IsKeyDown(key) &&
                _previousKeyboard.IsKeyUp(key))
            {
                return true;
            }

            return false;
        }
        public bool IsKeyHeldDown(Keys key)
        {
            return _currentKeyboard.IsKeyDown(key);
        }

        public virtual void GetPressedKeys()
        {

        }

        public virtual Microsoft.Xna.Framework.Input.Keys GetKeyFromString(string KEY)
        {
            switch (KEY)
            {
                case "A":
                    return Keys.A;
                case "B":
                    return Keys.B;
                case "C":
                    return Keys.C;
                case "D": 
                    return Keys.D;
                case "M":
                    return Keys.M;
                case "N":
                    return Keys.N;
                case "O":
                    return Keys.O;
                case "P":
                    return Keys.P;
                case "Q":
                    return Keys.Q;
                case "R":
                    return Keys.R;
                case "S":
                    return Keys.S;
                case "T":
                    return Keys.T;
                case "W":
                    return Keys.W;
                case "BACKSPACE":
                    return Keys.Back;
                case "CTRL":
                    return Keys.LeftControl;
                case "DELETE":
                    return Keys.Delete;
                case "ENTER":
                    return Keys.Enter;
                case "ESC":
                    return Keys.Escape;
                case "SPACEBAR":
                    return Keys.Space;
                case "SHIFT":
                    return Keys.LeftShift;
                case "LEFT_SHIFT":
                    return Keys.LeftShift;
                case "RIGHT_SHIFT":
                    return Keys.RightShift;
                case "ARROW_UP":
                    return Keys.Up;
                case "ARROW_DOWN":
                    return Keys.Down;
                case "ARROW_LEFT":
                    return Keys.Left;
                case "ARROW_RIGHT":
                    return Keys.Right;
            }

            return Keys.Sleep;
        }
    }
}
