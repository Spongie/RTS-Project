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
    class Ground
    {
        Model model;
        _3dBox box;

        public _3dBox Box
        {
            get { return box; }
            set
            {
                if (value != null)
                    box = value;
            }
        }

        public Ground(Model mod, Vector3 pos)
        {
            model = mod;
            box = new _3dBox(pos, 1, 50, 50);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = view;
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(box.Position);
                    effect.Projection = projection;
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
    }
}
