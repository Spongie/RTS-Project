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
using SkinnedModel;

namespace XNA3DTesting
{
    class thing
    {
        Model model;
        Vector3 position;
        Vector3 scale;
        Vector3 rotation;
        KeyboardState keystate;
        AnimationPlayer animPlayer;
        
        public thing(Model mod, Vector3 pos)
        {
            model = mod;
            position = pos;
            scale = new Vector3(1, 1, 1);
            rotation = new Vector3(0, 0, 0);
            SkinningData skData = model.Tag as SkinningData;
            animPlayer = new AnimationPlayer(skData);
            AnimationClip clip = skData.AnimationClips["Walking"];
            animPlayer.StartClip(clip);
        }

        public void Update(GameTime gameTime)
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

                 animPlayer.Update(gameTime.ElapsedGameTime, true, Matrix.Identity);

            
        }

        public void Draw(Matrix view, Matrix projection)
        {
            Matrix[] bones = animPlayer.GetSkinTransforms();

            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);

            

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.SetBoneTransforms(bones);

                    effect.View = view;
                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateRotationY(rotation.Y) * Matrix.CreateTranslation(position);
                    effect.Projection = projection;
                    effect.EnableDefaultLighting();
                }
                mesh.Draw();
            }
        }
    }
}
