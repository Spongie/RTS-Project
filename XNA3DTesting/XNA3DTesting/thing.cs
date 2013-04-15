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
    class thing
    {
        Model model;
        Vector3 position;
        Vector3 scale;
        Vector3 rotation;
        KeyboardState keystate;

        public thing(Model mod, Vector3 pos)
        {
            model = mod;
            position = pos;
            scale = new Vector3(1, 1, 1);
            rotation = new Vector3(0, 0, 0);
        }

        public void Update()
        {
            keystate = Keyboard.GetState();

            if (keystate.IsKeyDown(Keys.Left))
                position.X--;
            if (keystate.IsKeyDown(Keys.Right))
                position.X++;
            if (keystate.IsKeyDown(Keys.Down))
                position.Z++;
            if (keystate.IsKeyDown(Keys.Up))
                position.Z--;
            if (keystate.IsKeyDown(Keys.Space))
                rotation.Y+= 0.1f;
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            int i = 0;
            foreach (ModelMesh mesh in model.Meshes)
            {
                i++;
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = view;
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position);
                    effect.Projection = projection;
                    effect.EnableDefaultLighting();
                }
                if(i%2 == 0)
                    mesh.Draw();
            }
        }
    }
}
