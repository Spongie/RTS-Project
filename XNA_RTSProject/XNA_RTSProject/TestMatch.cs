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

namespace XNA_RTSProject
{
    class TestMatch
    {
        private Matrix view;
        private Matrix projection;
        private MovableObject testObject;
        private float aspectRatio;
        Camera camera;

        public TestMatch(Model testModel, float aspRatio)
        {
            aspectRatio = aspRatio;
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), aspectRatio, 1f, 1000f);
            //testObject = new testObject(we need more stuffs
        }

        public void Update(GameTime gameTime)
        {
           // view = Matrix.CreateLookAt( Waiting for Camera to be done
            testObject.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            testObject.Draw(view, projection);
        }
    }
}
