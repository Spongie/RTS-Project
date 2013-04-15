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
    class BaseObject
    {

        #region classValues

        private Vector3 position;
        private Model model;
        private float targetAttraction;
        private bool isSelected;
        private float maxHealth;
        private float currentHealth;
        private float lightArmor;
        private float mediumArmor;
        private float heavyArmor;
        private float visionRange;
        private float attackRange;
        private float stealthDetectionRadius;
        private AttackType attackType;
        private _3dBox box;

        #endregion

        #region Properties

        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }

        public Model _Model
        {
            get { return model; }
        }

        public float TargetAttractionValue
        {
            get { return targetAttraction; }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (value != null)
                    isSelected = value;
            }
        }

        public float MaximumHealth
        {
            get { return maxHealth; }
        }

        public float CurrentHealth
        {
            get { return currentHealth; }
            set
            {
                if (value != null)
                    currentHealth = value;
            }
        }

        public float CurrentHealthPercentage
        {
            get { return (currentHealth / maxHealth); }
        }

        public float LightArmor
        {
            get { return lightArmor; }
            set { lightArmor = value; }
        }

        public float MediumArmor
        {
            get { return mediumArmor; }
            set { mediumArmor = value; }
        }

        public float HeavyArmor
        {
            get { return heavyArmor; }
            set { heavyArmor = value; }
        }

        public float VisionRadius
        {
            get { return visionRange; }
            set
            {
                if (value != null)
                    visionRange = value;
            }
        }

        public float AttackRange
        {
            get { return attackRange; }
            set
            {
                if (value != null)
                    attackRange = value;
            }
        }

        public float StealthDetectionRadius
        {
            get { return stealthDetectionRadius; }
            set
            {
                if (value != null)
                    stealthDetectionRadius = value;
            }
        }

        public AttackType AttckType
        {
            get { return attackType; }
        }

        public _3dBox Box
        {
            get { return box; }
        }

        #endregion

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(Matrix view, Matrix projection)
        {
            Matrix[] transforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(transforms);
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
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
