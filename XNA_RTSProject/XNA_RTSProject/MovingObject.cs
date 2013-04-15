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
    class MovingObject : BaseObject
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
        private Vector3 targetEnemy;
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

        public float Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        public Vector3 TargetEnemy
        {
            get { return targetEnemy; }
            set { targetEnemy = value; }
        }
        #endregion

        public MovingObject(Vector3 pos, Model modl, float targetAttr, float maxHp, float ligghtarm, float medArm, float hevArm,
            float visRange, float attRange, float stealthDetRadius, AttackType attType, Vector3 position, float speed, float priority,
            float timeTrain, float cost, bool stealthed, float dmg, float atkSpeed, float lastAttack, Vector3 enemyTarget)
            : base(pos, modl, targetAttr, maxHp, ligghtarm, medArm, hevArm, visRange, attRange, stealthDetRadius, attType)
        {
            targetPosition = position;
            this.speed = speed;
            selectionPriority = priority;
            timeToTrain = timeTrain;
            this.cost = cost;
            isStealthed = stealthed;
            damage = dmg;
            timeBetweenAttacks = atkSpeed;
            timeSinceLastAttack = lastAttack;
            targetEnemy = enemyTarget;
        }
        public override void Update(GameTime gameTime)
        {
        }
        public virtual void Draw(Matrix view, Matrix projction)
        {

        }
    }
}
