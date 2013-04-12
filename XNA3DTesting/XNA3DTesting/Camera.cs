using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XNA3DTesting
{
    class Camera
    {
        public Vector3 position;
        public Vector3 lookAt;
        public Vector3 up;
        KeyboardState keyState;

        public Camera(Vector3 pos, Vector3 look)
        {
            position = pos;
            lookAt = look;
            up = Vector3.Up;
        }

        public void UpdateCamera()
        {
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.A))
            {
                position.X--;
                lookAt.X--;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                position.X++;
                lookAt.X++;
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                position.Z--;
                lookAt.Z--;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                position.Z++;
                lookAt.Z++;
            }
            if (keyState.IsKeyDown(Keys.Q))
            {
                position.Y--;
                lookAt.Y--;
            }
            if (keyState.IsKeyDown(Keys.E))
            {
                position.Y++;
                lookAt.Y++;
            }
            if (keyState.IsKeyDown(Keys.D1))
            {
                lookAt.X -= 5;
                lookAt.Z -= 5;
            }
            if (keyState.IsKeyDown(Keys.D2))
            {
                lookAt.Z += 5;
                lookAt.X += 5;
            }

        }
    }
}
