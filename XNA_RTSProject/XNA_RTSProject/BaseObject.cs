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
        /// <summary>
        /// Constructor to Init baseObjecy
        /// </summary>
        /// <param name="pos">objects position</param>
        /// <param name="modl">objects model</param>
        /// <param name="targetAttr">a value that show how likely he is to be attacked</param>
        /// <param name="maxHp">Maximum HP</param>
        /// <param name="ligghtarm">light armor value</param>
        /// <param name="medArm">medium armor value</param>
        /// <param name="hevArm">heavy armor value</param>
        /// <param name="visRange">vision range</param>
        /// <param name="attRange">attack range</param>
        /// <param name="stealthDetRadius">range of stealth detection</param>
        /// <param name="attType">attack typ</param>
        public BaseObject(Vector3 pos, Model modl, float targetAttr, float maxHp, float ligghtarm, float medArm, float hevArm,
            float visRange, float attRange, float stealthDetRadius, AttackType attType)
        {
            position = pos;
            model = modl;
            targetAttraction = targetAttr;
            maxHealth = maxHp;
            currentHealth = maxHp;
            lightArmor = ligghtarm;
            mediumArmor = medArm;
            heavyArmor = hevArm;
            visionRange = visRange;
            attackRange = attRange;
            attackType = attType;
            box = new _3dBox(pos, 100, 100, 100); // WAIT FOR REAL CONSTRUCTOR
        }

        /// <summary>
        /// Updates BaseObject
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the object
        /// </summary>
        /// <param name="view"></param>
        /// <param name="projection"></param>
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
