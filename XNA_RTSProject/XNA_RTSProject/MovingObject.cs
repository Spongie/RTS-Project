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
    class MovingObject:BaseObject
    {
        #region classValues
        private Vector3 targetPosition;
        private float speed;
        private float selectionPriority;
        private float timeToTrain;
        private float cost;
        private bool isStealthed;
        private float damage;
        private float timeBetweenAttacks;
        private float timeSinceLastAttack;
        #endregion

        #region properties

        public Vector3 TargetPosition
        {
            get { return targetPosition; }
            set { targetPosition = value; }
        }

        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public bool IsStealthed
        {
            get { return isStealthed; }
            set { isStealthed = value; }
        }

        public float SelectionPriority
        {
            get { return selectionPriority; }
        }

        #endregion

        public override void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(Matrix view, Matrix projction)
        {

        }
    }
}
